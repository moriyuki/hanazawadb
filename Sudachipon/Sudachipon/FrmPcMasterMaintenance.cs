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

            
            foreach (DbAccessor.PcMaster pc in dba.PcMasters)
            {
                this.lbxPcs.Items.Add(pc);
            }
        }

        // 選択変更時
        private void lbxPcs_SelectedValueChanged(object sender, EventArgs e)
        {
            //if (sender == null){ 
            //    return;
            //}

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

        private void lbxPcs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
