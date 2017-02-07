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

        public FrmSoftwareMasterMaintenance()
        {
            InitializeComponent();
        }

        private void lbxSoftwares_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
