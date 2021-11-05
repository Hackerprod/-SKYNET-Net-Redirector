using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EasyHook;

namespace SKYNET.Hook
{
    public class ReadFile : IHook
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
        private delegate bool ReadFileDelegate(IntPtr hFile, IntPtr lpBuffer, uint nNumberOfBytesToRead, out uint lpNumberOfBytesRead, IntPtr lpOverlapped);
        private ReadFileDelegate _ReadFile;
        public override string Library => "kernel32.dll";
        public override string Method => "ReadFile";
        public override LocalHook Hook { get; set; }
        public override Color Color => ColorTranslator.FromHtml("#FF33B4");
        public override Delegate Delegate
        {
            get
            {
                _ReadFile = Marshal.GetDelegateForFunctionPointer<ReadFileDelegate>(ProcAddress);

                return new ReadFileDelegate(Callback);
            }
        }

        string lastMessage = "";
        private bool Callback(IntPtr hFile, IntPtr lpBuffer, uint nNumberOfBytesToRead, out uint lpNumberOfBytesRead, IntPtr lpOverlapped)
        {
            bool result = _ReadFile(hFile, lpBuffer, nNumberOfBytesToRead, out lpNumberOfBytesRead, lpOverlapped);

            try
            {
                StringBuilder filename = new StringBuilder(255);
                GetFinalPathNameByHandle(hFile, filename, 255, 0);

                if (string.IsNullOrEmpty(filename.ToString()))
                {
                    return result;
                }
                string file = filename.ToString().Replace(@"\\?\", "");
                string Message = $"Reading file {file}";
                if (Message != lastMessage)
                {
                    Write(Message);
                    lastMessage = Message;
                }
            }
            catch (Exception)
            {

               
            }
            return result;
        }
        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern uint GetFinalPathNameByHandle(IntPtr hFile, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpszFilePath, uint cchFilePath, uint dwFlags);

    }

}
