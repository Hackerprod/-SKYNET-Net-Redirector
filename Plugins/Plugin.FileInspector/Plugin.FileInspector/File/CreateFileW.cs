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
    public class CreateFileW : IHook
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
        private delegate int CreateFileWDelegate([MarshalAs(UnmanagedType.LPWStr)] string filename, [MarshalAs(UnmanagedType.U4)] FileAccess access, [MarshalAs(UnmanagedType.U4)] FileShare share, IntPtr securityAttributes, [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition, [MarshalAs(UnmanagedType.U4)] FileAttributes flagsAndAttributes, IntPtr templateFile);
        private CreateFileWDelegate _CreateFileW;
        public override string Library => "kernel32.dll";
        public override string Method => "CreateFileW";
        public override LocalHook Hook { get; set; }
        public override Color Color => ColorTranslator.FromHtml("#FF0080");
        public override Delegate Delegate
        {
            get
            {
                _CreateFileW = Marshal.GetDelegateForFunctionPointer<CreateFileWDelegate>(ProcAddress);

                return new CreateFileWDelegate(Callback);
            }
        }

        string lastMessage = "";
        private int Callback([MarshalAs(UnmanagedType.LPWStr)] string filename, [MarshalAs(UnmanagedType.U4)] FileAccess access, [MarshalAs(UnmanagedType.U4)] FileShare share, IntPtr securityAttributes, [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition, [MarshalAs(UnmanagedType.U4)] FileAttributes flagsAndAttributes, IntPtr templateFile)
        {

            var result = _CreateFileW(filename, access, share, securityAttributes, creationDisposition, flagsAndAttributes, templateFile);

            try
            {
                string file = filename.Replace(@"\\?\", "");
                if (!Path.IsPathRooted(file))
                {
                    return result;
                }
                string Message = $"Accessing to {file}";
                if (Message != lastMessage)
                {
                    Write(Message);
                    lastMessage = Message;
                }
            }
            catch 
            {
            }

            return result;
        }
    }

}
