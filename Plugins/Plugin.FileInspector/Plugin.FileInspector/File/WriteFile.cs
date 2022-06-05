using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using EasyHook;

namespace SKYNET.Hook
{
    public class WriteFile : IHook
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
        private delegate bool WriteFileDelegate(IntPtr hFile, IntPtr lpBuffer, uint nNumberOfBytesToWrite, out uint lpNumberOfBytesWritten, IntPtr lpOverlapped);
        private WriteFileDelegate _WriteFile;
        public override string Library => "kernel32.dll";
        public override string Method => "WriteFile";
        public override LocalHook Hook { get; set; }
        public override Color Color => ColorTranslator.FromHtml("#D60059");
        public override Delegate Delegate
        {
            get
            {
                _WriteFile = Marshal.GetDelegateForFunctionPointer<WriteFileDelegate>(ProcAddress);

                return new WriteFileDelegate(Callback);
            }
        }

        private bool Callback(IntPtr hFile, IntPtr lpBuffer, uint nNumberOfBytesToWrite, out uint lpNumberOfBytesWritten, IntPtr lpOverlapped)
        {
            bool result = false;

            result = _WriteFile(hFile, lpBuffer, nNumberOfBytesToWrite, out lpNumberOfBytesWritten, lpOverlapped);

            try
            {
                StringBuilder filename = new StringBuilder(255);
                GetFinalPathNameByHandle(hFile, filename, 255, 0);

                string file = filename.ToString().Replace(@"\\?\", "");
                if (!string.IsNullOrEmpty(file))
                {
                    Write($"Writing {file}, {LongToMbytes(nNumberOfBytesToWrite)}");
                }
            }
            catch
            {
            }

            return result;
        }

        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern uint GetFinalPathNameByHandle(IntPtr hFile, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpszFilePath, uint cchFilePath, uint dwFlags);

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
    }
}
