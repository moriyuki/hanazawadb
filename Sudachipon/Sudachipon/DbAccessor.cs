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

                var command = new NpgsqlCommand(@"select * from mt_pc", conn);
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

        // ========================= data model =========================
        // PC_master
        struct PcMaster
        {
            // PC data model
        }
        // Soft master
        // User master


    }
}
