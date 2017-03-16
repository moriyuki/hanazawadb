namespace Sudachipon
{
    partial class UserControl1
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.chkUpdate = new System.Windows.Forms.CheckBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblPrevUser = new System.Windows.Forms.Label();
            this.lblNewUser = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chkUpdate
            // 
            this.chkUpdate.AutoSize = true;
            this.chkUpdate.Checked = true;
            this.chkUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUpdate.Location = new System.Drawing.Point(4, 4);
            this.chkUpdate.Name = "chkUpdate";
            this.chkUpdate.Size = new System.Drawing.Size(48, 16);
            this.chkUpdate.TabIndex = 0;
            this.chkUpdate.Text = "更新";
            this.chkUpdate.UseVisualStyleBackColor = true;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(113, 4);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(35, 12);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "label1";
            // 
            // lblPrevUser
            // 
            this.lblPrevUser.AutoSize = true;
            this.lblPrevUser.Location = new System.Drawing.Point(255, 5);
            this.lblPrevUser.Name = "lblPrevUser";
            this.lblPrevUser.Size = new System.Drawing.Size(35, 12);
            this.lblPrevUser.TabIndex = 2;
            this.lblPrevUser.Text = "label2";
            // 
            // lblNewUser
            // 
            this.lblNewUser.AutoSize = true;
            this.lblNewUser.Location = new System.Drawing.Point(445, 4);
            this.lblNewUser.Name = "lblNewUser";
            this.lblNewUser.Size = new System.Drawing.Size(35, 12);
            this.lblNewUser.TabIndex = 3;
            this.lblNewUser.Text = "label3";
            // 
            // UserControl2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblNewUser);
            this.Controls.Add(this.lblPrevUser);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.chkUpdate);
            this.Name = "UserControl2";
            this.Size = new System.Drawing.Size(675, 24);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkUpdate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblPrevUser;
        private System.Windows.Forms.Label lblNewUser;
    }
}
