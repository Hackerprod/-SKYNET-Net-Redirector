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
using SKYNET.Helper;
using SKYNET.Hook.Types;
using static SKYNET.Hook.Types.WinSockHelper;

namespace SKYNET.Hook.Processor
{
    /// <summary>
    /// The WSAConnect function establishes a connection to another socket application, exchanges connect data, and specifies required quality of service based on the specified FLOWSPEC structure.
    /// </summary>
    public class WSAConnect : IHook
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
        private delegate int WSAConnectDelegate(IntPtr socket, IntPtr lpSockAddr, int namelen, IntPtr lpCallerData, IntPtr lpCalleeData, IntPtr lpSQOS, IntPtr lpGQOS);
        WSAConnectDelegate _WSAConnect;

        public override string Library => "ws2_32.dll";
        public override string Method => "WSAConnect";
        public override LocalHook Hook { get; set; }
        public override Color Color => ColorTranslator.FromHtml("#00FA00");
        public override Delegate Delegate
        {
            get
            {
                _WSAConnect = Marshal.GetDelegateForFunctionPointer<WSAConnectDelegate>(ProcAddress);

                return new WSAConnectDelegate(Callback);
            }
        }
        private int Callback(IntPtr socket, IntPtr lpSockAddr, int namelen, IntPtr lpCallerData, IntPtr lpCalleeData, IntPtr lpSQOS, IntPtr lpGQOS)
        {
            SOCKADDR_IN addr_in = Marshal.PtrToStructure<SOCKADDR_IN>(lpSockAddr);
            string originalIp = new IPAddress(addr_in.sin_addr).ToString();
            var originalPort = Ws2_32.ntohs(addr_in.sin_port);

            string RedirectedIP = Main.GetRedirectedIP(originalIp);
            var RedirectedPort = Main.GetRedirectedPort(originalPort);

            var nAddr = WinSockHelper.CreateAddr(RedirectedIP, RedirectedPort);

            int r = _WSAConnect(socket, nAddr, namelen, lpCallerData, lpCalleeData, lpSQOS, lpGQOS);

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
