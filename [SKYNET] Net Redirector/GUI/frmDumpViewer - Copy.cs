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
using SKYNET.Controls;
using SKYNET.GUI;
using SKYNET.Helper;
using SKYNET.Hook.Types;
using SKYNET.Types;

namespace SKYNET
{
    public partial class frmDumpViewer : frmBase
    {
        public static frmDumpViewer frm;
        private NetMessage NetMessage;

        public frmDumpViewer(NetMessage msg)
        {
            modCommon.ShowShadow = true;
            InitializeComponent();
            frm = this;
            CheckForIllegalCrossThreadCalls = false;

            base.SetMouseMove(P_Top);
            base.EnableShadows = true;

            NetMessage = msg;

            DynamicByteProvider byteProvider = new DynamicByteProvider(NetMessage.Body);
            hexBox1.ByteProvider = byteProvider;
            if (NetMessage.Body.Length > 300)
            {
                hexBox1.VScrollBarVisible = true;
                TB_Payload.ScrollBars = ScrollBars.Vertical;
            }

            if (NetMessage.Direction == DIRECTION.IN)
            {
                LB_Destination.Text = msg.Source.ToString();
                LB_Source.Text = msg.Destination.ToString();
            }
            else
            {
                LB_Source.Text = msg.Source.ToString();
                LB_Destination.Text = msg.Destination.ToString();
            }
            if (NetMessage.NetObject.GetType() == typeof(HttpRequest))
            {
                HttpRequest Request = (HttpRequest)NetMessage.NetObject;
                LB_Type.Text = "HttpRequest";
                TB_Payload.Text = $"{Encoding.Default.GetString(msg.Body)}";
            }
            if (NetMessage.NetObject.GetType() == typeof(HttpResponse))
            {
                HttpResponse Request = (HttpResponse)NetMessage.NetObject;
                LB_Type.Text = "HttpResponse";
                TB_Payload.Text = $"{Request.HeaderString}{Environment.NewLine}{Environment.NewLine}{Request.BodyString}";

            }
            if (NetMessage.NetObject.GetType() == typeof(Packet))
            {
                Packet Request = (Packet)NetMessage.NetObject;
                LB_Type.Text = "Packet";
                TB_Payload.Text = $"{Encoding.Default.GetString(msg.Body)}";
            }


            //TB_Date.Text = msg.Da
            LB_Size.Text = msg.Body.Length.ToString() + " bytes";
            LB_Time.Text = msg.Time.ToShortDateString() + " " + msg.Time.ToLongTimeString();
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
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
    }
}
