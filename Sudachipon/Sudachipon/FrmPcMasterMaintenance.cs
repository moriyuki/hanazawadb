﻿using System;
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
            dba.SelectPcSoftData(dba.PcSoftDatas);

            this.btnDel.Enabled = false;

            // ListBoxPCs更新
            UpdatePcList();
            // ListBoxSoftMaster更新
            UpdateSoftwareMaster();

            this.cmbPcOs.Items.Add("Windows");
            this.cmbPcOs.Items.Add("MacOS");
            this.cmbPcOs.Items.Add("Windows/MacOS");
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
                this.cmbPcOs.SelectedIndex = -1;
                this.chbPcIsByod.Checked = false;
                this.chbpPcIsActive.Checked = false;
                this.txbComment.Text = String.Empty;

                this.txbPcName.Enabled = false;
                this.txbPcCpu.Enabled = false;
                this.txbPcMemory.Enabled = false;
                this.chbPcIsByod.Enabled = false;
                this.chbpPcIsActive.Enabled = false;
                this.txbComment.Enabled = false;
                this.lbxSoft.Items.Clear();
                this.lbxSoft.Enabled = false;
                this.lbxSoftMaster.Enabled = false;
                this.btnDel.Enabled = false;

            }
            else
            {
                this.txbPcName.Enabled = true;
                this.txbPcCpu.Enabled = true;
                this.txbPcMemory.Enabled = true;
                this.chbPcIsByod.Enabled = true;
                this.chbpPcIsActive.Enabled = true;
                this.txbComment.Enabled = true;
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
                this.cmbPcOs.SelectedIndex = -1;
                this.chbPcIsByod.Checked = false;
                this.chbpPcIsActive.Checked = false;
                this.txbComment.Text = String.Empty;

                this.txbPcName.Enabled = false;
                this.txbPcCpu.Enabled = false;
                this.txbPcMemory.Enabled = false;
                this.chbPcIsByod.Enabled = false;
                this.chbpPcIsActive.Enabled = false;
                this.txbComment.Enabled = false;
                this.btnDel.Enabled = false;
                this.lbxSoft.Items.Clear();
                this.lbxSoft.Enabled = false;
                this.lbxSoftMaster.Enabled = false;
            }
            else
            {
                // 詳細項目値代入
                this.txbPcName.Text = selectedPc.Name;
                this.txbPcCpu.Text = selectedPc.Cpu;
                this.txbPcMemory.Text = selectedPc.Memory;
               
                this.cmbPcOs.SelectedIndex = selectedPc.Os -1;
                this.chbPcIsByod.Checked = selectedPc.IsByod;
                this.chbpPcIsActive.Checked = selectedPc.Active;
                this.txbComment.Text = selectedPc.Comment;

                this.txbPcName.Enabled = true;
                this.txbPcCpu.Enabled = true;
                this.txbPcMemory.Enabled = true;
                this.chbPcIsByod.Enabled = true;
                this.chbpPcIsActive.Enabled = true;
                this.txbComment.Enabled = true;
                this.lbxSoft.Enabled = true;
                this.lbxSoftMaster.Enabled = true;

                // pc-soft項目
                this.lbxSoft.Items.Clear();
                foreach (DbAccessor.PcSoftData data in dba.PcSoftDatas)
                {
                    if (data.pcId == selectedPc.Id)
                    {
                        foreach (DbAccessor.SoftwareMaster soft in dba.SoftwareMasters)
                        {
                            if (data.softId == soft.id)
                            {
                                this.lbxSoft.Items.Add(soft);
                            }
                        }
                    }
                }
                if (selectedPc.Active)
                {
                    this.btnDel.Enabled = true;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 追加作業は、Addボタン押下、データ入力、Saveボタン押下
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
            this.cmbPcOs.SelectedIndex = -1;
            this.chbPcIsByod.Checked = false;
            this.chbpPcIsActive.Checked = false;
            this.txbComment.Text = String.Empty;
        }

        // updateボタンクリック時
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // nameが空欄、空白の場合は処理終了
            if (!cmn.ValidationCheck_NameIsNotNull(this.txbPcName.Text))
            {
                return;
            }

            // 元データと比較、変更がなければreturn
            // 更新処理を呼び出し
            DbAccessor.PcMaster pcm = this.lbxPcs.SelectedItem as DbAccessor.PcMaster;
            //DbAccessor.PcMaster pcm = new DbAccessor.PcMaster();
            pcm.Name = this.txbPcName.Text;
            //pcm.Os = int.Parse(this.txbPcOs.Text);
            pcm.Os = this.cmbPcOs.SelectedIndex + 1;
            pcm.Cpu = this.txbPcCpu.Text;
            pcm.Memory = this.txbPcMemory.Text;
            pcm.IsByod = this.chbPcIsByod.Checked;
            pcm.Active = this.chbpPcIsActive.Checked;
            pcm.Comment = this.txbComment.Text;

            // todo: transaction 処理がほしい
            // PCMaster UPDATE
            this.dba.UpdatePcMaster(pcm);

            // PC Soft Data UPDATE
            this.dba.MargePcSoftData(pcm);

            // 表示更新
            this.dba.SelectPcMaster();
            this.UpdatePcList();
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
            this.lbxPcs.SelectedIndex = -1;
            
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

        private void lbxSoft_DragDrop(object sender, DragEventArgs e)
        {
            // DragDropイベント
            if (e.Data.GetDataPresent(typeof(DbAccessor.SoftwareMaster)))
            {
                ListBox target = (ListBox)sender;
                DbAccessor.SoftwareMaster itemSoftware = (DbAccessor.SoftwareMaster)e.Data.GetData(typeof(DbAccessor.SoftwareMaster));
                // DB 更新 -> 内部データ更新
                DbAccessor.PcMaster pcm = this.lbxPcs.SelectedItem as DbAccessor.PcMaster;
                // Create PcSoftDataInstance;
                DbAccessor.PcSoftData psd = new DbAccessor.PcSoftData();
                psd.pcId = pcm.Id;
                psd.softId = itemSoftware.id;

                // Softwareのライセンス上限を超えていないかチェック。超えている場合はメッセージを表示し終了
                // ライセンス上限値確認
                int licenseCount = 0;
                for (int i = 0; i < this.dba.SoftwareMasters.Count; i++)
                {
                    if (this.dba.SoftwareMasters[i].id == itemSoftware.id)
                    {
                        licenseCount = this.dba.SoftwareMasters[i].pcLicense;
                        break;
                    }
                }

                // 現在のライセンス数確認
                int licensedPcCount = 0;
                for (int i = 0; i < this.dba.PcSoftDatas.Count; i++)
                {
                    if (this.dba.PcSoftDatas[i].softId == itemSoftware.id)
                    {
                        licensedPcCount += 1;
                    }
                }

                // ライセンス数チェック
                if (licenseCount < 0)
                {
                    // no problem
                }
                else if (licenseCount <= licensedPcCount)
                {
                    // show error message
                    MessageBox.Show("ライセンス数の上限値を超えるため、追加できません","注意",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    // do nothing
                }

                // 画面上のリストボックスに追加
                target.Items.Add(itemSoftware);

                // 内部データに追加
                this.dba.PcSoftDatas.Add(psd);
            }
        }

        // 
        private void lbxSoft_KeyDown(object sender, KeyEventArgs e)
        {
            // 削除用　keydown
           if ((e.KeyCode == Keys.Delete) || (e.KeyCode == Keys.Back))
            {
                DbAccessor.SoftwareMaster soft = (DbAccessor.SoftwareMaster)this.lbxSoft.SelectedItem;

                if (soft == null)
                {
                    return;
                }

                if (DialogResult.OK != MessageBox.Show("選択したソフトウェアを削除します","caution",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning))
                {
                    return;
                }
                else
                {
                    this.lbxSoft.Items.Remove(soft);
                    DbAccessor.PcMaster pcm = this.lbxPcs.SelectedItem as DbAccessor.PcMaster;
                    // todo listから除外する
                    for (int i = 0; i < dba.PcSoftDatas.Count -1; i++)
                    {
                        if (dba.PcSoftDatas[i].pcId == pcm.Id && dba.PcSoftDatas[i].softId == soft.id )
                        {
                            dba.PcSoftDatas.Remove(dba.PcSoftDatas[i]);
                        }
                    }
                    // this.dba.DeletePcSoftData(pcm, soft.id);
                }
            }
        }

        private void lbxSoft_Leave(object sender, EventArgs e)
        {
            this.lbxSoft.SelectedIndex = -1;
        }
    }
}
