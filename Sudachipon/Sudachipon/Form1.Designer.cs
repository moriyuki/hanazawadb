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
            this.lblUsersCaption = new System.Windows.Forms.Label();
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
            this.lbxUsers.Location = new System.Drawing.Point(1375, 84);
            this.lbxUsers.Name = "lbxUsers";
            this.lbxUsers.Size = new System.Drawing.Size(170, 346);
            this.lbxUsers.TabIndex = 0;
            this.lbxUsers.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbxUsers_MouseDown);
            // 
            // dgvPcDateManager
            // 
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
            this.dgvPcDateManager.Size = new System.Drawing.Size(1313, 407);
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
            this.msiUser});
            this.msMasters.Location = new System.Drawing.Point(0, 0);
            this.msMasters.Name = "msMasters";
            this.msMasters.Size = new System.Drawing.Size(1557, 33);
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
            // lblUsersCaption
            // 
            this.lblUsersCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsersCaption.AutoSize = true;
            this.lblUsersCaption.Location = new System.Drawing.Point(1375, 45);
            this.lblUsersCaption.Name = "lblUsersCaption";
            this.lblUsersCaption.Size = new System.Drawing.Size(51, 18);
            this.lblUsersCaption.TabIndex = 4;
            this.lblUsersCaption.Text = "Users";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1557, 455);
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
    }
}

