namespace SKYNET.GUI.Controls
{
    partial class ModuleControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.LB_ModuleAddress = new System.Windows.Forms.Label();
            this.LB_ModuleName = new System.Windows.Forms.Label();
            this.PB_ModuleIcon = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_ModuleIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(40)))), ((int)(((byte)(52)))));
            this.panel1.Controls.Add(this.LB_ModuleAddress);
            this.panel1.Controls.Add(this.LB_ModuleName);
            this.panel1.Controls.Add(this.PB_ModuleIcon);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 30);
            this.panel1.TabIndex = 2;
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Controls_MouseClick);
            this.panel1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.PB_ModuleIcon_MouseDoubleClick);
            this.panel1.MouseLeave += new System.EventHandler(this.Controls_MouseLeave);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Controls_MouseMove);
            // 
            // LB_ModuleAddress
            // 
            this.LB_ModuleAddress.AutoSize = true;
            this.LB_ModuleAddress.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LB_ModuleAddress.ForeColor = System.Drawing.SystemColors.Control;
            this.LB_ModuleAddress.Location = new System.Drawing.Point(230, 7);
            this.LB_ModuleAddress.Name = "LB_ModuleAddress";
            this.LB_ModuleAddress.Size = new System.Drawing.Size(45, 13);
            this.LB_ModuleAddress.TabIndex = 2;
            this.LB_ModuleAddress.Text = "Address";
            this.LB_ModuleAddress.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Controls_MouseClick);
            this.LB_ModuleAddress.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.PB_ModuleIcon_MouseDoubleClick);
            this.LB_ModuleAddress.MouseLeave += new System.EventHandler(this.Controls_MouseLeave);
            this.LB_ModuleAddress.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Controls_MouseMove);
            // 
            // LB_ModuleName
            // 
            this.LB_ModuleName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LB_ModuleName.ForeColor = System.Drawing.SystemColors.Control;
            this.LB_ModuleName.Location = new System.Drawing.Point(53, 7);
            this.LB_ModuleName.Name = "LB_ModuleName";
            this.LB_ModuleName.Size = new System.Drawing.Size(171, 13);
            this.LB_ModuleName.TabIndex = 1;
            this.LB_ModuleName.Text = "ModuleName";
            this.LB_ModuleName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Controls_MouseClick);
            this.LB_ModuleName.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.PB_ModuleIcon_MouseDoubleClick);
            this.LB_ModuleName.MouseLeave += new System.EventHandler(this.Controls_MouseLeave);
            this.LB_ModuleName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Controls_MouseMove);
            // 
            // PB_ModuleIcon
            // 
            this.PB_ModuleIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PB_ModuleIcon.Location = new System.Drawing.Point(3, 2);
            this.PB_ModuleIcon.Name = "PB_ModuleIcon";
            this.PB_ModuleIcon.Size = new System.Drawing.Size(25, 25);
            this.PB_ModuleIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_ModuleIcon.TabIndex = 0;
            this.PB_ModuleIcon.TabStop = false;
            this.PB_ModuleIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Controls_MouseClick);
            this.PB_ModuleIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.PB_ModuleIcon_MouseDoubleClick);
            this.PB_ModuleIcon.MouseLeave += new System.EventHandler(this.Controls_MouseLeave);
            this.PB_ModuleIcon.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Controls_MouseMove);
            // 
            // ModuleControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(62)))));
            this.Controls.Add(this.panel1);
            this.Name = "ModuleControl";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(322, 32);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_ModuleIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PB_ModuleIcon;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LB_ModuleName;
        private System.Windows.Forms.Label LB_ModuleAddress;
    }
}
