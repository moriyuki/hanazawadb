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
            this.btnEdit = new System.Windows.Forms.Button();
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.chbPcIsByod = new System.Windows.Forms.CheckBox();
            this.chbpPcIsActive = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbxPcs
            // 
            this.lbxPcs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbxPcs.FormattingEnabled = true;
            this.lbxPcs.ItemHeight = 18;
            this.lbxPcs.Location = new System.Drawing.Point(12, 63);
            this.lbxPcs.Name = "lbxPcs";
            this.lbxPcs.Size = new System.Drawing.Size(229, 526);
            this.lbxPcs.TabIndex = 0;
            // 
            // lblPcMasterCaption
            // 
            this.lblPcMasterCaption.AutoSize = true;
            this.lblPcMasterCaption.Location = new System.Drawing.Point(13, 13);
            this.lblPcMasterCaption.Name = "lblPcMasterCaption";
            this.lblPcMasterCaption.Size = new System.Drawing.Size(87, 18);
            this.lblPcMasterCaption.TabIndex = 1;
            this.lblPcMasterCaption.Text = "PC Master";
            // 
            // chbShowInactive
            // 
            this.chbShowInactive.AutoSize = true;
            this.chbShowInactive.Location = new System.Drawing.Point(16, 35);
            this.chbShowInactive.Name = "chbShowInactive";
            this.chbShowInactive.Size = new System.Drawing.Size(131, 22);
            this.chbShowInactive.TabIndex = 2;
            this.chbShowInactive.Text = "showInactive";
            this.chbShowInactive.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.Location = new System.Drawing.Point(16, 595);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(71, 55);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(93, 595);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(71, 55);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDel.Location = new System.Drawing.Point(170, 595);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(71, 55);
            this.btnDel.TabIndex = 5;
            this.btnDel.Text = "Delete";
            this.btnDel.UseVisualStyleBackColor = true;
            // 
            // lblNameCaption
            // 
            this.lblNameCaption.AutoSize = true;
            this.lblNameCaption.Location = new System.Drawing.Point(275, 63);
            this.lblNameCaption.Name = "lblNameCaption";
            this.lblNameCaption.Size = new System.Drawing.Size(71, 18);
            this.lblNameCaption.TabIndex = 6;
            this.lblNameCaption.Text = "pc_name";
            // 
            // txbPcName
            // 
            this.txbPcName.Location = new System.Drawing.Point(302, 84);
            this.txbPcName.Name = "txbPcName";
            this.txbPcName.Size = new System.Drawing.Size(229, 25);
            this.txbPcName.TabIndex = 7;
            // 
            // txbPcOs
            // 
            this.txbPcOs.Location = new System.Drawing.Point(302, 146);
            this.txbPcOs.Name = "txbPcOs";
            this.txbPcOs.Size = new System.Drawing.Size(229, 25);
            this.txbPcOs.TabIndex = 9;
            // 
            // lblPcOsCaption
            // 
            this.lblPcOsCaption.AutoSize = true;
            this.lblPcOsCaption.Location = new System.Drawing.Point(275, 125);
            this.lblPcOsCaption.Name = "lblPcOsCaption";
            this.lblPcOsCaption.Size = new System.Drawing.Size(48, 18);
            this.lblPcOsCaption.TabIndex = 8;
            this.lblPcOsCaption.Text = "pc_os";
            // 
            // txbPcMemory
            // 
            this.txbPcMemory.Location = new System.Drawing.Point(302, 208);
            this.txbPcMemory.Name = "txbPcMemory";
            this.txbPcMemory.Size = new System.Drawing.Size(229, 25);
            this.txbPcMemory.TabIndex = 11;
            // 
            // lblPcMemoryCaption
            // 
            this.lblPcMemoryCaption.AutoSize = true;
            this.lblPcMemoryCaption.Location = new System.Drawing.Point(275, 187);
            this.lblPcMemoryCaption.Name = "lblPcMemoryCaption";
            this.lblPcMemoryCaption.Size = new System.Drawing.Size(90, 18);
            this.lblPcMemoryCaption.TabIndex = 10;
            this.lblPcMemoryCaption.Text = "pc_memory";
            // 
            // txbPcCpu
            // 
            this.txbPcCpu.Location = new System.Drawing.Point(302, 269);
            this.txbPcCpu.Name = "txbPcCpu";
            this.txbPcCpu.Size = new System.Drawing.Size(229, 25);
            this.txbPcCpu.TabIndex = 13;
            // 
            // lblPcCpuCaption
            // 
            this.lblPcCpuCaption.AutoSize = true;
            this.lblPcCpuCaption.Location = new System.Drawing.Point(275, 248);
            this.lblPcCpuCaption.Name = "lblPcCpuCaption";
            this.lblPcCpuCaption.Size = new System.Drawing.Size(58, 18);
            this.lblPcCpuCaption.TabIndex = 12;
            this.lblPcCpuCaption.Text = "pc_cpu";
            // 
            // lblPcByod
            // 
            this.lblPcByod.AutoSize = true;
            this.lblPcByod.Location = new System.Drawing.Point(275, 307);
            this.lblPcByod.Name = "lblPcByod";
            this.lblPcByod.Size = new System.Drawing.Size(0, 18);
            this.lblPcByod.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(275, 369);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 18);
            this.label6.TabIndex = 16;
            // 
            // lblPcCommentCaption
            // 
            this.lblPcCommentCaption.AutoSize = true;
            this.lblPcCommentCaption.Location = new System.Drawing.Point(275, 433);
            this.lblPcCommentCaption.Name = "lblPcCommentCaption";
            this.lblPcCommentCaption.Size = new System.Drawing.Size(76, 18);
            this.lblPcCommentCaption.TabIndex = 18;
            this.lblPcCommentCaption.Text = "comment";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 18;
            this.listBox1.Location = new System.Drawing.Point(587, 84);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(229, 220);
            this.listBox1.TabIndex = 20;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 18;
            this.listBox2.Location = new System.Drawing.Point(587, 351);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(229, 238);
            this.listBox2.TabIndex = 21;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(745, 595);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 55);
            this.button1.TabIndex = 22;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(668, 595);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(71, 55);
            this.button2.TabIndex = 23;
            this.button2.Text = "OK";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // chbPcIsByod
            // 
            this.chbPcIsByod.AutoSize = true;
            this.chbPcIsByod.Location = new System.Drawing.Point(302, 329);
            this.chbPcIsByod.Name = "chbPcIsByod";
            this.chbPcIsByod.Size = new System.Drawing.Size(81, 22);
            this.chbPcIsByod.TabIndex = 24;
            this.chbPcIsByod.Text = "BYOD";
            this.chbPcIsByod.UseVisualStyleBackColor = true;
            // 
            // chbpPcIsActive
            // 
            this.chbpPcIsActive.AutoSize = true;
            this.chbpPcIsActive.Location = new System.Drawing.Point(302, 391);
            this.chbpPcIsActive.Name = "chbpPcIsActive";
            this.chbpPcIsActive.Size = new System.Drawing.Size(82, 22);
            this.chbpPcIsActive.TabIndex = 25;
            this.chbpPcIsActive.Text = "Active";
            this.chbpPcIsActive.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(302, 455);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(229, 134);
            this.textBox1.TabIndex = 26;
            // 
            // FrmPcMasterMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 673);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.chbpPcIsActive);
            this.Controls.Add(this.chbPcIsByod);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
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
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.chbShowInactive);
            this.Controls.Add(this.lblPcMasterCaption);
            this.Controls.Add(this.lbxPcs);
            this.Name = "FrmPcMasterMaintenance";
            this.Text = "FrmPcMasterMaintenance";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxPcs;
        private System.Windows.Forms.Label lblPcMasterCaption;
        private System.Windows.Forms.CheckBox chbShowInactive;
        private System.Windows.Forms.Button btnEdit;
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox chbPcIsByod;
        private System.Windows.Forms.CheckBox chbpPcIsActive;
        private System.Windows.Forms.TextBox textBox1;
    }
}