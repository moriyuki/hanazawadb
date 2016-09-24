namespace Sudachipon
{
    partial class FrmPcMasterMaintenance
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
            this.lbxPcs = new System.Windows.Forms.ListBox();
            this.lblPcMasterCaption = new System.Windows.Forms.Label();
            this.chbShowInactive = new System.Windows.Forms.CheckBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.lblNameCaption = new System.Windows.Forms.Label();
            this.txbPcName = new System.Windows.Forms.TextBox();
            this.txbPcOs = new System.Windows.Forms.TextBox();
            this.lblPcOsCaption = new System.Windows.Forms.Label();
            this.txbPcMemory = new System.Windows.Forms.TextBox();
            this.lblPcMemoryCaption = new System.Windows.Forms.Label();
            this.txbPcCpu = new System.Windows.Forms.TextBox();
            this.lblPcCpuCaption = new System.Windows.Forms.Label();
            this.lblPcByod = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPcCommentCaption = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.chbPcIsByod = new System.Windows.Forms.CheckBox();
            this.chbpPcIsActive = new System.Windows.Forms.CheckBox();
            this.txbComment = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbxPcs
            // 
            this.lbxPcs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbxPcs.FormattingEnabled = true;
            this.lbxPcs.ItemHeight = 12;
            this.lbxPcs.Location = new System.Drawing.Point(7, 42);
            this.lbxPcs.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lbxPcs.Name = "lbxPcs";
            this.lbxPcs.Size = new System.Drawing.Size(139, 352);
            this.lbxPcs.TabIndex = 0;
            this.lbxPcs.SelectedValueChanged += new System.EventHandler(this.lbxPcs_SelectedValueChanged);
            // 
            // lblPcMasterCaption
            // 
            this.lblPcMasterCaption.AutoSize = true;
            this.lblPcMasterCaption.Location = new System.Drawing.Point(8, 9);
            this.lblPcMasterCaption.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPcMasterCaption.Name = "lblPcMasterCaption";
            this.lblPcMasterCaption.Size = new System.Drawing.Size(59, 12);
            this.lblPcMasterCaption.TabIndex = 1;
            this.lblPcMasterCaption.Text = "PC Master";
            // 
            // chbShowInactive
            // 
            this.chbShowInactive.AutoSize = true;
            this.chbShowInactive.Location = new System.Drawing.Point(10, 23);
            this.chbShowInactive.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chbShowInactive.Name = "chbShowInactive";
            this.chbShowInactive.Size = new System.Drawing.Size(90, 16);
            this.chbShowInactive.TabIndex = 2;
            this.chbShowInactive.Text = "showInactive";
            this.chbShowInactive.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(7, 397);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(60, 37);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDel.Location = new System.Drawing.Point(86, 397);
            this.btnDel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(60, 37);
            this.btnDel.TabIndex = 5;
            this.btnDel.Text = "Delete";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // lblNameCaption
            // 
            this.lblNameCaption.AutoSize = true;
            this.lblNameCaption.Location = new System.Drawing.Point(165, 42);
            this.lblNameCaption.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNameCaption.Name = "lblNameCaption";
            this.lblNameCaption.Size = new System.Drawing.Size(48, 12);
            this.lblNameCaption.TabIndex = 6;
            this.lblNameCaption.Text = "pc_name";
            // 
            // txbPcName
            // 
            this.txbPcName.Location = new System.Drawing.Point(181, 56);
            this.txbPcName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txbPcName.Name = "txbPcName";
            this.txbPcName.Size = new System.Drawing.Size(139, 19);
            this.txbPcName.TabIndex = 7;
            // 
            // txbPcOs
            // 
            this.txbPcOs.Location = new System.Drawing.Point(181, 97);
            this.txbPcOs.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txbPcOs.Name = "txbPcOs";
            this.txbPcOs.Size = new System.Drawing.Size(139, 19);
            this.txbPcOs.TabIndex = 9;
            // 
            // lblPcOsCaption
            // 
            this.lblPcOsCaption.AutoSize = true;
            this.lblPcOsCaption.Location = new System.Drawing.Point(165, 83);
            this.lblPcOsCaption.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPcOsCaption.Name = "lblPcOsCaption";
            this.lblPcOsCaption.Size = new System.Drawing.Size(33, 12);
            this.lblPcOsCaption.TabIndex = 8;
            this.lblPcOsCaption.Text = "pc_os";
            // 
            // txbPcMemory
            // 
            this.txbPcMemory.Location = new System.Drawing.Point(181, 139);
            this.txbPcMemory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txbPcMemory.Name = "txbPcMemory";
            this.txbPcMemory.Size = new System.Drawing.Size(139, 19);
            this.txbPcMemory.TabIndex = 11;
            // 
            // lblPcMemoryCaption
            // 
            this.lblPcMemoryCaption.AutoSize = true;
            this.lblPcMemoryCaption.Location = new System.Drawing.Point(165, 125);
            this.lblPcMemoryCaption.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPcMemoryCaption.Name = "lblPcMemoryCaption";
            this.lblPcMemoryCaption.Size = new System.Drawing.Size(61, 12);
            this.lblPcMemoryCaption.TabIndex = 10;
            this.lblPcMemoryCaption.Text = "pc_memory";
            // 
            // txbPcCpu
            // 
            this.txbPcCpu.Location = new System.Drawing.Point(181, 179);
            this.txbPcCpu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txbPcCpu.Name = "txbPcCpu";
            this.txbPcCpu.Size = new System.Drawing.Size(139, 19);
            this.txbPcCpu.TabIndex = 13;
            // 
            // lblPcCpuCaption
            // 
            this.lblPcCpuCaption.AutoSize = true;
            this.lblPcCpuCaption.Location = new System.Drawing.Point(165, 165);
            this.lblPcCpuCaption.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPcCpuCaption.Name = "lblPcCpuCaption";
            this.lblPcCpuCaption.Size = new System.Drawing.Size(39, 12);
            this.lblPcCpuCaption.TabIndex = 12;
            this.lblPcCpuCaption.Text = "pc_cpu";
            // 
            // lblPcByod
            // 
            this.lblPcByod.AutoSize = true;
            this.lblPcByod.Location = new System.Drawing.Point(165, 205);
            this.lblPcByod.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPcByod.Name = "lblPcByod";
            this.lblPcByod.Size = new System.Drawing.Size(0, 12);
            this.lblPcByod.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(165, 246);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 12);
            this.label6.TabIndex = 16;
            // 
            // lblPcCommentCaption
            // 
            this.lblPcCommentCaption.AutoSize = true;
            this.lblPcCommentCaption.Location = new System.Drawing.Point(165, 289);
            this.lblPcCommentCaption.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPcCommentCaption.Name = "lblPcCommentCaption";
            this.lblPcCommentCaption.Size = new System.Drawing.Size(51, 12);
            this.lblPcCommentCaption.TabIndex = 18;
            this.lblPcCommentCaption.Text = "comment";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(352, 56);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(139, 148);
            this.listBox1.TabIndex = 20;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 12;
            this.listBox2.Location = new System.Drawing.Point(352, 234);
            this.listBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(139, 160);
            this.listBox2.TabIndex = 21;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Location = new System.Drawing.Point(716, 595);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 56);
            this.btnClose.TabIndex = 22;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpdate.Location = new System.Drawing.Point(587, 596);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 56);
            this.btnUpdate.TabIndex = 23;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // chbPcIsByod
            // 
            this.chbPcIsByod.AutoSize = true;
            this.chbPcIsByod.Location = new System.Drawing.Point(181, 219);
            this.chbPcIsByod.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chbPcIsByod.Name = "chbPcIsByod";
            this.chbPcIsByod.Size = new System.Drawing.Size(55, 16);
            this.chbPcIsByod.TabIndex = 24;
            this.chbPcIsByod.Text = "BYOD";
            this.chbPcIsByod.UseVisualStyleBackColor = true;
            // 
            // chbpPcIsActive
            // 
            this.chbpPcIsActive.AutoSize = true;
            this.chbpPcIsActive.Location = new System.Drawing.Point(181, 261);
            this.chbpPcIsActive.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chbpPcIsActive.Name = "chbpPcIsActive";
            this.chbpPcIsActive.Size = new System.Drawing.Size(57, 16);
            this.chbpPcIsActive.TabIndex = 25;
            this.chbpPcIsActive.Text = "Active";
            this.chbpPcIsActive.UseVisualStyleBackColor = true;
            // 
            // txbComment
            // 
            this.txbComment.Location = new System.Drawing.Point(181, 303);
            this.txbComment.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txbComment.Multiline = true;
            this.txbComment.Name = "txbComment";
            this.txbComment.Size = new System.Drawing.Size(139, 91);
            this.txbComment.TabIndex = 26;
            // 
            // FrmPcMasterMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 449);
            this.Controls.Add(this.txbComment);
            this.Controls.Add(this.chbpPcIsActive);
            this.Controls.Add(this.chbPcIsByod);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.lblPcCommentCaption);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblPcByod);
            this.Controls.Add(this.txbPcCpu);
            this.Controls.Add(this.lblPcCpuCaption);
            this.Controls.Add(this.txbPcMemory);
            this.Controls.Add(this.lblPcMemoryCaption);
            this.Controls.Add(this.txbPcOs);
            this.Controls.Add(this.lblPcOsCaption);
            this.Controls.Add(this.txbPcName);
            this.Controls.Add(this.lblNameCaption);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.chbShowInactive);
            this.Controls.Add(this.lblPcMasterCaption);
            this.Controls.Add(this.lbxPcs);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmPcMasterMaintenance";
            this.Text = "FrmPcMasterMaintenance";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxPcs;
        private System.Windows.Forms.Label lblPcMasterCaption;
        private System.Windows.Forms.CheckBox chbShowInactive;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Label lblNameCaption;
        private System.Windows.Forms.TextBox txbPcName;
        private System.Windows.Forms.TextBox txbPcOs;
        private System.Windows.Forms.Label lblPcOsCaption;
        private System.Windows.Forms.TextBox txbPcMemory;
        private System.Windows.Forms.Label lblPcMemoryCaption;
        private System.Windows.Forms.TextBox txbPcCpu;
        private System.Windows.Forms.Label lblPcCpuCaption;
        private System.Windows.Forms.Label lblPcByod;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPcCommentCaption;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.CheckBox chbPcIsByod;
        private System.Windows.Forms.CheckBox chbpPcIsActive;
        private System.Windows.Forms.TextBox txbComment;
    }
}