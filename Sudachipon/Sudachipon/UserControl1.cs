using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudachipon
{
    public partial class UserControl1 : UserControl
    {

            private DateTime _date;
            private DbAccessor.UserMaster _prevuser;
            private DbAccessor.UserMaster _newuser;

            public UserControl1()
            {
                InitializeComponent();

                this.lblDate.Text = _date.ToString("MM/dd (ddd)");
                if (_prevuser == null)
                {
                    this.lblPrevUser.Text = "";
                }
                else
                {
                    this.lblPrevUser.Text = _prevuser.name;
                }

                if (_newuser == null)
                {
                    this.lblNewUser.Text = "";
                }
                else
                {
                    this.lblNewUser.Text = _newuser.name;
                }
            }

            public DateTime Date
            {
                get
                {
                    return _date;
                }
                set
                {
                    _date = value;
                }
            }

            public DbAccessor.UserMaster PrevUser
            {
                get
                {
                    return _prevuser;
                }
                set
                {
                    _prevuser = value;
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
        }
    }
