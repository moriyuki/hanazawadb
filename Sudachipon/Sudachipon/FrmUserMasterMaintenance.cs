using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//private readonly object cmbUserType;

namespace Sudachipon
{
    public partial class FrmUserMasterMaintenance : Form
    {
        DbAccessor dba = DbAccessor.GetInstance();
        DbAccessor.UserMaster selectedUser;

        public FrmUserMasterMaintenance()
        {
            InitializeComponent();

            // ListBoxUsers更新
            updateUserList();
        }

        // ListBoxUsers更新
        private void updateUserList()
        {
            dba.SelectUserMaster();

            this.lbxUsers.Items.Clear();

            foreach (DbAccessor.UserMaster user in dba.UserMasters)
            {
                if (this.chbShowInactive.Checked || user.active)
                {
                    this.lbxUsers.Items.Add(user);
                }

            }

        }

        //選択変更時
        private void lbxUsers_SelectedValueChanged(object sender, EventArgs e)
        {

            selectedUser = this.lbxUsers.SelectedItem as DbAccessor.UserMaster;

            if (selectedUser == null)
            {
                return;
            }


            // 詳細項目値代入
            this.txbUserName.Text = selectedUser.name;
            this.cmbUserType.Text = selectedUser.type.ToString();
            this.chbpSoftwareIsActive.Checked = selectedUser.active;
            this.txbUserComment.Text = selectedUser.comment;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 表示されているデータの更新確認
            // 新しいUserの登録
            // Useritem 生成
            // UserIDを取得
            DbAccessor.UserMaster um = new DbAccessor.UserMaster();
            um.id = um.GetNextId();
            dba.UserMasters.Add(um);

            // ListBoxの更新
            this.updateUserList();

            // ListBox選択の変更
            for (var i = 0; i < this.lbxUsers.Items.Count; i++)
            {
                DbAccessor.UserMaster user = this.lbxUsers.Items[i] as DbAccessor.UserMaster;
                if (user.id == um.id)
                {
                    this.lbxUsers.SelectedIndex = i;
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DbAccessor.UserMaster um = this.lbxUsers.SelectedItem as DbAccessor.UserMaster;
            um.active = false;
            this.dba.UpdateUserMaster(um);
            // ListBox更新
            this.updateUserList();
        }

    }
}
