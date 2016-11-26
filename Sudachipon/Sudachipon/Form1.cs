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
    public partial class Form1 : Form
    {
        // 定数定義
        
        // 変数定義

        // 初期化
        public Form1()
        {
            InitializeComponent();
            
            // dgv値表示
            this.SetDgvPcDateManagerContents();

            // UserList表示
            this.SetUsersList();
        }

        // 内部関数
        // DGV表示
        private void SetDgvPcDateManagerContents()
        {
            // データクリア
            this.dgvPcDateManager.Rows.Clear();
            // カラムもクリアすること

            // 初回表示ならカラムを追加
            // カラム追加
            DataGridViewTextBoxColumn dgvcolPc = new DataGridViewTextBoxColumn();
            dgvcolPc.ReadOnly = true;
            dgvcolPc.Tag = "";
            dgvcolPc.HeaderText = "PCs";
            dgvcolPc.Name = "dgvcolPc";

            // dateカラムを指定回数追加する（31列）
            DataGridViewTextBoxColumn dgvcolDate1 = new DataGridViewTextBoxColumn();
            dgvcolDate1.ReadOnly = true;
            dgvcolDate1.Tag = DateTime.Now.AddDays(0);
            dgvcolDate1.HeaderText = ((DateTime)dgvcolDate1.Tag).ToShortDateString();
            dgvcolDate1.Name = "dgvcolDate1";

            DataGridViewTextBoxColumn dgvcolDisable = new DataGridViewTextBoxColumn();
            dgvcolDisable.ReadOnly = true;
            dgvcolDisable.Visible = false;
            //dgvcolDisable.HeaderText = ((DateTime)dgvcolDate1.Tag).ToShortDateString();
            dgvcolDisable.Name = "dgvcolDisable";

            this.dgvPcDateManager.Columns.AddRange(new DataGridViewColumn[] { dgvcolPc, dgvcolDate1 });

            // レコード追加
            // PCマスタから必要な数を追加する
            this.dgvPcDateManager.Rows.Add(10);

            // データ反映
            // MessageBox.Show(this.dgvPcDateManager.Columns[0].ToString());
            this.dgvPcDateManager.Rows[3].Cells[0].Value = "PC4";
            // this.dgvPcDateManager.Rows[masterData,Pcs[i].order].Cells[0].Value = masterData.Pcs[i].Name;
        }
        
        // userリスト表示
        private void SetUsersList()
        {
            // 初期化
            this.lbxUsers.Items.Clear();

            // データ表示
            // userマスタからユーザを追加
            DbAccessor dba = DbAccessor.GetInstance();
            dba.SelectUserMaster();

            foreach (DbAccessor.UserMaster user in dba.UserMasters)
            {
                if (user.active)
                {
                    this.lbxUsers.Items.Add(user);
                }
            }
        }
        // イベント関数

        // PCマスタ編集画面を表示する
        private void mstPc_Click(object sender, EventArgs e)
        {
            // PCマスタ表示
            FrmPcMasterMaintenance fpmm = new FrmPcMasterMaintenance();
            fpmm.ShowDialog();
        }

        // Softwareマスタ編集画面を表示する
        private void mstSoftware_Click(object sender, EventArgs e)
        {
            // Softwareマスタ表示
            FrmSoftwareMasterMaintenance fsmm = new FrmSoftwareMasterMaintenance();
            fsmm.ShowDialog();
        }

        // Userマスタ編集画面を表示する
        private void msiUser_Click(object sender, EventArgs e)
        {
            // Userマスタ表示
            FrmUserMasterMaintenance fumm = new FrmUserMasterMaintenance();
            fumm.ShowDialog();

        }

        // D&Dイベント用
        private void dgvPcDateManager_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void lbxUsers_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.lbxUsers.SelectedIndex < 0)
            {
                // Userマスターの選択が無ければ終了
                return;
            }

            if (e.Button == MouseButtons.Left)
            {
                ListBox lbx = (ListBox)sender;
                DbAccessor.UserMaster usm = lbx.SelectedItem as DbAccessor.UserMaster;
                DragDropEffects dde = lbx.DoDragDrop(usm, DragDropEffects.All);
            }
        }

        private void dgvPcDateManager_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dgvPcDateManager_DragDrop(object sender, DragEventArgs e)
        {

        }
    }
}
