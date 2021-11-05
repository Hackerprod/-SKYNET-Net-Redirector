using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO.Pipes;
using Be.Windows.Forms;

namespace PacketEditor
{
    public partial class ReplayEditor : Form
    {
        ByteCollection bcBytes = new ByteCollection();
        NamedPipeClientStream pipeOut;
        int isocket = new int();

        public ReplayEditor(byte[] ReplayData, int socket, NamedPipeClientStream pipe)
        {
            InitializeComponent();
            
            DynamicByteProvider BytePro = new DynamicByteProvider(ReplayData);

            hexBox1.ByteProvider = BytePro;
            isocket = socket;
            pipeOut = pipe;
            txtSockID.Text = socket.ToString("X4");
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            isocket = 0;
            this.Close();
        }
        private void btnSend_Click(object sender, EventArgs e)
        {

        }
        private void frmReplayEditor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Close();
            }
        }
        private void hexBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Close();
            }
        }
        private void frmReplayEditor_Activated(object sender, EventArgs e)
        {
            if (this.TopMost == true)
            {
                this.Opacity = 1;
            }
        }
        private void frmReplayEditor_Deactivate(object sender, EventArgs e)
        {
            if (this.TopMost == true)
            {
                this.Opacity = .5;
            }
        }

        private void ReplayEditor_Load(object sender, EventArgs e)
        {

        }
    }
}
