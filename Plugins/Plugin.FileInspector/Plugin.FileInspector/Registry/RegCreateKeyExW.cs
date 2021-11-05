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
using static SKYNET.Registry.RegistryHelper;

namespace SKYNET.Hook
{
    public class RegCreateKeyExW : IHook
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
        private delegate int RegCreateKeyExWDelegate(ROOT_KEY hKey, [MarshalAs(UnmanagedType.LPWStr)]string subKey, int Reserved, [MarshalAs(UnmanagedType.LPWStr)]string lpClass, int dwOptions, int samDesired, ref SECURITY_ATTRIBUTES lpSecurityAttributes, ref UIntPtr phkResult, ref int lpdwDisposition);
        private RegCreateKeyExWDelegate _RegCreateKeyExW;
        public override string Library => "advapi32.dll";
        public override string Method => "RegCreateKeyExW";
        public override LocalHook Hook { get; set; }
        public override Color Color => ColorTranslator.FromHtml("#D70058");
        public override Delegate Delegate
        {
            get
            {
                _RegCreateKeyExW = Marshal.GetDelegateForFunctionPointer<RegCreateKeyExWDelegate>(ProcAddress);

                return new RegCreateKeyExWDelegate(Callback);
            }
        }

        private int Callback(ROOT_KEY hKey, [MarshalAs(UnmanagedType.LPWStr)]string subKey, int Reserved, [MarshalAs(UnmanagedType.LPWStr)]string lpClass, int dwOptions, int samDesired, ref SECURITY_ATTRIBUTES lpSecurityAttributes, ref UIntPtr phkResult, ref int lpdwDisposition)
        {
            var result = _RegCreateKeyExW(hKey, subKey, Reserved, lpClass, dwOptions, samDesired, ref lpSecurityAttributes, ref phkResult, ref lpdwDisposition);

            try
            {
                string Message = $"Creating Key {hKey}/{subKey}";
                Write(Message);
            }
            catch (Exception)
            {
            }

            return result;
        }
        


    }

}
