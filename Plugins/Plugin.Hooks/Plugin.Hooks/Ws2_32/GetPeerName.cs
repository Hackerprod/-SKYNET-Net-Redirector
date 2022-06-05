using System;
using System.Drawing;
using System.Runtime.InteropServices;
using EasyHook;

namespace SKYNET.Hook.Processor
{
    /// <summary>
    /// The connect function establishes a connection to a specified socket.
    /// </summary>
    public class GetPeerName : IHook
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
        private delegate int GetPeerNameDelegate(IntPtr s, IntPtr addr, int addrsize);
        GetPeerNameDelegate _GetPeerName;

        public override string Library => "ws2_32.dll";
        public override string Method => "getpeername";
        public override LocalHook Hook { get; set; }
        public override Color Color => ColorTranslator.FromHtml("#00FA00");
        public override Delegate Delegate
        {
            get
            {
                _GetPeerName = Marshal.GetDelegateForFunctionPointer<GetPeerNameDelegate>(ProcAddress);
                return new GetPeerNameDelegate(Callback);
            }
        }

        private int Callback(IntPtr s, IntPtr sockAddr, int addrsize)
        {
            //SOCKADDR_IN addr_in = Marshal.PtrToStructure<SOCKADDR_IN>(sockAddr);
            //string originalIp = new IPAddress(addr_in.sin_addr).ToString();
            //string originalPort = Ws2_32.ntohs(addr_in.sin_port).ToString();

            //string RedirectedIP = Main.GetRedirectedIP(originalIp);
            //string RedirectedPort = Main.GetRedirectedPort(originalPort);

            //var nAddr = WinSockHelper.CreateAddr(RedirectedIP, RedirectedPort);

            //int r = _GetPeerName(s, nAddr, addrsize);
            int r = _GetPeerName(s, sockAddr, addrsize);

            //if (originalIp != RedirectedIP || originalPort != RedirectedPort)
            //{
            //    Write($"Binding connection from: {originalIp}:{originalPort} to: {RedirectedIP}:{RedirectedPort} [{(((SocketError)Ws2_32.WSAGetLastError()).ToString())}]");
            //}
            //else
            //{
            //    Write($"Connecting to: {originalIp}:{originalPort} [{(((SocketError)Ws2_32.WSAGetLastError()).ToString())}]");
            //}

            return r;
        }
    }
}
