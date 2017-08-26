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
            //这儿用grupby可以暂时实现保存文件时冲掉已有工程文件，在最近文件里旧的工程文件也被冲掉
            //groupby会按文件名和文件路径将数据库中冗余的内容压缩、
            //但压缩后无论order by如何，均显示rec_time最晚的一条记录
            //利用max（rec_time）保证压缩后的时间是最晚的
            string sqlSearchLog = "select pro_name,sto_path,max(rec_time) from tb_projlog group by sto_path order by rec_time desc limit 0,5";
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
         
        public bool DeleteLog(string sto_path)
        {
            string sqlDeleteLog = "delete from tb_projlog where sto_path ='"+sto_path+"'";
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
