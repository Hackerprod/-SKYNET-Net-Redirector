using System;
using System.Drawing;
using System.Runtime.InteropServices;
using EasyHook;

namespace SKYNET.Hook.Processor
{
	public class InternetOpenUrlA : IHook
	{
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi, SetLastError = true)]
        private delegate int InternetOpenUrlADelegate(IntPtr hIneternetSession, string sUrl, string sHeaders, uint lHeadrsLength, uint lFlags, uint lContext);
        private InternetOpenUrlADelegate _InternetOpenUrlA;

        public override string Library => "wininet.dll";
        public override string Method => "InternetConnectA";
        public override LocalHook Hook { get; set; }
        public override Color Color => ColorTranslator.FromHtml("#f58207");
        public override Delegate Delegate
        {
            get
            {
                _InternetOpenUrlA = Marshal.GetDelegateForFunctionPointer<InternetOpenUrlADelegate>(ProcAddress);

                return new InternetOpenUrlADelegate(Callback);
            }
        }

        private int Callback(IntPtr hIneternetSession, string sUrl, string sHeaders, uint lHeadrsLength, uint lFlags, uint lContext)
        {
            Write($"InternetOpenUrlA");

            return _InternetOpenUrlA(hIneternetSession, sUrl, sHeaders, lHeadrsLength, lFlags, lContext);
        }
    }
}
