﻿namespace Sudachipon
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
            this.components = new System.ComponentModel.Container();
            this.lbxPcs = new System.Windows.Forms.ListBox();
            this.lblPcMasterCaption = new System.Windows.Forms.Label();
            this.chbShowInactive = new System.Windows.Forms.CheckBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.lblNameCaption = new System.Windows.Forms.Label();
            this.txbPcName = new System.Windows.Forms.TextBox();
            this.lblPcOsCaption = new System.Windows.Forms.Label();
            this.txbPcMemory = new System.Windows.Forms.TextBox();
            this.lblPcMemoryCaption = new System.Windows.Forms.Label();
            this.txbPcCpu = new System.Windows.Forms.TextBox();
            this.lblPcCpuCaption = new System.Windows.Forms.Label();
            this.lblPcByod = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPcCommentCaption = new System.Windows.Forms.Label();
            this.lbxSoft = new System.Windows.Forms.ListBox();
            this.lbxSoftMaster = new System.Windows.Forms.ListBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.chbPcIsByod = new System.Windows.Forms.CheckBox();
            this.chbpPcIsActive = new System.Windows.Forms.CheckBox();
            this.txbComment = new System.Windows.Forms.TextBox();
            this.lblSoftwareMasterCaption = new System.Windows.Forms.Label();
            this.lblSftwaresCaption = new System.Windows.Forms.Label();
            this.ttpPcName = new System.Windows.Forms.ToolTip(this.components);
            this.cmbPcOs = new System.Windows.Forms.ComboBox();
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
            this.lbxPcs.SelectedValueChanged += new System.EventHandler(this.lbxPcs_SelectedValueChanged);
            // 
            // lblPcMasterCaption
            // 
            this.lblPcMasterCaption.AutoSize = true;
            this.lblPcMasterCaption.Location = new System.Drawing.Point(8, 26);
            this.lblPcMasterCaption.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPcMasterCaption.Name = "lblPcMasterCaption";
            this.lblPcMasterCaption.Size = new System.Drawing.Size(87, 18);
            this.lblPcMasterCaption.TabIndex = 1;
            this.lblPcMasterCaption.Text = "PC Master";
            // 
            // chbShowInactive
            // 
            this.chbShowInactive.AutoSize = true;
            this.chbShowInactive.Location = new System.Drawing.Point(110, 21);
            this.chbShowInactive.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chbShowInactive.Name = "chbShowInactive";
            this.chbShowInactive.Size = new System.Drawing.Size(131, 22);
            this.chbShowInactive.TabIndex = 2;
            this.chbShowInactive.Text = "showInactive";
            this.chbShowInactive.UseVisualStyleBackColor = true;
            this.chbShowInactive.CheckedChanged += new System.EventHandler(this.chbShowInactive_CheckedChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(20, 608);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(167, 84);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDel.Location = new System.Drawing.Point(198, 608);
            this.btnDel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(167, 84);
            this.btnDel.TabIndex = 5;
            this.btnDel.Text = "Delete";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // lblNameCaption
            // 
            this.lblNameCaption.AutoSize = true;
            this.lblNameCaption.Location = new System.Drawing.Point(275, 63);
            this.lblNameCaption.Name = "lblNameCaption";
            this.lblNameCaption.Size = new System.Drawing.Size(49, 18);
            this.lblNameCaption.TabIndex = 6;
            this.lblNameCaption.Text = "PC名";
            // 
            // txbPcName
            // 
            this.txbPcName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txbPcName.Location = new System.Drawing.Point(278, 84);
            this.txbPcName.Name = "txbPcName";
            this.txbPcName.Size = new System.Drawing.Size(229, 25);
            this.txbPcName.TabIndex = 7;
            this.ttpPcName.SetToolTip(this.txbPcName, "シングルクォーテーションは使用できません");
            // 
            // lblPcOsCaption
            // 
            this.lblPcOsCaption.AutoSize = true;
            this.lblPcOsCaption.Location = new System.Drawing.Point(275, 124);
            this.lblPcOsCaption.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPcOsCaption.Name = "lblPcOsCaption";
            this.lblPcOsCaption.Size = new System.Drawing.Size(32, 18);
            this.lblPcOsCaption.TabIndex = 8;
            this.lblPcOsCaption.Text = "OS";
            // 
            // txbPcMemory
            // 
            this.txbPcMemory.Location = new System.Drawing.Point(278, 208);
            this.txbPcMemory.Name = "txbPcMemory";
            this.txbPcMemory.Size = new System.Drawing.Size(229, 25);
            this.txbPcMemory.TabIndex = 11;
            // 
            // lblPcMemoryCaption
            // 
            this.lblPcMemoryCaption.AutoSize = true;
            this.lblPcMemoryCaption.Location = new System.Drawing.Point(275, 188);
            this.lblPcMemoryCaption.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPcMemoryCaption.Name = "lblPcMemoryCaption";
            this.lblPcMemoryCaption.Size = new System.Drawing.Size(88, 18);
            this.lblPcMemoryCaption.TabIndex = 10;
            this.lblPcMemoryCaption.Text = "メモリサイズ";
            // 
            // txbPcCpu
            // 
            this.txbPcCpu.Location = new System.Drawing.Point(278, 270);
            this.txbPcCpu.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbPcCpu.Name = "txbPcCpu";
            this.txbPcCpu.Size = new System.Drawing.Size(229, 25);
            this.txbPcCpu.TabIndex = 13;
            // 
            // lblPcCpuCaption
            // 
            this.lblPcCpuCaption.AutoSize = true;
            this.lblPcCpuCaption.Location = new System.Drawing.Point(275, 248);
            this.lblPcCpuCaption.Name = "lblPcCpuCaption";
            this.lblPcCpuCaption.Size = new System.Drawing.Size(43, 18);
            this.lblPcCpuCaption.TabIndex = 12;
            this.lblPcCpuCaption.Text = "CPU";
            // 
            // lblPcByod
            // 
            this.lblPcByod.AutoSize = true;
            this.lblPcByod.Location = new System.Drawing.Point(458, 462);
            this.lblPcByod.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
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
            this.lblPcCommentCaption.Location = new System.Drawing.Point(275, 370);
            this.lblPcCommentCaption.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPcCommentCaption.Name = "lblPcCommentCaption";
            this.lblPcCommentCaption.Size = new System.Drawing.Size(44, 18);
            this.lblPcCommentCaption.TabIndex = 18;
            this.lblPcCommentCaption.Text = "備考";
            // 
            // lbxSoft
            // 
            this.lbxSoft.AllowDrop = true;
            this.lbxSoft.FormattingEnabled = true;
            this.lbxSoft.ItemHeight = 18;
            this.lbxSoft.Location = new System.Drawing.Point(692, 86);
            this.lbxSoft.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.lbxSoft.Name = "lbxSoft";
            this.lbxSoft.Size = new System.Drawing.Size(199, 238);
            this.lbxSoft.TabIndex = 20;
            this.lbxSoft.DragDrop += new System.Windows.Forms.DragEventHandler(this.lbxSoft_DragDrop);
            this.lbxSoft.DragEnter += new System.Windows.Forms.DragEventHandler(this.lbxSoft_DragEnter);
            this.lbxSoft.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbxSoft_KeyDown);
            this.lbxSoft.Leave += new System.EventHandler(this.lbxSoft_Leave);
            // 
            // lbxSoftMaster
            // 
            this.lbxSoftMaster.FormattingEnabled = true;
            this.lbxSoftMaster.ItemHeight = 18;
            this.lbxSoftMaster.Location = new System.Drawing.Point(692, 370);
            this.lbxSoftMaster.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.lbxSoftMaster.Name = "lbxSoftMaster";
            this.lbxSoftMaster.Size = new System.Drawing.Size(199, 220);
            this.lbxSoftMaster.TabIndex = 21;
            this.lbxSoftMaster.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbxSoftMaster_MouseDown);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Location = new System.Drawing.Point(723, 608);
            this.btnClose.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(167, 84);
            this.btnClose.TabIndex = 22;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpdate.Location = new System.Drawing.Point(542, 608);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(167, 84);
            this.btnUpdate.TabIndex = 23;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // chbPcIsByod
            // 
            this.chbPcIsByod.AutoSize = true;
            this.chbPcIsByod.Location = new System.Drawing.Point(278, 314);
            this.chbPcIsByod.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chbPcIsByod.Name = "chbPcIsByod";
            this.chbPcIsByod.Size = new System.Drawing.Size(81, 22);
            this.chbPcIsByod.TabIndex = 24;
            this.chbPcIsByod.Text = "BYOD";
            this.chbPcIsByod.UseVisualStyleBackColor = true;
            // 
            // chbpPcIsActive
            // 
            this.chbpPcIsActive.AutoSize = true;
            this.chbpPcIsActive.Location = new System.Drawing.Point(277, 344);
            this.chbpPcIsActive.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chbpPcIsActive.Name = "chbpPcIsActive";
            this.chbpPcIsActive.Size = new System.Drawing.Size(82, 22);
            this.chbpPcIsActive.TabIndex = 25;
            this.chbpPcIsActive.Text = "Active";
            this.chbpPcIsActive.UseVisualStyleBackColor = true;
            // 
            // txbComment
            // 
            this.txbComment.Location = new System.Drawing.Point(277, 390);
            this.txbComment.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbComment.Multiline = true;
            this.txbComment.Name = "txbComment";
            this.txbComment.Size = new System.Drawing.Size(379, 199);
            this.txbComment.TabIndex = 26;
            // 
            // lblSoftwareMasterCaption
            // 
            this.lblSoftwareMasterCaption.AutoSize = true;
            this.lblSoftwareMasterCaption.Location = new System.Drawing.Point(688, 344);
            this.lblSoftwareMasterCaption.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSoftwareMasterCaption.Name = "lblSoftwareMasterCaption";
            this.lblSoftwareMasterCaption.Size = new System.Drawing.Size(131, 18);
            this.lblSoftwareMasterCaption.TabIndex = 27;
            this.lblSoftwareMasterCaption.Text = "Software Master";
            // 
            // lblSftwaresCaption
            // 
            this.lblSftwaresCaption.AutoSize = true;
            this.lblSftwaresCaption.Location = new System.Drawing.Point(688, 63);
            this.lblSftwaresCaption.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSftwaresCaption.Name = "lblSftwaresCaption";
            this.lblSftwaresCaption.Size = new System.Drawing.Size(83, 18);
            this.lblSftwaresCaption.TabIndex = 28;
            this.lblSftwaresCaption.Text = "Softwares";
            // 
            // cmbPcOs
            // 
            this.cmbPcOs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPcOs.FormattingEnabled = true;
            this.cmbPcOs.Location = new System.Drawing.Point(277, 147);
            this.cmbPcOs.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cmbPcOs.Name = "cmbPcOs";
            this.cmbPcOs.Size = new System.Drawing.Size(199, 26);
            this.cmbPcOs.TabIndex = 29;
            // 
            // FrmPcMasterMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 706);
            this.Controls.Add(this.cmbPcOs);
            this.Controls.Add(this.lblSftwaresCaption);
            this.Controls.Add(this.lblSoftwareMasterCaption);
            this.Controls.Add(this.txbComment);
            this.Controls.Add(this.chbpPcIsActive);
            this.Controls.Add(this.chbPcIsByod);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbxSoftMaster);
            this.Controls.Add(this.lbxSoft);
            this.Controls.Add(this.lblPcCommentCaption);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblPcByod);
            this.Controls.Add(this.txbPcCpu);
            this.Controls.Add(this.lblPcCpuCaption);
            this.Controls.Add(this.txbPcMemory);
            this.Controls.Add(this.lblPcMemoryCaption);
            this.Controls.Add(this.lblPcOsCaption);
            this.Controls.Add(this.txbPcName);
            this.Controls.Add(this.lblNameCaption);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAdd);
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
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Label lblNameCaption;
        private System.Windows.Forms.TextBox txbPcName;
        private System.Windows.Forms.Label lblPcOsCaption;
        private System.Windows.Forms.TextBox txbPcMemory;
        private System.Windows.Forms.Label lblPcMemoryCaption;
        private System.Windows.Forms.TextBox txbPcCpu;
        private System.Windows.Forms.Label lblPcCpuCaption;
        private System.Windows.Forms.Label lblPcByod;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPcCommentCaption;
        private System.Windows.Forms.ListBox lbxSoft;
        private System.Windows.Forms.ListBox lbxSoftMaster;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.CheckBox chbPcIsByod;
        private System.Windows.Forms.CheckBox chbpPcIsActive;
        private System.Windows.Forms.TextBox txbComment;
        private System.Windows.Forms.Label lblSoftwareMasterCaption;
        private System.Windows.Forms.Label lblSftwaresCaption;
        private System.Windows.Forms.ToolTip ttpPcName;
        private System.Windows.Forms.ComboBox cmbPcOs;
    }
}