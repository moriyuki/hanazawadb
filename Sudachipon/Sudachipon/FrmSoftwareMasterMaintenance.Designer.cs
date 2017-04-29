namespace Sudachipon
{
    partial class FrmSoftwareMasterMaintenance
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
            this.txbSoftwareComment = new System.Windows.Forms.TextBox();
            this.chbpSoftwareIsActive = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.lsbPcMaster = new System.Windows.Forms.ListBox();
            this.lsbPcs = new System.Windows.Forms.ListBox();
            this.lblSoftwareCommentCaption = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPcByod = new System.Windows.Forms.Label();
            this.txbSoftAvailable = new System.Windows.Forms.TextBox();
            this.lblSoftwareAvailableNumberCaption = new System.Windows.Forms.Label();
            this.lblSoftOSCaption = new System.Windows.Forms.Label();
            this.txbSoftwareVersion = new System.Windows.Forms.TextBox();
            this.lblSoftwareOsCaption = new System.Windows.Forms.Label();
            this.txbSoftwareName = new System.Windows.Forms.TextBox();
            this.lblSoftwareCaption = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.chbShowInactive = new System.Windows.Forms.CheckBox();
            this.lblSoftwareMasterCaption = new System.Windows.Forms.Label();
            this.lbxSoftwares = new System.Windows.Forms.ListBox();
            this.lsbUserMaster = new System.Windows.Forms.ListBox();
            this.lsbUsers = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSoftwareOs = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txbSoftwareComment
            // 
            this.txbSoftwareComment.Location = new System.Drawing.Point(185, 309);
            this.txbSoftwareComment.Margin = new System.Windows.Forms.Padding(2);
            this.txbSoftwareComment.Multiline = true;
            this.txbSoftwareComment.Name = "txbSoftwareComment";
            this.txbSoftwareComment.Size = new System.Drawing.Size(139, 91);
            this.txbSoftwareComment.TabIndex = 50;
            // 
            // chbpSoftwareIsActive
            // 
            this.chbpSoftwareIsActive.AutoSize = true;
            this.chbpSoftwareIsActive.Location = new System.Drawing.Point(185, 224);
            this.chbpSoftwareIsActive.Margin = new System.Windows.Forms.Padding(2);
            this.chbpSoftwareIsActive.Name = "chbpSoftwareIsActive";
            this.chbpSoftwareIsActive.Size = new System.Drawing.Size(57, 16);
            this.chbpSoftwareIsActive.TabIndex = 49;
            this.chbpSoftwareIsActive.Text = "Active";
            this.chbpSoftwareIsActive.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Location = new System.Drawing.Point(601, 412);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(59, 37);
            this.btnClose.TabIndex = 47;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lsbPcMaster
            // 
            this.lsbPcMaster.FormattingEnabled = true;
            this.lsbPcMaster.ItemHeight = 12;
            this.lsbPcMaster.Location = new System.Drawing.Point(356, 240);
            this.lsbPcMaster.Margin = new System.Windows.Forms.Padding(2);
            this.lsbPcMaster.Name = "lsbPcMaster";
            this.lsbPcMaster.Size = new System.Drawing.Size(139, 160);
            this.lsbPcMaster.TabIndex = 45;
            this.lsbPcMaster.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lsbPcMaster_MouseDown);
            // 
            // lsbPcs
            // 
            this.lsbPcs.AllowDrop = true;
            this.lsbPcs.FormattingEnabled = true;
            this.lsbPcs.ItemHeight = 12;
            this.lsbPcs.Location = new System.Drawing.Point(356, 62);
            this.lsbPcs.Margin = new System.Windows.Forms.Padding(2);
            this.lsbPcs.Name = "lsbPcs";
            this.lsbPcs.Size = new System.Drawing.Size(139, 148);
            this.lsbPcs.TabIndex = 44;
            this.lsbPcs.DragDrop += new System.Windows.Forms.DragEventHandler(this.lsbPcs_DragDrop);
            this.lsbPcs.DragEnter += new System.Windows.Forms.DragEventHandler(this.lsbPcs_DragEnter);
            this.lsbPcs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsbPcs_KeyDown);
            // 
            // lblSoftwareCommentCaption
            // 
            this.lblSoftwareCommentCaption.AutoSize = true;
            this.lblSoftwareCommentCaption.Location = new System.Drawing.Point(169, 295);
            this.lblSoftwareCommentCaption.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSoftwareCommentCaption.Name = "lblSoftwareCommentCaption";
            this.lblSoftwareCommentCaption.Size = new System.Drawing.Size(65, 12);
            this.lblSoftwareCommentCaption.TabIndex = 43;
            this.lblSoftwareCommentCaption.Text = "sf_comment";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(169, 252);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 12);
            this.label6.TabIndex = 42;
            // 
            // lblPcByod
            // 
            this.lblPcByod.AutoSize = true;
            this.lblPcByod.Location = new System.Drawing.Point(169, 211);
            this.lblPcByod.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPcByod.Name = "lblPcByod";
            this.lblPcByod.Size = new System.Drawing.Size(0, 12);
            this.lblPcByod.TabIndex = 41;
            // 
            // txbSoftAvailable
            // 
            this.txbSoftAvailable.Location = new System.Drawing.Point(185, 185);
            this.txbSoftAvailable.Margin = new System.Windows.Forms.Padding(2);
            this.txbSoftAvailable.Name = "txbSoftAvailable";
            this.txbSoftAvailable.Size = new System.Drawing.Size(139, 19);
            this.txbSoftAvailable.TabIndex = 40;
            // 
            // lblSoftwareAvailableNumberCaption
            // 
            this.lblSoftwareAvailableNumberCaption.AutoSize = true;
            this.lblSoftwareAvailableNumberCaption.Location = new System.Drawing.Point(169, 171);
            this.lblSoftwareAvailableNumberCaption.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSoftwareAvailableNumberCaption.Name = "lblSoftwareAvailableNumberCaption";
            this.lblSoftwareAvailableNumberCaption.Size = new System.Drawing.Size(105, 12);
            this.lblSoftwareAvailableNumberCaption.TabIndex = 39;
            this.lblSoftwareAvailableNumberCaption.Text = "sf_available_number";
            // 
            // lblSoftOSCaption
            // 
            this.lblSoftOSCaption.AutoSize = true;
            this.lblSoftOSCaption.Location = new System.Drawing.Point(169, 131);
            this.lblSoftOSCaption.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSoftOSCaption.Name = "lblSoftOSCaption";
            this.lblSoftOSCaption.Size = new System.Drawing.Size(31, 12);
            this.lblSoftOSCaption.TabIndex = 37;
            this.lblSoftOSCaption.Text = "sf_os";
            // 
            // txbSoftwareVersion
            // 
            this.txbSoftwareVersion.Location = new System.Drawing.Point(185, 103);
            this.txbSoftwareVersion.Margin = new System.Windows.Forms.Padding(2);
            this.txbSoftwareVersion.Name = "txbSoftwareVersion";
            this.txbSoftwareVersion.Size = new System.Drawing.Size(139, 19);
            this.txbSoftwareVersion.TabIndex = 36;
            // 
            // lblSoftwareOsCaption
            // 
            this.lblSoftwareOsCaption.AutoSize = true;
            this.lblSoftwareOsCaption.Location = new System.Drawing.Point(169, 89);
            this.lblSoftwareOsCaption.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSoftwareOsCaption.Name = "lblSoftwareOsCaption";
            this.lblSoftwareOsCaption.Size = new System.Drawing.Size(56, 12);
            this.lblSoftwareOsCaption.TabIndex = 35;
            this.lblSoftwareOsCaption.Text = "sf_version";
            // 
            // txbSoftwareName
            // 
            this.txbSoftwareName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txbSoftwareName.Location = new System.Drawing.Point(185, 62);
            this.txbSoftwareName.Margin = new System.Windows.Forms.Padding(2);
            this.txbSoftwareName.Name = "txbSoftwareName";
            this.txbSoftwareName.Size = new System.Drawing.Size(139, 19);
            this.txbSoftwareName.TabIndex = 34;
            this.txbSoftwareName.TextChanged += new System.EventHandler(this.txbSoftwareName_TextChanged);
            // 
            // lblSoftwareCaption
            // 
            this.lblSoftwareCaption.AutoSize = true;
            this.lblSoftwareCaption.Location = new System.Drawing.Point(169, 48);
            this.lblSoftwareCaption.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSoftwareCaption.Name = "lblSoftwareCaption";
            this.lblSoftwareCaption.Size = new System.Drawing.Size(46, 12);
            this.lblSoftwareCaption.TabIndex = 33;
            this.lblSoftwareCaption.Text = "sf_name";
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDel.Location = new System.Drawing.Point(82, 412);
            this.btnDel.Margin = new System.Windows.Forms.Padding(2);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(68, 37);
            this.btnDel.TabIndex = 32;
            this.btnDel.Text = "Delete";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(11, 412);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(67, 37);
            this.btnAdd.TabIndex = 31;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpdate.Location = new System.Drawing.Point(521, 412);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(57, 37);
            this.btnUpdate.TabIndex = 30;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // chbShowInactive
            // 
            this.chbShowInactive.AutoSize = true;
            this.chbShowInactive.Location = new System.Drawing.Point(14, 29);
            this.chbShowInactive.Margin = new System.Windows.Forms.Padding(2);
            this.chbShowInactive.Name = "chbShowInactive";
            this.chbShowInactive.Size = new System.Drawing.Size(90, 16);
            this.chbShowInactive.TabIndex = 29;
            this.chbShowInactive.Text = "showInactive";
            this.chbShowInactive.UseVisualStyleBackColor = true;
            this.chbShowInactive.CheckedChanged += new System.EventHandler(this.chbShowInactive_CheckedChanged);
            // 
            // lblSoftwareMasterCaption
            // 
            this.lblSoftwareMasterCaption.AutoSize = true;
            this.lblSoftwareMasterCaption.Location = new System.Drawing.Point(12, 15);
            this.lblSoftwareMasterCaption.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSoftwareMasterCaption.Name = "lblSoftwareMasterCaption";
            this.lblSoftwareMasterCaption.Size = new System.Drawing.Size(89, 12);
            this.lblSoftwareMasterCaption.TabIndex = 28;
            this.lblSoftwareMasterCaption.Text = "Software Master";
            // 
            // lbxSoftwares
            // 
            this.lbxSoftwares.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbxSoftwares.FormattingEnabled = true;
            this.lbxSoftwares.ItemHeight = 12;
            this.lbxSoftwares.Location = new System.Drawing.Point(11, 48);
            this.lbxSoftwares.Margin = new System.Windows.Forms.Padding(2);
            this.lbxSoftwares.Name = "lbxSoftwares";
            this.lbxSoftwares.Size = new System.Drawing.Size(139, 352);
            this.lbxSoftwares.TabIndex = 27;
            this.lbxSoftwares.SelectedValueChanged += new System.EventHandler(this.lbxSoftwares_SelectedValueChanged);
            // 
            // lsbUserMaster
            // 
            this.lsbUserMaster.FormattingEnabled = true;
            this.lsbUserMaster.ItemHeight = 12;
            this.lsbUserMaster.Location = new System.Drawing.Point(521, 240);
            this.lsbUserMaster.Margin = new System.Windows.Forms.Padding(2);
            this.lsbUserMaster.Name = "lsbUserMaster";
            this.lsbUserMaster.Size = new System.Drawing.Size(139, 160);
            this.lsbUserMaster.TabIndex = 52;
            this.lsbUserMaster.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lsbUserMaster_MouseDown);
            // 
            // lsbUsers
            // 
            this.lsbUsers.AllowDrop = true;
            this.lsbUsers.FormattingEnabled = true;
            this.lsbUsers.ItemHeight = 12;
            this.lsbUsers.Location = new System.Drawing.Point(521, 62);
            this.lsbUsers.Margin = new System.Windows.Forms.Padding(2);
            this.lsbUsers.Name = "lsbUsers";
            this.lsbUsers.Size = new System.Drawing.Size(139, 148);
            this.lsbUsers.TabIndex = 51;
            this.lsbUsers.DragDrop += new System.Windows.Forms.DragEventHandler(this.lsbUsers_DragDrop);
            this.lsbUsers.DragEnter += new System.Windows.Forms.DragEventHandler(this.lsbUsers_DragEnter);
            this.lsbUsers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsbUsers_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(406, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 12);
            this.label1.TabIndex = 53;
            this.label1.Text = "PCs";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(396, 226);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 54;
            this.label2.Text = "PC Master";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(555, 226);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 12);
            this.label3.TabIndex = 55;
            this.label3.Text = "User Master";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(569, 48);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 56;
            this.label4.Text = "Users";
            // 
            // cmbSoftwareOs
            // 
            this.cmbSoftwareOs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSoftwareOs.FormattingEnabled = true;
            this.cmbSoftwareOs.Location = new System.Drawing.Point(185, 146);
            this.cmbSoftwareOs.Name = "cmbSoftwareOs";
            this.cmbSoftwareOs.Size = new System.Drawing.Size(139, 20);
            this.cmbSoftwareOs.TabIndex = 57;
            this.cmbSoftwareOs.SelectedIndexChanged += new System.EventHandler(this.cmbSoftwareOs_SelectedIndexChanged);
            // 
            // FrmSoftwareMasterMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 513);
            this.Controls.Add(this.cmbSoftwareOs);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lsbUserMaster);
            this.Controls.Add(this.lsbUsers);
            this.Controls.Add(this.txbSoftwareComment);
            this.Controls.Add(this.chbpSoftwareIsActive);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lsbPcMaster);
            this.Controls.Add(this.lsbPcs);
            this.Controls.Add(this.lblSoftwareCommentCaption);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblPcByod);
            this.Controls.Add(this.txbSoftAvailable);
            this.Controls.Add(this.lblSoftwareAvailableNumberCaption);
            this.Controls.Add(this.lblSoftOSCaption);
            this.Controls.Add(this.txbSoftwareVersion);
            this.Controls.Add(this.lblSoftwareOsCaption);
            this.Controls.Add(this.txbSoftwareName);
            this.Controls.Add(this.lblSoftwareCaption);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.chbShowInactive);
            this.Controls.Add(this.lblSoftwareMasterCaption);
            this.Controls.Add(this.lbxSoftwares);
            this.Name = "FrmSoftwareMasterMaintenance";
            this.Text = "FrmSoftwareMasterMaintenance";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbSoftwareComment;
        private System.Windows.Forms.CheckBox chbpSoftwareIsActive;
        private System.Windows.Forms.ListBox lsbPcMaster;
        private System.Windows.Forms.ListBox lsbPcs;
        private System.Windows.Forms.Label lblSoftwareCommentCaption;
        private System.Windows.Forms.Label lblSoftwareAvailableNumberCaption;
        private System.Windows.Forms.Label lblSoftOSCaption;
        private System.Windows.Forms.TextBox txbSoftwareVersion;
        private System.Windows.Forms.Label lblSoftwareOsCaption;
        private System.Windows.Forms.TextBox txbSoftwareName;
        private System.Windows.Forms.Label lblSoftwareCaption;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblSoftwareMasterCaption;
        private System.Windows.Forms.ListBox lbxSoftwares;
        private System.Windows.Forms.ListBox lsbUserMaster;
        private System.Windows.Forms.ListBox lsbUsers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chbShowInactive;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.TextBox txbSoftAvailable;
        private System.Windows.Forms.Label lblPcByod;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cmbSoftwareOs;
    }
}