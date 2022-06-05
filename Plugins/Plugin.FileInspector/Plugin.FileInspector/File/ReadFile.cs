using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
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

        private bool Callback(IntPtr hFile, IntPtr lpBuffer, uint nNumberOfBytesToRead, out uint lpNumberOfBytesRead, IntPtr lpOverlapped)
        {
            bool result = false;
            lpNumberOfBytesRead = 0;

            result = _ReadFile(hFile, lpBuffer, nNumberOfBytesToRead, out lpNumberOfBytesRead, lpOverlapped);

            try
            {
                StringBuilder filename = new StringBuilder(255);
                GetFinalPathNameByHandle(hFile, filename, 255, 0);
                string file = filename.ToString().Replace(@"\\?\", "");
                if (!string.IsNullOrEmpty(file))
                {
                    Write($"Reading file {file}, {LongToMbytes(lpNumberOfBytesRead)}");
                }
            }
            catch
            {
            }

            return result;
        }

        public static string LongToMbytes(long lBytes)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string str1 = "Bytes";
            if (lBytes > 1024L)
            {
                string str2;
                float num;
                if (lBytes < 1048576L)
                {
                    str2 = "KB";
                    num = Convert.ToSingle(lBytes) / 1024f;
                }
                else
                {
                    str2 = "MB";
                    num = Convert.ToSingle(lBytes) / 1048576f;
                }
                stringBuilder.AppendFormat("{0:0.0} {1}", (object)num, (object)str2);
            }
            else
            {
                float num = Convert.ToSingle(lBytes);
                stringBuilder.AppendFormat("{0:0} {1}", (object)num, (object)str1);
            }
            return stringBuilder.ToString();
        }

        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern uint GetFinalPathNameByHandle(IntPtr hFile, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpszFilePath, uint cchFilePath, uint dwFlags);

        [DllImport("kernel32.dll", EntryPoint = "ReadFile", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        static extern bool ReadFileImported(IntPtr hFile, IntPtr lpBuffer, uint nNumberOfBytesToRead, out uint lpNumberOfBytesRead, IntPtr lpOverlapped);
    }
}
