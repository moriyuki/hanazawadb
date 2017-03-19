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
        private DbAccessor.UserMaster _newuser;

        private bool _deleteflag;

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

        public DbAccessor.UserMaster NewUser
        {
            get
            {
                return _newuser;
            }
            set
            {
                _newuser = value;
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
            _deleteflag = false;

        }

        public FrmRepeatRegst(bool deleteon)
        {
            InitializeComponent();
            _deleteflag = true;
            btnReplace.Text = "削除";
            label4.Text = "";

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.lblPCName.Text = _pc.Name;

            DbAccessor dba = DbAccessor.GetInstance();

//

            for (int i = 0; i < 5; i++)
            {
                UserControl1 mycontrol = new UserControl1();
                
                if(_deleteflag == true)   mycontrol = new UserControl1(true);
                

                mycontrol.Name = "ucmycontrol" + i.ToString();
                mycontrol.Size = new System.Drawing.Size(700, 30);
                mycontrol.Location = new System.Drawing.Point(10, 10 +35 * i);
                mycontrol.TabIndex = 0;
                mycontrol.Date = this.StartDate.AddDays(7 * i);
                if (mycontrol.Date.Month != this.StartDate.Month) break;
                mycontrol.NewUser = this.NewUser;
                mycontrol.PrevUser = dba.SelectPcUserDateData(mycontrol.Date, _pc);

                this.panel1.Controls.Add(mycontrol);
            }
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            foreach(UserControl1 mycontorl in this.panel1.Controls)
            {
                if (_deleteflag == false)
                {

                    if (mycontorl.UpdateFlag == true)
                    {
                        //System.Windows.Forms.MessageBox.Show(mycontorl.PrevUser.name + " + " + mycontorl.NewUser.name);
                        DbAccessor dba = DbAccessor.GetInstance();
                        if (mycontorl.PrevUser != null)
                        {
                            dba.UpdatePcUserDateData(mycontorl.Date, PC.Id, mycontorl.PrevUser.id, mycontorl.NewUser.id);
                        }
                        else {
                            dba.InsertPcUserDateData(mycontorl.Date, PC.Id, mycontorl.NewUser.id);
                        }
                    }
                } else
                {
                    if (mycontorl.UpdateFlag == true)
                    {
                        //System.Windows.Forms.MessageBox.Show(mycontorl.PrevUser.name + " + " + mycontorl.NewUser.name);
                        DbAccessor dba = DbAccessor.GetInstance();
                        if (mycontorl.PrevUser != null)
                        {
                            dba.DeletePcUserDateData(mycontorl.Date, PC.Id, mycontorl.PrevUser.id);
                        }
                    }
                }

        }

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
