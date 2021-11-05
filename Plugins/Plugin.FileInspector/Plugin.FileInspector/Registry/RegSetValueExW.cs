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
using SKYNET.Registry;
using static SKYNET.Registry.RegistryHelper;

namespace SKYNET.Hook
{
    public class RegSetValueExW : IHook
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
        private delegate int RegSetValueExWDelegate(UIntPtr hKey, [MarshalAs(UnmanagedType.LPWStr)]string lpValueName, int lpReserved, out uint lpType, [Optional] IntPtr lpData, ref uint lpcbData);
        private RegSetValueExWDelegate _RegSetValueExW;
        public override string Library => "advapi32.dll";
        public override string Method => "RegSetValueExW";
        public override LocalHook Hook { get; set; }
        public override Color Color => ColorTranslator.FromHtml("#FFFF00");
        public override Delegate Delegate
        {
            get
            {
                _RegSetValueExW = Marshal.GetDelegateForFunctionPointer<RegSetValueExWDelegate>(ProcAddress);

                return new RegSetValueExWDelegate(Callback);
            }
        }
        private int Callback(UIntPtr hKey, [MarshalAs(UnmanagedType.LPWStr)]string lpValueName, int lpReserved, out uint lpType, IntPtr lpData, ref uint lpcbData)
        {
            var result = _RegSetValueExW(hKey, lpValueName, lpReserved, out lpType, lpData, ref lpcbData);
            try
            {
                Write($"Modified value {lpValueName} = {Marshal.PtrToStringAuto(lpData)}");
            }
            catch (Exception)
            {
            }
            return result;
        }
        //private int Callback(UIntPtr hKey, [MarshalAs(UnmanagedType.LPWStr)] string lpValueName, int lpReserved, uint dwType, ref IntPtr lpData, int cbData)
        //{
        //    var result = 0;
        //    try
        //    {
        //        switch ((VALUE_TYPE)dwType)
        //        {
        //            case VALUE_TYPE.REG_NONE:
        //                break;
        //            case VALUE_TYPE.REG_SZ:
        //                StringBuilder builder = new StringBuilder();
        //                uint cdata = (uint)cbData;
        //                result = RegSetValueEx(hKey, lpValueName, lpReserved, out dwType, builder, ref cdata);
        //                //cbData = (int)cdata;
        //                lpData = Marshal.StringToHGlobalAuto(builder.ToString());
        //                Write($"Modified value {lpValueName} = {builder}");
        //                break;
        //            default:
        //                result = _RegSetValueExW(hKey, lpValueName, lpReserved, dwType, ref lpData, cbData);
        //                break;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //    }
        //    return result;
        //}

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegSetValueExW", SetLastError = true)]
        private static extern int RegSetValueEx(UIntPtr hKey, [MarshalAs(UnmanagedType.LPWStr)]string lpValueName, int lpReserved, out uint lpType, [Optional] StringBuilder lpData, ref uint lpcbData);

        private const int ERROR_NONE = 0x0;

        public static byte[] GetBytes(IntPtr buffer, int length)
        {
            byte[] array = new byte[length];
            Marshal.Copy(buffer, array, 0, length);
            return array;
        }
    }


}
