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
using SKYNET.GUI.Controls;
using SKYNET.Helper;
using SKYNET.Hook.Types;
using SKYNET.Types;

namespace SKYNET
{
    public partial class frmFunctions : Form
    {
        public static frmFunctions frm;
        private NativeModule Module;

        public List<ExportFunctionInfo> Functions { get; set; }

        public frmFunctions(NativeModule module)
        {
            InitializeComponent();
            frm = this;
            CheckForIllegalCrossThreadCalls = false;

            Module = module;
        }
        private void FrmModules_Shown(object sender, EventArgs e)
        {
            Thread t = new Thread(LoadFunctionsThread);
            t.IsBackground = true;
            t.Start();

        }

        private void LoadFunctionsThread()
        {
            ShowPanelDialog("Loading Modules");
            Thread.Sleep(200);
            NativeSharp.NativeProcess d = NativeSharp.NativeProcess.Open((uint)Process.GetCurrentProcess().Id, ProcessAccess.AllAccess);
            Functions = Module.EnumerateFunctionInfos().ToList();
            LoadFunctions();
        }

        private void ShowPanelDialog(string v)
        {
            LV_ItemsView.Visible = false;
        }

        private void LoadFunctions()
        {
            LV_ItemsView.Visible = false;
            LV_ItemsView.Controls.Clear();

            foreach (var Function in Functions)
            {
                AddItem(Function);
            }
            modCommon.InvokeVisible(PN_Info, false);
            modCommon.InvokeVisible(LV_ItemsView, true);
        }

        private void AddItem(ExportFunctionInfo function)
        {
            ListViewItem item = new ListViewItem();
            item.SubItems.Add(new ListViewItem.ListViewSubItem() { Name = "LV1"});
            item.SubItems.Add(new ListViewItem.ListViewSubItem() { Name = "LV2" });
            item.SubItems.Add(new ListViewItem.ListViewSubItem() { Name = "LV3" });
            item.SubItems.Add(new ListViewItem.ListViewSubItem() { Name = "LV4" });

            unsafe
            {
                item.SubItems[0].Text = function.Name;
                item.SubItems[1].Text = function.Ordinal.ToString();
                item.SubItems[2].Text = "0x" + ((IntPtr)function.Address).ToString("X8");
            }

            LV_ItemsView.Items.Add(item);
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

        private void LV_ItemsView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ListViewItem item = LV_ItemsView.SelectedItems[0];
                LB_Function.Text = $"{Module.Name}   {item.SubItems[0].Text}";
                Clipboard.SetText(item.SubItems[0].Text);
            }
            catch (Exception)
            {
            }
        }
    }
}
