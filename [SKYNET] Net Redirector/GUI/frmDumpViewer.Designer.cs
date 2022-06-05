namespace SKYNET
{
    partial class frmDumpViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDumpViewer));
            this.P_Top = new System.Windows.Forms.Panel();
            this.B_Minimize = new SKYNET.Controls.SKYNET_MinimizeBox();
            this.B_Close = new SKYNET.Controls.SKYNET_CloseBox();
            this.label13 = new System.Windows.Forms.Label();
            this._notifyplayer = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LB_Protocol = new System.Windows.Forms.Label();
            this.LB_Size = new System.Windows.Forms.Label();
            this.LB_Destination = new System.Windows.Forms.Label();
            this.LB_Source = new System.Windows.Forms.Label();
            this.LB_Time = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.hexBox1 = new Be.Windows.Forms.HexBox();
            this.LB_Type = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TB_Payload = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.P_Top.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // P_Top
            // 
            this.P_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(40)))), ((int)(((byte)(52)))));
            this.P_Top.Controls.Add(this.B_Minimize);
            this.P_Top.Controls.Add(this.B_Close);
            this.P_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.P_Top.ForeColor = System.Drawing.Color.White;
            this.P_Top.Location = new System.Drawing.Point(0, 0);
            this.P_Top.Name = "P_Top";
            this.P_Top.Size = new System.Drawing.Size(911, 26);
            this.P_Top.TabIndex = 6;
            // 
            // B_Minimize
            // 
            this.B_Minimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(40)))), ((int)(((byte)(52)))));
            this.B_Minimize.Color = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(40)))), ((int)(((byte)(52)))));
            this.B_Minimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.B_Minimize.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(62)))));
            this.B_Minimize.Location = new System.Drawing.Point(843, 0);
            this.B_Minimize.MaximumSize = new System.Drawing.Size(34, 26);
            this.B_Minimize.MinimumSize = new System.Drawing.Size(34, 26);
            this.B_Minimize.Name = "B_Minimize";
            this.B_Minimize.Size = new System.Drawing.Size(34, 26);
            this.B_Minimize.TabIndex = 1;
            // 
            // B_Close
            // 
            this.B_Close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(40)))), ((int)(((byte)(52)))));
            this.B_Close.Color = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(40)))), ((int)(((byte)(52)))));
            this.B_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.B_Close.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(62)))));
            this.B_Close.Location = new System.Drawing.Point(877, 0);
            this.B_Close.MaximumSize = new System.Drawing.Size(34, 26);
            this.B_Close.MinimumSize = new System.Drawing.Size(34, 26);
            this.B_Close.Name = "B_Close";
            this.B_Close.Size = new System.Drawing.Size(34, 26);
            this.B_Close.TabIndex = 0;
            this.B_Close.Clicked += new System.EventHandler(this.B_Close_Clicked);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(195)))), ((int)(((byte)(252)))));
            this.label13.Location = new System.Drawing.Point(12, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 15);
            this.label13.TabIndex = 143;
            this.label13.Text = "Message info.";
            // 
            // _notifyplayer
            // 
            this._notifyplayer.AutoSize = true;
            this._notifyplayer.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this._notifyplayer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this._notifyplayer.Location = new System.Drawing.Point(12, 46);
            this._notifyplayer.Name = "_notifyplayer";
            this._notifyplayer.Size = new System.Drawing.Size(46, 15);
            this._notifyplayer.TabIndex = 144;
            this._notifyplayer.Text = "Source";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label1.Location = new System.Drawing.Point(12, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 145;
            this.label1.Text = "Destination";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label2.Location = new System.Drawing.Point(12, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 15);
            this.label2.TabIndex = 146;
            this.label2.Text = "Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label4.Location = new System.Drawing.Point(248, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 15);
            this.label4.TabIndex = 148;
            this.label4.Text = "Protocol";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label5.Location = new System.Drawing.Point(248, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 15);
            this.label5.TabIndex = 147;
            this.label5.Text = "Size";
            // 
            // LB_Protocol
            // 
            this.LB_Protocol.AutoSize = true;
            this.LB_Protocol.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.LB_Protocol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(135)))), ((int)(((byte)(150)))));
            this.LB_Protocol.Location = new System.Drawing.Point(314, 64);
            this.LB_Protocol.Name = "LB_Protocol";
            this.LB_Protocol.Size = new System.Drawing.Size(29, 15);
            this.LB_Protocol.TabIndex = 149;
            this.LB_Protocol.Text = "TCP";
            // 
            // LB_Size
            // 
            this.LB_Size.AutoSize = true;
            this.LB_Size.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.LB_Size.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(135)))), ((int)(((byte)(150)))));
            this.LB_Size.Location = new System.Drawing.Point(314, 46);
            this.LB_Size.Name = "LB_Size";
            this.LB_Size.Size = new System.Drawing.Size(50, 15);
            this.LB_Size.TabIndex = 150;
            this.LB_Size.Text = "0 bytes";
            // 
            // LB_Destination
            // 
            this.LB_Destination.AutoSize = true;
            this.LB_Destination.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.LB_Destination.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(135)))), ((int)(((byte)(150)))));
            this.LB_Destination.Location = new System.Drawing.Point(102, 64);
            this.LB_Destination.Name = "LB_Destination";
            this.LB_Destination.Size = new System.Drawing.Size(75, 15);
            this.LB_Destination.TabIndex = 151;
            this.LB_Destination.Text = "127.0.0.1:80";
            // 
            // LB_Source
            // 
            this.LB_Source.AutoSize = true;
            this.LB_Source.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.LB_Source.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(135)))), ((int)(((byte)(150)))));
            this.LB_Source.Location = new System.Drawing.Point(102, 46);
            this.LB_Source.Name = "LB_Source";
            this.LB_Source.Size = new System.Drawing.Size(89, 15);
            this.LB_Source.TabIndex = 152;
            this.LB_Source.Text = "127.0.0.1:6582";
            // 
            // LB_Time
            // 
            this.LB_Time.AutoSize = true;
            this.LB_Time.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.LB_Time.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(135)))), ((int)(((byte)(150)))));
            this.LB_Time.Location = new System.Drawing.Point(102, 82);
            this.LB_Time.Name = "LB_Time";
            this.LB_Time.Size = new System.Drawing.Size(108, 15);
            this.LB_Time.TabIndex = 153;
            this.LB_Time.Text = "04-10-2021 11:03";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(60)))), ((int)(((byte)(72)))));
            this.panel1.Controls.Add(this.hexBox1);
            this.panel1.Location = new System.Drawing.Point(15, 120);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(581, 337);
            this.panel1.TabIndex = 155;
            // 
            // hexBox1
            // 
            this.hexBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hexBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(60)))), ((int)(((byte)(72)))));
            this.hexBox1.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hexBox1.LineInfoForeColor = System.Drawing.Color.Empty;
            this.hexBox1.Location = new System.Drawing.Point(5, 7);
            this.hexBox1.Name = "hexBox1";
            this.hexBox1.SelectionBackColor = System.Drawing.Color.FromArgb(0, 118, 214);
            this.hexBox1.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hexBox1.Size = new System.Drawing.Size(571, 323);
            this.hexBox1.StringViewVisible = true;
            this.hexBox1.TabIndex = 2;
            this.hexBox1.UseFixedBytesPerLine = true;
            // 
            // LB_Type
            // 
            this.LB_Type.AutoSize = true;
            this.LB_Type.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.LB_Type.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(135)))), ((int)(((byte)(150)))));
            this.LB_Type.Location = new System.Drawing.Point(314, 82);
            this.LB_Type.Name = "LB_Type";
            this.LB_Type.Size = new System.Drawing.Size(60, 15);
            this.LB_Type.TabIndex = 157;
            this.LB_Type.Text = "Message";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label7.Location = new System.Drawing.Point(248, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 15);
            this.label7.TabIndex = 156;
            this.label7.Text = "Type";
            // 
            // TB_Payload
            // 
            this.TB_Payload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(60)))), ((int)(((byte)(72)))));
            this.TB_Payload.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_Payload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TB_Payload.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_Payload.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.TB_Payload.Location = new System.Drawing.Point(2, 2);
            this.TB_Payload.Multiline = true;
            this.TB_Payload.Name = "TB_Payload";
            this.TB_Payload.Size = new System.Drawing.Size(284, 333);
            this.TB_Payload.TabIndex = 158;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(60)))), ((int)(((byte)(72)))));
            this.panel2.Controls.Add(this.TB_Payload);
            this.panel2.Location = new System.Drawing.Point(602, 120);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(2);
            this.panel2.Size = new System.Drawing.Size(288, 337);
            this.panel2.TabIndex = 159;
            // 
            // frmDump
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(40)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(911, 480);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.LB_Type);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LB_Time);
            this.Controls.Add(this.LB_Source);
            this.Controls.Add(this.LB_Destination);
            this.Controls.Add(this.LB_Size);
            this.Controls.Add(this.LB_Protocol);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._notifyplayer);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.P_Top);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDump";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            this.P_Top.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel P_Top;
        private Controls.SKYNET_MinimizeBox B_Minimize;
        private Controls.SKYNET_CloseBox B_Close;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label _notifyplayer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LB_Protocol;
        private System.Windows.Forms.Label LB_Size;
        private System.Windows.Forms.Label LB_Destination;
        private System.Windows.Forms.Label LB_Source;
        private System.Windows.Forms.Label LB_Time;
        private System.Windows.Forms.Panel panel1;
        private Be.Windows.Forms.HexBox hexBox1;
        private System.Windows.Forms.Label LB_Type;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TB_Payload;
        private System.Windows.Forms.Panel panel2;
    }
}