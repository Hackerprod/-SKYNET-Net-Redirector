using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using EasyHook;

namespace SKYNET.Hook.Processor
{
	public class GetServByName : IHook
	{
        public override string Library => "ws2_32.dll";
        public override string Method => "getservbyname";
        public override LocalHook Hook { get; set; }
        public override Color Color => ColorTranslator.FromHtml("#f58207");

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi, SetLastError = true)]
		private delegate IntPtr GetServByNameDelegate([MarshalAs(UnmanagedType.LPWStr)] string name, [Optional] string proto);
        private GetServByNameDelegate _GetServByName;

        public override Delegate Delegate
        {
            get
            {
                _GetServByName = Marshal.GetDelegateForFunctionPointer<GetServByNameDelegate>(ProcAddress);
                return new GetServByNameDelegate(Callback);
            }
        }

		private IntPtr Callback(string name, [Optional] string proto)
		{
            Write("name: " + name + ", proto: " + proto);

            return _GetServByName(name, proto);
		}
    }
}
