using System;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace SKYNET.Helper
{
    public class ShellManager
    {
        [DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);

        /// <summary>
        /// Add Context Menu Item to specified file type
        /// </summary>
        /// <param name="Extension">Extension of the file (.zip, .txt etc.)</param>
        /// <param name="MenuName">Name for the menu item (Play, Open etc.)</param>
        /// <param name="MenuDescription">The actual text that will be shown</param>
        /// <param name="Executable">Path to executable</param>
        public static bool AddContextMenuItem(string Extension, string MenuName, string MenuDescription, string Executable)
        {
            bool ret = false;

            try
            {
                RegistryKey rkey = Registry.ClassesRoot.OpenSubKey(Extension);
                if (rkey == null)
                {
                    rkey = Registry.ClassesRoot.CreateSubKey(Extension);
                    rkey.SetValue("", Extension.Replace(".", "") + "file");
                }
                if (rkey != null)
                {
                    string extstring = rkey.GetValue("").ToString();
                    rkey.Close();
                    if (extstring != null)
                    {
                        if (extstring.Length > 0)
                        {
                            rkey = Registry.ClassesRoot.OpenSubKey(extstring, true);
                            if (rkey == null)
                            {
                                rkey = Registry.ClassesRoot.CreateSubKey(extstring);
                            }
                            if (rkey != null)
                            {
                                string Icokey = "shell\\" + MenuName;
                                RegistryKey Ikey = rkey.CreateSubKey(Icokey);
                                if (Ikey != null)
                                {
                                    Ikey.SetValue("Icon", Executable);
                                }

                                string strkey = "shell\\" + MenuName + "\\command";
                                RegistryKey subky = rkey.CreateSubKey(strkey);
                                if (subky != null)
                                {
                                    subky.SetValue("", Executable + " %1");
                                    subky.Close();
                                    subky = rkey.OpenSubKey("shell\\" + MenuName, true);
                                    if (subky != null)
                                    {
                                        subky.SetValue("", MenuDescription);
                                        subky.Close();
                                    }
                                    ret = true;
                                }
                                rkey.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                ret = false;
            }
            return ret;
        }

        internal static void RemoveContextMenuItem(string MenuName)
        {
            try
            {
                string subKey = "exefile\\shell\\" + MenuName;
                RegistryKey registry = Registry.ClassesRoot.OpenSubKey(subKey, true);
                if (registry != null)
                {
                    Registry.ClassesRoot.DeleteSubKeyTree(subKey, false);
                }
            }
            catch
            {
            }
        }

        public static void AsociateExtention(string Extension, string FilePath)
        {
            try
            {
                RegistryKey RegKey = Registry.ClassesRoot.CreateSubKey(Extension);
                RegistryKey User_AutoFile_Command = RegKey.CreateSubKey("shell").CreateSubKey("open").CreateSubKey("command");
                User_AutoFile_Command.SetValue("", FilePath + " \"%1\"");
                RegKey.Close();
            }
            catch
            {
            }
            SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);
        }

        public static void DeAsociateExtention(string Extension)
        {
            try
            {
                string ProperName = Extension.Replace(".", "") + " File";
                if (Extension == null || ProperName == null)
                    throw new ArgumentNullException();
                if (Extension == "" || ProperName == "")
                    throw new ArgumentException();
                Registry.ClassesRoot.DeleteSubKeyTree(Extension);
                Registry.ClassesRoot.DeleteSubKeyTree(ProperName);
            }
            catch (Exception)
            {

            }
            SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);
        }
    }
}