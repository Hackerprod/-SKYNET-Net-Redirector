using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using EasyHook;
using SKYNET.Hook.Types;

namespace SKYNET.Hook.Processor
{
	public class CreateProcessA : IHook
	{
        public override string Library => "kernel32.dll";
        public override string Method => "CreateProcessA";
        public override LocalHook Hook { get; set; }
        public override Color Color => ColorTranslator.FromHtml("#f58207");

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi, SetLastError = true)]
		private delegate bool CreateProcessADelegate(string lpApplicationName, StringBuilder lpCommandLine, IntPtr lpProcessAttributes, IntPtr lpThreadAttributes, bool bInheritHandles, IntPtr dwCreationFlags, IntPtr lpEnvironment, string lpCurrentDirectory, ref IntPtr lpStartupInfo, out PROCESS_INFORMATION ProcessInformation);
		private CreateProcessADelegate _CreateProcessA;

        public override Delegate Delegate
        {
            get
            {
                _CreateProcessA = Marshal.GetDelegateForFunctionPointer<CreateProcessADelegate>(ProcAddress);
                return new CreateProcessADelegate(Callback);
            }
        }
        private bool Callback(string lpApplicationName, StringBuilder lpCommandLine, IntPtr lpProcessAttributes, IntPtr lpThreadAttributes, bool bInheritHandles, IntPtr dwCreationFlags, IntPtr lpEnvironment, string lpCurrentDirectory, ref IntPtr lpStartupInfo, out PROCESS_INFORMATION ProcessInformation)
        {
            string file = lpCommandLine.ToString();
            try
            {
                file = lpCommandLine.ToString().Contains(" ") ? lpCommandLine.ToString().Split(' ')[0] : lpCommandLine.ToString();
                file = Path.GetFileName(file);
            }
            catch { }

            bool created = _CreateProcessA(lpApplicationName, lpCommandLine, lpProcessAttributes, lpThreadAttributes, bInheritHandles, dwCreationFlags, lpEnvironment, lpCurrentDirectory, ref lpStartupInfo, out ProcessInformation);
            if (!created)
            {
                return created;
            }
            uint ProcessId = ProcessInformation.dwProcessId;
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
