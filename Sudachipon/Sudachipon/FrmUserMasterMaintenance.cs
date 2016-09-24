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
    public partial class FrmUserMasterMaintenance : Form
    {
        DbAccessor dba = DbAccessor.GetInstance();
        DbAccessor.UserMaster selectedUser;

        public FrmUserMasterMaintenance()
        {
            InitializeComponent();
            dba.SelectUserMaster();

            foreach (DbAccessor.UserMaster user in dba.UserMasters)
            {
                this.lbxUsers.Items.Add(user);
            }
      
  
    }

        //選択ユーザー変更時
        private void lbxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            //selectedUser = this.lbxUsers.SelectedItem as DbAccessor.UserMaster;
    
            // 詳細項目クリア


            // 詳細項目値代入
            this.txbUserName.Text = selectedUser.name;
            this.cmbUserType.Text = selectedUser.type.ToString();
            this.chbpSoftwareIsActive.Checked = selectedUser.active;
            this.txbUserComment.Text = selectedUser.comment;
            
        }

    }
}
