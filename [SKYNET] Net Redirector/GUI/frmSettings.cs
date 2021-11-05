﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using EasyHook;
using Microsoft.Win32;
using SKYNET.Controls;
using SKYNET.GUI;
using SKYNET.Helper;

namespace SKYNET
{
    public partial class frmSettings : frmBase
    {
        public static frmSettings frm;

        private bool DnsChanged;
        private bool IpChanged;
        private bool PortChanged;

        public frmSettings()
        {
            modCommon.ShowShadow = true;
            InitializeComponent();
            frm = this;
            CheckForIllegalCrossThreadCalls = false;
            base.SetMouseMove(P_Top);
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            LB_Path.Text = frmMain.ExecutablePath.Replace(@"\", "/");
            InjectOnStart.Checked = frmMain.HookInterface.InjectOnStart;
            LoadPlugins.Checked = frmMain.HookInterface.LoadPlugins;
            DumpToConsole.Checked = frmMain.HookInterface.DumpToConsole;
            DumpToFile.Checked = frmMain.HookInterface.DumpToFile;
            SkipCertificateChainVerification.Checked = frmMain.HookInterface.SkipCertificateChainVerification;

            foreach (var Dns in frmMain.HookInterface.DnsRedirection)
            {
                DNSRedirection.Text += $"{Dns.Key} = {Dns.Value} {Environment.NewLine}";
            }

            foreach (var IP in frmMain.HookInterface.IPRedirection)
            {
                IPRedirection.Text += $"{IP.Key} = {IP.Value} {Environment.NewLine}";
            }

            foreach (var Port in frmMain.HookInterface.PortRedirection)
            {
                PortRedirection.Text += $"{Port.Key} = {Port.Value} {Environment.NewLine}";
            }

            CH_WindowsMenuItem.Checked = frmMain.frm.WindowsMenuItem;
            CH_AssociateFileExtension.Checked = frmMain.frm.AssociateFileExtension;
            RunOnStartup.Checked = frmMain.frm.RunOnStartup;

        }

        private void B_Close_Clicked(object sender, EventArgs e)
        {
            Close();
        }
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            int attrValue = 2;
            DwmApi.DwmSetWindowAttribute(base.Handle, 2, ref attrValue, 16);
            DwmApi.MARGINS mARGINS = default(DwmApi.MARGINS);
            mARGINS.cyBottomHeight = 1;
            mARGINS.cxLeftWidth = 0;
            mARGINS.cxRightWidth = 0;
            mARGINS.cyTopHeight = 0;
            DwmApi.MARGINS marInset = mARGINS;
            DwmApi.DwmExtendFrameIntoClientArea(base.Handle, ref marInset);
        }

        private void Path_Click(object sender, EventArgs e)
        {
            OpenFileDialog oDialog = new OpenFileDialog();
            oDialog.InitialDirectory = LB_Path.Text;
            DialogResult result = oDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                LB_Path.Text = oDialog.FileName.Replace(@"\", "/");
            }
        }

        private void BT_Apply_Click(object sender, EventArgs e)
        {
            frmMain.ExecutablePath = LB_Path.Text;

            frmMain.frm.RunOnStartup = RunOnStartup.Checked;
            RegisterOnStartup(RunOnStartup.Checked);

            frmMain.HookInterface.InjectOnStart = InjectOnStart.Checked;
            frmMain.HookInterface.LoadPlugins = LoadPlugins.Checked;

            if (frmMain.HookInterface.DumpToConsole != DumpToConsole.Checked)
            {
                frmMain.HookInterface.DumpToConsole = DumpToConsole.Checked;
                frmMain.HookCallback?.InvokeDumpToConsoleChanged(DumpToConsole.Checked);
            }

            if (frmMain.HookInterface.DumpToFile != DumpToFile.Checked)
            {
                frmMain.HookInterface.DumpToFile = DumpToFile.Checked;
                frmMain.HookCallback?.InvokeDumpToFileChanged(DumpToFile.Checked);
            }

            if (frmMain.HookInterface.SkipCertificateChainVerification != SkipCertificateChainVerification.Checked)
            {
                frmMain.HookInterface.SkipCertificateChainVerification = SkipCertificateChainVerification.Checked;
                frmMain.HookCallback?.InvokeSkipChainVerificationChanged(SkipCertificateChainVerification.Checked);
            }

            if (DnsChanged)
            {
                var Dns = GetKeyValuePair(DNSRedirection.Lines);
                frmMain.HookInterface.DnsRedirection = Dns;
                try
                {
                    frmMain.HookCallback?.InvokeDnsRedirectionChanged(Dns);
                }
                catch 
                {
                }
            }

            if (IpChanged)
            {
                var Ip = GetKeyValuePair(IPRedirection.Lines);
                frmMain.HookInterface.IPRedirection = Ip;
                try
                {
                    frmMain.HookCallback?.InvokeIpRedirectionChanged(Ip);
                }
                catch
                {
                }
            }

            if (PortChanged)
            {
                var Port = GetKeyValuePair(PortRedirection.Lines);
                frmMain.HookInterface.PortRedirection = Port;
                try
                {
                    frmMain.HookCallback?.InvokePortRedirectionChanged(Port);
                }
                catch
                {
                }
            }

            frmMain.frm.RegistrySettings.Set("WindowsMenuItem", CH_WindowsMenuItem.Checked);
            frmMain.frm.RegistrySettings.Set("AssociateFileExtension", CH_AssociateFileExtension.Checked);
            frmMain.frm.RegistrySettings.Set("RunOnStartup", RunOnStartup.Checked);

            string exePath = Process.GetCurrentProcess().MainModule.FileName;
            if (CH_WindowsMenuItem.Checked != frmMain.frm.WindowsMenuItem)
            {
                if (CH_WindowsMenuItem.Checked)
                {
                    ShellManager.AddContextMenuItem(".exe", "Open with [SKYNET] Net Redirector", "", exePath);
                    ShellManager.AddContextMenuItem(".dump", "Show dump with [SKYNET] Net Redirector", "", exePath);
                }
                else
                {
                    ShellManager.RemoveContextMenuItem("Open with [SKYNET] Net Redirector");
                    ShellManager.RemoveContextMenuItem("Show dump with [SKYNET] Net Redirector");
                }
            }
            if (CH_AssociateFileExtension.Checked != frmMain.frm.AssociateFileExtension)
            {
                if (CH_AssociateFileExtension.Checked)
                {
                    ShellManager.AsociateExtention(".dump", exePath);
                }
                else
                {
                    ShellManager.DeAsociateExtention(".dump");
                }
            }
            frmMain.frm.WindowsMenuItem = CH_WindowsMenuItem.Checked;
            frmMain.frm.AssociateFileExtension = CH_AssociateFileExtension.Checked;

            frmMain.SaveSettings();

            Close();
        }
        [DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);
        private ConcurrentDictionary<string, string> GetKeyValuePair(string[] lines)
        {
            ConcurrentDictionary<string, string> KeyValue = new ConcurrentDictionary<string, string>();
            foreach (var line in lines)
            {
                if (line.Contains("=") && line.Split('=').Length > 1)
                {
                    string[] KV = line.Replace(" =", "=").Replace("= ", "=").Split('=');
                    KeyValue.TryAdd(KV[0], KV[1]);
                }
            }
            return KeyValue;
        }

        private void RegisterOnStartup(bool Start)
        {
            try
            {
                RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", writable: true);
                try
                {
                    if (Start)
                    {
                        registryKey.SetValue("[SKYNET] Net Redirector", Application.ExecutablePath.ToString());
                    }
                    else
                    {
                        registryKey.DeleteValue("[SKYNET] Net Redirector");
                    }
                }
                catch { }
            }
            catch { }
        }

        private void DNSRedirection_TextChanged(object sender, EventArgs e)
        {
            DnsChanged = true;
        }

        private void IPRedirection_TextChanged(object sender, EventArgs e)
        {
            IpChanged = true;
        }

        private void PortRedirection_TextChanged(object sender, EventArgs e)
        {
            PortChanged = true;
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            string senderName = ((Control)sender).Name;
            if (senderName == BT_Main.Name)
            {
                TabControl1.SelectTab(tabPage1);
            }
            if (senderName == BT_Detour.Name)
            {
                TabControl1.SelectTab(tabPage2);
            }
            if (senderName == BT_Redirection.Name)
            {
                TabControl1.SelectTab(tabPage3);
            }

            ClearMenuColor();
            ((Control)sender).Parent.BackColor = Color.FromArgb(120, 195, 252);
        }
        private void ClearMenuColor()
        {
            BT_Main.Parent.BackColor = BackColor;
            BT_Detour.Parent.BackColor = BackColor;
            BT_Redirection.Parent.BackColor = BackColor;
        }

    }
}
