using System;
using System.Drawing;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using EasyHook;
using SKYNET.Helper;
using static SKYNET.Hook.Types.WinSockHelper;

namespace SKYNET.Hook.Processor
{
	public class CreateUrlCacheEntryW : IHook
	{
        public override string Library => "wininet.dll";
        public override string Method => "CreateUrlCacheEntryW";
        public override LocalHook Hook { get; set; }
        public override Color Color => ColorTranslator.FromHtml("#F26B31");

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi, SetLastError = true)]
		private delegate IntPtr CreateUrlCacheEntryWDelegate(string urlName, int expectedFileSize, string fileExtension, StringBuilder fileName, int dwReserved);
        private CreateUrlCacheEntryWDelegate _CreateUrlCacheEntryW;

        public override Delegate Delegate
        {
            get
            {
                _CreateUrlCacheEntryW = Marshal.GetDelegateForFunctionPointer<CreateUrlCacheEntryWDelegate>(ProcAddress);
                return new CreateUrlCacheEntryWDelegate(Callback);
            }
        }

		private IntPtr Callback(string urlName, int expectedFileSize, string fileExtension, StringBuilder fileName, int dwReserved)
		{
            Write($"{urlName}");
            return _CreateUrlCacheEntryW(urlName, expectedFileSize, fileExtension, fileName, dwReserved);
		}
    }
}
