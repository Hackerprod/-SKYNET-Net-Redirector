using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using EasyHook;

namespace SKYNET.Hook.Processor
{
	public class GetHostByName : IHook
	{
        public override string Library => "ws2_32.dll";
        public override string Method => "gethostbyname";
        public override LocalHook Hook { get; set; }
        public override Color Color => ColorTranslator.FromHtml("#f58207");

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi, SetLastError = true)]
		private delegate IntPtr GetHostByNameDelegate(string hostname);
        private GetHostByNameDelegate _GetHostByName;

        public override Delegate Delegate
        {
            get
            {
                _GetHostByName = Marshal.GetDelegateForFunctionPointer<GetHostByNameDelegate>(ProcAddress);
                return new GetHostByNameDelegate(Callback);
            }
        }

		private IntPtr Callback(string hostname)
		{
            string RedirectedHost = Main.GetRedirectedHost(hostname);
            var result = _GetHostByName(RedirectedHost);
            if (hostname != RedirectedHost)
            {
                Write($"Redirected DNS {hostname} to {RedirectedHost} [{(System.Net.Sockets.SocketError)result}]");
            }
            else
            {
                Write($"Processed DNS {hostname} [{(System.Net.Sockets.SocketError)result}]");
            }
            return _GetHostByName(RedirectedHost);
		}
    }
}
