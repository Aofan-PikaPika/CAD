using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;
using Model.Entity;

namespace DAL
{
       
    public class ProjlogHandle
    {
        private SQLiteConnectionBase con = new SQLiteConnectionBase();
        public bool AddLog(int pro_Id, string pro_Name,string sto_Path, string rec_Time)
        {
            string sqlInsertLog= "insert into tb_projlog(pro_id,pro_name,sto_path,rec_time)"
           +"values("+pro_Id+",'"+pro_Name+"','"+sto_Path+"','"+rec_Time+"')";
            SQLiteConnection conn = con.connectToDatabase();
            int i = SQLiteHelper.ExecuteNonQuery(conn,sqlInsertLog);
            if (i == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataTable SearchLog()
        {
            string sqlSearchLog = "select pro_name,sto_path,rec_time from tb_projlog order by rec_time desc limit 0,5";
            SQLiteConnection conn = con.connectToDatabase();
            DataTable dt = SQLiteHelper.ExecuteDataSet(conn, sqlSearchLog, null).Tables[0];
            return dt;
        }

        public bool UpdateLog(int pro_Id,string pro_Name, string sto_Path, string rec_Time)
        {
            string sqlUpdateLog = "update tb_projlog set pro_name='"+pro_Name+"',sto_path='"+sto_Path+"',rec_time='"+rec_Time+"'" 
                                  + "where pro_id =" + pro_Id;
            SQLiteConnection conn = con.connectToDatabase();
            SQLiteCommand cmd = SQLiteHelper.CreateCommand(conn, sqlUpdateLog);
            int n = SQLiteHelper.ExecuteNonQuery(cmd);
            if (n == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
          public bool DeleteLog(int pro_Id)
        {
            string sqlDeleteLog = "delete from tb_projlog where pro_id ="+pro_Id;
            SQLiteConnection conn =con.connectToDatabase();
            SQLiteCommand cmd = SQLiteHelper.CreateCommand(conn, sqlDeleteLog);
            int m = SQLiteHelper.ExecuteNonQuery(cmd);
            if (m == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
