using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SKYNET.Registry
{
    public class RegistryHelper
    {
        #region Enums  

        enum RegistryDispositionValue : uint
        {
            REG_CREATED_NEW_KEY = 0x00000001,
            REG_OPENED_EXISTING_KEY = 0x00000002
        }
        // root keys  
        public enum ROOT_KEY : uint
        {
            HKEY_CLASSES_ROOT = 0x80000000,
            HKEY_CURRENT_USER = 0x80000001,
            HKEY_LOCAL_MACHINE = 0x80000002,
            HKEY_USERS = 0x80000003,
            HKEY_PERFORMANCE_DATA = 0x80000004,
            HKEY_CURRENT_CONFIG = 0x80000005,
            HKEY_DYN_DATA = 0x80000006
        }

        // value types  
        public enum VALUE_TYPE : uint
        {
            REG_NONE,
            REG_SZ = 1,
            REG_EXPAND_SZ = 2,
            REG_BINARY = 3,
            REG_DWORD = 4,
            REG_DWORD_LITTLE_ENDIAN = 4,
            REG_DWORD_BIG_ENDIAN = 5,
            REG_LINK = 6,
            REG_MULTI_SZ = 7,
            REG_RESOURCE_LIST = 8,
            REG_FULL_RESOURCE_DESCRIPTOR = 9,
            REG_RESOURCE_REQUIREMENTS_LIST = 10,
            REG_QWORD_LITTLE_ENDIAN = 11
        }

        // token privileges  
        private enum ETOKEN_PRIVILEGES : uint
        {
            ASSIGN_PRIMARY = 0x1,
            TOKEN_DUPLICATE = 0x2,
            TOKEN_IMPERSONATE = 0x4,
            TOKEN_QUERY = 0x8,
            TOKEN_QUERY_SOURCE = 0x10,
            TOKEN_ADJUST_PRIVILEGES = 0x20,
            TOKEN_ADJUST_GROUPS = 0x40,
            TOKEN_ADJUST_DEFAULT = 0x80,
            TOKEN_ADJUST_SESSIONID = 0x100
        }
        #endregion

        #region Structs  
        // filetime (unused)  
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct FILETIME
        {
            public int dwLowDateTime;
            public int dwHighDateTime;
        }

        // permissions  
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct SECURITY_ATTRIBUTES
        {
            public int nLength;
            public int lpSecurityDescriptor;
            public bool bInheritHandle;
        }

        // perm luid  
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct LUID
        {
            public int LowPart;
            public int HighPart;
        }

        // perm attributes  
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct LUID_AND_ATTRIBUTES
        {
            public LUID pLuid;
            public int Attributes;
        }

        // perm token  
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct TOKEN_PRIVILEGES
        {
            public int PrivilegeCount;
            public LUID_AND_ATTRIBUTES Privileges;
        }

        #endregion

        #region PInvoke
        // RegQueryValueEx overloads- added ansi decl versions for old platforms [untested AND no methods provided]  
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegQueryValueExW", SetLastError = true)]
        public static extern int RegQueryValueEx(UIntPtr hKey, [MarshalAs(UnmanagedType.LPWStr)]string lpValueName, int lpReserved, out uint lpType, [Optional] System.Text.StringBuilder lpData, ref uint lpcbData);

        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, EntryPoint = "RegQueryValueExA", SetLastError = true)]
        static extern int RegQueryValueExA(UIntPtr hKey, [MarshalAs(UnmanagedType.LPStr)]string lpValueName, int lpReserved, out uint lpType, [Optional] [MarshalAs(UnmanagedType.LPStr)]string lpData, ref uint lpcbData);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegQueryValueExW", SetLastError = true)]
        static extern int RegQueryValueEx(UIntPtr hKey, [MarshalAs(UnmanagedType.LPWStr)]string lpValueName, int lpReserved, ref uint lpType, [Optional] ref byte lpData, ref uint lpcbData);

        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, EntryPoint = "RegQueryValueExA", SetLastError = true)]
        static extern int RegQueryValueExA(UIntPtr hKey, [MarshalAs(UnmanagedType.LPStr)]string lpValueName, int lpReserved, ref uint lpType, [Optional] ref byte lpData, ref uint lpcbData);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegQueryValueExW", SetLastError = true)]
        static extern int RegQueryValueEx(UIntPtr hKey, [MarshalAs(UnmanagedType.LPWStr)]string lpValueName, int lpReserved, ref uint lpType, [Optional] ref int lpData, ref uint lpcbData);

        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, EntryPoint = "RegQueryValueExA", SetLastError = true)]
        static extern int RegQueryValueExA(UIntPtr hKey, [MarshalAs(UnmanagedType.LPStr)]string lpValueName, int lpReserved, ref uint lpType, [Optional] ref int lpData, ref uint lpcbData);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegQueryValueExW", SetLastError = true)]
        static extern int RegQueryValueEx(UIntPtr hKey, [MarshalAs(UnmanagedType.LPWStr)]string lpValueName, int lpReserved, ref uint lpType, [Optional] ref long lpData, ref uint lpcbData);

        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, EntryPoint = "RegQueryValueExA", SetLastError = true)]
        static extern int RegQueryValueExA(UIntPtr hKey, [MarshalAs(UnmanagedType.LPStr)]string lpValueName, int lpReserved, ref uint lpType, [Optional] ref long lpData, ref uint lpcbData);

        // RegSetValueEx overloads  
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegSetValueExW", SetLastError = true)]
        private static extern int RegSetValueEx(UIntPtr hKey, [MarshalAs(UnmanagedType.LPWStr)]string lpValueName, int Reserved, uint dwType, ref int lpData, int cbData);
        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, EntryPoint = "RegSetValueExA", SetLastError = true)]
        private static extern int RegSetValueExA(UIntPtr hKey, [MarshalAs(UnmanagedType.LPStr)]string lpValueName, int Reserved, uint dwType, ref int lpData, int cbData);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegSetValueExW", SetLastError = true)]
        private static extern int RegSetValueEx(UIntPtr hKey, [MarshalAs(UnmanagedType.LPWStr)]string lpValueName, int Reserved, uint dwType, ref long lpData, int cbData);
        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, EntryPoint = "RegSetValueExA", SetLastError = true)]
        private static extern int RegSetValueExA(UIntPtr hKey, [MarshalAs(UnmanagedType.LPStr)]string lpValueName, int Reserved, uint dwType, ref long lpData, int cbData);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegSetValueExW", SetLastError = true)]
        private static extern int RegSetValueEx(UIntPtr hKey, [MarshalAs(UnmanagedType.LPWStr)]string lpValueName, int Reserved, uint dwType, IntPtr lpData, int cbData);
        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, EntryPoint = "RegSetValueEA", SetLastError = true)]
        private static extern int RegSetValueExA(UIntPtr hKey, [MarshalAs(UnmanagedType.LPStr)]string lpValueName, int Reserved, uint dwType, [MarshalAs(UnmanagedType.LPStr)]string lpData, int cbData);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegSetValueExW", SetLastError = true)]
        private static extern int RegSetValueEx(UIntPtr hKey, [MarshalAs(UnmanagedType.LPWStr)]string lpValueName, int Reserved, uint dwType, ref byte lpData, int cbData);
        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, EntryPoint = "RegSetValueExA", SetLastError = true)]
        private static extern int RegSetValueExA(UIntPtr hKey, [MarshalAs(UnmanagedType.LPStr)]string lpValueName, int Reserved, uint dwType, ref byte lpData, int cbData);

        // registry  
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegCloseKey", SetLastError = true)]
        private static extern int RegCloseKey(UIntPtr hKey);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegCreateKeyW", SetLastError = true)]
        private static extern int RegCreateKey(ROOT_KEY hKey, [MarshalAs(UnmanagedType.LPWStr)]string subKey, ref UIntPtr phkResult);
        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, EntryPoint = "RegCreateKeyA", SetLastError = true)]
        private static extern int RegCreateKeyA(ROOT_KEY hKey, [MarshalAs(UnmanagedType.LPStr)]string subKey, ref UIntPtr phkResult);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegOpenKeyExW", SetLastError = true)]
        private static extern int RegOpenKeyEx(ROOT_KEY hKey, [MarshalAs(UnmanagedType.LPWStr)]string subKey, int options, int samDesired, ref UIntPtr phkResult);

        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, EntryPoint = "RegOpenKeyExA", SetLastError = true)]
        private static extern int RegOpenKeyExA(ROOT_KEY hKey, [MarshalAs(UnmanagedType.LPStr)]string subKey, int options, int samDesired, ref UIntPtr phkResult);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegDeleteKeyA", SetLastError = true)]
        private static extern int RegDeleteKeyA(ROOT_KEY hKey, [MarshalAs(UnmanagedType.LPStr)]string subKey);
        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, EntryPoint = "RegDeleteKeyW", SetLastError = true)]
        private static extern int RegDeleteKey(ROOT_KEY hKey, [MarshalAs(UnmanagedType.LPWStr)]string subKey);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegDeleteValueW", SetLastError = true)]
        private static extern int RegDeleteValue(UIntPtr hKey, [MarshalAs(UnmanagedType.LPWStr)]string lpValueName);
        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, EntryPoint = "RegDeleteValueA", SetLastError = true)]
        private static extern int RegDeleteValueA(UIntPtr hKey, [MarshalAs(UnmanagedType.LPStr)]string lpValueName);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegCreateKeyExW", SetLastError = true)]
        private static extern int RegCreateKeyEx(ROOT_KEY hKey, [MarshalAs(UnmanagedType.LPWStr)]string subKey, int Reserved, [MarshalAs(UnmanagedType.LPWStr)]string lpClass, int dwOptions, int samDesired, ref SECURITY_ATTRIBUTES lpSecurityAttributes, ref UIntPtr phkResult, ref int lpdwDisposition);
        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, EntryPoint = "RegCreateKeyExA", SetLastError = true)]
        private static extern int RegCreateKeyExA(ROOT_KEY hKey, [MarshalAs(UnmanagedType.LPStr)]string subKey, int Reserved, [MarshalAs(UnmanagedType.LPStr)]string lpClass, int dwOptions, int samDesired, ref SECURITY_ATTRIBUTES lpSecurityAttributes, ref UIntPtr phkResult, ref int lpdwDisposition);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegEnumKeyExW", SetLastError = true)]
        private static extern int RegEnumKeyEx(UIntPtr hKey, uint index, StringBuilder lpName, ref uint lpcbName, IntPtr reserved, IntPtr lpClass, IntPtr lpcbClass, out long lpftLastWriteTime);
        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, EntryPoint = "RegEnumKeyExA", SetLastError = true)]
        private static extern int RegEnumKeyExA(UIntPtr hKey, uint index, [MarshalAs(UnmanagedType.LPStr)]string lpName, ref uint lpcbName, IntPtr reserved, IntPtr lpClass, IntPtr lpcbClass, out long lpftLastWriteTime);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegEnumValueW", SetLastError = true)]
        private static extern int RegEnumValue(UIntPtr hKey, uint dwIndex, StringBuilder lpValueName, ref uint lpcValueName, IntPtr lpReserved, IntPtr lpType, IntPtr lpData, IntPtr lpcbData);
        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, EntryPoint = "RegEnumValueA", SetLastError = true)]
        private static extern int RegEnumValueA(UIntPtr hKey, uint dwIndex, [MarshalAs(UnmanagedType.LPStr)]string lpValueName, ref uint lpcValueName, IntPtr lpReserved, IntPtr lpType, IntPtr lpData, IntPtr lpcbData);
        #endregion
    }
}
