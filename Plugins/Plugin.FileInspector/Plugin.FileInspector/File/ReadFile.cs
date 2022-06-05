using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
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
        private delegate bool ReadFileDelegate(IntPtr hFile, IntPtr lpBuffer, uint nNumberOfBytesToRead, IntPtr lpNumberOfBytesRead, IntPtr lpOverlapped);
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

        private bool Callback(IntPtr hFile, IntPtr lpBuffer, uint nNumberOfBytesToRead, IntPtr lpNumberOfBytesRead, IntPtr lpOverlapped)
        {
            Write("ReadFile");
            Marshal.WriteInt32(lpNumberOfBytesRead, 0);
            return false;
            //bool Result = _ReadFile(hFile, lpBuffer, ref nNumberOfBytesToRead, lpOverlapped);
            byte[] bytes = default;
            //lpNumberOfBytesRead = 0;

            try
            {
                StringBuilder filename = new StringBuilder(255);
                GetFinalPathNameByHandle(hFile, filename, 255, 0);

                if (string.IsNullOrEmpty(filename.ToString()))
                {
                    return false;
                }
                string file = filename.ToString().Replace(@"\\?\", "");
                string Message = $"Reading file {file}";

                if (File.Exists(file))
                {
                    bytes = File.ReadAllBytes(file);
                }

                if (bytes != null && bytes.Length > 0)
                {
                    //Marshal.Copy(bytes, 0, lpBuffer, bytes.Length);
                    //Marshal.WriteInt32(lpNumberOfBytesRead, bytes.Length);
                    //Array.Copy(bytes, lpBuffer, bytes.Length);
                    //lpNumberOfBytesRead = (uint)bytes.Length;
                    //return true;
                }

                Write(Message + $", {lpNumberOfBytesRead} bytes");

            }
            catch 
            {
            }
            return false;
        }

        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern uint GetFinalPathNameByHandle(IntPtr hFile, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpszFilePath, uint cchFilePath, uint dwFlags);

    }
}
