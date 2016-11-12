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
            UpdatePcMaster();
            // ListBoxUserMaster更新
            UpdateUserMaster();


            this.cmbSoftwareOs.Items.Add("Windows");
            this.cmbSoftwareOs.Items.Add("MacOS");
            this.cmbSoftwareOs.Items.Add("Windows/MacOS");
        }

        // ListBoxSoftwares更新
        private void updateSoftList()
        {
            dba.SelectSoftwareMaster();

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

        // 選択変更時
        private void lbxSoftwares_SelectedValueChanged(object sender, EventArgs e)
        {
            selectedSoftware = this.lbxSoftwares.SelectedItem as DbAccessor.SoftwareMaster;

            if (selectedSoftware == null)
            {
                return;
            }
            // 詳細項目クリア


            // 詳細項目値代入
            this.txbSoftwareName.Text = selectedSoftware.name;
            this.txbSoftwareVersion.Text = selectedSoftware.version;
            this.cmbSoftwareOs.SelectedIndex = selectedSoftware.osType -1;
            this.txbSoftAvailable.Text = selectedSoftware.available.ToString();
            this.chbpSoftwareIsActive.Checked = selectedSoftware.active;
            this.txbSoftwareComment.Text = selectedSoftware.comment;
        }

        private void chbShowInactive_CheckedChanged(object sender, EventArgs e)
        {
            updateSoftList();
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

            // ListBoxの更新
            this.updateSoftList();

            // ListBox選択の変更
            for (var i = 0; i < this.lbxSoftwares.Items.Count; i++)
            {
                DbAccessor.SoftwareMaster sf = this.lbxSoftwares.Items[i] as DbAccessor.SoftwareMaster;
                if (sf.id == sfm.id)
                {
                    this.lbxSoftwares.SelectedIndex = i;
                }
            }

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DbAccessor.SoftwareMaster sfm = this.lbxSoftwares.SelectedItem as DbAccessor.SoftwareMaster;
            sfm.active = false;
            this.dba.UpdateSoftwareMaster(sfm);
            // ListBox更新
            this.updateSoftList();

            // 詳細項目値代入
            this.txbSoftwareName.Text = String.Empty;
            this.txbSoftwareVersion.Text = String.Empty;
            this.cmbSoftwareOs.SelectedIndex = -1;
            this.txbSoftAvailable.Text = "";
            this.chbpSoftwareIsActive.Checked = false;
            this.txbSoftwareComment.Text = String.Empty;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // 元データと比較、変更がなければreturn
            // 更新処理を呼び出し
            DbAccessor.SoftwareMaster sfm = this.lbxSoftwares.SelectedItem as DbAccessor.SoftwareMaster;
            sfm.name = this.txbSoftwareName.Text;
            sfm.version = this.txbSoftwareVersion.Text;
            sfm.osType = this.cmbSoftwareOs.SelectedIndex + 1;
            sfm.available = int.Parse(this.txbSoftAvailable.Text);
            sfm.active = this.chbpSoftwareIsActive.Checked;
            sfm.comment = this.txbSoftwareComment.Text;

            this.dba.UpdateSoftwareMaster(sfm);
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
            }
        }

        private bool IsSame(ListBox t, DbAccessor.PcMaster itemPc)
        {

        }

        private void lsbUsers_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DbAccessor.UserMaster)))
            {
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
            }
        }


    }
}
