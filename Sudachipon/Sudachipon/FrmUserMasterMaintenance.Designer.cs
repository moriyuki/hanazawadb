namespace Sudachipon
{
    partial class FrmUserMasterMaintenance
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbUserComment = new System.Windows.Forms.TextBox();
            this.chbpUsersActive = new System.Windows.Forms.CheckBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lsbSoftwareMaster = new System.Windows.Forms.ListBox();
            this.lsbSoftwares = new System.Windows.Forms.ListBox();
            this.lblUserCommentCaption = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblUserTypeCaption = new System.Windows.Forms.Label();
            this.txbUserName = new System.Windows.Forms.TextBox();
            this.lblUserNameCaption = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.chbShowInactive = new System.Windows.Forms.CheckBox();
            this.lblUserMasterCaption = new System.Windows.Forms.Label();
            this.lbxUsers = new Sudachipon.SortedListBox();
            this.cmbUserType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(628, 330);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 18);
            this.label2.TabIndex = 83;
            this.label2.Text = "Software Master";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(655, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 18);
            this.label1.TabIndex = 82;
            this.label1.Text = "Softwares";
            // 
            // txbUserComment
            // 
            this.txbUserComment.Location = new System.Drawing.Point(302, 454);
            this.txbUserComment.Multiline = true;
            this.txbUserComment.Name = "txbUserComment";
            this.txbUserComment.Size = new System.Drawing.Size(229, 134);
            this.txbUserComment.TabIndex = 79;
            // 
            // chbpUsersActive
            // 
            this.chbpUsersActive.AutoSize = true;
            this.chbpUsersActive.Location = new System.Drawing.Point(308, 219);
            this.chbpUsersActive.Name = "chbpUsersActive";
            this.chbpUsersActive.Size = new System.Drawing.Size(82, 22);
            this.chbpUsersActive.TabIndex = 78;
            this.chbpUsersActive.Text = "Active";
            this.chbpUsersActive.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnUpdate.Location = new System.Drawing.Point(587, 596);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 56);
            this.btnUpdate.TabIndex = 77;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(718, 596);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 56);
            this.button1.TabIndex = 76;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lsbSoftwareMaster
            // 
            this.lsbSoftwareMaster.FormattingEnabled = true;
            this.lsbSoftwareMaster.ItemHeight = 18;
            this.lsbSoftwareMaster.Location = new System.Drawing.Point(587, 351);
            this.lsbSoftwareMaster.Name = "lsbSoftwareMaster";
            this.lsbSoftwareMaster.Size = new System.Drawing.Size(229, 238);
            this.lsbSoftwareMaster.TabIndex = 75;
            this.lsbSoftwareMaster.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lsbSoftwareMaster_MouseDown);
            // 
            // lsbSoftwares
            // 
            this.lsbSoftwares.AllowDrop = true;
            this.lsbSoftwares.FormattingEnabled = true;
            this.lsbSoftwares.ItemHeight = 18;
            this.lsbSoftwares.Location = new System.Drawing.Point(587, 84);
            this.lsbSoftwares.Name = "lsbSoftwares";
            this.lsbSoftwares.Size = new System.Drawing.Size(229, 220);
            this.lsbSoftwares.TabIndex = 74;
            this.lsbSoftwares.DragDrop += new System.Windows.Forms.DragEventHandler(this.lsbSoftwares_DragDrop);
            this.lsbSoftwares.DragEnter += new System.Windows.Forms.DragEventHandler(this.lsbSoftwares_DragEnter);
            this.lsbSoftwares.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsbSoftwares_KeyDown);
            // 
            // lblUserCommentCaption
            // 
            this.lblUserCommentCaption.AutoSize = true;
            this.lblUserCommentCaption.Location = new System.Drawing.Point(275, 434);
            this.lblUserCommentCaption.Name = "lblUserCommentCaption";
            this.lblUserCommentCaption.Size = new System.Drawing.Size(98, 18);
            this.lblUserCommentCaption.TabIndex = 73;
            this.lblUserCommentCaption.Text = "us_comment";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(282, 380);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 18);
            this.label6.TabIndex = 72;
            // 
            // lblUserTypeCaption
            // 
            this.lblUserTypeCaption.AutoSize = true;
            this.lblUserTypeCaption.Location = new System.Drawing.Point(275, 124);
            this.lblUserTypeCaption.Name = "lblUserTypeCaption";
            this.lblUserTypeCaption.Size = new System.Drawing.Size(63, 18);
            this.lblUserTypeCaption.TabIndex = 65;
            this.lblUserTypeCaption.Text = "us_type";
            // 
            // txbUserName
            // 
            this.txbUserName.Location = new System.Drawing.Point(302, 84);
            this.txbUserName.Name = "txbUserName";
            this.txbUserName.Size = new System.Drawing.Size(229, 25);
            this.txbUserName.TabIndex = 64;
            // 
            // lblUserNameCaption
            // 
            this.lblUserNameCaption.AutoSize = true;
            this.lblUserNameCaption.Location = new System.Drawing.Point(275, 63);
            this.lblUserNameCaption.Name = "lblUserNameCaption";
            this.lblUserNameCaption.Size = new System.Drawing.Size(70, 18);
            this.lblUserNameCaption.TabIndex = 63;
            this.lblUserNameCaption.Text = "us_name";
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDel.Location = new System.Drawing.Point(143, 596);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(100, 56);
            this.btnDel.TabIndex = 62;
            this.btnDel.Text = "Delete";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(12, 596);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 56);
            this.btnAdd.TabIndex = 61;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // chbShowInactive
            // 
            this.chbShowInactive.AutoSize = true;
            this.chbShowInactive.Location = new System.Drawing.Point(17, 34);
            this.chbShowInactive.Name = "chbShowInactive";
            this.chbShowInactive.Size = new System.Drawing.Size(131, 22);
            this.chbShowInactive.TabIndex = 59;
            this.chbShowInactive.Text = "showInactive";
            this.chbShowInactive.UseVisualStyleBackColor = true;
            this.chbShowInactive.CheckedChanged += new System.EventHandler(this.chbShowInactive_CheckedChanged);
            // 
            // lblUserMasterCaption
            // 
            this.lblUserMasterCaption.AutoSize = true;
            this.lblUserMasterCaption.Location = new System.Drawing.Point(13, 14);
            this.lblUserMasterCaption.Name = "lblUserMasterCaption";
            this.lblUserMasterCaption.Size = new System.Drawing.Size(99, 18);
            this.lblUserMasterCaption.TabIndex = 58;
            this.lblUserMasterCaption.Text = "User Master";
            // 
            // lbxUsers
            // 
            this.lbxUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbxUsers.FormattingEnabled = true;
            this.lbxUsers.ItemHeight = 18;
            this.lbxUsers.Location = new System.Drawing.Point(12, 63);
            this.lbxUsers.Name = "lbxUsers";
            this.lbxUsers.Size = new System.Drawing.Size(229, 526);
            this.lbxUsers.TabIndex = 57;
            this.lbxUsers.SelectedValueChanged += new System.EventHandler(this.lbxUsers_SelectedValueChanged);
            // 
            // cmbUserType
            // 
            this.cmbUserType.FormattingEnabled = true;
            this.cmbUserType.Location = new System.Drawing.Point(302, 146);
            this.cmbUserType.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cmbUserType.Name = "cmbUserType";
            this.cmbUserType.Size = new System.Drawing.Size(229, 26);
            this.cmbUserType.TabIndex = 84;
            // 
            // FrmUserMasterMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 674);
            this.Controls.Add(this.cmbUserType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbUserComment);
            this.Controls.Add(this.chbpUsersActive);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lsbSoftwareMaster);
            this.Controls.Add(this.lsbSoftwares);
            this.Controls.Add(this.lblUserCommentCaption);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblUserTypeCaption);
            this.Controls.Add(this.txbUserName);
            this.Controls.Add(this.lblUserNameCaption);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.chbShowInactive);
            this.Controls.Add(this.lblUserMasterCaption);
            this.Controls.Add(this.lbxUsers);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "FrmUserMasterMaintenance";
            this.Text = "FrmUserMasterMaintenance";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbUserComment;
        private System.Windows.Forms.CheckBox chbpUsersActive;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox lsbSoftwareMaster;
        private System.Windows.Forms.ListBox lsbSoftwares;
        private System.Windows.Forms.Label lblUserCommentCaption;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblUserTypeCaption;
        private System.Windows.Forms.TextBox txbUserName;
        private System.Windows.Forms.Label lblUserNameCaption;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.CheckBox chbShowInactive;
        private System.Windows.Forms.Label lblUserMasterCaption;
        private SortedListBox lbxUsers;
        private System.Windows.Forms.ComboBox cmbUserType;
    }
}