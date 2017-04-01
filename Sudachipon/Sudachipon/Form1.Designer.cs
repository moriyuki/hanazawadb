namespace Sudachipon
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.lbxUsers = new System.Windows.Forms.ListBox();
            this.dgvPcDateManager = new System.Windows.Forms.DataGridView();
            this.msMasters = new System.Windows.Forms.MenuStrip();
            this.mstPc = new System.Windows.Forms.ToolStripMenuItem();
            this.mstSoftware = new System.Windows.Forms.ToolStripMenuItem();
            this.msiUser = new System.Windows.Forms.ToolStripMenuItem();
            this.msiSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.msiImport = new System.Windows.Forms.ToolStripMenuItem();
            this.msiExport = new System.Windows.Forms.ToolStripMenuItem();
            this.msiDBSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.lblUsersCaption = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.chkRepeatRegst = new System.Windows.Forms.CheckBox();
            this.msiCsvExport = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPcDateManager)).BeginInit();
            this.msMasters.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbxUsers
            // 
            this.lbxUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxUsers.FormattingEnabled = true;
            this.lbxUsers.ItemHeight = 18;
            this.lbxUsers.Location = new System.Drawing.Point(1415, 106);
            this.lbxUsers.Name = "lbxUsers";
            this.lbxUsers.Size = new System.Drawing.Size(171, 364);
            this.lbxUsers.TabIndex = 0;
            this.lbxUsers.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbxUsers_MouseDown);
            // 
            // dgvPcDateManager
            // 
            this.dgvPcDateManager.AllowDrop = true;
            this.dgvPcDateManager.AllowUserToAddRows = false;
            this.dgvPcDateManager.AllowUserToDeleteRows = false;
            this.dgvPcDateManager.AllowUserToResizeRows = false;
            this.dgvPcDateManager.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPcDateManager.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPcDateManager.Location = new System.Drawing.Point(33, 36);
            this.dgvPcDateManager.Name = "dgvPcDateManager";
            this.dgvPcDateManager.RowHeadersVisible = false;
            this.dgvPcDateManager.RowTemplate.Height = 27;
            this.dgvPcDateManager.Size = new System.Drawing.Size(1343, 441);
            this.dgvPcDateManager.TabIndex = 2;
            this.dgvPcDateManager.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvPcDateManager_DragDrop);
            this.dgvPcDateManager.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgvPcDateManager_DragEnter);
            this.dgvPcDateManager.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvPcDateManager_KeyDown);
            // 
            // msMasters
            // 
            this.msMasters.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.msMasters.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mstPc,
            this.mstSoftware,
            this.msiUser,
            this.msiSetting});
            this.msMasters.Location = new System.Drawing.Point(0, 0);
            this.msMasters.Name = "msMasters";
            this.msMasters.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.msMasters.Size = new System.Drawing.Size(1637, 33);
            this.msMasters.TabIndex = 3;
            this.msMasters.Text = "menuStrip1";
            // 
            // mstPc
            // 
            this.mstPc.Name = "mstPc";
            this.mstPc.Size = new System.Drawing.Size(45, 29);
            this.mstPc.Text = "PC";
            this.mstPc.Click += new System.EventHandler(this.mstPc_Click);
            // 
            // mstSoftware
            // 
            this.mstSoftware.Name = "mstSoftware";
            this.mstSoftware.Size = new System.Drawing.Size(94, 29);
            this.mstSoftware.Text = "Software";
            this.mstSoftware.Click += new System.EventHandler(this.mstSoftware_Click);
            // 
            // msiUser
            // 
            this.msiUser.Name = "msiUser";
            this.msiUser.Size = new System.Drawing.Size(59, 29);
            this.msiUser.Text = "User";
            this.msiUser.Click += new System.EventHandler(this.msiUser_Click);
            // 
            // msiSetting
            // 
            this.msiSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msiImport,
            this.msiExport,
            this.msiDBSetting,
            this.msiCsvExport});
            this.msiSetting.Name = "msiSetting";
            this.msiSetting.Size = new System.Drawing.Size(80, 29);
            this.msiSetting.Text = "Setting";
            // 
            // msiImport
            // 
            this.msiImport.Name = "msiImport";
            this.msiImport.Size = new System.Drawing.Size(211, 30);
            this.msiImport.Text = "Import";
            this.msiImport.Click += new System.EventHandler(this.msiImport_Click);
            // 
            // msiExport
            // 
            this.msiExport.Name = "msiExport";
            this.msiExport.Size = new System.Drawing.Size(211, 30);
            this.msiExport.Text = "Export";
            this.msiExport.Click += new System.EventHandler(this.msiExport_Click);
            // 
            // msiDBSetting
            // 
            this.msiDBSetting.Name = "msiDBSetting";
            this.msiDBSetting.Size = new System.Drawing.Size(211, 30);
            this.msiDBSetting.Text = "DBSetting";
            this.msiDBSetting.Click += new System.EventHandler(this.msiDBSetting_Click);
            // 
            // lblUsersCaption
            // 
            this.lblUsersCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsersCaption.AutoSize = true;
            this.lblUsersCaption.Location = new System.Drawing.Point(1658, 50);
            this.lblUsersCaption.Name = "lblUsersCaption";
            this.lblUsersCaption.Size = new System.Drawing.Size(0, 18);
            this.lblUsersCaption.TabIndex = 4;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // chkRepeatRegst
            // 
            this.chkRepeatRegst.AutoSize = true;
            this.chkRepeatRegst.Location = new System.Drawing.Point(1415, 50);
            this.chkRepeatRegst.Name = "chkRepeatRegst";
            this.chkRepeatRegst.Size = new System.Drawing.Size(175, 22);
            this.chkRepeatRegst.TabIndex = 5;
            this.chkRepeatRegst.Text = "繰り返し登録/削除";
            this.chkRepeatRegst.UseVisualStyleBackColor = true;
            // 
            // msiCsvExport
            // 
            this.msiCsvExport.Name = "msiCsvExport";
            this.msiCsvExport.Size = new System.Drawing.Size(211, 30);
            this.msiCsvExport.Text = "CSV Export";
            this.msiCsvExport.Click += new System.EventHandler(this.msiCsvExport_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1637, 489);
            this.Controls.Add(this.chkRepeatRegst);
            this.Controls.Add(this.lblUsersCaption);
            this.Controls.Add(this.dgvPcDateManager);
            this.Controls.Add(this.lbxUsers);
            this.Controls.Add(this.msMasters);
            this.MainMenuStrip = this.msMasters;
            this.Name = "Form1";
            this.Text = "Sudachipon";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPcDateManager)).EndInit();
            this.msMasters.ResumeLayout(false);
            this.msMasters.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxUsers;
        private System.Windows.Forms.DataGridView dgvPcDateManager;
        private System.Windows.Forms.MenuStrip msMasters;
        private System.Windows.Forms.ToolStripMenuItem mstPc;
        private System.Windows.Forms.ToolStripMenuItem mstSoftware;
        private System.Windows.Forms.ToolStripMenuItem msiUser;
        private System.Windows.Forms.Label lblUsersCaption;
        private System.Windows.Forms.ToolStripMenuItem msiSetting;
        private System.Windows.Forms.ToolStripMenuItem msiImport;
        private System.Windows.Forms.ToolStripMenuItem msiExport;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.CheckBox chkRepeatRegst;
        private System.Windows.Forms.ToolStripMenuItem msiDBSetting;
        private System.Windows.Forms.ToolStripMenuItem msiCsvExport;
    }
}

