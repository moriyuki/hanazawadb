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
    public partial class FrmRepeatRegst : Form
    {
        private DbAccessor.PcMaster _pc;
        private DateTime _startdate;

        public DbAccessor.PcMaster PC
        {
            get
            {
                return _pc;
            }
            set
            {
                _pc = value;
            }
        }

        public DateTime StartDate
        {
            get
            {
                return _startdate;
            }
            set
            {
                _startdate = value;
            }
        }



        public FrmRepeatRegst()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.lblPCName.Text = _pc.Name;

            UserControl1 mycontrol = new UserControl1();

            this.panel1.Controls.Add(mycontrol);
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
