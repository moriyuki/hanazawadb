using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;

namespace Sudachipon
{
    // DB Access Class, Data Model Class
    class DbAccessor
    {
        // 別途設定ファイル外出で設定できるようにする
        const String CONN_STRING = @"Server=192.168.11.3;Port=5432;User Id=postgres;Password=hanazawa0108;Database=Sudachipon";

        // singleton
        private static DbAccessor _DbAccessor = new DbAccessor();
        public static DbAccessor GetInstance()
        {
            return _DbAccessor;
        }

        private DbAccessor()
        {
            // 接続文字列生成。DbConnectionは生成しない。（再接続の手間を減らすため）
        }

        // SELECT Execute
        NpgsqlDataReader exeuteSql(String sql)
        {
            // NpgsqlDataReader ret = new NpgsqlDataReader();

            if (string.IsNullOrEmpty(sql))
            {
                return null;
            }

            using (var conn = new NpgsqlConnection(CONN_STRING))
            {
                conn.Open();

                var command = new NpgsqlCommand(sql, conn);
                // System.Windows.Forms.MessageBox.Show("record number",String.Format("{0}", (int)command.ExecuteScalar()));
                var dataReader = command.ExecuteReader();

                return dataReader;
            }
        }

        // INSERT UPDATE Execute
        int executeNonSql(String sql)
        {
            using (var conn = new NpgsqlConnection(CONN_STRING))
            {
                var command = new NpgsqlCommand(sql, conn);
                return command.ExecuteNonQuery();
            }
        }
        // ========================= DB access =========================
        public
        void SelectPcMaster()
        {
            String sql = "select * from mt_pc;";

            using (var conn = new NpgsqlConnection(CONN_STRING))
            {
                conn.Open();

                var command = new NpgsqlCommand(sql, conn);
                // System.Windows.Forms.MessageBox.Show("record number",String.Format("{0}", (int)command.ExecuteScalar()));
                var dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    PcMaster pm = new PcMaster();
                    
                    pm.Id = int.Parse(String.Format("{0}",dataReader["pc_id"]));
                    pm.Name = String.Format("{0}", dataReader["pc_name"]);
                    pm.Os = String.Format("{0}", dataReader["pc_os"]);
                    pm.Memory = String.Format("{0}", dataReader["pc_memory"]);
                    pm.Cpu = String.Format("{0}", dataReader["pc_cpu"]);
                    pm.Active = bool.Parse(String.Format("{0}", dataReader["pc_active"]));
                    pm.IsByod = bool.Parse(String.Format("{0}", dataReader["pc_is_byod"]));
                    pm.Comment = String.Format("{0}", dataReader["pc_comment"]);

                    this.PcMasters.Add(pm);
                   // System.Windows.Forms.MessageBox.Show(String.Format("{0}", dataReader[0]));
                }
            }
        }

        void SelectSoftwareMaster()
        {
            String sql = "select * from mt_soft;";

            using (var conn = new NpgsqlConnection(CONN_STRING))
            {
                conn.Open();

                var command = new NpgsqlCommand(sql, conn);
                // System.Windows.Forms.MessageBox.Show("record number",String.Format("{0}", (int)command.ExecuteScalar()));
                var dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    SoftwareMaster sm = new SoftwareMaster();
                    sm.createData();

                    sm.id = int.Parse(String.Format("{0}", dataReader["sf_id"]));
                    sm.name = String.Format("{0}", dataReader["sf_name"]);
                    sm.version = String.Format("{0}", dataReader["sf_version"]);
                    sm.osType = int.Parse(String.Format("{0}", dataReader["sf_os"]));
                    sm.available = int.Parse(String.Format("{0}", dataReader["sf_available"]));
                    sm.active = bool.Parse(String.Format("{0}", dataReader["sf_active"]));
                    sm.comment = String.Format("{0}", dataReader["sf_comment"]);

                    this.SoftwareMasters.Add(sm);
                    // System.Windows.Forms.MessageBox.Show(String.Format("{0}", dataReader[0]));
                }
            }
        }

        public void SelectUserMaster()
        {
            String sql = "select * from mt_user;";

            using (var conn = new NpgsqlConnection(CONN_STRING))
            {
                conn.Open();

                var command = new NpgsqlCommand(sql, conn);
                // System.Windows.Forms.MessageBox.Show("record number",String.Format("{0}", (int)command.ExecuteScalar()));
                var dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    UserMaster um = new UserMaster();
                    um.createData();

                    um.id = int.Parse(String.Format("{0}", dataReader["us_id"]));
                    um.name = String.Format("{0}", dataReader["us_name"]);
                    um.type = int.Parse(String.Format("{0}", dataReader["us_type"]));
                    um.active = bool.Parse(String.Format("{0}", dataReader["us_active"]));
                    um.comment = String.Format("{0}", dataReader["us_comment"]);

                    this.UserMasters.Add(um);
                    // System.Windows.Forms.MessageBox.Show(String.Format("{0}", dataReader[0]));
                }
            }
        }

        public
        void UpdatePcMaster(PcMaster pcm)
        {
            StringBuilder sbupdatesql = new StringBuilder();
            sbupdatesql.Append("update mt_pc set ");
            sbupdatesql.Append("pc_name = '" + pcm.Name + "', ");
            sbupdatesql.Append("pc_os = '" + pcm.Os + "' ");
            sbupdatesql.Append("where pc_id = " + pcm.Id + ";");

            StringBuilder sbinsertsql = new StringBuilder();
            sbinsertsql.Append("insert into mt_pc (pc_id, pc_name, pc_os, pc_memory, pc_cpu, pc_active, pc_is_byod, pc_comment) values(");
            sbinsertsql.Append(pcm.Id + ",");
            sbinsertsql.Append("'" + pcm.Name + "',");
            sbinsertsql.Append("'" + pcm.Os + "',");
            sbinsertsql.Append("'" + pcm.Memory + "',");
            sbinsertsql.Append("'" + pcm.Cpu + "',");
            sbinsertsql.Append(pcm.Active.ToString() + ",");
            sbinsertsql.Append(pcm.IsByod.ToString() + ",");
            sbinsertsql.Append("'" + pcm.Comment + "');");

            
            //= sbsql.ToString();

            String IdExistSql = "select count(*) as count from mt_pc where pc_id = " + pcm.Id + ";";

            using (var conn = new NpgsqlConnection(CONN_STRING))
            {
                String sql = String.Empty;
                conn.Open();

                var existCheckCommand = new NpgsqlCommand(IdExistSql, conn);
                var existCheckResultReader = existCheckCommand.ExecuteReader();

                while (existCheckResultReader.Read())
                {
                    
                    if (int.Parse(String.Format("{0}", existCheckResultReader["count"])) == 0){
                        // insert
                        sql = sbinsertsql.ToString();
                    }
                    else
                    {
                        sql = sbupdatesql.ToString();
                    }
                }
                conn.Close();
                conn.Open();

                var command = new NpgsqlCommand(sql, conn);
                // System.Windows.Forms.MessageBox.Show("record number",String.Format("{0}", (int)command.ExecuteScalar()));
                var result = command.ExecuteNonQuery();

                if (result == 0) {
                    System.Windows.Forms.MessageBox.Show("PcMasterは更新されませんでした");
                }
            }
        }
        // ========================= data model =========================
        public
        // PC_master
        class PcMaster
        {
            // PC data model
            private
            int _id;
            String _name;
            String _os;
            String _memory;
            String _cpu;
            bool _active;
            bool _isByod; 
            String _comment;

            public

            PcMaster()
            {
//                PcMaster pm = new PcMaster();
                this._id = 0;
                this._name = "New Pc";
                this._os = String.Empty;
                this._memory = String.Empty;
                this._cpu = String.Empty;
                this._active = true;
                this._isByod = false;
                this._comment = String.Empty;
            }

            public override string ToString()
            {
                if (_name == null)
                {
                    return base.ToString();
                }
                else
                {
                    return _name;
                }
            }

            // pc_id の最大値+1を返す
            public int GetNextId()
            {
                int ret = 0;
                foreach (PcMaster pc in _DbAccessor.PcMasters)
                {
                    if (ret < pc.Id) ret = pc.Id;
                }
                return ret+1;
            }

            // idプロパティ
            public int Id
            {
                get
                {
                    return _id;
                }
                set
                {
                    if (value > 0)
                    {
                        _id = value;
                    }
                }
            }

            // nameプロパティ
            public String Name
            {
                get
                {
                    return _name;
                }
                set
                {
                    _name = value;
                }
            }

            // osプロパティ
            public String Os
            {
                get
                {
                    return _os;
                }
                set
                {
                    _os = value;
                }
            }

            // memoryプロパティ
            public String Memory
            {
                get
                {
                    return _memory;
                }
                set
                {
                    _memory = value;
                }
            }

            // cpuプロパティ
            public String Cpu
            {
                get
                {
                    return _cpu;
                }
                set
                {
                    _cpu = value;
                }
            }

            // active 
            public bool Active
            {
                get
                {
                    return _active;
                }
                set
                {
                    _active = value;
                }
            }

            // byod
            public bool IsByod
            {
                get
                {
                    return _isByod;
                }
                set
                {
                    _isByod = value;
                }
            }

            // comment
            public String Comment
            {
                get
                {
                    return _comment;
                }
                set
                {
                    _comment = value;
                }
            }

        }

        public List<PcMaster> PcMasters = new List<PcMaster>();

        // Soft master
        public
        struct SoftwareMaster
        {
            // SoftwareataModel;
            public
            int id;
            public
            String name;
            public
            String version;
            public
            int osType;
            public
            int available;
            public
            bool active;
            public
            String comment;

            public SoftwareMaster createData()
            {
                SoftwareMaster sm = new SoftwareMaster();
                sm.id = 0;
                sm.name = String.Empty;
                sm.version = String.Empty;
                sm.osType = 1;
                sm.available = 1;
                sm.active = true;
                sm.comment = String.Empty;
                return sm;
            }
        }

        public List<SoftwareMaster> SoftwareMasters = new List<SoftwareMaster>();

        // User master
        public
        struct UserMaster
        {
            public
            int id;
            public
            String name;
            public
            int type;
            public
            bool active;
            public
            String comment;

            public UserMaster createData()
            {
                UserMaster um = new UserMaster();
                um.id = 0;
                um.name = String.Empty;
                um.type = 1;
                um.active = true;
                um.comment = String.Empty;

                return um;
            }
        }

        public List<UserMaster> UserMasters = new List<UserMaster>();

        // Pc Soft Relation Data
        struct PcSoftData
        {
            int pcId;
            int softId;
            String comment;

            PcSoftData createData()
            {
                PcSoftData pd = new PcSoftData();
                pd.pcId = 0;
                pd.softId = 0;
                pd.comment = String.Empty;

                return pd;
            }
        }

        // Pc User Date Relation Data
        struct PcUserDateData
        {
            DateTime date;
            int pcId;
            int userId;

            PcUserDateData createData()
            {
                PcUserDateData pd = new PcUserDateData();
                pd.date = DateTime.MinValue;
                pd.pcId = 0;
                pd.userId = 0;
                return pd;
            }
        }

        PcUserDateData[] PcUserDateDatas;

        // User Soft RelationData
        struct UserSoftData
        {
            int userId;
            int softId;
            String comment;

            UserSoftData createData()
            {
                UserSoftData ud = new UserSoftData();
                ud.userId = 0;
                ud.softId = 0;
                ud.comment = String.Empty;
                return ud;
            }
        }

        UserSoftData[] UserSoftDatas;

    }
}
