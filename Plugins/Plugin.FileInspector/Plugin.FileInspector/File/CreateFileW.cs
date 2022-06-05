using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using EasyHook;

namespace SKYNET.Hook
{
    public class CreateFileW : IHook
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
        private delegate int CreateFileWDelegate(String filename, UInt32 desiredAccess, UInt32 shareMode, IntPtr securityAttributes, UInt32 creationDisposition, UInt32 flagsAndAttributes, IntPtr templateFile);
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
        private int Callback(String filename, UInt32 desiredAccess, UInt32 shareMode, IntPtr securityAttributes, UInt32 creationDisposition, UInt32 flagsAndAttributes, IntPtr templateFile)
        {
            try
            {
                string mode = string.Empty;
                switch (creationDisposition)
                {
                    case 1:
                        mode = "CREATE_NEW";
                        break;
                    case 2:
                        mode = "CREATE_ALWAYS";
                        break;
                    case 3:
                        mode = "OPEN_ALWAYS";
                        break;
                    case 4:
                        mode = "OPEN_EXISTING";
                        break;
                    case 5:
                        mode = "TRUNCATE_EXISTING";
                        break;
                }
                string file = filename.Replace(@"\\?\", "");
                if (!Path.IsPathRooted(file))
                {
                    string Message = $"Access {mode} to {file}";
                    Write(Message);
                }
            }
            catch 
            {
            }

            return _CreateFileW(
                filename,
                desiredAccess,
                shareMode,
                securityAttributes,
                creationDisposition,
                flagsAndAttributes,
                templateFile); ;
        }
    }

}
