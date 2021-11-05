namespace SKYNET
{
    partial class frmFunctions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFunctions));
            this.P_Top = new System.Windows.Forms.Panel();
            this.B_Close = new SKYNET.Controls.SKYNET_CloseBox();
            this.LV_ItemsView = new System.Windows.Forms.ListView();
            this.PN_Info = new System.Windows.Forms.Panel();
            this.LB_Loading = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LB_Function = new System.Windows.Forms.Label();
            this.P_Top.SuspendLayout();
            this.PN_Info.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.P_Top.Size = new System.Drawing.Size(515, 26);
            this.P_Top.TabIndex = 6;
            // 
            // B_Close
            // 
            this.B_Close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(40)))), ((int)(((byte)(52)))));
            this.B_Close.Color = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(40)))), ((int)(((byte)(52)))));
            this.B_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.B_Close.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(62)))));
            this.B_Close.Location = new System.Drawing.Point(481, 0);
            this.B_Close.MaximumSize = new System.Drawing.Size(34, 26);
            this.B_Close.MinimumSize = new System.Drawing.Size(34, 26);
            this.B_Close.Name = "B_Close";
            this.B_Close.Size = new System.Drawing.Size(34, 26);
            this.B_Close.TabIndex = 0;
            this.B_Close.Clicked += new System.EventHandler(this.B_Close_Clicked);
            // 
            // LV_ItemsView
            // 
            this.LV_ItemsView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(40)))), ((int)(((byte)(52)))));
            this.LV_ItemsView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LV_ItemsView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.LV_ItemsView.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LV_ItemsView.FullRowSelect = true;
            this.LV_ItemsView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.LV_ItemsView.Location = new System.Drawing.Point(12, 53);
            this.LV_ItemsView.Name = "LV_ItemsView";
            this.LV_ItemsView.Size = new System.Drawing.Size(491, 374);
            this.LV_ItemsView.TabIndex = 157;
            this.LV_ItemsView.UseCompatibleStateImageBehavior = false;
            this.LV_ItemsView.View = System.Windows.Forms.View.Details;
            this.LV_ItemsView.SelectedIndexChanged += new System.EventHandler(this.LV_ItemsView_SelectedIndexChanged);
            // 
            // PN_Info
            // 
            this.PN_Info.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(62)))));
            this.PN_Info.Controls.Add(this.LB_Loading);
            this.PN_Info.Location = new System.Drawing.Point(120, 171);
            this.PN_Info.Name = "PN_Info";
            this.PN_Info.Size = new System.Drawing.Size(272, 100);
            this.PN_Info.TabIndex = 0;
            // 
            // LB_Loading
            // 
            this.LB_Loading.AutoSize = true;
            this.LB_Loading.Location = new System.Drawing.Point(92, 45);
            this.LB_Loading.Name = "LB_Loading";
            this.LB_Loading.Size = new System.Drawing.Size(94, 13);
            this.LB_Loading.TabIndex = 0;
            this.LB_Loading.Text = "Loading Functions";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(62)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(491, 25);
            this.panel1.TabIndex = 158;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(386, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Address";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Function Name";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 321;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 62;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 85;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(322, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ordinal";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(62)))));
            this.panel2.Controls.Add(this.LB_Function);
            this.panel2.Location = new System.Drawing.Point(12, 443);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(491, 25);
            this.panel2.TabIndex = 159;
            // 
            // LB_Function
            // 
            this.LB_Function.AutoSize = true;
            this.LB_Function.Location = new System.Drawing.Point(3, 6);
            this.LB_Function.Name = "LB_Function";
            this.LB_Function.Size = new System.Drawing.Size(0, 13);
            this.LB_Function.TabIndex = 1;
            // 
            // frmFunctions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(40)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(515, 480);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PN_Info);
            this.Controls.Add(this.LV_ItemsView);
            this.Controls.Add(this.P_Top);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFunctions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.Shown += new System.EventHandler(this.FrmModules_Shown);
            this.P_Top.ResumeLayout(false);
            this.PN_Info.ResumeLayout(false);
            this.PN_Info.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel P_Top;
        private Controls.SKYNET_CloseBox B_Close;
        private System.Windows.Forms.ListView LV_ItemsView;
        private System.Windows.Forms.Panel PN_Info;
        private System.Windows.Forms.Label LB_Loading;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LB_Function;
    }
}