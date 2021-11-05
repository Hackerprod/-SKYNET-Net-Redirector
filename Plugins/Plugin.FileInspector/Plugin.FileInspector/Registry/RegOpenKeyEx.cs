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
    public class RegOpenKeyExW : IHook
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
        private delegate int RegOpenKeyExWDelegate(ROOT_KEY hKey, [MarshalAs(UnmanagedType.LPWStr)]string subKey, int options, int samDesired, ref UIntPtr phkResult);
        private RegOpenKeyExWDelegate _RegOpenKeyExW;
        public override string Library => "advapi32.dll";
        public override string Method => "RegOpenKeyExW";
        public override LocalHook Hook { get; set; }
        public override Color Color => ColorTranslator.FromHtml("#D70058");
        public override Delegate Delegate
        {
            get
            {
                _RegOpenKeyExW = Marshal.GetDelegateForFunctionPointer<RegOpenKeyExWDelegate>(ProcAddress);

                return new RegOpenKeyExWDelegate(Callback);
            }
        }

        private int Callback(ROOT_KEY hKey, [MarshalAs(UnmanagedType.LPWStr)]string subKey, int options, int samDesired, ref UIntPtr phkResult)
        {
            var result = _RegOpenKeyExW(hKey, subKey, options, samDesired, ref phkResult);

            try
            {
                switch (hKey)
                {
                    case ROOT_KEY.HKEY_CLASSES_ROOT:
                    case ROOT_KEY.HKEY_CURRENT_USER:
                    case ROOT_KEY.HKEY_LOCAL_MACHINE:
                    case ROOT_KEY.HKEY_USERS:
                    case ROOT_KEY.HKEY_PERFORMANCE_DATA:
                    case ROOT_KEY.HKEY_CURRENT_CONFIG:
                    case ROOT_KEY.HKEY_DYN_DATA:
                        break;
                    default:
                        return result;
                }
                StringBuilder code = new StringBuilder();
                code.AppendLine($"Opening Key: {hKey}");
                code.AppendLine($"SubKey:     {subKey}");
                string Message = code.ToString();
                Write(Message);
            }
            catch (Exception)
            {
            }

            return result;
        }



    }

}
