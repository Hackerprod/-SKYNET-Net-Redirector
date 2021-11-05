using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Be.Windows.Forms;
using EasyHook;
using SKYNET.Controls;
using SKYNET.GUI;
using SKYNET.Helper;
using SKYNET.Hook.Types;
using SKYNET.Types;

namespace SKYNET
{
    public partial class frmDumps : frmBase
    {
        public static frmDumps frm;
        private List<NetMessage> NetMessages;
        public frmDumps(List<NetMessage> netMessages)
        {
            modCommon.ShowShadow = true;
            InitializeComponent();
            frm = this;
            CheckForIllegalCrossThreadCalls = false;
            base.SetMouseMove(P_Top);
            NetMessages = netMessages;

        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            foreach (var netMessage in NetMessages)
            {
                AddDump(netMessage);
            }
        }
        private void FrmMain_Shown(object sender, EventArgs e)
        {
        }
        private void B_Close_Clicked(object sender, EventArgs e)
        {
            Close();
        }
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
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
        private void AddDump(NetMessage Body)
        {
            ListViewItem listViewItem = new ListViewItem();
            listViewItem.SubItems.AddRange(GetItems());

            listViewItem.SubItems[0].Text = Body.Time.ToShortDateString() + " " + Body.Time.ToShortTimeString();
            listViewItem.SubItems[0].Tag = Body;
            listViewItem.SubItems[1].Text = Body.Source.ToString();
            listViewItem.SubItems[2].Text = Body.Destination.ToString();
            listViewItem.SubItems[3].Text = Body.Protocol.ToString();
            listViewItem.SubItems[4].Text = Body.Body.Length.ToString();
            listViewItem.SubItems[5].Text = Encoding.Default.GetString(Body.Body);

            switch (Body.Protocol)
            {
                case ProtocolType.Tcp:
                    listViewItem.SubItems[3].ForeColor = Color.FromArgb(253, 204, 34);
                    break;
                case ProtocolType.Udp:
                    listViewItem.SubItems[3].ForeColor = Color.FromArgb(40, 158, 255);
                    break;
                //case ProtocolType.Http:
                //    listViewItem.SubItems[3].ForeColor = Color.FromArgb(228, 255, 199);
                //    break;
            }

            listView.Items.Add(listViewItem);
        }

        private ListViewItem.ListViewSubItem[] GetItems()
        {
            List<ListViewItem.ListViewSubItem> Items = new List<ListViewItem.ListViewSubItem>();

            ListViewItem.ListViewSubItem timeSubItem = new ListViewItem.ListViewSubItem();
            ListViewItem.ListViewSubItem sourceSubItem = new ListViewItem.ListViewSubItem();
            ListViewItem.ListViewSubItem destinationSubItem = new ListViewItem.ListViewSubItem();
            ListViewItem.ListViewSubItem protocolSubItem = new ListViewItem.ListViewSubItem();
            ListViewItem.ListViewSubItem lengthSubItem = new ListViewItem.ListViewSubItem();
            ListViewItem.ListViewSubItem dataSubItem = new ListViewItem.ListViewSubItem();

            Items.Add(timeSubItem);
            Items.Add(sourceSubItem);
            Items.Add(destinationSubItem);
            Items.Add(protocolSubItem);
            Items.Add(lengthSubItem);
            Items.Add(dataSubItem);
            return Items.ToArray();
        }

        private void ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                NetMessage NetMessage = (NetMessage)listView.SelectedItems[0].SubItems[0].Tag;

                DynamicByteProvider byteProvider = new DynamicByteProvider(NetMessage.Body);
                hexBox1.ByteProvider = byteProvider;

                if (NetMessage.Body.Length > 300)
                {
                    hexBox1.VScrollBarVisible = true;
                }

            }
            catch
            {
            }

        }

        private void ListView_DoubleClick(object sender, EventArgs e)
        {
            NetMessage NetMessage = (NetMessage)listView.SelectedItems[0].SubItems[0].Tag;
            new frmDumpViewer(NetMessage).ShowDialog();
        }
    }
}
