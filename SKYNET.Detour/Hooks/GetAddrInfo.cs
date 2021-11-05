using System;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using EasyHook;
using SKYNET.Helper;
using SKYNET.Hook.Types;

namespace SKYNET.Hook.Processor
{
	public class GetAddrInfo : IHook
	{
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi, SetLastError = true)]
        private delegate int GetAddrInfoDelegate(string nodename, string servicename, ref IntPtr hints, out IntPtr handle);
        private GetAddrInfoDelegate _GetAddrInfo;

        public override string Library => "ws2_32.dll";
        public override string Method => "getaddrinfo";
        public override LocalHook Hook { get; set; }
        public override Color Color => ColorTranslator.FromHtml("#f58207");

        public override Delegate Delegate
        {
            get
            {
                _GetAddrInfo = Marshal.GetDelegateForFunctionPointer<GetAddrInfoDelegate>(ProcAddress);

                return new GetAddrInfoDelegate(Callback);
            }
        }

        private int Callback(string nname, string servicename, ref IntPtr hints, out IntPtr handle)
        {
            string RedirectedHost = nname;

            //Testing Connect
            //IntPtr newSock =  OpenSocket(AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Stream, ProtocolType.Tcp);
            //IntPtr o = WinSockHelper.CreateSockaddrStructure(new IPEndPoint(IPAddress.Parse("10.31.0.1"), int.Parse("3333")), out int size);
            //Connect(newSock, o, size);

            //Testing WSAConnect
            //IntPtr m_Handle = WinSockHelper.WSASocket(AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Stream, ProtocolType.Tcp, IntPtr.Zero, 0, 1 /*overlapped*/);
            //IntPtr o = WinSockHelper.CreateSockaddrStructure(new IPEndPoint(IPAddress.Parse("10.31.0.1"), int.Parse("28000")), out int size);
            //bool re = (WinSockHelper.WSAConnect(m_Handle, o, size, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero) == 0);
            //Write(re);

            if (modCommon.IsValidDomain(nname))
            {
                RedirectedHost = Main.GetRedirectedHost(nname);

                var result = _GetAddrInfo(RedirectedHost, servicename, ref hints, out handle);
                System.Net.Sockets.SocketError err = (System.Net.Sockets.SocketError)result;

                if (nname != RedirectedHost)
                {
                    Write($"Redirected DNS {nname} to {RedirectedHost} [{err}]");
                }
                else
                {
                    Write($"Processed DNS {nname} [{err}]");
                }

                return result;
            }
            else
            {
                return _GetAddrInfo(nname, servicename, ref hints, out handle);
            }
        }
        [DllImport("ws2_32", SetLastError = true, EntryPoint = "socket")]
        public static extern IntPtr OpenSocket(AddressFamily addressFamily, System.Net.Sockets.SocketType type, ProtocolType protocol);




    }
}
