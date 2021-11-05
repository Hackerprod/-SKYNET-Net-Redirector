using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EasyHook;
using SKYNET.Hook.Types;
using SKYNET.Helper;
using static SKYNET.Hook.Types.WinSockHelper;

namespace SKYNET.Hook.Processor
{
    /// <summary>
    /// The WSAConnect function establishes a connection to another socket application, exchanges connect data, and specifies required quality of service based on the specified FLOWSPEC structure.
    /// </summary>
    public class WSAConnectByNameA : IHook
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
        private delegate int WSAConnectByNameADelegate(IntPtr s, string nodename, string servicename, int LocalAddressLength, IntPtr LocalAddress, int RemoteAddressLength, IntPtr RemoteAddress, IntPtr timeout, IntPtr Reserved);
        WSAConnectByNameADelegate _WSAConnectByNameA;

        public override string Library => "ws2_32.dll";
        public override string Method => "WSAConnectByNameA";
        public override LocalHook Hook { get; set; }
        public override Color Color => ColorTranslator.FromHtml("#00FA00");
        public override Delegate Delegate
        {
            get
            {
                _WSAConnectByNameA = Marshal.GetDelegateForFunctionPointer<WSAConnectByNameADelegate>(ProcAddress);
                return new WSAConnectByNameADelegate(Callback);
            }
        }
        private int Callback(IntPtr s, string nodename, string servicename, int LocalAddressLength, IntPtr LocalAddress, int RemoteAddressLength, IntPtr RemoteAddress, IntPtr timeout, IntPtr Reserved)
        {
            SOCKADDR_IN addr_in = Marshal.PtrToStructure<SOCKADDR_IN>(RemoteAddress);
            string originalIp = new IPAddress(addr_in.sin_addr).ToString();
            string originalPort = Ws2_32.ntohs(addr_in.sin_port).ToString();

            string RedirectedIP = Main.GetRedirectedIP(originalIp);
            string RedirectedPort = Main.GetRedirectedPort(originalPort);

            var nAddr = CreateAddr(RedirectedIP, RedirectedPort);

            int r = _WSAConnectByNameA(s, nodename, servicename, LocalAddressLength, LocalAddress, RemoteAddressLength, RemoteAddress, timeout, Reserved);

            if (originalIp != RedirectedIP || originalPort != RedirectedPort)
            {
                Write($"Binding connection from: {originalIp}:{originalPort} to: {RedirectedIP}:{RedirectedPort} [{(((SocketError)Ws2_32.WSAGetLastError()).ToString())}]");
            }
            else
            {
                Write($"Connecting to: {originalIp}:{originalPort} [{(((SocketError)Ws2_32.WSAGetLastError()).ToString())}]");
            }

            return r;
        }
    }
}
