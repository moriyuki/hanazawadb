﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Diagnostics;
using Npgsql;

namespace Sudachipon
{
    // DB Access Class, Data Model Class
    public class DbAccessor
    {
        private static String CONN_STRING;

        // singleton
        private static DbAccessor _DbAccessor = new DbAccessor();
        public static DbAccessor GetInstance()
        {
            DBConnectionSetting dbcs = new DBConnectionSetting();
            dbcs.LoadSetting();
            CONN_STRING = dbcs.CreatePostgresConnectionString();
            return _DbAccessor;
        }

        private DbAccessor()
        {
            // 接続文字列生成。DbConnectionは生成しない。（再接続の手間を減らすため）
        }

        public bool DbConnectionCheck(String host, String user, String password, String db)
        {
            try
            {
                string tmp = DBConnectionSetting.CreatePostgresConnectionStringForCheck(host, user, password, db);
                using (var conn = new NpgsqlConnection(CONN_STRING))
                {
                    conn.Open();
                    var command = new NpgsqlCommand("SELECT 'A' ;", conn);
                    var dataReader = command.ExecuteReader();
                    conn.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }

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
            try
            {


                using (var conn = new NpgsqlConnection(CONN_STRING))
                {
                    conn.Open();

                    var command = new NpgsqlCommand(sql, conn);
                    // System.Windows.Forms.MessageBox.Show("record number",String.Format("{0}", (int)command.ExecuteScalar()));
                    var dataReader = command.ExecuteReader();

                    // PcMasters クリア
                    this.PcMasters.Clear();

                    while (dataReader.Read())
                    {
                        PcMaster pm = new PcMaster();

                        pm.Id = int.Parse(String.Format("{0}", dataReader["pc_id"]));
                        pm.Name = String.Format("{0}", dataReader["pc_name"]);
                        pm.Os = int.Parse(String.Format("{0}", dataReader["pc_os"]));
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
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
                System.Windows.Forms.MessageBox.Show("DBへの接続に失敗しました。DB設定を確認してください。");
                DBSetting dbs = new DBSetting();
                dbs.ShowDialog();

                DBConnectionSetting dbcs = new DBConnectionSetting();
                dbcs.LoadSetting();
                CONN_STRING = dbcs.CreatePostgresConnectionString();
            }
        }

        public
        void SelectSoftwareMaster()
        {
            String sql = "select * from mt_soft;";

            using (var conn = new NpgsqlConnection(CONN_STRING))
            {
                conn.Open();

                var command = new NpgsqlCommand(sql, conn);
                // System.Windows.Forms.MessageBox.Show("record number",String.Format("{0}", (int)command.ExecuteScalar()));
                var dataReader = command.ExecuteReader();

                // SoftwareMasters クリア
                this.SoftwareMasters.Clear();

                while (dataReader.Read())
                {
                    SoftwareMaster sm = new SoftwareMaster();
                    //                    sm.createData();

                    sm.id = int.Parse(String.Format("{0}", dataReader["sf_id"]));
                    sm.name = String.Format("{0}", dataReader["sf_name"]);
                    sm.version = String.Format("{0}", dataReader["sf_version"]);
                    sm.osType = int.Parse(String.Format("{0}", dataReader["sf_os"]));
                    //sm.available = int.Parse(String.Format("{0}", dataReader["sf_available_number"]));
                    sm.userLicense = int.Parse(String.Format("{0}", dataReader["sf_user_license_number"]));
                    sm.pcLicense= int.Parse(String.Format("{0}", dataReader["sf_pc_license_number"]));
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

                // UserMasters クリア
                this.UserMasters.Clear();

                while (dataReader.Read())
                {
                    UserMaster um = new UserMaster();

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

        public void SelectPcSoftData(List<PcSoftData> strage)
        {
            String sql = "select * from dt_pc_soft;";

            using (var conn = new NpgsqlConnection(CONN_STRING))
            {
                conn.Open();

                var command = new NpgsqlCommand(sql, conn);
                // System.Windows.Forms.MessageBox.Show("record number",String.Format("{0}", (int)command.ExecuteScalar()));

                var dataReader = command.ExecuteReader();

                strage.Clear();

                while (dataReader.Read())
                {
                    PcSoftData psd = new PcSoftData();
                    //psd.createData();

                    psd.pcId = int.Parse(String.Format("{0}", dataReader["ps_pc_id"]));
                    psd.softId = int.Parse(String.Format("{0}", dataReader["ps_soft_id"]));
                    psd.comment = String.Format("{0}", dataReader["ps_comment"]);

                    strage.Add(psd);
                    // System.Windows.Forms.MessageBox.Show(String.Format("{0}", dataReader[0]));
                }
            }
        }

        public void SelectPcSoftData(int softid)
        {
            StringBuilder selectsql = new StringBuilder();

            selectsql.Append("select * from dt_pc_soft");
            selectsql.Append(" where ps_soft_id = " + softid + ";");

            String sql = selectsql.ToString();

            try
            {

                using (var conn = new NpgsqlConnection(CONN_STRING))
                {
                    conn.Open();

                    var command = new NpgsqlCommand(sql, conn);
                    // System.Windows.Forms.MessageBox.Show("record number",String.Format("{0}", (int)command.ExecuteScalar()));

                    var dataReader = command.ExecuteReader();
 

            this.PcSoftDatas.Clear();

            while (dataReader.Read())
            {
                PcSoftData psd = new PcSoftData();
                //psd.createData();

                psd.pcId = int.Parse(String.Format("{0}", dataReader["ps_pc_id"]));
                psd.softId = int.Parse(String.Format("{0}", dataReader["ps_soft_id"]));
                psd.comment = String.Format("{0}", dataReader["ps_comment"]);

                this.PcSoftDatas.Add(psd);
                // System.Windows.Forms.MessageBox.Show(String.Format("{0}", dataReader[0]));
            }
        }
    }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }

        }

        public void SelectUserSoftData(List<UserSoftData> strage)
        {
            StringBuilder selectsql = new StringBuilder();
            selectsql.Append("select * from dt_user_soft ;");

            String sql = selectsql.ToString();

            try
            {
                using (var conn = new NpgsqlConnection(CONN_STRING))
                {
                    conn.Open();

                    var command = new NpgsqlCommand(sql, conn);
                    // System.Windows.Forms.MessageBox.Show("record number",String.Format("{0}", (int)command.ExecuteScalar()));
                    var dataReader = command.ExecuteReader();

                    strage.Clear();
                    while (dataReader.Read())
                    {
                        UserSoftData usd = new UserSoftData();
                        //usd.createData();

                        usd.userId = int.Parse(String.Format("{0}", dataReader["usf_us_id"]));
                        usd.softId = int.Parse(String.Format("{0}", dataReader["usf_sf_id"]));
                        usd.comment = String.Format("{0}", dataReader["usf_comment"]);

                        strage.Add(usd);
                        // System.Windows.Forms.MessageBox.Show(String.Format("{0}", dataReader[0]));
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        public void SelectUserSoftData(int softid)
        {
            StringBuilder selectsql = new StringBuilder();

            selectsql.Append("select * from dt_user_soft");
            selectsql.Append(" where usf_sf_id = " + softid + ";");

            String sql = selectsql.ToString();

            try
            {

                using (var conn = new NpgsqlConnection(CONN_STRING))
                {
                    conn.Open();

                    var command = new NpgsqlCommand(sql, conn);
                    // System.Windows.Forms.MessageBox.Show("record number",String.Format("{0}", (int)command.ExecuteScalar()));
                    var dataReader = command.ExecuteReader();


                    this.UserSoftDatas.Clear();

                    while (dataReader.Read())
                    {
                        UserSoftData usd = new UserSoftData();
                        //usd.createData();

                        usd.userId = int.Parse(String.Format("{0}", dataReader["usf_us_id"]));
                        usd.softId = int.Parse(String.Format("{0}", dataReader["usf_sf_id"]));
                        usd.comment = String.Format("{0}", dataReader["usf_comment"]);

                        this.UserSoftDatas.Add(usd);
                        // System.Windows.Forms.MessageBox.Show(String.Format("{0}", dataReader[0]));
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }

        }

        public 
        bool CheckPcSoftData(PcMaster pc)
        {
            bool ret = true;
            this.SelectPcSoftData(this.PcSoftDatas);
            for (int i = 0; i < this.PcSoftDatas.Count; i++)
            {
                if (this.PcSoftDatas[i].pcId == pc.Id)
                {
                    ret = false;
                    break;
                }
            }
                return ret;
        }

        public
        bool CheckUserSoftData(PcMaster pc, UserMaster user)
        {
            bool ret = false;

            // PCに紐づくソフトを探す。
            for (int i = 0; i < this.PcSoftDatas.Count; i++)
            {
                int userNums = 0;
                this.SelectUserSoftData(this.UserSoftDatas);
                for (int j = 0; j < this.UserSoftDatas.Count; j++)
                {
                    //todo:ユーザリストが空のソフトがあれば　falseを返す。それ以外はtrueを返す。
                    if(this.UserSoftDatas[j].softId == this.PcSoftDatas[i].softId)
                    {
                        userNums += 1;
                    }
                }
                //ソフトに紐づくユーザが空なら登録を許可する（True）
                if (userNums == 0)
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }

        public 
        bool CheckSelectPcSoftDataAndUserSoftData(PcMaster pc, UserMaster user)
        {
            bool ret = false;

            String IdExistSql = "select count(*) as count from dt_pc_soft, dt_user_soft where dt_pc_soft.ps_pc_id = " + pc.Id + 
                " and dt_user_soft.usf_us_id = " + user.id +
                " and dt_pc_soft.ps_soft_id = dt_user_soft.usf_sf_id ;";

            using (var conn = new NpgsqlConnection(CONN_STRING))
            {
                String sql = String.Empty;
                conn.Open();

                var existCheckCommand = new NpgsqlCommand(IdExistSql, conn);
                var existCheckResultReader = existCheckCommand.ExecuteReader();

                while (existCheckResultReader.Read())
                {

                    int tmp = 0;
                    if (int.TryParse(String.Format("{0}", existCheckResultReader["count"]), out  tmp)
                        && tmp == 0)
                    {
                        ret = false;
                    }
                    else if (tmp != 0)
                    {
                        ret = true;
                    }
                    else
                    {
                        ret = false;
                    }
                }
                conn.Close();
            }

                return ret;
        }

        public
        void UpdatePcMaster(PcMaster pcm)
        {
            StringBuilder sbupdatesql = new StringBuilder();
            sbupdatesql.Append("update mt_pc set ");
            sbupdatesql.Append("pc_name = '" + ConvertIntoSQLString(pcm.Name) + "', ");
            sbupdatesql.Append("pc_os = " + pcm.Os + ", ");
            sbupdatesql.Append("pc_active = '" + pcm.Active + "' ");
            sbupdatesql.Append("where pc_id = " + pcm.Id + ";");

            StringBuilder sbinsertsql = new StringBuilder();
            sbinsertsql.Append("insert into mt_pc (pc_id, pc_name, pc_os, pc_memory, pc_cpu, pc_active, pc_is_byod, pc_comment) values(");
            sbinsertsql.Append("(select nextval('seq_pc')),");
            sbinsertsql.Append("'" + ConvertIntoSQLString(pcm.Name) + "',");
            sbinsertsql.Append( pcm.Os + ",");
            sbinsertsql.Append("'" + ConvertIntoSQLString(pcm.Memory) + "',");
            sbinsertsql.Append("'" + ConvertIntoSQLString(pcm.Cpu) + "',");
            sbinsertsql.Append(pcm.Active.ToString() + ",");
            sbinsertsql.Append(pcm.IsByod.ToString() + ",");
            sbinsertsql.Append("'" + ConvertIntoSQLString(pcm.Comment) + "');");

            
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

        public
        void UpdateSoftwareMaster(SoftwareMaster sfm)
        {
            StringBuilder sbupdatesql = new StringBuilder();
            sbupdatesql.Append("update mt_soft set ");
            sbupdatesql.Append("sf_name = '" + ConvertIntoSQLString(sfm.name) + "', ");
            sbupdatesql.Append("sf_version = '" + ConvertIntoSQLString(sfm.version) + "', ");
            sbupdatesql.Append("sf_os = " + sfm.osType + ", ");
            // mt_softのフィールドsf_available_number
            //sbupdatesql.Append("sf_available_number = " + sfm.available + ", ");
            sbupdatesql.Append("sf_pc_license_number = " + sfm.pcLicense + ", ");
            sbupdatesql.Append("sf_user_license_number = " + sfm.userLicense + ", ");
            sbupdatesql.Append("sf_comment = '" + ConvertIntoSQLString(sfm.comment) + "', ");
            
            
            // mt_softのフィールドsf_active
            sbupdatesql.Append("sf_active = '" + sfm.active + "' ");
            sbupdatesql.Append("where sf_id = " + sfm.id + ";");

            StringBuilder sbinsertsql = new StringBuilder();
            // mt_softのフィールドsf_available_number
            // mt_softのフィールドsf_active

            //todo PclicenseとUserLicenseを追加
            sbinsertsql.Append("insert into mt_soft (sf_id, sf_name, sf_version, sf_os,sf_pc_license_number,sf_user_license_number, sf_active, sf_comment) values(");
            //            sbinsertsql.Append(sfm.id + ",");
            sbinsertsql.Append("(select nextval('seq_soft')),");
            sbinsertsql.Append("'" + ConvertIntoSQLString(sfm.name) + "',");
            sbinsertsql.Append("'" + ConvertIntoSQLString(sfm.version) + "',");
            sbinsertsql.Append("" + sfm.osType + ",");
            //sbinsertsql.Append("" + sfm.available.ToString()+ ",");
            sbinsertsql.Append("" + sfm.pcLicense.ToString()+ ",");
            sbinsertsql.Append("" + sfm.userLicense.ToString()+ ",");
            sbinsertsql.Append(sfm.active.ToString() + ",");
            sbinsertsql.Append("'" + ConvertIntoSQLString(sfm.comment) + "');");


            //= sbsql.ToString();

            String IdExistSql = "select count(*) as count from mt_soft where sf_id = " + sfm.id + ";";

            using (var conn = new NpgsqlConnection(CONN_STRING))
            {
                String sql = String.Empty;
                conn.Open();

                var existCheckCommand = new NpgsqlCommand(IdExistSql, conn);
                var existCheckResultReader = existCheckCommand.ExecuteReader();

                while (existCheckResultReader.Read())
                {

                    if (int.Parse(String.Format("{0}", existCheckResultReader["count"])) == 0)
                    {
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

                try {
                    var result = command.ExecuteNonQuery();

                    if (result == 0)
                    {
                        System.Windows.Forms.MessageBox.Show("SoftwareMasterは更新されませんでした");
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                }
            }
        }

        public void UpdateUserMaster(UserMaster um)
        {
            StringBuilder sbupdatesql = new StringBuilder();
            sbupdatesql.Append("update mt_user set ");
            sbupdatesql.Append("us_name = '" + ConvertIntoSQLString(um.name) + "', ");
            sbupdatesql.Append("us_type = '" + um.type + "', ");
            sbupdatesql.Append("us_active = '" + um.active + "', ");
            sbupdatesql.Append("us_comment = '" + ConvertIntoSQLString(um.comment) + "' ");
            sbupdatesql.Append("where us_id = " + um.id + ";");

            StringBuilder sbinsertsql = new StringBuilder();
            sbinsertsql.Append("insert into mt_user (us_id, us_name, us_type, us_active, us_comment) values(");
            sbinsertsql.Append("(select nextval('seq_user')),");
            sbinsertsql.Append("'" + ConvertIntoSQLString(um.name) + "',");
            sbinsertsql.Append("'" + um.type + "',");
            sbinsertsql.Append(um.active.ToString() + ",");
            sbinsertsql.Append("'" + ConvertIntoSQLString(um.comment) + "');");


            //= sbsql.ToString();

            String IdExistSql = "select count(*) as count from mt_user where us_id = " + um.id + ";";

            using (var conn = new NpgsqlConnection(CONN_STRING))
            {
                String sql = String.Empty;
                conn.Open();

                var existCheckCommand = new NpgsqlCommand(IdExistSql, conn);
                var existCheckResultReader = existCheckCommand.ExecuteReader();

                while (existCheckResultReader.Read())
                {

                    if (int.Parse(String.Format("{0}", existCheckResultReader["count"])) == 0)
                    {
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

                if (result == 0)
                {
                    System.Windows.Forms.MessageBox.Show("UserMasterは更新されませんでした");
                }
            }
        }

        public void MargePcSoftData(PcMaster pcm)
        {
            // 最新のPcSoftData（DbData）を取得します
            List<PcSoftData> dbData = new List<PcSoftData>();
            SelectPcSoftData(dbData);
            // 内部データ（LocalData）とDbDataを比較します。
            for (int i = 0; i < this.PcSoftDatas.Count; i++)
            {
                // pcidによる縛り
                if (this.PcSoftDatas[i].pcId != pcm.Id)
                {
                    continue;
                }

                int existedSoftId = this.PcSoftDatas[i].softId;

                for (int j=0; j < dbData.Count; j++)
                {
                    // pcidによる縛り
                    if (dbData[j].pcId != pcm.Id)
                    {
                        continue;
                    }

                    if (dbData[j].softId == this.PcSoftDatas[i].softId)
                    {
                        existedSoftId = -1;
                        continue ;
                    }
                }
                // LocalDataにあるが、DBDataにない場合　－＞　Insert
                if (existedSoftId != -1) {
                    // INSERT 
                    InsertPcSoftData(pcm, existedSoftId);
                }
            }

            for (int i = 0; i < dbData.Count; i++)
            {
                // pcidによる縛り
                if (dbData[i].pcId != pcm.Id)
                {
                    continue;
                }
                int existedSoftId = dbData[i].softId;
                for (int j = 0; j < this.PcSoftDatas.Count; j++)
                {
                    // pcidによる縛り
                    if (PcSoftDatas[j].pcId != pcm.Id)
                    {
                        continue;
                    }
                    if (dbData[i].softId == this.PcSoftDatas[j].softId)
                    {
                        existedSoftId = -1;
                        break;
                    }
                }
                // insert or delete
                // DBDataにあるがLocalDataにない場合　→　Delete
                if (existedSoftId != -1)
                {
                    //DELETE
                    DeletePcSoftData(pcm, existedSoftId);
                }
            } 
        }

        public void MargeUserSoftData(UserMaster usm)
        {
            // 最新のPcSoftData（DbData）を取得します
            List<UserSoftData> dbData = new List<UserSoftData>();
            SelectUserSoftData(dbData);
            // 内部データ（LocalData）とDbDataを比較します。
            for (int i = 0; i < this.UserSoftDatas.Count; i++)
            {
                // useridによる縛り
                if (this.UserSoftDatas[i].userId != usm.id)
                {
                    continue;
                }

                int existedSoftId = this.UserSoftDatas[i].softId;

                for (int j = 0; j < dbData.Count; j++)
                {
                    // useridによる縛り
                    if (dbData[j].userId != usm.id)
                    {
                        continue;
                    }

                    if (dbData[j].softId == this.UserSoftDatas[i].softId)
                    {
                        existedSoftId = -1;
                        continue;
                    }
                }
                // LocalDataにあるが、DBDataにない場合　－＞　Insert
                if (existedSoftId != -1)
                {
                    // INSERT 
                    InsertUserSoftData(usm, existedSoftId);
                }
            }

            for (int i = 0; i < dbData.Count; i++)
            {
                // useridによる縛り
                if (dbData[i].userId != usm.id)
                {
                    continue;
                }
                int existedSoftId = dbData[i].softId;
                for (int j = 0; j < this.PcSoftDatas.Count; j++)
                {
                    // useridによる縛り
                    if (UserSoftDatas[j].userId != usm.id)
                    {
                        continue;
                    }
                    if (dbData[i].softId == this.UserSoftDatas[j].softId)
                    {
                        existedSoftId = -1;
                        break;
                    }
                }
                // insert or delete
                // DBDataにあるがLocalDataにない場合　→　Delete
                if (existedSoftId != -1)
                {
                    //DELETE
                    DeleteUserSoftData(usm, existedSoftId);
                }
            }
        }

        public void MargePcSoftData(SoftwareMaster swm)
        {
            // 最新のPcSoftData（DbData）を取得します
            List<PcSoftData> dbData = new List<PcSoftData>();
            SelectPcSoftData(dbData);
            // 内部データ（LocalData）とDbDataを比較します。
            for (int i = 0; i < this.PcSoftDatas.Count; i++)
            {
                // softidによる縛り
                if (this.PcSoftDatas[i].softId != swm.id)
                {
                    continue;
                }

                int existedPcId = this.PcSoftDatas[i].pcId;

                for (int j = 0; j < dbData.Count; j++)
                {
                    // softidによる縛り
                    if (dbData[j].softId != swm.id)
                    {
                        continue;
                    }

                    if (dbData[j].pcId == this.PcSoftDatas[i].pcId)
                    {
                        existedPcId = -1;
                        continue;
                    }
                }
                // LocalDataにあるが、DBDataにない場合　－＞　Insert
                if (existedPcId != -1)
                {
                    // INSERT 
                    InsertPcSoftData(swm, existedPcId);
                }
            }

            for (int i = 0; i < dbData.Count; i++)
            {
                // softidによる縛り
                if (dbData[i].softId != swm.id)
                {
                    continue;
                }
                int existedPcId = dbData[i].pcId;
                for (int j = 0; j < this.PcSoftDatas.Count; j++)
                {
                    // softidによる縛り
                    if (PcSoftDatas[j].softId != swm.id)
                    {
                        continue;
                    }
                    if (dbData[i].pcId == this.PcSoftDatas[j].pcId)
                    {
                        existedPcId = -1;
                        break;
                    }
                }
                // insert or delete
                // DBDataにあるがLocalDataにない場合　→　Delete
                if (existedPcId != -1)
                {
                    //DELETE
                    DeletePcSoftData(swm, existedPcId);
                }
            }
        }

        public void MargeUserSoftData(SoftwareMaster swm)
        {
            // 最新のPcSoftData（DbData）を取得します
            List<UserSoftData> dbData = new List<UserSoftData>();
            SelectUserSoftData(dbData);
            // 内部データ（LocalData）とDbDataを比較します。
            for (int i = 0; i < this.UserSoftDatas.Count; i++)
            {
                // softidによる縛り
                if (this.UserSoftDatas[i].softId != swm.id)
                {
                    continue;
                }

                int existedUserId = this.UserSoftDatas[i].userId;

                for (int j = 0; j < dbData.Count; j++)
                {
                    // softidによる縛り
                    if (dbData[j].softId != swm.id)
                    {
                        continue;
                    }

                    if (dbData[j].userId == this.UserSoftDatas[i].userId)
                    {
                        existedUserId = -1;
                        continue;
                    }
                }
                // LocalDataにあるが、DBDataにない場合　－＞　Insert
                if (existedUserId != -1)
                {
                    // INSERT 
                    InsertUserSoftData(swm, existedUserId);
                }
            }

            for (int i = 0; i < dbData.Count; i++)
            {
                // softidによる縛り
                if (dbData[i].softId != swm.id)
                {
                    continue;
                }
                int existedUserId = dbData[i].userId;
                for (int j = 0; j < this.UserSoftDatas.Count; j++)
                {
                    // softidによる縛り
                    if (UserSoftDatas[j].softId != swm.id)
                    {
                        continue;
                    }
                    if (dbData[i].userId == this.UserSoftDatas[j].userId)
                    {
                        existedUserId = -1;
                        break;
                    }
                }
                // insert or delete
                // DBDataにあるがLocalDataにない場合　→　Delete
                if (existedUserId != -1)
                {
                    //DELETE
                    DeleteUserSoftData(swm, existedUserId);
                }
            }

        }

        //internal void InsertPcSoftData(PcMaster pcm, int softid)
        public void InsertPcSoftData(PcMaster pcm, int softid)
        {
            // throw new NotImplementedException();

            StringBuilder sbinsertsql = new StringBuilder();
            sbinsertsql.Append("insert into dt_pc_soft (ps_pc_id, ps_soft_id) values(");
            sbinsertsql.Append(pcm.Id + ",");
            sbinsertsql.Append(softid + ");");

            using (var conn = new NpgsqlConnection(CONN_STRING))
            {
                String sql = String.Empty;
                conn.Open();

                var insertCommand = new NpgsqlCommand(sbinsertsql.ToString(), conn);
                var result = insertCommand.ExecuteNonQuery();

                if (result == 0)
                {
                    System.Windows.Forms.MessageBox.Show("Pc-Soft DBは更新されませんでした");
                }
            }

        }

        public void InsertPcSoftData(SoftwareMaster swm, int pcid)
        {
            // throw new NotImplementedException();

            StringBuilder sbinsertsql = new StringBuilder();
            sbinsertsql.Append("insert into dt_pc_soft (ps_pc_id, ps_soft_id) values(");
            sbinsertsql.Append(pcid + ",");
            sbinsertsql.Append(swm.id + ");");

            using (var conn = new NpgsqlConnection(CONN_STRING))
            {
                String sql = String.Empty;
                conn.Open();

                var insertCommand = new NpgsqlCommand(sbinsertsql.ToString(), conn);
                var result = insertCommand.ExecuteNonQuery();

                if (result == 0)
                {
                    System.Windows.Forms.MessageBox.Show("Pc-Soft DBは更新されませんでした");
                }
            }

        }
        //internal void DeletePcSoftData(PcMaster pcm, int softid)
        public void DeletePcSoftData(PcMaster pcm, int softid)
        {
            // throw new NotImplementedException();

            StringBuilder sbdeletesql = new StringBuilder();
            sbdeletesql.Append("delete from dt_pc_soft where ");
            sbdeletesql.Append("ps_pc_id =" + pcm.Id + " ");
            sbdeletesql.Append("and ps_soft_id =" + softid + ";");

            using (var conn = new NpgsqlConnection(CONN_STRING))
            {
                String sql = String.Empty;
                conn.Open();

                var deleteCommand = new NpgsqlCommand(sbdeletesql.ToString(), conn);
                var result = deleteCommand.ExecuteNonQuery();

                if (result == 0)
                {
                    System.Windows.Forms.MessageBox.Show("Pc-Soft DBは更新されませんでした");
                }
            }
        }

        public void DeletePcSoftData(SoftwareMaster swm, int pcid)
        {
            // throw new NotImplementedException();

            StringBuilder sbdeletesql = new StringBuilder();
            sbdeletesql.Append("delete from dt_pc_soft where ");
            sbdeletesql.Append("ps_pc_id =" + pcid + " ");
            sbdeletesql.Append("and ps_soft_id =" + swm.id + ";");

            using (var conn = new NpgsqlConnection(CONN_STRING))
            {
                String sql = String.Empty;
                conn.Open();

                var deleteCommand = new NpgsqlCommand(sbdeletesql.ToString(), conn);
                var result = deleteCommand.ExecuteNonQuery();

                if (result == 0)
                {
                    System.Windows.Forms.MessageBox.Show("Pc-Soft DBは更新されませんでした");
                }
            }
        }

        public void InsertUserSoftData(UserMaster um, int softid)
        {
            // throw new NotImplementedException();

            StringBuilder sbinsertsql = new StringBuilder();
            sbinsertsql.Append("insert into dt_user_soft (usf_us_id, usf_sf_id) values(");
            sbinsertsql.Append(um.id + ",");
            sbinsertsql.Append(softid + ");");

            using (var conn = new NpgsqlConnection(CONN_STRING))
            {
                String sql = String.Empty;
                conn.Open();

                var insertCommand = new NpgsqlCommand(sbinsertsql.ToString(), conn);
                var result = insertCommand.ExecuteNonQuery();

                if (result == 0)
                {
                    System.Windows.Forms.MessageBox.Show("User-Soft DBは更新されませんでした");
                }
            }

        }

        public void InsertUserSoftData(SoftwareMaster swm, int userid)
        {
            // throw new NotImplementedException();

            StringBuilder sbinsertsql = new StringBuilder();
            sbinsertsql.Append("insert into dt_user_soft (usf_us_id, usf_sf_id) values(");
            sbinsertsql.Append(userid + ",");
            sbinsertsql.Append(swm.id + ");");

            using (var conn = new NpgsqlConnection(CONN_STRING))
            {
                String sql = String.Empty;
                conn.Open();

                var insertCommand = new NpgsqlCommand(sbinsertsql.ToString(), conn);
                var result = insertCommand.ExecuteNonQuery();

                if (result == 0)
                {
                    System.Windows.Forms.MessageBox.Show("User-Soft DBは更新されませんでした");
                }
            }

        }

        public void DeleteUserSoftData(UserMaster um, int softid)
        {
            // throw new NotImplementedException();

            StringBuilder sbdeletesql = new StringBuilder();
            sbdeletesql.Append("delete from dt_user_soft where ");
            sbdeletesql.Append("usf_us_id =" + um.id + " ");
            sbdeletesql.Append("and usf_sf_id =" + softid + ";");

            using (var conn = new NpgsqlConnection(CONN_STRING))
            {
                String sql = String.Empty;
                conn.Open();

                var deleteCommand = new NpgsqlCommand(sbdeletesql.ToString(), conn);
                var result = deleteCommand.ExecuteNonQuery();

                if (result == 0)
                {
                    System.Windows.Forms.MessageBox.Show("User-Soft DBは更新されませんでした");
                }
            }
        }

        public void DeleteUserSoftData(SoftwareMaster swm, int userid)
        {
            // throw new NotImplementedException();

            StringBuilder sbdeletesql = new StringBuilder();
            sbdeletesql.Append("delete from dt_user_soft where ");
            sbdeletesql.Append("usf_us_id =" + userid + " ");
            sbdeletesql.Append("and usf_sf_id =" + swm.id + ";");

            using (var conn = new NpgsqlConnection(CONN_STRING))
            {
                String sql = String.Empty;
                conn.Open();

                var deleteCommand = new NpgsqlCommand(sbdeletesql.ToString(), conn);
                var result = deleteCommand.ExecuteNonQuery();

                if (result == 0)
                {
                    System.Windows.Forms.MessageBox.Show("User-Soft DBは更新されませんでした");
                }
            }
        }

        public void SelectPcUserDateData(DateTime startdate, int limitnum)
        {
            DateTime enddate;
            enddate = startdate.AddDays(limitnum - 1);

            StringBuilder selectsql = new StringBuilder();

            selectsql.Append("select * from dt_pc_user_date");
            selectsql.Append(" where pud_date >= '" + startdate.ToString("yyyy-MM-dd") + "' ");
            selectsql.Append(" and pud_date <= '" + enddate.ToString("yyyy-MM-dd") + "';");

            String sql = selectsql.ToString();

            try
            {

                using (var conn = new NpgsqlConnection(CONN_STRING))
                {
                    conn.Open();

                    var command = new NpgsqlCommand(sql, conn);
                    // System.Windows.Forms.MessageBox.Show("record number",String.Format("{0}", (int)command.ExecuteScalar()));
                    var dataReader = command.ExecuteReader();


                    this.PcUserDateDatas.Clear();

                    while (dataReader.Read())
                    {
                        PcUserDateData pud = new PcUserDateData();

                        pud.Date = DateTime.Parse(String.Format("{0}", dataReader["pud_date"]));
                        pud.PcId = int.Parse(String.Format("{0}", dataReader["pud_pc_id"]));
                        pud.UserId = int.Parse(String.Format("{0}", dataReader["pud_user_id"]));

                        this.PcUserDateDatas.Add(pud);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }

        }

        public void InsertPcUserDateData(DateTime dt, int pcid, int userid)
        {
            // throw new NotImplementedException();

            StringBuilder sbinsertsql = new StringBuilder();
            sbinsertsql.Append("insert into dt_pc_user_date (pud_date, pud_pc_id, pud_user_id) values('");
            sbinsertsql.Append(dt.ToString("yyyy-MM-dd") + "',");
            sbinsertsql.Append(pcid + ",");
            sbinsertsql.Append(userid + ");");

            using (var conn = new NpgsqlConnection(CONN_STRING))
            {
                String sql = String.Empty;
                conn.Open();

                var insertCommand = new NpgsqlCommand(sbinsertsql.ToString(), conn);
                var result = insertCommand.ExecuteNonQuery();

                if (result == 0)
                {
                    System.Windows.Forms.MessageBox.Show("Pc-User DBは更新されませんでした");
                }
            }

        }

        public DbAccessor.UserMaster SelectPcUserDateData(DateTime targetdate, DbAccessor.PcMaster targetpc)
        {

            StringBuilder selectsql = new StringBuilder();

            selectsql.Append("select * from dt_pc_user_date");
            selectsql.Append(" where pud_date = '" + targetdate.ToString("yyyy-MM-dd") + "' ");
            selectsql.Append(" and pud_pc_id = " + targetpc.Id + ";");

            String sql = selectsql.ToString();

            try
            {

                using (var conn = new NpgsqlConnection(CONN_STRING))
                {
                    conn.Open();

                    var command = new NpgsqlCommand(sql, conn);
                    // System.Windows.Forms.MessageBox.Show("record number",String.Format("{0}", (int)command.ExecuteScalar()));
                    var dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        int UserId;

                        UserId = int.Parse(String.Format("{0}", dataReader["pud_user_id"]));

                        foreach(DbAccessor.UserMaster targetuser in _DbAccessor.UserMasters)
                        {
                            if (targetuser.id == UserId) return targetuser;
                        }

                        return null;
                        
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
                return null;
            }

            return null;

        }



        public void UpdatePcUserDateData(DateTime dt, int pcid, int olduserid, int newuserid)
        {
            // throw new NotImplementedException();

            StringBuilder sbupdatesql = new StringBuilder();
            sbupdatesql.Append("update dt_pc_user_date  set  pud_user_id = ");
            sbupdatesql.Append(newuserid);
            sbupdatesql.Append(" where pud_date = '");
            sbupdatesql.Append(dt.ToString("yyyy-MM-dd") + "' and ");
            sbupdatesql.Append("pud_pc_id = " + pcid + " and ");
            sbupdatesql.Append("pud_user_id = " +olduserid + ";");

            using (var conn = new NpgsqlConnection(CONN_STRING))
            {
                String sql = String.Empty;
                conn.Open();

                var insertCommand = new NpgsqlCommand(sbupdatesql.ToString(), conn);
                var result = insertCommand.ExecuteNonQuery();

                if (result == 0)
                {
                    System.Windows.Forms.MessageBox.Show("Pc-User DBは更新されませんでした");
                }
            }

        }

        public void DeletePcUserDateData(DateTime dt, int pcid, int userid)
        {
            // throw new NotImplementedException();

            StringBuilder sbdeletesql = new StringBuilder();
            sbdeletesql.Append("delete from dt_pc_user_date where ");
            sbdeletesql.Append("pud_date ='" + dt.ToString("yyyy-MM-dd") + "' ");
            sbdeletesql.Append("and pud_pc_id =" + pcid + " ");
            sbdeletesql.Append("and pud_user_id =" + userid + ";");

            using (var conn = new NpgsqlConnection(CONN_STRING))
            {
                String sql = String.Empty;
                conn.Open();

                var deleteCommand = new NpgsqlCommand(sbdeletesql.ToString(), conn);
                var result = deleteCommand.ExecuteNonQuery();

                if (result == 0)
                {
                    System.Windows.Forms.MessageBox.Show("Pc-User DBは更新されませんでした");
                }
            }
        }

        // SQL文内の文字列を適切なエスケープ文字を追加する
        public String ConvertIntoSQLString(String str)
        { 

            const Char EscapeCode = '\'';

            StringBuilder sbsqlstr = new StringBuilder();

            for(int i =0;i<str.Length;i++)
            {
                if(str[i] == EscapeCode)
                {
                    sbsqlstr.Append(EscapeCode);
                    sbsqlstr.Append(EscapeCode);
                } else
                {
                    sbsqlstr.Append(str[i]);
                }
            }


            return sbsqlstr.ToString();
        }


        // DB DUMP
        public void DBDump(string filefullpath)
        {
            StreamWriter sw = new StreamWriter("DbBackup.bat");
            StringBuilder sb = new StringBuilder("\"C:\\Program Files\\PostgreSQL\\9.5\\bin\\");

            if (sb.Length == 0)
            {
                return;
            }

            sb.Append("pg_dump.exe\" --host 192.168.0.3 --port 5432 --username postgres --format plain --blobs --verbose --file ");
            sb.Append("\"" + filefullpath + "\"");
            sb.Append(" \"Sudachipon\"\r\n\r\n");
            sw.WriteLine(sb);
            sw.Dispose();
            sw.Close();

            Process processDB = Process.Start("DbBackup.bat");
            do { }
            while (!processDB.HasExited);
            {
                System.Windows.Forms.MessageBox.Show("Successfully Backed up");
            }

        }

        // ========================= data model =========================
        public
        // PC_master
        class PcMaster
        {
            const int PC_OS_DEFAULT = 1;
            // PC data model
            private
            int _id;
            String _name;
            int _os;
            String _memory;
            String _cpu;
            bool _active;
            bool _isByod; 
            String _comment;

            public PcMaster()
            {
//                PcMaster pm = new PcMaster();
                this._id = 0;
                this._name = "New Pc";
                this._os = PC_OS_DEFAULT;
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
            public int Os
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
        class SoftwareMaster
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
            int pcLicense;
            public
            int userLicense;
            //int available;
            public
            bool active;
            public
            String comment;

            public 
            SoftwareMaster()
            { 
//                SoftwareMaster sm = new SoftwareMaster();
                this.id = 0;
                this.name = "A Software";
                this.version = String.Empty;
                this.osType = 1;
                //this.available = 1;
                this.pcLicense = -1;
                this.userLicense = -1;
                this.active = true;
                this.comment = String.Empty;
//                return sm;
            }

            // sf_id の最大値+1を返す
            public int GetNextId()
            {
                int ret = 0;
                foreach (SoftwareMaster sf in _DbAccessor.SoftwareMasters)
                {
                    if (ret < sf.id) ret = sf.id;
                }
                return ret + 1;
            }

            public override string ToString()
            {
                return name;
            }
        }

 

        public List<SoftwareMaster> SoftwareMasters = new List<SoftwareMaster>();

        // User master
        public
        class UserMaster
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

            public UserMaster()
            {
                this.id = 0;
                this.name = String.Empty;
                this.type = 1;
                this.active = true;
                this.comment = String.Empty;
            }

            public override string ToString()
            {
                if (name == null)
                {
                    return base.ToString();
                }
                else
                {
                    return name;
        }
            }
            // user_id の最大値+1を返す
            public int GetNextId()
            {
                int ret = 0;
                foreach (UserMaster user in _DbAccessor.UserMasters)
                {
                    if (ret < user.id) ret = user.id;
                }
                return ret + 1;
            }
        }

        public List<UserMaster> UserMasters = new List<UserMaster>();

        // Pc Soft Relation Data
        public class PcSoftData
        {
            public int pcId;
            public int softId;
            public String comment;

            public PcSoftData()
            {
               // PcSoftData pd = new PcSoftData();
                this.pcId = 0;
                this.softId = 0;
                this.comment = String.Empty;
                //return pd;
            }
        }
        public List<PcSoftData> PcSoftDatas = new List<PcSoftData>();

        // Pc User Date Relation Data
        public class PcUserDateData
        {
            private
            DateTime _date;
            int _pcId;
            int _userId;

            public PcUserDateData()
            {
                //PcUserDateData pd = new PcUserDateData();
                this._date = DateTime.MinValue;
                this._pcId = 0;
                this._userId = 0;
                //return pd;
            }

            // dateプロパティ
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

            // pcidプロパティ
            public int PcId
            {
                get
                {
                    return _pcId;
                }
                set
                {
                    if (value > 0)
                    {
                        _pcId = value;
                    }
                }
            }

            // useridプロパティ
            public int UserId
            {
                get
                {
                    return _userId;
                }
                set
                {
                    if (value > 0)
                    {
                        _userId = value;
                    }
                }
            }
        }

        public List<PcUserDateData> PcUserDateDatas = new List<PcUserDateData>();

        // User Soft RelationData
        public class UserSoftData
        {
            public int userId;
            public int softId;
            public String comment;

            public UserSoftData()
            {
                //UserSoftData ud = new UserSoftData();
                this.userId = 0;
                this.softId = 0;
                this.comment = String.Empty;
                //return ud;
            }
        }

        public List<UserSoftData> UserSoftDatas = new List<UserSoftData>();

    }
}
