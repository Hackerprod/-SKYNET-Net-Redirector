using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using EasyHook;
using SKYNET.Helper;

namespace SKYNET.Hook.Processor
{
	public class LdrLoadDll : IHook
	{
        public override string Library => "ntdll.dll";
        public override string Method => "LdrLoadDll";
        public override LocalHook Hook { get; set; }
        public override Color Color => ColorTranslator.FromHtml("#f58207");

        [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Unicode, SetLastError = true)]
		private delegate uint LdrLoadDllDelegate(IntPtr pathToFile, IntPtr flags, IntPtr moduleFileName, IntPtr moduleHandle);
		private LdrLoadDllDelegate _LdrLoadDll;

        public override Delegate Delegate
        {
            get
            {
                _LdrLoadDll = Marshal.GetDelegateForFunctionPointer<LdrLoadDllDelegate>(ProcAddress);
                return new LdrLoadDllDelegate(Callback);
            }
        }

		private uint Callback(IntPtr pathToFile, IntPtr flags, IntPtr moduleFileName, IntPtr moduleHandle)
		{
			uint result = _LdrLoadDll(pathToFile, flags, moduleFileName, moduleHandle);
			try
			{

                string path = moduleFileName.GetUnicodeString();
                path = Path.GetFileNameWithoutExtension(path).ToLower();

                Main.HookManager.Install(path.ToUpper());
                Main.ModuleLoaded(path.ToUpper());

                return result;
			}
			catch
			{
				return result;
			}
		}
	}
}
