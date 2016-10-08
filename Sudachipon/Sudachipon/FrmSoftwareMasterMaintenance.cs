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
    }
}
