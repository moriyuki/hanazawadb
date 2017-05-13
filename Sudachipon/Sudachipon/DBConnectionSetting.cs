using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudachipon
{

    // DB接続詞管理
    class DBConnectionSetting
    {
        // 
        const String UADR_HOST = "SudachiponConnStringHost";
        const String UADR_USER = "SudachiponConnStringUser";
        const String UADR_PASSWD = "SudachiponConnStringPasswd";
        const String UADR_DB = "SudachiponConnStringDb";
        public const String CONNECTION_STRING_TEMPLATE = "Server={0};Port=5432;User Id={1};Password={2};Database={3}";

        // properties
        private static String _host;
        public String Host
        {
            get
            {
                return _host;
            }
            set
            {
                _host = value;
            }
        }

        private static String _user;
        public String User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
            }
        }

        private static String _password;
        public String Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }

        private static String _db;
        public String Db
        {
            get
            {
                return _db;
            }
            set
            {
                _db = value;
            }
        }

        // 保存
        public bool SaveSetting()
        {
            try
            {
                Application.UserAppDataRegistry.SetValue(UADR_HOST, _host);
                Application.UserAppDataRegistry.SetValue(UADR_USER, _user);
                Application.UserAppDataRegistry.SetValue(UADR_PASSWD, _password);
                Application.UserAppDataRegistry.SetValue(UADR_DB, _db);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        public void LoadSetting()
        {
            try
            {
                if(Application.UserAppDataRegistry.GetValue(UADR_HOST) != null)
                {
                    this.Host = Application.UserAppDataRegistry.GetValue(UADR_HOST).ToString();
                }

                if (Application.UserAppDataRegistry.GetValue(UADR_USER) != null)
                {
                    this.User = Application.UserAppDataRegistry.GetValue(UADR_USER).ToString();
                }

                if (Application.UserAppDataRegistry.GetValue(UADR_PASSWD) != null)
                {
                    this.Password = Application.UserAppDataRegistry.GetValue(UADR_PASSWD).ToString();
                }

                if (Application.UserAppDataRegistry.GetValue(UADR_DB) != null)
                {
                    this.Db = Application.UserAppDataRegistry.GetValue(UADR_DB).ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 接続文字列を返す
       public  String CreatePostgresConnectionString()
        {
            if (String.IsNullOrEmpty(Host) || 
                String.IsNullOrEmpty(User) ||
                String.IsNullOrEmpty(Password) ||
                String.IsNullOrEmpty(Db))
            {
                return String.Empty;
            }

            return String.Format(CONNECTION_STRING_TEMPLATE, Host, User, Password, Db);
        }

        // 接続文字列を返す
        public static String CreatePostgresConnectionStringForCheck(String host, String user, String password, String db)
        {
            return String.Format(CONNECTION_STRING_TEMPLATE, host, user, password, db);
        }
    }
}
