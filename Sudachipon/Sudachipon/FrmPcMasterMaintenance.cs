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

        public FrmPcMasterMaintenance()
        {
            InitializeComponent();
            dba.SelectPcMaster();

            this.lbxPcs.Items.Clear();
            
            // ListBoxPCs更新
            updatePcList();
        }

        // ListBoxPCs更新
        private void updatePcList()
        {
            this.lbxPcs.Items.Clear();

            foreach (DbAccessor.PcMaster pc in dba.PcMasters)
            {
                this.lbxPcs.Items.Add(pc);
            }

        }
        // 選択変更時
        private void lbxPcs_SelectedValueChanged(object sender, EventArgs e)
        {
            if (sender == null){ 
                return;
            }

            selectedPc = this.lbxPcs.SelectedItem as DbAccessor.PcMaster;

            // 詳細項目クリア


            // 詳細項目値代入
            this.txbPcName.Text = selectedPc.Name;
            this.txbPcCpu.Text = selectedPc.Cpu;
            this.txbPcMemory.Text = selectedPc.Memory;
            this.txbPcOs.Text = selectedPc.Os;
            this.chbPcIsByod.Checked = selectedPc.IsByod;
            this.chbpPcIsActive.Checked = selectedPc.Active;
            this.txbComment.Text = selectedPc.Comment;
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
            this.updatePcList();

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

        private void btnDel_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // 元データと比較、変更がなければreturn
            // 更新処理を呼び出し
            DbAccessor.PcMaster pcm = this.lbxPcs.SelectedItem as DbAccessor.PcMaster;
            //DbAccessor.PcMaster pcm = new DbAccessor.PcMaster();
            pcm.Name = this.txbPcName.Text;
            pcm.Os = this.txbPcOs.Text;

            this.dba.UpdatePcMaster(pcm);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
