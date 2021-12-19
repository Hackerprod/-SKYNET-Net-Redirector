using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Be.Windows.Forms;
using EasyHook;
using NativeSharp;
using SKYNET.Controls;
using SKYNET.GUI;
using SKYNET.GUI.Controls;
using SKYNET.Helper;
using SKYNET.Hook.Types;
using SKYNET.Types;

namespace SKYNET
{
    public partial class frmModules : frmBase
    {
        public static frmModules frm;
        private Process Process;
        private List<NativeModule> Modules;
        public frmModules(Process process)
        {
            modCommon.ShowShadow = true;
            InitializeComponent();
            frm = this;
            CheckForIllegalCrossThreadCalls = false;
            Process = process;
            base.EnableShadows = true;
        }
        private void FrmModules_Shown(object sender, EventArgs e)
        {
            Thread t = new Thread(LoadModulesThread);
            t.IsBackground = true;
            t.Start();

        }

        private void LoadModulesThread()
        {
            ShowPanelDialog();
            NativeProcess NativeProcess = NativeSharp.NativeProcess.Open((uint)Process.Id, ProcessAccess.AllAccess);

            Modules = NativeProcess.GetModules();
            LoadModules("");
        }

        private void ShowPanelDialog()
        {
            PN_ModuleContainer.Visible = false;
        }

        private void LoadModules(string word)
        {
            PN_ModuleContainer.Visible = false;
            PN_ModuleContainer.Controls.Clear();

            foreach (var Module in Modules)
            {
                var module = new ModuleControl()
                {
                    Module = Module
                };
                module.Dock = DockStyle.Top;
                module.MouseDoubleClick += Module_MouseDoubleClick;

                if (string.IsNullOrEmpty(word))
                {
                    modCommon.InvokeAddControl(PN_ModuleContainer, module);
                }
                else if (Module.Name.ToLower().Contains(word.ToLower()))
                {
                    modCommon.InvokeAddControl(PN_ModuleContainer, module);
                }
            }
            modCommon.InvokeVisible(PN_Info, false);
            modCommon.InvokeVisible(PN_ModuleContainer, true);
        }

        private void Module_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            new frmFunctions(((ModuleControl)sender).Module).ShowDialog();
        }

        private void B_Close_Clicked(object sender, EventArgs e)
        {
            Close();
        }
        private void TB_SearchClicked(object sender, EventArgs e)
        {
            LoadModules(TB_Search.Text);
        }
        private void TB_Search_KeyUp(object sender, KeyEventArgs e)
        {
            LoadModules(TB_Search.Text);
        }

    }
}

