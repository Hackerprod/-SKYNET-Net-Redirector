using System;
using System.Runtime.InteropServices;

namespace SKYNET.Helper
{
    public class ProcessMemoryReader
	{
		public static class ProcessMemoryReaderApi
		{
			[Flags]
			public enum ProcessAccessType
			{
				PROCESS_TERMINATE = 0x1,
				PROCESS_CREATE_THREAD = 0x2,
				PROCESS_SET_SESSIONID = 0x4,
				PROCESS_VM_OPERATION = 0x8,
				PROCESS_VM_READ = 0x10,
				PROCESS_VM_WRITE = 0x20,
				PROCESS_DUP_HANDLE = 0x40,
				PROCESS_CREATE_PROCESS = 0x80,
				PROCESS_SET_QUOTA = 0x100,
				PROCESS_SET_INFORMATION = 0x200,
				PROCESS_QUERY_INFORMATION = 0x400
			}

			[DllImport("kernel32.dll")]
			public static extern IntPtr OpenProcess(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

			[DllImport("kernel32.dll")]
			public static extern int CloseHandle(IntPtr hObject);

			[DllImport("kernel32.dll")]
			public static extern int ReadProcessMemory(IntPtr hProcess, int lpBaseAddress, [In][Out] byte[] buffer, uint size, out uint lpNumberOfBytesRead);

            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out UIntPtr lpNumberOfBytesWritten);
        }

        private IntPtr _mHProcess = IntPtr.Zero;

		private int _procId;

		public ProcessMemoryReader(int procId)
		{
			_procId = procId;
		}

		public void OpenProcess()
		{
			_mHProcess = ProcessMemoryReaderApi.OpenProcess(16u, 1, (uint)_procId);
		}

		public void CloseHandle()
		{
			try
			{
				if (ProcessMemoryReaderApi.CloseHandle(_mHProcess) == 0)
				{
					throw new Exception("CloseHandle failed");
				}
			}
			catch
			{
			}
		}
	}
}
