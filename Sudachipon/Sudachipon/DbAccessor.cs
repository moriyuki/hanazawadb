using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Sudachipon
{
    // DB Access Class, Data Model Class
    class DbAccessor
    {
        // 別途設定ファイル外出で設定できるようにする
        const String CONN_STRING = @"Server=localhost;Port=5432;User Id=postgres;Password=hanazawa0108;Database=Sudachipon";

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
            if (string.IsNullOrEmpty(sql))
            {
                return null;
            }

            using (var conn = new NpgsqlConnection(CONN_STRING))
            {
                conn.Open();

                var command = new NpgsqlCommand(sql, conn);
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


        // ========================= data model =========================
        public
        // PC_master
        struct PcMaster
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
            PcMaster createData()
            {
                PcMaster pm = new PcMaster();
                pm._id = 0;
                pm._name = String.Empty;
                pm._os = String.Empty;
                pm._memory = String.Empty;
                pm._cpu = String.Empty;
                pm._active = true;
                pm._isByod = false;
                pm._comment = String.Empty;

                return pm;
            }

            // pc_id の最大値+1を返す
            int GetNextId()
            {
                int ret = 0;
                foreach (var pc in PcMasters)
                {
                    if (ret < pc.Id) ret = pc.Id;
                }
                return ret+1;
            }

            // idプロパティ
            int Id
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
            String Name
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
            String Os
            {
                get
                {
                    return _name;
                }
                set
                {
                    _os = value;
                }
            }

            // memoryプロパティ
            String Memory
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
            String Cpu
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
        }

        static PcMaster[] PcMasters;

        // Soft master
        struct SoftwareMaster
        {
            // SoftwareataModel;
            int id;
            String name;
            String version;
            int osType;
            int avalable;
            bool active;
            String comment;

            SoftwareMaster createData()
            {
                SoftwareMaster sm = new SoftwareMaster();
                sm.id = 0;
                sm.name = String.Empty;
                sm.version = String.Empty;
                sm.osType = 1;
                sm.avalable = 1;
                sm.active = true;
                sm.comment = String.Empty;
                return sm;
            }
        }

        SoftwareMaster[] SoftwareMasters;

        // User master
        struct UserMaster
        {
            int id;
            String name;
            int type;
            bool active;
            String comment;

            UserMaster createData()
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

        UserMaster[] UserMasters;

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
