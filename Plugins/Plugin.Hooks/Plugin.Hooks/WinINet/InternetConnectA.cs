using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using EasyHook;

namespace SKYNET.Hook.Processor
{
	public class InternetConnectA : IHook
	{
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi, SetLastError = true)]
        private delegate int InternetConnectADelegate(IntPtr hInternet, string lpszServerName, int nServerPort, string lpszUsername, string lpszPassword, int dwService, int dwFlags, int dwContext);
        private InternetConnectADelegate _InternetConnectA;
        public override string Library => "wininet.dll";
        public override string Method => "InternetConnectA";
        public override LocalHook Hook { get; set; }
        public override Color Color => ColorTranslator.FromHtml("#f58207");

        public override Delegate Delegate
        {
            get
            {
                _InternetConnectA = Marshal.GetDelegateForFunctionPointer<InternetConnectADelegate>(ProcAddress);

                return new InternetConnectADelegate(Callback);
            }
        }

        private int Callback(IntPtr hInternet, string lpszServerName, int nServerPort, string lpszUsername, string lpszPassword, int dwService, int dwFlags, int dwContext)
        {
            Write($"{lpszServerName}");

            return _InternetConnectA(hInternet, lpszServerName, nServerPort, lpszUsername, lpszPassword, dwService, dwFlags, dwContext);
        }
    }
}
