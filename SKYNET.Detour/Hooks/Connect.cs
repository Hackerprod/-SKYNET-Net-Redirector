using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EasyHook;
using SKYNET.Helper;
using SKYNET.Hook.Types;
using static SKYNET.Hook.Types.WinSockHelper;

namespace SKYNET.Hook.Processor
{
    /// <summary>
    /// The connect function establishes a connection to a specified socket.
    /// </summary>
    public class Connect : IHook
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
        private delegate int ConnectDelegate(IntPtr s, IntPtr addr, int addrsize);
        ConnectDelegate _Connect;
        public override string Library => "ws2_32.dll"; //WSOCK32.dll
        public override string Method => "connect";
        public override LocalHook Hook { get; set; }
        public override Color Color => ColorTranslator.FromHtml("#00FA00");
        public override Delegate Delegate
        {
            get
            {
                _Connect = Marshal.GetDelegateForFunctionPointer<ConnectDelegate>(ProcAddress);
                return new ConnectDelegate(Callback);
            }
        }

        private unsafe int Callback(IntPtr s, IntPtr sockAddr, int addrsize)
        {
            SOCKADDR_IN addr_in = Marshal.PtrToStructure<SOCKADDR_IN>(sockAddr);
            string originalIp = new IPAddress(addr_in.sin_addr).ToString();
            string originalPort = Ws2_32.ntohs(addr_in.sin_port).ToString();


            //SockAddr addr_in = Marshal.PtrToStructure<SockAddr>(sockAddr);
            //string originalIp = addr_in.IPAddress.ToString();
            //string originalPort = Ws2_32.ntohs(addr_in.Port).ToString();

            string RedirectedIP = Main.GetRedirectedIP(originalIp);
            string RedirectedPort = Main.GetRedirectedPort(originalPort);

            var nAddr = CreateAddr(RedirectedIP, RedirectedPort);
            Bind();
            int r = _Connect(s, nAddr, addrsize);

            if (originalIp != RedirectedIP || originalPort != RedirectedPort)
            {
                Write($"Binding connection from: {originalIp}:{originalPort} to: {RedirectedIP}:{RedirectedPort} [{(((SocketError)Ws2_32.WSAGetLastError()).ToString())}]");
            }
            else
            {
                Write($"Connecting to: {originalIp}:{originalPort} [{(((SocketError)Ws2_32.WSAGetLastError()).ToString())}]");
            }

            return 0;
        }

        [DllImport("ws2_32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern uint inet_addr(string cp);
        private IntPtr CreateAddr(string redirectedIP, string redirectedPort)
        {
            var s = Marshal.AllocHGlobal(16);
            SOCKADDR_IN sockAddr = new SOCKADDR_IN();
            sockAddr.sin_family = (int)AddressFamily.InterNetwork;
            sockAddr.sin_addr = inet_addr(redirectedIP);
            sockAddr.sin_port = Ws2_32.htons(Convert.ToUInt16(redirectedPort.ToString()));

            Marshal.StructureToPtr(sockAddr, s, true);
            return s;
        }


        public static object RawDeserializeEx(byte[] rawdatas, Type anytype)
        {
            int rawsize = Marshal.SizeOf(anytype);
            if (rawsize > rawdatas.Length)
                return null;
            GCHandle handle = GCHandle.Alloc(rawdatas, GCHandleType.Pinned);
            IntPtr buffer = handle.AddrOfPinnedObject();
            object retobj = Marshal.PtrToStructure(buffer, anytype);
            handle.Free();
            return retobj;
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct sockaddr_in
        {
            [MarshalAs(UnmanagedType.I2)]
            public short sin_family;
            public ushort sin_port;
            [MarshalAs(UnmanagedType.I1)]
            public byte s_b1;
            public byte s_b2;
            public byte s_b3;
            public byte s_b4;
            [MarshalAs(UnmanagedType.I8)]
            public long sin_zero;
        }
        private void Bind()
        {
            //SafeCloseSocket m_Handle = SafeCloseSocket.CreateWSASocket(
            //         AddressFamily.InterNetwork,
            //        SocketType.Stream,
            //         ProtocolType.IPv4);
            //SocketError errorCode = UnsafeNclNativeMethods.OSSOCK.listen(
            //                m_Handle,
            //                90);
        }

        [DllImport("ws2_32.dll", SetLastError = true)]
        internal static extern SocketError bind(
                             [In] IntPtr socketHandle,
                             [In] byte[] socketAddress,
                             [In] int socketAddressSize
                             );
    }
}
