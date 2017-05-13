using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Sudachipon
{
    public partial class Form1 : Form
    {
        // 定数定義
        private ToolStripStatusLabel tssl;
        // 変数定義
        public DateTime StartDate;
        public int LimitNumberOfDate;

        // 初期化
        public Form1()
        {
            InitializeComponent();

            //Default Setting
            this.LimitNumberOfDate = 31;
            this.StartDate = DateTime.Now.Date;

            // dgv値表示
            this.SetDgvPcDateManagerContents();

            // UserList表示
            this.SetUsersList();

            this.tssl = new ToolStripStatusLabel();
            this.stsMessage.Items.Add(tssl);
            tssl.Text = "hello";
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

            // データクリア
            this.dgvPcDateManager.Columns.Clear();
            this.dgvPcDateManager.Columns.Add(dgvcolPc);

            // dateカラムを指定回数追加する（31列）
            //           DataGridViewTextBoxColumn dgvcolDate1 = new DataGridViewTextBoxColumn();
            //           dgvcolDate1.ReadOnly = true;
            //           dgvcolDate1.Tag = DateTime.Now.AddDays(0);
            //           dgvcolDate1.HeaderText = ((DateTime)dgvcolDate1.Tag).ToShortDateString();
            //           dgvcolDate1.Name = "dgvcolDate1";
            dgvPcDateManager.EnableHeadersVisualStyles = false;
            // dgvPcDateManager.ColumnHeadersDefaultCellStyle.BackColor = Color.Red;

            DataGridViewTextBoxColumn[] dgvcolDate = new DataGridViewTextBoxColumn[this.LimitNumberOfDate];
            for (int i = 0; i < this.LimitNumberOfDate; i++)
            {
                dgvcolDate[i] = new DataGridViewTextBoxColumn();
                dgvcolDate[i].ReadOnly = true;
                //dgvcolDate[i].Tag = DateTime.Now.AddDays(i);
                dgvcolDate[i].Tag = StartDate.AddDays(i);
                dgvcolDate[i].HeaderText = ((DateTime)dgvcolDate[i].Tag).ToString("MM/dd (ddd)");
                dgvcolDate[i].Name = "dgvcolDate" + i.ToString();
                dgvcolDate[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                // paint weekend
                if (((DateTime)dgvcolDate[i].Tag).DayOfWeek == DayOfWeek.Saturday || ((DateTime)dgvcolDate[i].Tag).DayOfWeek == DayOfWeek.Sunday) {
                    dgvcolDate[i].HeaderCell.Style.BackColor = Color.Gray;
                    dgvcolDate[i].DefaultCellStyle.BackColor = Color.LightGray;
                }
            }

            // test
            this.dgvPcDateManager.Columns.AddRange(dgvcolDate);
            


            DataGridViewTextBoxColumn dgvcolDisable = new DataGridViewTextBoxColumn();
            dgvcolDisable.ReadOnly = true;
            dgvcolDisable.Visible = false;
            //dgvcolDisable.HeaderText = ((DateTime)dgvcolDate1.Tag).ToShortDateString();
            dgvcolDisable.Name = "dgvcolDisable";

            //           this.dgvPcDateManager.Columns.AddRange(new DataGridViewColumn[] { dgvcolPc, dgvcolDate1 });

            // レコード追加
            // PCマスタから必要な数を追加する
            // this.dgvPcDateManager.Rows.Add(10);

            // データ反映
            // MessageBox.Show(this.dgvPcDateManager.Columns[0].ToString());
            // this.dgvPcDateManager.Rows[3].Cells[0].Value = "PC4";
            // this.dgvPcDateManager.Rows[masterData,Pcs[i].order].Cells[0].Value = masterData.Pcs[i].Name;

            DbAccessor dba = DbAccessor.GetInstance();
            dba.SelectPcMaster();
            int activePcNumber = 0;
            for (int i = 0; i < dba.PcMasters.Count; i++)
            {
                if (dba.PcMasters[i].Active)
                {
                    activePcNumber += 1;
                }
            }

            //Get PcMaster,UserMaster,PcUserDate from DB
            dba.SelectPcMaster();
            dba.SelectUserMaster();
            dba.SelectPcUserDateData(this.StartDate, this.LimitNumberOfDate);

            // add row
            DataGridViewRow[] rows = new DataGridViewRow[activePcNumber];
            int j = 0;
            for (int i = 0; i < dba.PcMasters.Count; i++)
            {
                if (!dba.PcMasters[i].Active)
                {
                    continue;
                }
                rows[j] = new DataGridViewRow();
                rows[j].CreateCells(this.dgvPcDateManager);
                // this.dgvPcDateManager.Rows.Add(1);
                rows[j].Cells[0].Value = dba.PcMasters[i];

                //SetRowsFromPcUserDateData((DataGridViewRow)rows[j], this.StartDate, this.LimitNumberOfDate);

                j++;
            }
            SetRowsFromPcUserDateData(rows, activePcNumber, this.StartDate, this.LimitNumberOfDate);

            this.dgvPcDateManager.Rows.AddRange(rows);

            //SetRowsFromPcUserDateData(activePcNumber, this.StartDate, this.LimitNumberOfDate);
        }

        // SetRows from PcUserDateDate
        private void SetRowsFromPcUserDateData(DataGridViewRow[] rows, int activepc,DateTime startdate, int limitnum)
        {
            DbAccessor dba = DbAccessor.GetInstance();

            for (int k = 0; k < activepc; k++)
            {
                DbAccessor.PcMaster pc = (DbAccessor.PcMaster)rows[k].Cells[0].Value;

                foreach (DbAccessor.PcUserDateData pud in dba.PcUserDateDatas)
                {
                    if (pc.Id == pud.PcId)
                    {
                        for (int i = 0; i < limitnum; i++)
                        {
                            if (startdate.AddDays(i) == pud.Date)
                            {
                                foreach (DbAccessor.UserMaster user in dba.UserMasters)
                                {
                                    if ((user.id == pud.UserId) && user.active) rows[k].Cells[i + 1].Value = user;
                                }
                            }
                        }
                    }
                }
            }


        }

        private void SetRowsFromPcUserDateData(DataGridViewRow row, DateTime startdate, int limitnum)
        {
            DbAccessor.PcMaster pc = (DbAccessor.PcMaster)row.Cells[0].Value;
            DbAccessor dba = DbAccessor.GetInstance();

            foreach (DbAccessor.PcUserDateData pud in dba.PcUserDateDatas)
            {
                if (pc.Id == pud.PcId)
                {
                    for (int i=0; i < limitnum; i++)
                    {
                        if (startdate.AddDays(i) == pud.Date)
                        {
                            foreach (DbAccessor.UserMaster user in dba.UserMasters)
                            {
                                if ((user.id == pud.UserId) && user.active) row.Cells[i + 1].Value = user;
                            }
                        }
                    }
                }
            }
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

            // なぜかtrueに変えた瞬間しか並び替えが実行されない
            this.lbxUsers.Sorted = false;
            this.lbxUsers.Sorted = true;

        }
        // イベント関数

        // PCマスタ編集画面を表示する
        private void mstPc_Click(object sender, EventArgs e)
        {
            // PCマスタ表示
            FrmPcMasterMaintenance fpmm = new FrmPcMasterMaintenance();
            fpmm.ShowDialog();

            //メイン画面のデータグリッドビューを更新する
            SetDgvPcDateManagerContents();

        }

        // Softwareマスタ編集画面を表示する
        private void mstSoftware_Click(object sender, EventArgs e)
        {
            // Softwareマスタ表示
            FrmSoftwareMasterMaintenance fsmm = new FrmSoftwareMasterMaintenance();
            fsmm.ShowDialog();

            //メイン画面のデータグリッドビューを更新する
            SetDgvPcDateManagerContents();

        }

        // Userマスタ編集画面を表示する
        private void msiUser_Click(object sender, EventArgs e)
        {
            // Userマスタ表示
            FrmUserMasterMaintenance fumm = new FrmUserMasterMaintenance();
            fumm.ShowDialog();

            //メイン画面のデータグリッドビューを更新する
            SetDgvPcDateManagerContents();

        }

        // D&Dイベント用
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

        private void dgvPcDateManager_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DbAccessor.UserMaster)))
            {
                DataGridView target = (DataGridView)sender;
                DbAccessor.UserMaster itemuser = (DbAccessor.UserMaster)e.Data.GetData(typeof(DbAccessor.UserMaster));
                // 空欄チェック
                // 

                //DataGridView.HitTestInfo info = ((DataGridView)sender).HitTest(e.X, e.Y);
                // Console.WriteLine("" + this.dgvPcDateManager.CurrentCell.RowIndex + " " + this.dgvPcDateManager.CurrentCell.ColumnIndex);

                //Point clientPoint = this.dgvPcDateManager.PointToClient(new Point(e.X, e.Y));
                //DataGridView.HitTestInfo hit = this.dgvPcDateManager.HitTest(clientPoint.X, clientPoint.Y);
                //if (this.dgvPcDateManager.Rows[hit.RowIndex].Cells[hit.ColumnIndex].Value != null)
                //{
                //    MessageBox.Show("値を上書きします。よろしいですか？", "注意", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                //}

                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

        }

        private void dgvPcDateManager_DragDrop(object sender, DragEventArgs e)
        {
            // DragDropイベント
            if (e.Data.GetDataPresent(typeof(DbAccessor.UserMaster)))
            {
                DataGridView target = (DataGridView)sender;
                DbAccessor.UserMaster itemUser = (DbAccessor.UserMaster)e.Data.GetData(typeof(DbAccessor.UserMaster));

                Point clientPoint = this.dgvPcDateManager.PointToClient(new Point(e.X, e.Y));
                DataGridView.HitTestInfo hit = this.dgvPcDateManager.HitTest(clientPoint.X, clientPoint.Y);

                if (this.chkRepeatRegst.Checked == false) { 

                // Console.WriteLine("" + hit.RowIndex + " " + hit.ColumnIndex);
                if (this.dgvPcDateManager.Rows[hit.RowIndex].Cells[hit.ColumnIndex].Value != null)
                {
                    if (MessageBox.Show("値を上書きします。よろしいですか？", "注意", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        // DB update
                        DbAccessor.PcMaster pc = (DbAccessor.PcMaster)this.dgvPcDateManager.Rows[hit.RowIndex].Cells[0].Value;
                        DateTime currentdate = this.StartDate.AddDays(hit.ColumnIndex - 1);
                        DbAccessor dba = DbAccessor.GetInstance();
                        DbAccessor.UserMaster oldUser = (DbAccessor.UserMaster)this.dgvPcDateManager.Rows[hit.RowIndex].Cells[hit.ColumnIndex].Value;
                        dba.UpdatePcUserDateData(currentdate, pc.Id, oldUser.id, itemUser.id);

                        this.dgvPcDateManager.Rows[hit.RowIndex].Cells[hit.ColumnIndex].Value = itemUser;

                    }
                }
                else
                {
                    this.dgvPcDateManager.Rows[hit.RowIndex].Cells[hit.ColumnIndex].Value = itemUser;

                    // DB insert
                    DbAccessor.PcMaster pc = (DbAccessor.PcMaster)this.dgvPcDateManager.Rows[hit.RowIndex].Cells[0].Value;
                    DateTime currentdate = this.StartDate.AddDays(hit.ColumnIndex - 1);
                    DbAccessor dba = DbAccessor.GetInstance();
                    dba.InsertPcUserDateData(currentdate, pc.Id, itemUser.id);
                }

                } else { 
                //Test Test
                FrmRepeatRegst fm = new FrmRepeatRegst();
                fm.PC = (DbAccessor.PcMaster)this.dgvPcDateManager.Rows[hit.RowIndex].Cells[0].Value;
                    fm.NewUser = itemUser;
                    fm.StartDate = this.StartDate.AddDays(hit.ColumnIndex - 1);
                    fm.ShowDialog();
                    SetDgvPcDateManagerContents();
                    // DB 更新
                }
            }
        }


        private void dgvPcDateManager_KeyDown(object sender, KeyEventArgs e)
        {
            // 削除用　keydown
            if ((e.KeyCode == Keys.Delete) || (e.KeyCode == Keys.Back))
            {
                if (chkRepeatRegst.Checked == false)
                {

                    for (int cou = 0; cou < this.dgvPcDateManager.SelectedCells.Count; cou++)
                    {


                        if (this.dgvPcDateManager.SelectedCells[cou].Value != null)
                        {
                            DbAccessor dba = DbAccessor.GetInstance();
                            DbAccessor.UserMaster user = (DbAccessor.UserMaster)(this.dgvPcDateManager.SelectedCells[cou].Value);
                            DbAccessor.PcMaster pc = (DbAccessor.PcMaster)this.dgvPcDateManager.Rows[this.dgvPcDateManager.SelectedCells[cou].RowIndex].Cells[0].Value;
                            DateTime currentdate = this.StartDate.AddDays(this.dgvPcDateManager.SelectedCells[cou].ColumnIndex - 1);

                            String strmessage;
                            strmessage = "選択したユーザー:" + user.name + "を削除します";

                            if (DialogResult.OK != MessageBox.Show(strmessage, "caution", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                            {
                                continue;
                            }
                            else
                            {
                                //DB delete
                                dba.DeletePcUserDateData(currentdate, pc.Id, user.id);
                                // 削除
                                this.dgvPcDateManager.SelectedCells[cou].Value = null;

                            }

                        }

                    }
                } else
                {
                    for (int cou = 0; cou < this.dgvPcDateManager.SelectedCells.Count; cou++)
                    {
                        // forms
                        DbAccessor dba = DbAccessor.GetInstance();
                        DbAccessor.UserMaster user = (DbAccessor.UserMaster)(this.dgvPcDateManager.SelectedCells[cou].Value);
                        DbAccessor.PcMaster pc = (DbAccessor.PcMaster)this.dgvPcDateManager.Rows[this.dgvPcDateManager.SelectedCells[cou].RowIndex].Cells[0].Value;
                        DateTime currentdate = this.StartDate.AddDays(this.dgvPcDateManager.SelectedCells[cou].ColumnIndex - 1);
                        FrmRepeatRegst fm = new FrmRepeatRegst(true);
                        fm.PC = pc;
                        fm.StartDate = currentdate;
                        fm.ShowDialog();
                    }
                    SetDgvPcDateManagerContents();
                }
            }
    }

        private void msiImport_Click(object sender, EventArgs e)
        {
            // ファイルを選択するダイアログを表示させる
            this.openFileDialog.Title = "バックアップファイルを選択してください。";
            this.openFileDialog.ShowReadOnly = true;

            this.openFileDialog.FileName = "";
            this.openFileDialog.Filter = "SQLファイル (*.sql)|*.sql|すべてのファイル (*.*)|*.*";
            this.openFileDialog.DefaultExt = "sql";
            this.openFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            this.openFileDialog.Multiselect = false;


            if (DialogResult.OK == this.openFileDialog.ShowDialog())
            {
                this.openFileDialog.OpenFile();
            }
        }


        private void msiExport_Click(object sender, EventArgs e)
        {
            // ダンプを実行し、ファイルをダイアログを介して保存する
            this.saveFileDialog.Title = "データベースのバックアップ先を指定してください。";
            DateTime dt = DateTime.Now;
            this.saveFileDialog.FileName = "hanazawadb_" + dt.ToString("yyyyMMdd_HHmm");
            this.saveFileDialog.DefaultExt = "sql";
            this.saveFileDialog.Filter = "backup files (*.sql)|*.sql";

            String before = Application.ExecutablePath;
            this.saveFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(before);

            DialogResult result = this.saveFileDialog.ShowDialog();

            // Stream fileStream;

            if (result == DialogResult.OK)
            {
                //fileStream = this.saveFileDialog.OpenFile();
                //fileStream.Close();
                DbAccessor dba = DbAccessor.GetInstance();
                dba.DBDump(this.saveFileDialog.FileName);
            }
        }

        // DB設定ダイアログを表示
        private void msiDBSetting_Click(object sender, EventArgs e)
        {
            DBSetting dbs = new DBSetting();
            dbs.ShowDialog();
        }


        // CSVの文字列用にダブルコーテーションを付加する処理
        private String ConvertCSVString(String str)
        {
            const Char DoubleQuote = '"';

            StringBuilder sbcsvstr = new StringBuilder();

            sbcsvstr.Append(DoubleQuote);

            for(int i=0;i<str.Length;i++)
            {
                if(str[i] == DoubleQuote)
                {
                    sbcsvstr.Append(DoubleQuote);
                    sbcsvstr.Append(DoubleQuote);
                } else
                {
                    sbcsvstr.Append(str[i]);
                }
            }

            sbcsvstr.Append(DoubleQuote);

            return sbcsvstr.ToString();
        }


        // CSV出力
        private void msiCsvExport_Click(object sender, EventArgs e)
        {
            if (DialogResult.No == MessageBox.Show("CSVデータを出力します。よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                return;
            }

            /// todo カンマ区切りのデータ作成
            StringBuilder sb = new StringBuilder();
            List<int> pcIds = new List<int>();
            DbAccessor dba = DbAccessor.GetInstance();
            foreach (DbAccessor.PcMaster pcm in dba.PcMasters)
            {
                if (pcm.Active)
                {
                    sb.Append(",");
                    sb.Append(ConvertCSVString(pcm.Name));
                    pcIds.Add(pcm.Id);
                }
            }
            sb.Append("\r\n");

            DateTime n = DateTime.Now;
            DateTime startDate = new DateTime(n.Year, n.Month, 1);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);

            /// 当月1か月間のデータのみ出力対象にする
            DateTime tmpDate = startDate;
            while(tmpDate <= endDate)
            {
                sb.Append(tmpDate.ToShortDateString());

                // PcId
                foreach (int pcid in pcIds)
                {
                    sb.Append(",");

                    foreach (DbAccessor.PcUserDateData pcudd in dba.PcUserDateDatas)
                    {
                        // Date 
                        if (pcudd.Date == tmpDate)
                        {
                            if (pcudd.PcId == pcid)
                            {
                                // User
                                foreach (DbAccessor.UserMaster um in dba.UserMasters)
                                {
                                    if (um.id == pcudd.UserId)
                                    {
                                        sb.Append(ConvertCSVString(um.name));
                                    }
                                }
                            }
                        }
                    }
                }
                tmpDate = tmpDate.AddDays(1);
                sb.Append("\r\n");
            }
           
            this.csvSaveFileDialog.Title = "CSVファイルの保存先を指定してください。";
            DateTime dt = DateTime.Now;
            this.csvSaveFileDialog.FileName = "hanazawacsv_" + dt.ToString("yyyyMMdd_HHmm");
            this.csvSaveFileDialog.DefaultExt = "csv";
            this.csvSaveFileDialog.Filter = "csv files (*.csv)|*.csv";

            String before = Application.ExecutablePath;
            this.csvSaveFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(before);

            DialogResult result = this.csvSaveFileDialog.ShowDialog();

            // Stream fileStream;

            if (result == DialogResult.OK)
            {

                using (StreamWriter sw = File.AppendText(this.csvSaveFileDialog.FileName))
                {
                    sw.Write(sb.ToString());
                }

            }
        }
    }
}

