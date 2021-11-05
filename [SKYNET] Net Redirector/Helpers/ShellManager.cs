using System;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace SKYNET.Helper
{
    public class ShellManager
    {
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

        public static string GetProgId(string ext)
        {
            string result = "";
            try
            {
                using (RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey(ext))
                {
                    if (registryKey != null)
                    {
                        result = registryKey.GetValue("").ToString();
                        registryKey.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                return "";
            }
            return result;
        }
        public static void AsociateExtention(string Extension, string OpenWith, string ExecutableName)
        {
            try
            {
                using (RegistryKey User_Classes = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Classes\\", true))
                using (RegistryKey User_Ext = User_Classes.CreateSubKey("." + Extension))
                using (RegistryKey User_AutoFile = User_Classes.CreateSubKey(Extension + "_auto_file"))
                using (RegistryKey User_AutoFile_Command = User_AutoFile.CreateSubKey("shell").CreateSubKey("open").CreateSubKey("command"))
                using (RegistryKey ApplicationAssociationToasts = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\ApplicationAssociationToasts\\", true))
                using (RegistryKey User_Classes_Applications = User_Classes.CreateSubKey("Applications"))
                using (RegistryKey User_Classes_Applications_Exe = User_Classes_Applications.CreateSubKey(ExecutableName))
                using (RegistryKey User_Application_Command = User_Classes_Applications_Exe.CreateSubKey("shell").CreateSubKey("open").CreateSubKey("command"))
                using (RegistryKey User_Explorer = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\." + Extension))
                using (RegistryKey User_Choice = User_Explorer.OpenSubKey("UserChoice"))
                {
                    User_Ext.SetValue("", Extension + "_auto_file", RegistryValueKind.String);
                    User_Classes.SetValue("", Extension + "_auto_file", RegistryValueKind.String);
                    User_Classes.CreateSubKey(Extension + "_auto_file");
                    User_AutoFile_Command.SetValue("", "\"" + OpenWith + "\"" + " \"%1\"");
                    ApplicationAssociationToasts.SetValue(Extension + "_auto_file_." + Extension, 0);
                    ApplicationAssociationToasts.SetValue(@"Applications\" + ExecutableName + "_." + Extension, 0);
                    User_Application_Command.SetValue("", "\"" + OpenWith + "\"" + " \"%1\"");
                    User_Explorer.CreateSubKey("OpenWithList").SetValue("a", ExecutableName);
                    User_Explorer.CreateSubKey("OpenWithProgids").SetValue(Extension + "_auto_file", "0");
                    if (User_Choice != null) User_Explorer.DeleteSubKey("UserChoice");
                    User_Explorer.CreateSubKey("UserChoice").SetValue("ProgId", @"Applications\" + ExecutableName);
                }

                SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);
            }
            catch (Exception excpt)
            {
                //Your code here
            }
        }

        public static bool DeAsociateExtention2(string Extension)
        {
            if (Extension.IndexOf(".") == -1)
            {
                Extension = "." + Extension;
            }
            string progId = GetProgId(Extension);
            try
            {
                if (!string.IsNullOrEmpty(progId) && progId.Length > 0)
                {
                    Registry.ClassesRoot.DeleteSubKeyTree(Extension);
                    Registry.ClassesRoot.DeleteSubKeyTree(progId);
                    return true;
                }
                try
                {
                    RegistryKey User_Classes = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Classes\\", true);
                    User_Classes.DeleteSubKey("." + Extension);
                    User_Classes.DeleteSubKey(Extension + "_auto_file");
                    User_Classes.DeleteSubKey("Applications");
                    User_Classes.DeleteSubKey(Extension + "_auto_file");
                }
                catch 
                {

                }
                try
                {
                    RegistryKey ApplicationAssociationToasts = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\ApplicationAssociationToasts\\", true);
                    ApplicationAssociationToasts.DeleteValue(Extension + "_auto_file_." + Extension);
                }
                catch 
                {
                }
                Registry.CurrentUser.DeleteSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\." + Extension);

            }
            catch (Exception ex)
            {
            }
            return false;
        }

        [DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);

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