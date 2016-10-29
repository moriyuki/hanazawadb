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
    public partial class FrmPcMasterMaintenance : Form
    {
        DbAccessor dba = DbAccessor.GetInstance();
        DbAccessor.PcMaster selectedPc;
        DbAccessor.PcMaster AlterCheckPcData;

        public FrmPcMasterMaintenance()
        {
            InitializeComponent();

            dba.SelectPcMaster();

            // ListBoxPCs更新
            UpdatePcList();
            // ListBoxSoftMaster更新
            UpdateSoftwareMaster();
        }

        // ListBoxPCs更新
        private void UpdatePcList()
        {

            this.lbxPcs.Items.Clear();

            foreach (DbAccessor.PcMaster pc in dba.PcMasters)
            {
                if (this.chbShowInactive.Checked || pc.Active)
                {
                    this.lbxPcs.Items.Add(pc);
                }
            }

            // 非選択時は詳細項目空欄
            if (this.lbxPcs.SelectedIndex < 0)
            {
                // 詳細項目クリア
                this.txbPcName.Text = String.Empty;
                this.txbPcCpu.Text = String.Empty;
                this.txbPcMemory.Text = String.Empty;
                this.txbPcOs.Text = String.Empty;
                this.chbPcIsByod.Checked = false;
                this.chbpPcIsActive.Checked = false;
                this.txbComment.Text = String.Empty;
            }
        }

        // ListBoxPCs更新
        private void UpdateSoftwareMaster()
        {
            dba.SelectSoftwareMaster();
            this.lbxSoftMaster.Items.Clear();
            foreach (DbAccessor.SoftwareMaster soft in dba.SoftwareMasters)
            {
                if (soft.active)
                {
                    this.lbxSoftMaster.Items.Add(soft);
                }
            }
        }
        // 選択変更時
        private void lbxPcs_SelectedValueChanged(object sender, EventArgs e)
        {
            selectedPc = this.lbxPcs.SelectedItem as DbAccessor.PcMaster;

            if (selectedPc == null || this.lbxPcs.SelectedIndex < 0)
            {
                // 詳細項目クリア
                this.txbPcName.Text = String.Empty;
                this.txbPcCpu.Text = String.Empty;
                this.txbPcMemory.Text = String.Empty;
                this.txbPcOs.Text = String.Empty;
                this.chbPcIsByod.Checked = false;
                this.chbpPcIsActive.Checked = false;
                this.txbComment.Text = String.Empty;
            }
            else
            {
                // 詳細項目値代入
                this.txbPcName.Text = selectedPc.Name;
                this.txbPcCpu.Text = selectedPc.Cpu;
                this.txbPcMemory.Text = selectedPc.Memory;
                this.txbPcOs.Text = selectedPc.Os;
                this.chbPcIsByod.Checked = selectedPc.IsByod;
                this.chbpPcIsActive.Checked = selectedPc.Active;
                this.txbComment.Text = selectedPc.Comment;

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 表示されているデータの更新確認
            // 新しいPCの登録
            // PCitem 生成
            // PCIDを取得
            DbAccessor.PcMaster pcm = new DbAccessor.PcMaster();
            pcm.Id = pcm.GetNextId();
            dba.PcMasters.Add(pcm);

            // ListBoxの更新
            this.UpdatePcList();

            // ListBox選択の変更
            //foreach ( object lbxPc in this.lbxPcs.Items)
            for (var i = 0; i < this.lbxPcs.Items.Count; i++)
            {
                DbAccessor.PcMaster pc = this.lbxPcs.Items[i] as DbAccessor.PcMaster;
                if (pc.Id == pcm.Id)
                {
                    this.lbxPcs.SelectedIndex = i;
                }
            }

        }

        // deleteボタンクリック時
        private void btnDel_Click(object sender, EventArgs e)
        {
            DbAccessor.PcMaster pcm = this.lbxPcs.SelectedItem as DbAccessor.PcMaster;
            pcm.Active = false;
            this.dba.UpdatePcMaster(pcm);
            // ListBox更新
            dba.SelectPcMaster();
            this.UpdatePcList();

            // 詳細項目値代入
            this.txbPcName.Text = String.Empty;
            this.txbPcCpu.Text = String.Empty;
            this.txbPcMemory.Text = String.Empty;
            this.txbPcOs.Text = String.Empty;
            this.chbPcIsByod.Checked = false;
            this.chbpPcIsActive.Checked = false;
            this.txbComment.Text = String.Empty;
        }

        // updateボタンクリック時
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // 元データと比較、変更がなければreturn
            // 更新処理を呼び出し
            DbAccessor.PcMaster pcm = this.lbxPcs.SelectedItem as DbAccessor.PcMaster;
            //DbAccessor.PcMaster pcm = new DbAccessor.PcMaster();
            pcm.Name = this.txbPcName.Text;
            pcm.Os = this.txbPcOs.Text;
            pcm.Cpu = this.txbPcCpu.Text;
            pcm.Memory = this.txbPcMemory.Text;
            pcm.IsByod = this.chbPcIsByod.Checked;
            pcm.Active = this.chbpPcIsActive.Checked;
            pcm.Comment = this.txbComment.Text;

            this.dba.UpdatePcMaster(pcm);
        }

        // Closeボタンクリック時
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ShowInactiveチェック変更時
        private void chbShowInactive_CheckedChanged(object sender, EventArgs e)
        {
            dba.SelectPcMaster();
            // ListBox更新
            this.UpdatePcList();
        }

        // Drag Drop
        private void lbxSoftMaster_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.lbxPcs.SelectedIndex < 0)
            {
                // PCマスターの選択が無ければ終了
                return;    
            }

            if (e.Button == MouseButtons.Left)
            {
                ListBox lbx = (ListBox)sender;
                DbAccessor.SoftwareMaster sfm = lbx.SelectedItem as DbAccessor.SoftwareMaster;
                DragDropEffects dde = lbx.DoDragDrop(sfm, DragDropEffects.All);
            }
        }

        private void lbxSoft_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DbAccessor.SoftwareMaster)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void lbxSoft_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DbAccessor.SoftwareMaster)))
            {
                ListBox target = (ListBox)sender;
                DbAccessor.SoftwareMaster itemSoftware = (DbAccessor.SoftwareMaster)e.Data.GetData(typeof(DbAccessor.SoftwareMaster));
                target.Items.Add(itemSoftware);
            }
        }
    }
}
