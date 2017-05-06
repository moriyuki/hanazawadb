using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudachipon
{
    public partial class FrmSoftwareMasterMaintenance : Form
    {
        DbAccessor dba = DbAccessor.GetInstance();
        DbAccessor.SoftwareMaster selectedSoftware;

        public FrmSoftwareMasterMaintenance()
        {
            InitializeComponent();

            updateSoftList();

            // ListBoxPcMaster更新
            //UpdatePcMaster();
            // ListBoxUserMaster更新
            //UpdateUserMaster();


            this.cmbSoftwareOs.Items.Add("Windows");
            this.cmbSoftwareOs.Items.Add("MacOS");
            this.cmbSoftwareOs.Items.Add("Windows/MacOS");

            this.btnDel.Enabled = false;
            this.btnUpdate.Enabled = false;
        }

        // ListBoxSoftwares更新
        private void updateSoftList(bool dbreadflag = true)
        {
            if(dbreadflag) dba.SelectSoftwareMaster();

            this.lbxSoftwares.Items.Clear();

            foreach (DbAccessor.SoftwareMaster sm in dba.SoftwareMasters)
            {
                if (this.chbShowInactive.Checked || sm.active)
                {
                    this.lbxSoftwares.Items.Add(sm);
                }
            }

        }

        // ListBoxPCs更新
        private void UpdatePcMaster()
        {
            dba.SelectPcMaster();
            this.lsbPcMaster.Items.Clear();
            foreach (DbAccessor.PcMaster pc in dba.PcMasters)
            {
                if (pc.Active)
                {
                    this.lsbPcMaster.Items.Add(pc);
                }
            }
        }

        // ListBoxUsers更新
        private void UpdateUserMaster()
        {
            dba.SelectUserMaster();
            this.lsbUserMaster.Items.Clear();
            foreach (DbAccessor.UserMaster user in dba.UserMasters)
            {
                if (user.active)
                {
                    this.lsbUserMaster.Items.Add(user);
                }
            }
        }

        // ListBoxPCs更新
        private void UpdatePcSoftData()
        {
            selectedSoftware = this.lbxSoftwares.SelectedItem as DbAccessor.SoftwareMaster;
            dba.SelectPcSoftData(selectedSoftware.id);
            this.lsbPcs.Items.Clear();
            foreach (DbAccessor.PcSoftData pcsoft in dba.PcSoftDatas)
            {
                foreach (DbAccessor.PcMaster pc in dba.PcMasters)
                {
                    if (pcsoft.pcId == pc.Id)
                    {
                        this.lsbPcs.Items.Add(pc);
                    }
                }
            }
        }

        // ListBoxUsers更新
        private void UpdateUserSoftData()
        {
            selectedSoftware = this.lbxSoftwares.SelectedItem as DbAccessor.SoftwareMaster;
            dba.SelectUserSoftData(selectedSoftware.id);
            this.lsbUsers.Items.Clear();
            foreach (DbAccessor.UserSoftData usersoft in dba.UserSoftDatas)
            {
                foreach (DbAccessor.UserMaster user in dba.UserMasters)
                {
                    if (usersoft.userId == user.id)
                    {
                        this.lsbUsers.Items.Add(user);
                    }
                }
            }
        }

        // 選択変更時
        private void lbxSoftwares_SelectedValueChanged(object sender, EventArgs e)
        {
            selectedSoftware = this.lbxSoftwares.SelectedItem as DbAccessor.SoftwareMaster;

            if (selectedSoftware == null)
            {
                this.btnDel.Enabled = false;
                this.btnUpdate.Enabled = false;

                this.lsbPcMaster.Items.Clear();
                this.lsbPcs.Items.Clear();
                this.lsbUserMaster.Items.Clear();
                this.lsbUsers.Items.Clear();
                return;
            }
            // 詳細項目クリア


            // 詳細項目値代入
            this.txbSoftwareName.Text = selectedSoftware.name;
            this.txbSoftwareVersion.Text = selectedSoftware.version;
            this.cmbSoftwareOs.SelectedIndex = selectedSoftware.osType -1;
            //this.txbSoftAvailable.Text = selectedSoftware.available.ToString();
            this.nudPcLicense.Value =selectedSoftware.pcLicense;
            this.nudUserLicense.Value =selectedSoftware.userLicense;
            this.chbpSoftwareIsActive.Checked = selectedSoftware.active;
            this.txbSoftwareComment.Text = selectedSoftware.comment;

            this.btnDel.Enabled = true;
            this.btnUpdate.Enabled = true;

            // ListBoxPcMaster更新
            UpdatePcMaster();
            // ListBoxUserMaster更新
            UpdateUserMaster();
            // ListBoxPcs更新
            UpdatePcSoftData();
            // ListBoxUsers更新
            UpdateUserSoftData();

        }

        private void chbShowInactive_CheckedChanged(object sender, EventArgs e)
        {
            updateSoftList(false);

            this.lsbPcMaster.Items.Clear();
            this.lsbPcs.Items.Clear();
            this.lsbUserMaster.Items.Clear();
            this.lsbUsers.Items.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 表示されているデータの更新確認
            // 新しいSoftwareの登録
            // Softwareitem 生成
            // SoftwareIDを取得
            DbAccessor.SoftwareMaster sfm = new DbAccessor.SoftwareMaster();
            sfm.id = sfm.GetNextId();
            dba.SoftwareMasters.Add(sfm);

            this.dba.UpdateSoftwareMaster(sfm);

            // ListBoxの更新
            this.updateSoftList(false);


            // ListBox選択の変更
            for (var i = 0; i < this.lbxSoftwares.Items.Count; i++)
            {
                DbAccessor.SoftwareMaster sf = this.lbxSoftwares.Items[i] as DbAccessor.SoftwareMaster;
                if (sf.id == sfm.id)
                {
                    this.lbxSoftwares.SelectedIndex = i;
                }
            }

            // ListBoxPcMaster更新
            UpdatePcMaster();
            // ListBoxUserMaster更新
            UpdateUserMaster();
            // ListBoxPcs更新
            UpdatePcSoftData();
            // ListBoxUsers更新
            UpdateUserSoftData();



        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DbAccessor.SoftwareMaster sfm = this.lbxSoftwares.SelectedItem as DbAccessor.SoftwareMaster;
            sfm.active = false;
            this.dba.UpdateSoftwareMaster(sfm);
            // ListBox更新
            this.updateSoftList(false);

            // 詳細項目値代入
            this.txbSoftwareName.Text = String.Empty;
            this.txbSoftwareVersion.Text = String.Empty;
            this.cmbSoftwareOs.SelectedIndex = -1;
            //this.txbSoftAvailable.Text = "";
            this.chbpSoftwareIsActive.Checked = false;
            this.txbSoftwareComment.Text = String.Empty;

            this.btnDel.Enabled = false;
            this.btnUpdate.Enabled = false;

            this.lsbPcMaster.Items.Clear();
            this.lsbPcs.Items.Clear();
            this.lsbUserMaster.Items.Clear();
            this.lsbUsers.Items.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // nameが空欄、空白の場合は処理終了
            if (!cmn.ValidationCheck_NameIsNotNull(this.txbSoftwareName.Text))
            {
                return;
            }
            //PC-License数の上限のチェック
            if ((int)this.nudPcLicense.Value >= 0 && this.lsbPcs.Items.Count > (int)this.nudPcLicense.Value)
            {
                MessageBox.Show("PCライセンス数の上限を超えています！", "注意", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //User-License数の上限のチェック
            if ((int)this.nudUserLicense.Value >= 0 && this.lsbUsers.Items.Count > (int)this.nudUserLicense.Value)
            {
                MessageBox.Show("Userライセンス数の上限を超えています！", "注意", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // 元データと比較、変更がなければreturn
            // 更新処理を呼び出し
            DbAccessor.SoftwareMaster sfm = this.lbxSoftwares.SelectedItem as DbAccessor.SoftwareMaster;
            sfm.name = this.txbSoftwareName.Text;
            sfm.version = this.txbSoftwareVersion.Text;
            sfm.osType = this.cmbSoftwareOs.SelectedIndex + 1;
            //sfm.available = int.Parse(this.txbSoftAvailable.Text);
            sfm.pcLicense = (int)this.nudPcLicense.Value;
            sfm.userLicense = (int)this.nudUserLicense.Value;
            sfm.active = this.chbpSoftwareIsActive.Checked;
            sfm.comment = this.txbSoftwareComment.Text;

            this.dba.UpdateSoftwareMaster(sfm);

            updateSoftList(false);

            for (var i = 0; i < this.lbxSoftwares.Items.Count; i++)
            {
                DbAccessor.SoftwareMaster sf = this.lbxSoftwares.Items[i] as DbAccessor.SoftwareMaster;
                if (sf.id == sfm.id)
                {
                    this.lbxSoftwares.SelectedIndex = i;
                }
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lsbPcMaster_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.lbxSoftwares.SelectedIndex < 0)
            {
                // SoftwareMaster選択が無ければ終了
                return;
            }


            if (e.Button == MouseButtons.Left)
            {
                ListBox lbx = (ListBox)sender;
                DbAccessor.PcMaster pcm = lbx.SelectedItem as DbAccessor.PcMaster;
                DragDropEffects dde = lbx.DoDragDrop(pcm, DragDropEffects.All);
            }
        }

        private void lsbUserMaster_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.lbxSoftwares.SelectedIndex < 0)
            {
                // SoftwareMaster選択が無ければ終了
                return;
            }

            if (e.Button == MouseButtons.Left)
            {
                ListBox lbx = (ListBox)sender;
                DbAccessor.UserMaster usm = lbx.SelectedItem as DbAccessor.UserMaster;
                DragDropEffects dde = lbx.DoDragDrop(usm, DragDropEffects.All);
            }
        }

        private void lsbPcs_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DbAccessor.PcMaster)))
            {
                ListBox target = (ListBox)sender;
                DbAccessor.PcMaster itemPc = (DbAccessor.PcMaster)e.Data.GetData(typeof(DbAccessor.PcMaster));
                //同一PCは許可しない！
                foreach (DbAccessor.PcMaster item in target.Items)
                {
                    if (item.Id == itemPc.Id)
                    {
                        return;
                    }
                }
                //License数の上限のチェック
                if((int)this.nudPcLicense.Value >= 0 && this.lsbPcs.Items.Count >= (int)this.nudPcLicense.Value)
                {
                    return;
                }

                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void lsbPcs_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DbAccessor.PcMaster)))
            {
                ListBox target = (ListBox)sender;
                DbAccessor.PcMaster itemPc = (DbAccessor.PcMaster)e.Data.GetData(typeof(DbAccessor.PcMaster));
                target.Items.Add(itemPc);

                //DB insert
                DbAccessor.SoftwareMaster sfm = this.lbxSoftwares.SelectedItem as DbAccessor.SoftwareMaster;
                this.dba.InsertPcSoftData(itemPc, sfm.id);
            }
        }

        private bool IsSame(ListBox t, DbAccessor.PcMaster itemPc)
        {
            return false;
        }

        private void lsbUsers_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DbAccessor.UserMaster)))
            {
                ListBox target = (ListBox)sender;
                DbAccessor.UserMaster itemUser = (DbAccessor.UserMaster)e.Data.GetData(typeof(DbAccessor.UserMaster));
                foreach (DbAccessor.UserMaster item in target.Items)
                {
                    if (item.id == itemUser.id)
                    {
                        return;
                    }
                }
                //License数の上限のチェック
                if ((int)this.nudUserLicense.Value >= 0 && this.lsbUsers.Items.Count >= (int)this.nudUserLicense.Value)
                {
                    return;
                }


                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void lsbUsers_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DbAccessor.UserMaster)))
            {
                ListBox target = (ListBox)sender;
                DbAccessor.UserMaster itemUser = (DbAccessor.UserMaster)e.Data.GetData(typeof(DbAccessor.UserMaster));
                target.Items.Add(itemUser);

                //DB insert
                DbAccessor.SoftwareMaster sfm = this.lbxSoftwares.SelectedItem as DbAccessor.SoftwareMaster;
                this.dba.InsertUserSoftData(itemUser, sfm.id);
            }
        }

        private void lsbPcs_KeyDown(object sender, KeyEventArgs e)
        {
            // 削除用　keydown
            if ((e.KeyCode == Keys.Delete) || (e.KeyCode == Keys.Back))
            {
                DbAccessor.PcMaster pc = (DbAccessor.PcMaster)this.lsbPcs.SelectedItem;

                if (pc == null)
                {
                    return;
                }

                if (DialogResult.OK != MessageBox.Show("選択したPCを削除します", "caution", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                {
                    return;
                }
                else
                {
                    // 削除
                    lsbPcs.Items.Remove(pc);
                    //DB delete
                    DbAccessor.SoftwareMaster sfm = this.lbxSoftwares.SelectedItem as DbAccessor.SoftwareMaster;
                    this.dba.DeletePcSoftData(pc, sfm.id);

                }

            }
        }

        private void lsbUsers_KeyDown(object sender, KeyEventArgs e)
        {
            // 削除用　keydown
            if ((e.KeyCode == Keys.Delete) || (e.KeyCode == Keys.Back))
            {
                DbAccessor.UserMaster us = (DbAccessor.UserMaster)this.lsbUsers.SelectedItem;

                if (us == null)
                {
                    return;
                }

                if (DialogResult.OK != MessageBox.Show("選択したユーザーを削除します", "caution", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                {
                    return;
                }
                else
                {
                    // 削除
                    lsbUsers.Items.Remove(us);
                    //DB delete
                    DbAccessor.SoftwareMaster sfm = this.lbxSoftwares.SelectedItem as DbAccessor.SoftwareMaster;
                    this.dba.DeleteUserSoftData(us, sfm.id);

                }

            }
        }

        private void txbSoftwareName_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbSoftwareOs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
