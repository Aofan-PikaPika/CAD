using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;

namespace DAL
{
    public class AnchorHandle
    {
        private SQLiteConnectionBase _connBase = new SQLiteConnectionBase();

        public DataTable GetAnchorModelFromGSteel() 
        {
            SQLiteConnection conn = _connBase.connectToDatabase();
            string sql = "select model from tb_gsteel ";
            DataTable dt = SQLiteHelper.ExecuteDataSet(conn,sql,null).Tables[0];
            return dt;
        }

        public DataTable GetAnchorModelFromCSteel() 
        {
            SQLiteConnection conn = _connBase.connectToDatabase();
            string sql = "select model from tb_csteel ";
            DataTable dt = SQLiteHelper.ExecuteDataSet(conn, sql, null).Tables[0];
            return dt;
        }

        public DataTable GetAnchorModelFromJSteel() 
        {
            SQLiteConnection conn = _connBase.connectToDatabase();
            string sql = "select model from tb_jsteel ";
            DataTable dt = SQLiteHelper.ExecuteDataSet(conn, sql, null).Tables[0];
            return dt;
        }

        public DataTable GetAnchorModelFromTubeCharacter() 
        {
            SQLiteConnection conn = _connBase.connectToDatabase();
            string sql = "select model from tb_tubeCharacter where model not null";
            DataTable dt = SQLiteHelper.ExecuteDataSet(conn, sql, null).Tables[0];
            return dt;
        }



    }
}
