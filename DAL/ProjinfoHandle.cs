using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;
using Model.Entity;

namespace DAL
{
    /// <summary>
    /// 处理tb_projinfo表的DAL类
    /// 工程信息根据ID号增加，修改，查询
    /// </summary>
    public class ProjinfoHandle
    {
         
        //产生连接的库
        private SQLiteConnectionBase _connBase = new SQLiteConnectionBase();

        /// <summary>
        /// 函数直接从BLL中的实体类中获取数据并保存，成功返回工程ID值，失败返回-1
        /// </summary>
        /// <returns></returns>
        public int AddInfo()
        {

            //拼凑Sql语句的方法无法存null串，只能存入空字符串
            string sqlInsertInfo = "insert into tb_projinfo(pro_name,pro_type,con_province,con_city,unit,con_unit,sup_unit,con_area,con_height,des_unit)"
                        + " values('"+ProjectInfo.Pro_Name+"','"+ ProjectInfo.Pro_Type+"','"+ProjectInfo.Con_Province+"','"+ProjectInfo.Con_City+"','"+ProjectInfo.Unit+"','"+ProjectInfo.Sup_Unit+"','"+ProjectInfo.Sup_Unit+"','"+ProjectInfo.Con_Area+"','"+ProjectInfo.Con_Height+"','"+ProjectInfo.Des_Unit+"')";
            int isIn = -1;
            SQLiteConnection conn = null;
            try
            {
                conn = _connBase.connectToDatabase();
         
                //执行插入语句，同时Sqlite自动生成一个ID值
                isIn = SQLiteHelper.ExecuteNonQuery(conn, sqlInsertInfo);
            }
            catch { }
            //插入成功则找到ID值
            if (isIn == 1)
            {
                //查询最大的工程ID
                string sqlFindLastId = "select max(pro_id) from tb_projinfo";
                SQLiteCommand cmd =  SQLiteHelper.CreateCommand(conn, sqlFindLastId);
                DataTable dt = SQLiteHelper.ExecuteDataset(cmd).Tables[0];
                return int.Parse(dt.Rows[dt.Rows.Count - 1][0].ToString());
            }
            else
            {
                return -1;//不成功返回负1
            }
        }


        /// <summary>
        /// 根据ID号查询记录，返回一个dataTable，成功返回有数据的表，失败返回空表
        /// </summary>
        /// <returns></returns>
        public DataTable SearchInfo(int pro_Id)
        {
            string sqlSearchInfo = "select pro_name,pro_type,con_province,con_city,unit,con_unit,sup_unit,con_area,con_height,des_unit from tb_projinfo"
                                    + " where pro_id = " + pro_Id;
            SQLiteConnection conn = _connBase.connectToDatabase();
            DataTable dt = SQLiteHelper.ExecuteDataSet(conn, sqlSearchInfo,null).Tables[0];
            return dt;
        }



        /// <summary>
        /// 更新工程信息,成功返回true，不成功返回false
        /// </summary>
        /// <param name="pro_id"></param>
        /// <returns></returns>
        public bool UpdateInfo(int pro_Id)
        {
                      
            string sqlUpdate = "update tb_projinfo set pro_name = '"+ProjectInfo.Pro_Name+
                                "',pro_type='"+ProjectInfo.Pro_Type+
                                "',con_province='"+ProjectInfo.Con_Province+
                                "',con_city='"+ProjectInfo.Con_City+
                                "',unit='"+ProjectInfo.Unit+
                                "',con_unit='"+ProjectInfo.Con_Unit+
                                "',sup_unit='"+ProjectInfo.Sup_Unit+
                                "',con_area='"+ProjectInfo.Con_Area+
                                "',con_height="+ProjectInfo.Con_Height+
                                ",des_unit='"+ProjectInfo.Des_Unit+
                                "' where  pro_id = "+pro_Id;
            SQLiteConnection conn = _connBase.connectToDatabase();
            SQLiteCommand cmd = SQLiteHelper.CreateCommand(conn, sqlUpdate);
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

        
    }
}
