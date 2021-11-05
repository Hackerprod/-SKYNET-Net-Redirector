namespace SKYNET
{
    partial class frmModules
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModules));
            this.P_Top = new System.Windows.Forms.Panel();
            this.PN_ModuleContainer = new System.Windows.Forms.Panel();
            this.PN_Info = new System.Windows.Forms.Panel();
            this.LB_Loading = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TB_Search = new SKYNET.Controls.SKYNET_TextBox();
            this.B_Close = new SKYNET.Controls.SKYNET_CloseBox();
            this.P_Top.SuspendLayout();
            this.PN_Info.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // P_Top
            // 
            this.P_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(40)))), ((int)(((byte)(52)))));
            this.P_Top.Controls.Add(this.B_Close);
            this.P_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.P_Top.ForeColor = System.Drawing.Color.White;
            this.P_Top.Location = new System.Drawing.Point(0, 0);
            this.P_Top.Name = "P_Top";
            this.P_Top.Size = new System.Drawing.Size(365, 26);
            this.P_Top.TabIndex = 6;
            // 
            // PN_ModuleContainer
            // 
            this.PN_ModuleContainer.AutoScroll = true;
            this.PN_ModuleContainer.Location = new System.Drawing.Point(12, 53);
            this.PN_ModuleContainer.Name = "PN_ModuleContainer";
            this.PN_ModuleContainer.Size = new System.Drawing.Size(339, 374);
            this.PN_ModuleContainer.TabIndex = 157;
            // 
            // PN_Info
            // 
            this.PN_Info.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(62)))));
            this.PN_Info.Controls.Add(this.LB_Loading);
            this.PN_Info.Location = new System.Drawing.Point(45, 171);
            this.PN_Info.Name = "PN_Info";
            this.PN_Info.Size = new System.Drawing.Size(272, 100);
            this.PN_Info.TabIndex = 0;
            // 
            // LB_Loading
            // 
            this.LB_Loading.AutoSize = true;
            this.LB_Loading.Location = new System.Drawing.Point(93, 45);
            this.LB_Loading.Name = "LB_Loading";
            this.LB_Loading.Size = new System.Drawing.Size(88, 13);
            this.LB_Loading.TabIndex = 0;
            this.LB_Loading.Text = "Loading Modules";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(62)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(339, 25);
            this.panel1.TabIndex = 158;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(231, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Address";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Module Name";
            // 
            // TB_Search
            // 
            this.TB_Search.ActivatedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(60)))), ((int)(((byte)(72)))));
            this.TB_Search.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(60)))), ((int)(((byte)(72)))));
            this.TB_Search.Color = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(60)))), ((int)(((byte)(72)))));
            this.TB_Search.IsPassword = false;
            this.TB_Search.Location = new System.Drawing.Point(12, 433);
            this.TB_Search.Logo = global::SKYNET.Properties.Resources._1__12_;
            this.TB_Search.LogoCursor = System.Windows.Forms.Cursors.Hand;
            this.TB_Search.Name = "TB_Search";
            this.TB_Search.ShowLogo = true;
            this.TB_Search.Size = new System.Drawing.Size(339, 35);
            this.TB_Search.TabIndex = 156;
            this.TB_Search.OnLogoClicked += new System.EventHandler(this.TB_SearchClicked);
            this.TB_Search.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TB_Search_KeyUp);
            // 
            // B_Close
            // 
            this.B_Close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(40)))), ((int)(((byte)(52)))));
            this.B_Close.Color = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(40)))), ((int)(((byte)(52)))));
            this.B_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.B_Close.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(62)))));
            this.B_Close.Location = new System.Drawing.Point(331, 0);
            this.B_Close.MaximumSize = new System.Drawing.Size(34, 26);
            this.B_Close.MinimumSize = new System.Drawing.Size(34, 26);
            this.B_Close.Name = "B_Close";
            this.B_Close.Size = new System.Drawing.Size(34, 26);
            this.B_Close.TabIndex = 0;
            this.B_Close.Clicked += new System.EventHandler(this.B_Close_Clicked);
            // 
            // frmModules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(40)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(365, 480);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PN_Info);
            this.Controls.Add(this.PN_ModuleContainer);
            this.Controls.Add(this.TB_Search);
            this.Controls.Add(this.P_Top);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmModules";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.Shown += new System.EventHandler(this.FrmModules_Shown);
            this.P_Top.ResumeLayout(false);
            this.PN_Info.ResumeLayout(false);
            this.PN_Info.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel P_Top;
        private Controls.SKYNET_CloseBox B_Close;
        private Controls.SKYNET_TextBox TB_Search;
        private System.Windows.Forms.Panel PN_ModuleContainer;
        private System.Windows.Forms.Panel PN_Info;
        private System.Windows.Forms.Label LB_Loading;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}