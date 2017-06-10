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
    public partial class DBSetting : Form
    {
        private static DBConnectionSetting dbcs;
        public DBSetting()
        {
            InitializeComponent();
        }

        private void DBSetting_Load(object sender, EventArgs e)
        {
            dbcs = new DBConnectionSetting();
            dbcs.LoadSetting();

            this.txbHost.Text = dbcs.Host;
            this.txbUser.Text = dbcs.User;
            this.txbPasswd.Text = dbcs.Password;
            this.txbDb.Text = dbcs.Db;

        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            dbcs.Host = this.txbHost.Text;
            dbcs.User = this.txbUser.Text;
            dbcs.Password = this.txbPasswd.Text;
            dbcs.Db = this.txbDb.Text;

            dbcs.SaveSetting();
            this.Close();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            DbAccessor dba = DbAccessor.GetInstance();
            //if (dba.DbConnectionCheck())
            //{
            //    MessageBox.Show("false");
            //}
            //else
            //{
            //    MessageBox.Show("false");
            //}
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
