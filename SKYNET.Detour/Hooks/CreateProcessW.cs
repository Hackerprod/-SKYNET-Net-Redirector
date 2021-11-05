using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using EasyHook;
using SKYNET.Hook.Types;

namespace SKYNET.Hook.Processor
{
	public class CreateProcessW : IHook
	{
        public override string Library => "kernel32.dll";
        public override string Method => "CreateProcessW";
        public override LocalHook Hook { get; set; }
        public override Color Color => ColorTranslator.FromHtml("#f58207");

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
		private delegate bool CreateProcessWDelegate(string lpApplicationName, string lpCommandLine,  IntPtr lpProcessAttributes,  IntPtr lpThreadAttributes, [MarshalAsAttribute(UnmanagedType.Bool)] bool bInheritHandles, uint dwCreationFlags,  IntPtr lpEnvironment,  [MarshalAsAttribute(UnmanagedType.LPWStr)] string lpCurrentDirectory,  ref IntPtr lpStartupInfo, [OutAttribute()] out PROCESS_INFORMATION lpProcessInformation);
		private CreateProcessWDelegate _CreateProcessW;

        public override Delegate Delegate
        {
            get
            {
                _CreateProcessW = Marshal.GetDelegateForFunctionPointer<CreateProcessWDelegate>(ProcAddress);
                return new CreateProcessWDelegate(CreateProcessW_Hooked);
            }
        }
        private bool CreateProcessW_Hooked(string lpApplicationName, string lpCommandLine, IntPtr lpProcessAttributes, IntPtr lpThreadAttributes, [MarshalAsAttribute(UnmanagedType.Bool)] bool bInheritHandles, uint dwCreationFlags, IntPtr lpEnvironment, [MarshalAsAttribute(UnmanagedType.LPWStr)] string lpCurrentDirectory, ref IntPtr lpStartupInfo, [OutAttribute()] out PROCESS_INFORMATION lpProcessInformation)
        {
            string file = lpCommandLine.ToString();
            try
            {
                file = lpCommandLine.ToString().Contains(" ") ? lpCommandLine.ToString().Split(' ')[0] : lpCommandLine.ToString();
                file = Path.GetFileName(file.Replace("\"", ""));
            }
            catch { }

            bool created = _CreateProcessW(lpApplicationName, lpCommandLine, lpProcessAttributes, lpThreadAttributes, bInheritHandles, dwCreationFlags, lpEnvironment, lpCurrentDirectory, ref lpStartupInfo, out lpProcessInformation);

            if (!created)
            {
                return created;
            }
            uint ProcessId = lpProcessInformation.dwProcessId;
            try
            {
                Main.InjectToProcess(ProcessId, file);
                return created;
            }
            catch
            {
                return false;
            }
        }
    }
}
