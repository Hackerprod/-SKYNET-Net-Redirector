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

        string lastMessage = "";
        private bool Callback(IntPtr hFile, IntPtr lpBuffer, uint nNumberOfBytesToWrite, out uint lpNumberOfBytesWritten, IntPtr lpOverlapped)
        {
            bool result = _WriteFile(hFile, lpBuffer, nNumberOfBytesToWrite, out lpNumberOfBytesWritten, lpOverlapped);
            try
            {
                string text = Marshal.PtrToStringAnsi(hFile);

                StringBuilder filename = new StringBuilder(255);
                GetFinalPathNameByHandle(hFile, filename, 255, 0);

                string file = filename.ToString().Replace(@"\\?\", "");
                string Message = $"Writing {file}, {nNumberOfBytesToWrite} bytes";
                if (Message != lastMessage)
                {
                    if (string.IsNullOrEmpty(file))
                    {
                        return result;
                    }
                    if (lpNumberOfBytesWritten > 2048)
                    {
                        Write(Message);
                    }
                    else
                    {
                        byte[] array = GetBytes(lpBuffer, (int)lpNumberOfBytesWritten);
                        Write(Message + "\n" + Encoding.Default.GetString(array));

                    }
                    lastMessage = Message;
                }
            }
            catch
            {
            }

            return result;
        }
        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern uint GetFinalPathNameByHandle(IntPtr hFile, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpszFilePath, uint cchFilePath, uint dwFlags);
        public static byte[] GetBytes(IntPtr buffer, int length)
        {
            byte[] array = new byte[length];
            Marshal.Copy(buffer, array, 0, length);
            return array;
        }
    }

}
