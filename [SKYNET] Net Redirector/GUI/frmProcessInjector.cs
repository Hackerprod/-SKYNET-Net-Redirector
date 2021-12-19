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
    public partial class frmProcessInjector : frmBase
    {
        public static frmProcessInjector frm;
        private List<Process> Processes;
        private HookInterface hookInterface;
        private string channel;

        public frmProcessInjector(HookInterface hookInterface)
        {
            modCommon.ShowShadow = true;
            InitializeComponent();
            base.EnableShadows = true;
            frm = this;
            CheckForIllegalCrossThreadCalls = false;
            this.hookInterface = hookInterface;
            Processes = new List<Process>();

        }

        private void FrmModules_Shown(object sender, EventArgs e)
        {
            LoadProcess();

        }

        private void LoadProcess()
        {
            PN_ModuleContainer.Visible = false;
            PN_ModuleContainer.Controls.Clear();
            modCommon.InvokeVisible(PN_Info, true);

            Task.Run(() =>
            {
                if (!Processes.Any())
                {
                    Processes = Process.GetProcesses().ToList();
                }

                foreach (var process in Processes)
                {
                    var proc = new ModuleControl()
                    {
                        Process = process
                    };
                    proc.Dock = DockStyle.Top;
                    proc.MouseDoubleClick += Module_MouseDoubleClick;

                    modCommon.InvokeAddControl(PN_ModuleContainer, proc);
                }

                modCommon.InvokeVisible(PN_Info, false);
                modCommon.InvokeVisible(PN_ModuleContainer, true);
            });
        }
        private void SearchProcess(string word)
        {
            foreach (var item in PN_ModuleContainer.Controls)
            {
                ModuleControl control = (ModuleControl)item;
                if (string.IsNullOrEmpty(word))
                {
                    control.Visible = true;
                }
                else
                {
                    if (control.Process.ProcessName.ToLower().Contains(word.ToLower()))
                    {
                        control.Visible = true;
                    }
                    else
                    {
                        control.Visible = false;
                    }
                }
            }
        }

        private void Module_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ModuleControl process = ((ModuleControl)sender);

            try
            {
                var InObject = WellKnownObjectMode.Singleton;
                RemoteHooking.IpcCreateServer(ref channel, InObject, hookInterface);
                RemoteHooking.Inject(process.Process.Id, hookInterface.InjectionOptions, hookInterface.DllPath, hookInterface.DllPath, new object[]
                {
                    channel
                });
                frmMain.frm.InjectedProcess = Process.GetProcessById(process.Process.Id);
                Process.GetProcessById(process.Process.Id).WaitForExit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

            Close();
        }

        private void B_Close_Clicked(object sender, EventArgs e)
        {
            Close();
        }
        private void TB_SearchClicked(object sender, EventArgs e)
        {
            SearchProcess(TB_Search.Text);
        }
        private void TB_Search_KeyUp(object sender, KeyEventArgs e)
        {
            SearchProcess(TB_Search.Text);
        }


    }
}

