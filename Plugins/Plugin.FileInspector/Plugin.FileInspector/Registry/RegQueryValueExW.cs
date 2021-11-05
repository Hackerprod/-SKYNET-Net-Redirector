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
    public class RegQueryValueExW : IHook
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
        private delegate int RegQueryValueExWDelegate(UIntPtr hKey, [MarshalAs(UnmanagedType.LPWStr)]string lpValueName, int lpReserved, out uint lpType, IntPtr lpData, ref uint lpcbData);
        private RegQueryValueExWDelegate _RegQueryValueExW;
        public override string Library => "advapi32.dll";
        public override string Method => "RegQueryValueExW";
        public override LocalHook Hook { get; set; }
        public override Color Color => ColorTranslator.FromHtml("#FFFFAA");
        public override Delegate Delegate
        {
            get
            {
                _RegQueryValueExW = Marshal.GetDelegateForFunctionPointer<RegQueryValueExWDelegate>(ProcAddress);

                return new RegQueryValueExWDelegate(Callback);
            }
        }

        private int Callback(UIntPtr hKey, [MarshalAs(UnmanagedType.LPWStr)]string lpValueName, int lpReserved, out uint lpType, IntPtr lpData, ref uint lpcbData)
        {
            var result = _RegQueryValueExW(hKey, lpValueName, lpReserved, out lpType, lpData, ref lpcbData);
            try
            {
                //HKey key = Marshal.PtrToStructure<HKey>(hKey);
                switch ((VALUE_TYPE)lpType)
                {
                    case VALUE_TYPE.REG_EXPAND_SZ:
                    case VALUE_TYPE.REG_SZ:
                        string values = Marshal.PtrToStringAuto(lpData);
                        if (!string.IsNullOrEmpty(values))
                        {
                            Write($"Accessing to {lpValueName} in opened Key with value: {Marshal.PtrToStringAuto(lpData)}");
                        }
                        break;
                    case VALUE_TYPE.REG_BINARY:
                        byte[] bytes = GetBytes(lpData, (int)lpcbData);
                        Write($"Accessing to {lpValueName} in opened Key with value: {BitConverter.ToString(bytes).Replace("-", " ")}");
                        break;
                    case VALUE_TYPE.REG_DWORD_BIG_ENDIAN:
                    case VALUE_TYPE.REG_QWORD_LITTLE_ENDIAN:
                    case VALUE_TYPE.REG_DWORD:
                        Write($"Accessing to {lpValueName} in opened Key with value: {Marshal.ReadInt64(lpData)}");
                        break;
                    default:
                        Write($"Accessing to {lpValueName} in opened Key.");
                        break;
                }
            }
            catch (Exception)
            {
            }

            return result;
        }
        public static byte[] GetBytes(IntPtr buffer, int length)
        {
            byte[] array = new byte[length];
            Marshal.Copy(buffer, array, 0, length);
            return array;
        }

    }

}
