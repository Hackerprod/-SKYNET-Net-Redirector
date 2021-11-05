using SKYNET.Controls;

namespace SKYNET
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.P_Top = new System.Windows.Forms.Panel();
            this.B_Minimize = new SKYNET.Controls.SKYNET_MinimizeBox();
            this.B_Close = new SKYNET.Controls.SKYNET_CloseBox();
            this.ShadowBox = new SKYNET.SKYNET_ShadowBox();
            this.BT_Menu = new SKYNET_Button();
            this.BT_Retry = new SKYNET_Button();
            this.Logger = new SKYNET.Controls.SKYNET_WebLogger();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.etertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ertertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ukgfdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CM_Menu = new SKYNET_ContextMenuStrip();
            this.M_Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.M_ShowModules = new System.Windows.Forms.ToolStripMenuItem();
            this.M_Dumps = new System.Windows.Forms.ToolStripMenuItem();
            this.AttachToProcessMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoggerMenu = new SKYNET_ContextMenuStrip();
            this.ToTopMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToButtomMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.P_Top.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.CM_Menu.SuspendLayout();
            this.LoggerMenu.SuspendLayout();
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
            this.P_Top.Size = new System.Drawing.Size(800, 26);
            this.P_Top.TabIndex = 6;
            // 
            // B_Minimize
            // 
            this.B_Minimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(40)))), ((int)(((byte)(52)))));
            this.B_Minimize.Color = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(40)))), ((int)(((byte)(52)))));
            this.B_Minimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.B_Minimize.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(62)))));
            this.B_Minimize.Location = new System.Drawing.Point(732, 0);
            this.B_Minimize.MaximumSize = new System.Drawing.Size(34, 26);
            this.B_Minimize.MinimumSize = new System.Drawing.Size(34, 26);
            this.B_Minimize.Name = "B_Minimize";
            this.B_Minimize.Size = new System.Drawing.Size(34, 26);
            this.B_Minimize.TabIndex = 1;
            this.B_Minimize.Clicked += new System.EventHandler(this.B_Minimize_Clicked);
            // 
            // B_Close
            // 
            this.B_Close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(40)))), ((int)(((byte)(52)))));
            this.B_Close.Color = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(40)))), ((int)(((byte)(52)))));
            this.B_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.B_Close.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(62)))));
            this.B_Close.Location = new System.Drawing.Point(766, 0);
            this.B_Close.MaximumSize = new System.Drawing.Size(34, 26);
            this.B_Close.MinimumSize = new System.Drawing.Size(34, 26);
            this.B_Close.Name = "B_Close";
            this.B_Close.Size = new System.Drawing.Size(34, 26);
            this.B_Close.TabIndex = 0;
            this.B_Close.Clicked += new System.EventHandler(this.B_Close_Clicked);
            // 
            // ShadowBox
            // 
            this.ShadowBox.BackColor = System.Drawing.Color.Transparent;
            this.ShadowBox.Color = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(26)))), ((int)(((byte)(37)))));
            this.ShadowBox.Location = new System.Drawing.Point(0, 0);
            this.ShadowBox.Name = "ShadowBox";
            this.ShadowBox.Opacity = 80;
            this.ShadowBox.Size = new System.Drawing.Size(0, 0);
            this.ShadowBox.TabIndex = 114;
            // 
            // BT_Menu
            // 
            this.BT_Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(40)))), ((int)(((byte)(52)))));
            this.BT_Menu.BackColorMouseOver = System.Drawing.Color.Empty;
            this.BT_Menu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_Menu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BT_Menu.ForeColor = System.Drawing.Color.White;
            this.BT_Menu.ForeColorMouseOver = System.Drawing.Color.Empty;
            this.BT_Menu.ImageAlignment = SKYNET_Button.ImgAlign.Left;
            this.BT_Menu.ImageIcon = null;
            this.BT_Menu.Location = new System.Drawing.Point(748, 438);
            this.BT_Menu.MenuMode = true;
            this.BT_Menu.Name = "BT_Menu";
            this.BT_Menu.Rounded = false;
            this.BT_Menu.Size = new System.Drawing.Size(40, 25);
            this.BT_Menu.Style = SKYNET_Button._Style.TextOnly;
            this.BT_Menu.TabIndex = 113;
            this.BT_Menu.Click += new System.EventHandler(this.BT_Menu_Click);
            // 
            // BT_Retry
            // 
            this.BT_Retry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(60)))), ((int)(((byte)(72)))));
            this.BT_Retry.BackColorMouseOver = System.Drawing.Color.Empty;
            this.BT_Retry.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_Retry.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BT_Retry.ForeColor = System.Drawing.Color.White;
            this.BT_Retry.ForeColorMouseOver = System.Drawing.Color.Empty;
            this.BT_Retry.ImageAlignment = SKYNET_Button.ImgAlign.Left;
            this.BT_Retry.ImageIcon = null;
            this.BT_Retry.Location = new System.Drawing.Point(634, 438);
            this.BT_Retry.MenuMode = false;
            this.BT_Retry.Name = "BT_Retry";
            this.BT_Retry.Rounded = false;
            this.BT_Retry.Size = new System.Drawing.Size(100, 25);
            this.BT_Retry.Style = SKYNET_Button._Style.TextOnly;
            this.BT_Retry.TabIndex = 112;
            this.BT_Retry.Text = "Hook";
            this.BT_Retry.Visible = false;
            this.BT_Retry.Click += new System.EventHandler(this.BT_Retry_Click);
            // 
            // Logger
            // 
            this.Logger.AutoScrollLines = true;
            this.Logger.ContextMenuStrip = this.contextMenuStrip1;
            this.Logger.Location = new System.Drawing.Point(5, 26);
            this.Logger.LoggerBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(19)))), ((int)(((byte)(28)))));
            this.Logger.Name = "Logger";
            this.Logger.ScrollColors = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(19)))), ((int)(((byte)(28)))));
            this.Logger.Size = new System.Drawing.Size(790, 410);
            this.Logger.TabIndex = 7;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.etertToolStripMenuItem,
            this.ertertToolStripMenuItem,
            this.ukgfdToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(106, 70);
            // 
            // etertToolStripMenuItem
            // 
            this.etertToolStripMenuItem.Name = "etertToolStripMenuItem";
            this.etertToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.etertToolStripMenuItem.Text = "etert";
            // 
            // ertertToolStripMenuItem
            // 
            this.ertertToolStripMenuItem.Name = "ertertToolStripMenuItem";
            this.ertertToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.ertertToolStripMenuItem.Text = "ertert";
            // 
            // ukgfdToolStripMenuItem
            // 
            this.ukgfdToolStripMenuItem.Name = "ukgfdToolStripMenuItem";
            this.ukgfdToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.ukgfdToolStripMenuItem.Text = "ukgfd";
            // 
            // CM_Menu
            // 
            this.CM_Menu.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.CM_Menu.ForeColor = System.Drawing.Color.White;
            this.CM_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.M_Settings,
            this.M_ShowModules,
            this.M_Dumps,
            this.AttachToProcessMenuItem});
            this.CM_Menu.Name = "CM_Menu";
            this.CM_Menu.ShowImageMargin = false;
            this.CM_Menu.Size = new System.Drawing.Size(226, 114);
            this.CM_Menu.Opening += new System.ComponentModel.CancelEventHandler(this.CM_Menu_Opening);
            // 
            // M_Settings
            // 
            this.M_Settings.Name = "M_Settings";
            this.M_Settings.Size = new System.Drawing.Size(225, 22);
            this.M_Settings.Text = "Settings";
            this.M_Settings.Click += new System.EventHandler(this.M_Settings_Click);
            // 
            // M_ShowModules
            // 
            this.M_ShowModules.Name = "M_ShowModules";
            this.M_ShowModules.Size = new System.Drawing.Size(225, 22);
            this.M_ShowModules.Text = "Show Modules in injected process";
            this.M_ShowModules.Click += new System.EventHandler(this.M_ShowModules_Click);
            // 
            // M_Dumps
            // 
            this.M_Dumps.Name = "M_Dumps";
            this.M_Dumps.Size = new System.Drawing.Size(225, 22);
            this.M_Dumps.Text = "Show Dumps";
            this.M_Dumps.Click += new System.EventHandler(this.M_Dumps_Click);
            // 
            // AttachToProcessMenuItem
            // 
            this.AttachToProcessMenuItem.Name = "AttachToProcessMenuItem";
            this.AttachToProcessMenuItem.Size = new System.Drawing.Size(225, 22);
            this.AttachToProcessMenuItem.Text = "Attach to process";
            this.AttachToProcessMenuItem.Click += new System.EventHandler(this.AttachToProcessMenuItem_Click);
            // 
            // LoggerMenu
            // 
            this.LoggerMenu.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.LoggerMenu.ForeColor = System.Drawing.Color.White;
            this.LoggerMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToTopMenuItem,
            this.ToButtomMenuItem,
            this.ClearMenuItem});
            this.LoggerMenu.Name = "CM_Menu";
            this.LoggerMenu.ShowImageMargin = false;
            this.LoggerMenu.Size = new System.Drawing.Size(128, 70);
            // 
            // ToTopMenuItem
            // 
            this.ToTopMenuItem.Name = "ToTopMenuItem";
            this.ToTopMenuItem.Size = new System.Drawing.Size(127, 22);
            this.ToTopMenuItem.Text = "Go to Top";
            this.ToTopMenuItem.Click += new System.EventHandler(this.ToTopMenuItem_Click);
            // 
            // ToButtomMenuItem
            // 
            this.ToButtomMenuItem.Name = "ToButtomMenuItem";
            this.ToButtomMenuItem.Size = new System.Drawing.Size(127, 22);
            this.ToButtomMenuItem.Text = "Go to Buttom";
            this.ToButtomMenuItem.Click += new System.EventHandler(this.ToButtomMenuItem_Click);
            // 
            // ClearMenuItem
            // 
            this.ClearMenuItem.Name = "ClearMenuItem";
            this.ClearMenuItem.Size = new System.Drawing.Size(127, 22);
            this.ClearMenuItem.Text = "Clear messages";
            this.ClearMenuItem.Click += new System.EventHandler(this.ClearMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(40)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(800, 479);
            this.Controls.Add(this.ShadowBox);
            this.Controls.Add(this.BT_Menu);
            this.Controls.Add(this.BT_Retry);
            this.Controls.Add(this.Logger);
            this.Controls.Add(this.P_Top);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            this.P_Top.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.CM_Menu.ResumeLayout(false);
            this.LoggerMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel P_Top;
        private Controls.SKYNET_MinimizeBox B_Minimize;
        private Controls.SKYNET_CloseBox B_Close;
        public Controls.SKYNET_WebLogger Logger;
        private SKYNET_Button BT_Retry;
        private SKYNET_Button BT_Menu;
        private SKYNET_ContextMenuStrip CM_Menu;
        private System.Windows.Forms.ToolStripMenuItem M_Settings;
        private System.Windows.Forms.ToolStripMenuItem M_ShowModules;
        private SKYNET_ShadowBox ShadowBox;
        private System.Windows.Forms.ToolStripMenuItem M_Dumps;
        private SKYNET_ContextMenuStrip LoggerMenu;
        private System.Windows.Forms.ToolStripMenuItem ClearMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToTopMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToButtomMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem etertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ertertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ukgfdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AttachToProcessMenuItem;
    }
}