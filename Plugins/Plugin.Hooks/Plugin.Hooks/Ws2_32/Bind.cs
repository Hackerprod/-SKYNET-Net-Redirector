using System;
using System.Drawing;
using System.Net;
using System.Runtime.InteropServices;
using EasyHook;
using SKYNET.Helper;
using static SKYNET.Hook.Types.WinSockHelper;

namespace SKYNET.Hook.Processor
{
	public class Bind : IHook
	{
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi, SetLastError = true)]
        private delegate IntPtr BindDelegate(Socket socket, IntPtr lpSockAddr, int namelen);
        private BindDelegate _Bind;

        public override string Library => "ws2_32.dll";
        public override string Method => "bind";
        public override LocalHook Hook { get; set; }
        public override Color Color => ColorTranslator.FromHtml("#D79B66");
        public override Delegate Delegate
        {
            get
            {
                _Bind = Marshal.GetDelegateForFunctionPointer<BindDelegate>(ProcAddress);
                return new BindDelegate(Callback);
            }
        }

		private IntPtr Callback(Socket socket, IntPtr lpSockAddr, int namelen)
		{
            SOCKADDR_IN addr_in = Marshal.PtrToStructure<SOCKADDR_IN>(lpSockAddr);
            string originalIp = new IPAddress(addr_in.sin_addr).ToString();
            string originalPort = Ws2_32.ntohs(addr_in.sin_port).ToString();

            Write($"Binding socket to {originalIp}:{originalPort} ");

            return _Bind(socket, lpSockAddr, namelen);
		}

        public struct Socket
        {
            IntPtr Handle;
        }
    }
}
