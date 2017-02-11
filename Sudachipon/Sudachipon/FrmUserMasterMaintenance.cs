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

            //コンボボックスに値を追加
            this.cmbUserType.Items.Add("利用者");
            this.cmbUserType.Items.Add("管理者");

            // ListBoxUsers更新
            updateUserList();
            // ListBoxSoftMaster更新
            UpdateSoftwareMaster();
        }

        // ListBoxUsers更新
        private void updateUserList()
        {
            //dba.SelectUserMaster();

            this.lbxUsers.Items.Clear();

            foreach (DbAccessor.UserMaster user in dba.UserMasters)
            {
                if (this.chbShowInactive.Checked || user.active)
                {
                    this.lbxUsers.Items.Add(user);
                }

            }

            // 非選択時は詳細項目空欄
            if (this.lbxUsers.SelectedIndex < 0)
            {
                // 詳細項目クリア
                this.txbUserName.Text = String.Empty;
                this.cmbUserType.Text = String.Empty;
                this.chbpUsersActive.Checked = false;
                this.txbUserComment.Text = String.Empty;
            }

        }

        // ListBoxUsers更新
        private void UpdateUserMaster()
        {
            dba.SelectUserMaster();
            this.lbxUsers.Items.Clear();
            foreach (DbAccessor.UserMaster user in dba.UserMasters)
            {
                if (user.active)
                {
                    this.lbxUsers.Items.Add(user);
                }
            }
        }

        // ListBoxPCs更新
        private void UpdateSoftwareMaster()
        {
            dba.SelectSoftwareMaster();
            this.lsbSoftwareMaster.Items.Clear();
            foreach (DbAccessor.SoftwareMaster soft in dba.SoftwareMasters)
            {
                if (soft.active)
                {
                    this.lsbSoftwareMaster.Items.Add(soft);
                }
            }
        }

        //選択変更時
        private void lbxUsers_SelectedValueChanged(object sender, EventArgs e)
        {
            selectedUser = this.lbxUsers.SelectedItem as DbAccessor.UserMaster;
            if (selectedUser == null || this.lbxUsers.SelectedIndex < 0)
            {
                // 詳細項目クリア
                this.txbUserName.Text = String.Empty;
                this.cmbUserType.Text = String.Empty;
                this.chbpUsersActive.Checked = false;
                this.txbUserComment.Text = String.Empty;
            }
            else
            {
                // 詳細項目値代入
                this.txbUserName.Text = selectedUser.name;
                string typeNum = selectedUser.type.ToString();
                
                //コンボボックス数字から置換
                if (typeNum == "1")
                {
                    this.cmbUserType.Text = "利用者";  
                }
                else
                {
                    this.cmbUserType.Text = "管理者";
                }

                //this.cmbUserType.Text = selectedUser.type.ToString();
                this.chbpUsersActive.Checked = selectedUser.active;
                this.txbUserComment.Text = selectedUser.comment;
            }
        }

        //addボタンクリック
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 表示されているデータの更新確認
            // 新しいUserの登録
            // Useritem 生成
            // UserIDを取得
            DbAccessor.UserMaster um = new DbAccessor.UserMaster();
            um.id = um.GetNextId();
            um.name = "New Person";
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


        //deleteボタンクリック
        private void btnDel_Click(object sender, EventArgs e)
        {
            DbAccessor.UserMaster um = this.lbxUsers.SelectedItem as DbAccessor.UserMaster;
            um.active = false;
            this.dba.UpdateUserMaster(um);

            // ListBox更新
            dba.SelectUserMaster();
            this.updateUserList();

            this.txbUserName.Text = String.Empty;
            this.cmbUserType.Text = String.Empty;
            this.chbpUsersActive.Checked = false;
            this.txbUserComment.Text = String.Empty;

        }

        //アップデートボタンクリック
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // 元データと比較、変更がなければreturn
            // 更新処理を呼び出し
            DbAccessor.UserMaster um =this.lbxUsers.SelectedItem as DbAccessor.UserMaster;

            um.name = this.txbUserName.Text;
            if (this.cmbUserType.Text == "1") 
            {
                um.type = 1;
            }
            else
            {
                um.type = 2;
            }

            //um.type = this.cmbUserType.Text.ToString();
            um.active = this.chbpUsersActive.Checked;
            um.comment = this.txbUserComment.Text;

            this.dba.UpdateUserMaster(um);
            this.updateUserList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chbShowInactive_CheckedChanged(object sender, EventArgs e)
        {
            dba.SelectUserMaster();
            // ListBox更新
            this.updateUserList();
        }


        private void lsbSoftwareMaster_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.lbxUsers.SelectedIndex < 0)
            {
                // Userマスターの選択が無ければ終了
                return;
            }


            if (e.Button == MouseButtons.Left)
            {
                ListBox lbx = (ListBox)sender;
                DbAccessor.SoftwareMaster sfm = lbx.SelectedItem as DbAccessor.SoftwareMaster;
                DragDropEffects dde = lbx.DoDragDrop(sfm, DragDropEffects.All);

            }
        }

        private void lsbSoftwares_DragEnter(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(typeof(DbAccessor.SoftwareMaster)))
            {
                ListBox target = (ListBox)sender;
                DbAccessor.SoftwareMaster itemSoftware = (DbAccessor.SoftwareMaster)e.Data.GetData(typeof(DbAccessor.SoftwareMaster));
                foreach (DbAccessor.SoftwareMaster item in target.Items)
                {
                    if (item.id == itemSoftware.id)
                    {
                        return;
                    }
                }
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void lsbSoftwares_DragDrop(object sender, DragEventArgs e)
        {
           
            if (e.Data.GetDataPresent(typeof(DbAccessor.SoftwareMaster)))
            {
                ListBox target = (ListBox)sender;
                DbAccessor.SoftwareMaster itemSoftware = (DbAccessor.SoftwareMaster)e.Data.GetData(typeof(DbAccessor.SoftwareMaster));
                target.Items.Add(itemSoftware);
            }
        }

        private void lsbSoftwares_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.lbxUsers.SelectedIndex < 0 || this.lsbSoftwares.SelectedIndex <0)
            {
                // Userマスターの選択が無ければ終了
                return;
            }

            // 削除用　keydown
          if ((e.KeyCode == Keys.Delete) || (e.KeyCode == Keys.Back))
           {
               DbAccessor.SoftwareMaster soft = (DbAccessor.SoftwareMaster)this.lsbSoftwareMaster.SelectedItem;

                if (soft == null)
                {
                    return;
                }

                if (DialogResult.OK != MessageBox.Show("選択したソフトウェアを削除します", "caution", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                {
                    return;
                }
                else
                {
                this.lsbSoftwares.Items.Remove(soft);
             }

            }
        }
    }
}
