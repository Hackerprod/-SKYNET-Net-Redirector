using SKYNET.Controls;

namespace SKYNET
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.P_Top = new System.Windows.Forms.Panel();
            this.B_Minimize = new SKYNET.Controls.SKYNET_MinimizeBox();
            this.B_Close = new SKYNET.Controls.SKYNET_CloseBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.BT_Redirection = new SKYNET_Button();
            this.panel15 = new System.Windows.Forms.Panel();
            this.BT_Detour = new SKYNET_Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.BT_Main = new SKYNET_Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.TabControl1 = new SKYNET.Controls.SKYNET_TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label18 = new System.Windows.Forms.Label();
            this.CH_AssociateFileExtension = new SKYNET.Controls.SKYNET_Check();
            this.label19 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.CH_WindowsMenuItem = new SKYNET.Controls.SKYNET_Check();
            this.label17 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this._notifyplayer = new System.Windows.Forms.Label();
            this.RunOnStartup = new SKYNET.Controls.SKYNET_Check();
            this.panel7 = new System.Windows.Forms.Panel();
            this.LB_Path = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.LoadPlugins = new SKYNET.Controls.SKYNET_Check();
            this.label8 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.InjectOnStart = new SKYNET.Controls.SKYNET_Check();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.DumpToConsole = new SKYNET.Controls.SKYNET_Check();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SkipCertificateChainVerification = new SKYNET.Controls.SKYNET_Check();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.DumpToFile = new SKYNET.Controls.SKYNET_Check();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.PortRedirection = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.IPRedirection = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.DNSRedirection = new System.Windows.Forms.TextBox();
            this.BT_Apply = new SKYNET_Button();
            this.P_Top.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel10.SuspendLayout();
            this.TabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel14.SuspendLayout();
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
            this.P_Top.Size = new System.Drawing.Size(347, 26);
            this.P_Top.TabIndex = 6;
            // 
            // B_Minimize
            // 
            this.B_Minimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(40)))), ((int)(((byte)(52)))));
            this.B_Minimize.Color = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(40)))), ((int)(((byte)(52)))));
            this.B_Minimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.B_Minimize.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(62)))));
            this.B_Minimize.Location = new System.Drawing.Point(279, 0);
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
            this.B_Close.Location = new System.Drawing.Point(313, 0);
            this.B_Close.MaximumSize = new System.Drawing.Size(34, 26);
            this.B_Close.MinimumSize = new System.Drawing.Size(34, 26);
            this.B_Close.Name = "B_Close";
            this.B_Close.Size = new System.Drawing.Size(34, 26);
            this.B_Close.TabIndex = 0;
            this.B_Close.Clicked += new System.EventHandler(this.B_Close_Clicked);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel11);
            this.panel1.Controls.Add(this.panel15);
            this.panel1.Controls.Add(this.panel10);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(347, 24);
            this.panel1.TabIndex = 7;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(40)))), ((int)(((byte)(52)))));
            this.panel11.Controls.Add(this.BT_Redirection);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel11.Location = new System.Drawing.Point(225, 0);
            this.panel11.Name = "panel11";
            this.panel11.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.panel11.Size = new System.Drawing.Size(105, 24);
            this.panel11.TabIndex = 156;
            // 
            // BT_Redirection
            // 
            this.BT_Redirection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(60)))), ((int)(((byte)(72)))));
            this.BT_Redirection.BackColorMouseOver = System.Drawing.Color.Empty;
            this.BT_Redirection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_Redirection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BT_Redirection.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BT_Redirection.ForeColor = System.Drawing.Color.White;
            this.BT_Redirection.ForeColorMouseOver = System.Drawing.Color.Empty;
            this.BT_Redirection.ImageAlignment = SKYNET_Button.ImgAlign.Left;
            this.BT_Redirection.ImageIcon = null;
            this.BT_Redirection.Location = new System.Drawing.Point(0, 0);
            this.BT_Redirection.Name = "BT_Redirection";
            this.BT_Redirection.Rounded = false;
            this.BT_Redirection.Size = new System.Drawing.Size(105, 23);
            this.BT_Redirection.Style = SKYNET_Button._Style.TextOnly;
            this.BT_Redirection.TabIndex = 157;
            this.BT_Redirection.Text = "REDIRECTION";
            this.BT_Redirection.Click += new System.EventHandler(this.Menu_Click);
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(40)))), ((int)(((byte)(52)))));
            this.panel15.Controls.Add(this.BT_Detour);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel15.Location = new System.Drawing.Point(120, 0);
            this.panel15.Name = "panel15";
            this.panel15.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.panel15.Size = new System.Drawing.Size(105, 24);
            this.panel15.TabIndex = 154;
            // 
            // BT_Detour
            // 
            this.BT_Detour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(60)))), ((int)(((byte)(72)))));
            this.BT_Detour.BackColorMouseOver = System.Drawing.Color.Empty;
            this.BT_Detour.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_Detour.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BT_Detour.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BT_Detour.ForeColor = System.Drawing.Color.White;
            this.BT_Detour.ForeColorMouseOver = System.Drawing.Color.Empty;
            this.BT_Detour.ImageAlignment = SKYNET_Button.ImgAlign.Left;
            this.BT_Detour.ImageIcon = null;
            this.BT_Detour.Location = new System.Drawing.Point(0, 0);
            this.BT_Detour.Name = "BT_Detour";
            this.BT_Detour.Rounded = false;
            this.BT_Detour.Size = new System.Drawing.Size(105, 23);
            this.BT_Detour.Style = SKYNET_Button._Style.TextOnly;
            this.BT_Detour.TabIndex = 156;
            this.BT_Detour.Text = "DETOUR";
            this.BT_Detour.Click += new System.EventHandler(this.Menu_Click);
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(195)))), ((int)(((byte)(252)))));
            this.panel10.Controls.Add(this.BT_Main);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel10.Location = new System.Drawing.Point(15, 0);
            this.panel10.Name = "panel10";
            this.panel10.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.panel10.Size = new System.Drawing.Size(105, 24);
            this.panel10.TabIndex = 153;
            // 
            // BT_Main
            // 
            this.BT_Main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(60)))), ((int)(((byte)(72)))));
            this.BT_Main.BackColorMouseOver = System.Drawing.Color.Empty;
            this.BT_Main.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BT_Main.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BT_Main.ForeColor = System.Drawing.Color.White;
            this.BT_Main.ForeColorMouseOver = System.Drawing.Color.Empty;
            this.BT_Main.ImageAlignment = SKYNET_Button.ImgAlign.Left;
            this.BT_Main.ImageIcon = null;
            this.BT_Main.Location = new System.Drawing.Point(0, 0);
            this.BT_Main.Name = "BT_Main";
            this.BT_Main.Rounded = false;
            this.BT_Main.Size = new System.Drawing.Size(105, 23);
            this.BT_Main.Style = SKYNET_Button._Style.TextOnly;
            this.BT_Main.TabIndex = 155;
            this.BT_Main.Text = "MAIN";
            this.BT_Main.Click += new System.EventHandler(this.Menu_Click);
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(15, 24);
            this.panel6.TabIndex = 146;
            // 
            // TabControl1
            // 
            this.TabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.TabControl1.Controls.Add(this.tabPage1);
            this.TabControl1.Controls.Add(this.tabPage2);
            this.TabControl1.Controls.Add(this.tabPage3);
            this.TabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.TabControl1.HideBorders = true;
            this.TabControl1.Location = new System.Drawing.Point(0, 50);
            this.TabControl1.Multiline = true;
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(347, 512);
            this.TabControl1.TabIndex = 155;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(40)))), ((int)(((byte)(52)))));
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Controls.Add(this.CH_AssociateFileExtension);
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Controls.Add(this.panel9);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.CH_WindowsMenuItem);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.panel8);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this._notifyplayer);
            this.tabPage1.Controls.Add(this.RunOnStartup);
            this.tabPage1.Controls.Add(this.panel7);
            this.tabPage1.Controls.Add(this.LB_Path);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.LoadPlugins);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.panel5);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.InjectOnStart);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(339, 486);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label18.Location = new System.Drawing.Point(28, 371);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(218, 15);
            this.label18.TabIndex = 149;
            this.label18.Text = "Associate with the .dump extension ";
            // 
            // CH_AssociateFileExtension
            // 
            this.CH_AssociateFileExtension.BackColor = System.Drawing.Color.Transparent;
            this.CH_AssociateFileExtension.Checked = true;
            this.CH_AssociateFileExtension.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CH_AssociateFileExtension.Location = new System.Drawing.Point(282, 366);
            this.CH_AssociateFileExtension.Name = "CH_AssociateFileExtension";
            this.CH_AssociateFileExtension.Size = new System.Drawing.Size(34, 25);
            this.CH_AssociateFileExtension.TabIndex = 150;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(135)))), ((int)(((byte)(150)))));
            this.label19.Location = new System.Drawing.Point(28, 393);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(252, 38);
            this.label19.TabIndex = 151;
            this.label19.Text = "Associate the .dump file type with the program to open dumps directly ";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.panel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(32)))));
            this.panel9.Location = new System.Drawing.Point(28, 360);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(285, 1);
            this.panel9.TabIndex = 152;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label16.Location = new System.Drawing.Point(28, 298);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(172, 15);
            this.label16.TabIndex = 145;
            this.label16.Text = "Add item to windows menu ";
            // 
            // CH_WindowsMenuItem
            // 
            this.CH_WindowsMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.CH_WindowsMenuItem.Checked = true;
            this.CH_WindowsMenuItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CH_WindowsMenuItem.Location = new System.Drawing.Point(282, 293);
            this.CH_WindowsMenuItem.Name = "CH_WindowsMenuItem";
            this.CH_WindowsMenuItem.Size = new System.Drawing.Size(34, 25);
            this.CH_WindowsMenuItem.TabIndex = 146;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(135)))), ((int)(((byte)(150)))));
            this.label17.Location = new System.Drawing.Point(28, 320);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(252, 38);
            this.label17.TabIndex = 147;
            this.label17.Text = "Add item to windows menu to directly open applications ";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.panel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(32)))));
            this.panel8.Location = new System.Drawing.Point(28, 287);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(285, 1);
            this.panel8.TabIndex = 148;
            // 
            // label4
            // 
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(135)))), ((int)(((byte)(150)))));
            this.label4.Location = new System.Drawing.Point(28, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(252, 19);
            this.label4.TabIndex = 136;
            this.label4.Text = "Click to select executable path";
            this.label4.Click += new System.EventHandler(this.Path_Click);
            // 
            // _notifyplayer
            // 
            this._notifyplayer.AutoSize = true;
            this._notifyplayer.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this._notifyplayer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this._notifyplayer.Location = new System.Drawing.Point(28, 123);
            this._notifyplayer.Name = "_notifyplayer";
            this._notifyplayer.Size = new System.Drawing.Size(94, 15);
            this._notifyplayer.TabIndex = 100;
            this._notifyplayer.Text = "Run on startup";
            // 
            // RunOnStartup
            // 
            this.RunOnStartup.BackColor = System.Drawing.Color.Transparent;
            this.RunOnStartup.Checked = false;
            this.RunOnStartup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RunOnStartup.Location = new System.Drawing.Point(282, 118);
            this.RunOnStartup.Name = "RunOnStartup";
            this.RunOnStartup.Size = new System.Drawing.Size(34, 25);
            this.RunOnStartup.TabIndex = 101;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.panel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(32)))));
            this.panel7.Location = new System.Drawing.Point(28, 170);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(285, 1);
            this.panel7.TabIndex = 102;
            // 
            // Path
            // 
            this.LB_Path.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LB_Path.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.LB_Path.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.LB_Path.Location = new System.Drawing.Point(28, 36);
            this.LB_Path.Name = "Path";
            this.LB_Path.Size = new System.Drawing.Size(290, 15);
            this.LB_Path.TabIndex = 118;
            this.LB_Path.Text = "Executable Path";
            this.LB_Path.Click += new System.EventHandler(this.Path_Click);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(135)))), ((int)(((byte)(150)))));
            this.label7.Location = new System.Drawing.Point(28, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(252, 19);
            this.label7.TabIndex = 119;
            this.label7.Text = "Open Net Redirector when windows start  ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label9.Location = new System.Drawing.Point(28, 239);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(132, 15);
            this.label9.TabIndex = 120;
            this.label9.Text = "Load external plugins";
            // 
            // LoadPlugins
            // 
            this.LoadPlugins.BackColor = System.Drawing.Color.Transparent;
            this.LoadPlugins.Checked = true;
            this.LoadPlugins.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoadPlugins.Location = new System.Drawing.Point(282, 234);
            this.LoadPlugins.Name = "LoadPlugins";
            this.LoadPlugins.Size = new System.Drawing.Size(34, 25);
            this.LoadPlugins.TabIndex = 121;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(135)))), ((int)(((byte)(150)))));
            this.label8.Location = new System.Drawing.Point(28, 261);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(252, 19);
            this.label8.TabIndex = 123;
            this.label8.Text = "Load custom plugins stored in Plugins folder";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(195)))), ((int)(((byte)(252)))));
            this.label15.Location = new System.Drawing.Point(28, 99);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 15);
            this.label15.TabIndex = 144;
            this.label15.Text = "Application";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(195)))), ((int)(((byte)(252)))));
            this.label13.Location = new System.Drawing.Point(28, 14);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 15);
            this.label13.TabIndex = 142;
            this.label13.Text = "Executable Path";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(30)))), ((int)(((byte)(39)))));
            this.panel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(32)))));
            this.panel5.Location = new System.Drawing.Point(28, 77);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(285, 10);
            this.panel5.TabIndex = 137;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(135)))), ((int)(((byte)(150)))));
            this.label2.Location = new System.Drawing.Point(28, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(252, 19);
            this.label2.TabIndex = 135;
            this.label2.Text = "Inject automatically when Net Redirector start";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label12.Location = new System.Drawing.Point(28, 181);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 15);
            this.label12.TabIndex = 132;
            this.label12.Text = "Inject on start";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.panel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(32)))));
            this.panel3.Location = new System.Drawing.Point(28, 228);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(285, 1);
            this.panel3.TabIndex = 134;
            // 
            // InjectOnStart
            // 
            this.InjectOnStart.BackColor = System.Drawing.Color.Transparent;
            this.InjectOnStart.Checked = false;
            this.InjectOnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.InjectOnStart.Location = new System.Drawing.Point(282, 176);
            this.InjectOnStart.Name = "InjectOnStart";
            this.InjectOnStart.Size = new System.Drawing.Size(34, 25);
            this.InjectOnStart.TabIndex = 133;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(40)))), ((int)(((byte)(52)))));
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.DumpToConsole);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.SkipCertificateChainVerification);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.DumpToFile);
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(339, 486);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label10.Location = new System.Drawing.Point(28, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(137, 15);
            this.label10.TabIndex = 146;
            this.label10.Text = "Show traffic in console";
            // 
            // DumpToConsole
            // 
            this.DumpToConsole.BackColor = System.Drawing.Color.Transparent;
            this.DumpToConsole.Checked = true;
            this.DumpToConsole.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DumpToConsole.Location = new System.Drawing.Point(282, 28);
            this.DumpToConsole.Name = "DumpToConsole";
            this.DumpToConsole.Size = new System.Drawing.Size(34, 25);
            this.DumpToConsole.TabIndex = 147;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(32)))));
            this.panel2.Location = new System.Drawing.Point(28, 80);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(285, 1);
            this.panel2.TabIndex = 148;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(135)))), ((int)(((byte)(150)))));
            this.label5.Location = new System.Drawing.Point(28, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(252, 38);
            this.label5.TabIndex = 156;
            this.label5.Text = "In some cases the https call accepts self-signed certificates";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(135)))), ((int)(((byte)(150)))));
            this.label1.Location = new System.Drawing.Point(28, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 19);
            this.label1.TabIndex = 149;
            this.label1.Text = "Show received and sent packets in console";
            // 
            // SkipCertificateChainVerification
            // 
            this.SkipCertificateChainVerification.BackColor = System.Drawing.Color.Transparent;
            this.SkipCertificateChainVerification.Checked = false;
            this.SkipCertificateChainVerification.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SkipCertificateChainVerification.Location = new System.Drawing.Point(282, 148);
            this.SkipCertificateChainVerification.Name = "SkipCertificateChainVerification";
            this.SkipCertificateChainVerification.Size = new System.Drawing.Size(34, 25);
            this.SkipCertificateChainVerification.TabIndex = 155;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label11.Location = new System.Drawing.Point(28, 91);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(145, 15);
            this.label11.TabIndex = 150;
            this.label11.Text = "Save traffic in dump file";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label6.Location = new System.Drawing.Point(28, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(195, 15);
            this.label6.TabIndex = 154;
            this.label6.Text = "Skip certificate chain verification";
            // 
            // DumpToFile
            // 
            this.DumpToFile.BackColor = System.Drawing.Color.Transparent;
            this.DumpToFile.Checked = false;
            this.DumpToFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DumpToFile.Location = new System.Drawing.Point(282, 86);
            this.DumpToFile.Name = "DumpToFile";
            this.DumpToFile.Size = new System.Drawing.Size(34, 25);
            this.DumpToFile.TabIndex = 151;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.panel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(32)))));
            this.panel4.Location = new System.Drawing.Point(28, 141);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(285, 1);
            this.panel4.TabIndex = 152;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(135)))), ((int)(((byte)(150)))));
            this.label3.Location = new System.Drawing.Point(28, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(252, 19);
            this.label3.TabIndex = 153;
            this.label3.Text = "Save received and sent packets in dump file";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(40)))), ((int)(((byte)(52)))));
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.panel12);
            this.tabPage3.Controls.Add(this.label20);
            this.tabPage3.Controls.Add(this.panel13);
            this.tabPage3.Controls.Add(this.label21);
            this.tabPage3.Controls.Add(this.panel14);
            this.tabPage3.Location = new System.Drawing.Point(4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(339, 486);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label14.Location = new System.Drawing.Point(28, 14);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(103, 15);
            this.label14.TabIndex = 154;
            this.label14.Text = "DNS Redirection";
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(62)))));
            this.panel12.Controls.Add(this.PortRedirection);
            this.panel12.Location = new System.Drawing.Point(31, 353);
            this.panel12.Name = "panel12";
            this.panel12.Padding = new System.Windows.Forms.Padding(5);
            this.panel12.Size = new System.Drawing.Size(278, 130);
            this.panel12.TabIndex = 159;
            // 
            // PortRedirection
            // 
            this.PortRedirection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(62)))));
            this.PortRedirection.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PortRedirection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PortRedirection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(135)))), ((int)(((byte)(150)))));
            this.PortRedirection.Location = new System.Drawing.Point(5, 5);
            this.PortRedirection.Multiline = true;
            this.PortRedirection.Name = "PortRedirection";
            this.PortRedirection.Size = new System.Drawing.Size(268, 120);
            this.PortRedirection.TabIndex = 150;
            this.PortRedirection.TextChanged += new System.EventHandler(this.PortRedirection_TextChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label20.Location = new System.Drawing.Point(28, 172);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(88, 15);
            this.label20.TabIndex = 155;
            this.label20.Text = "IP Redirection";
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(62)))));
            this.panel13.Controls.Add(this.IPRedirection);
            this.panel13.Location = new System.Drawing.Point(31, 192);
            this.panel13.Name = "panel13";
            this.panel13.Padding = new System.Windows.Forms.Padding(5);
            this.panel13.Size = new System.Drawing.Size(278, 130);
            this.panel13.TabIndex = 158;
            // 
            // IPRedirection
            // 
            this.IPRedirection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(62)))));
            this.IPRedirection.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.IPRedirection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IPRedirection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(135)))), ((int)(((byte)(150)))));
            this.IPRedirection.Location = new System.Drawing.Point(5, 5);
            this.IPRedirection.Multiline = true;
            this.IPRedirection.Name = "IPRedirection";
            this.IPRedirection.Size = new System.Drawing.Size(268, 120);
            this.IPRedirection.TabIndex = 150;
            this.IPRedirection.TextChanged += new System.EventHandler(this.IPRedirection_TextChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label21.Location = new System.Drawing.Point(28, 333);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(101, 15);
            this.label21.TabIndex = 156;
            this.label21.Text = "Port Redirection";
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(62)))));
            this.panel14.Controls.Add(this.DNSRedirection);
            this.panel14.Location = new System.Drawing.Point(31, 34);
            this.panel14.Name = "panel14";
            this.panel14.Padding = new System.Windows.Forms.Padding(5);
            this.panel14.Size = new System.Drawing.Size(278, 130);
            this.panel14.TabIndex = 157;
            // 
            // DNSRedirection
            // 
            this.DNSRedirection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(62)))));
            this.DNSRedirection.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DNSRedirection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DNSRedirection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(135)))), ((int)(((byte)(150)))));
            this.DNSRedirection.Location = new System.Drawing.Point(5, 5);
            this.DNSRedirection.Multiline = true;
            this.DNSRedirection.Name = "DNSRedirection";
            this.DNSRedirection.Size = new System.Drawing.Size(268, 120);
            this.DNSRedirection.TabIndex = 150;
            this.DNSRedirection.TextChanged += new System.EventHandler(this.DNSRedirection_TextChanged);
            // 
            // BT_Apply
            // 
            this.BT_Apply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(60)))), ((int)(((byte)(72)))));
            this.BT_Apply.BackColorMouseOver = System.Drawing.Color.Empty;
            this.BT_Apply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_Apply.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BT_Apply.ForeColor = System.Drawing.Color.White;
            this.BT_Apply.ForeColorMouseOver = System.Drawing.Color.Empty;
            this.BT_Apply.ImageAlignment = SKYNET_Button.ImgAlign.Left;
            this.BT_Apply.ImageIcon = null;
            this.BT_Apply.Location = new System.Drawing.Point(129, 566);
            this.BT_Apply.Name = "BT_Apply";
            this.BT_Apply.Rounded = false;
            this.BT_Apply.Size = new System.Drawing.Size(100, 27);
            this.BT_Apply.Style = SKYNET_Button._Style.TextOnly;
            this.BT_Apply.TabIndex = 154;
            this.BT_Apply.Text = "Apply Changes";
            this.BT_Apply.Click += new System.EventHandler(this.BT_Apply_Click);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(40)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(347, 608);
            this.Controls.Add(this.TabControl1);
            this.Controls.Add(this.BT_Apply);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.P_Top);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.P_Top.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.TabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel P_Top;
        private Controls.SKYNET_MinimizeBox B_Minimize;
        private Controls.SKYNET_CloseBox B_Close;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel7;
        private Controls.SKYNET_Check RunOnStartup;
        private System.Windows.Forms.Label _notifyplayer;
        private System.Windows.Forms.Label LB_Path;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private Controls.SKYNET_Check LoadPlugins;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private Controls.SKYNET_Check InjectOnStart;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private SKYNET_Button BT_Apply;
        private Controls.SKYNET_TabControl TabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel6;
        private SKYNET_Button BT_Main;
        private SKYNET_Button BT_Redirection;
        private SKYNET_Button BT_Detour;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.TextBox PortRedirection;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.TextBox IPRedirection;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.TextBox DNSRedirection;
        private System.Windows.Forms.Label label10;
        private Controls.SKYNET_Check DumpToConsole;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private Controls.SKYNET_Check SkipCertificateChainVerification;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private Controls.SKYNET_Check DumpToFile;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label16;
        private Controls.SKYNET_Check CH_WindowsMenuItem;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label18;
        private Controls.SKYNET_Check CH_AssociateFileExtension;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Panel panel11;
    }
}