using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;
using System.Data.SQLite;

namespace DAL
{
    public class CheckTableHandle
    {
        /// <summary>
        /// 查询材料质量以及其特性的函数
        /// </summary>
        /// <param name="la">mm</param>
        /// <param name="lb">mm</param>
        /// <param name="h">mm</param>
        /// <param name="fitting_model"></param>
        /// <returns></returns>
        public DataTable SearchFitting(int la, int lb, int h ,string fitting_model)
        {
            string sqlCmd = " select m.[name],m.[model],m.[specifications],m.[material],m.[the_weight],c.[A],c.[I],c.[W],c.[radius] " +
                            " from tb_materialkind m,tb_tubeCharacter c " +
                            " where m.[model] like '" + fitting_model + "%' and ( " +
                            " (m.[name] = '立杆' and m.[model] like '%-" + h + "') or " +
                            " (m.[name] = '竖向斜杆' and m.[model] like '%-" + la + "×" + h + "') or " +
                            " (m.[name] = '水平斜杆' and m.[model] like '%-" + lb + "×" + la + "') or " +
                            " (m.[name] = '横向水平杆' and m.[model] like '%-" + lb + "') or  " +
                            "  (m.[name] = '纵向水平杆' and m.[model] like '%-" + la + "')" +
                            " ) and m.[character_id] = c.[character_id]";
            SQLiteConnection conn = new SQLiteConnectionBase().connectToDatabase();
            DataTable dt = SQLiteHelper.ExecuteDataSet(conn, sqlCmd, null).Tables[0];
            return dt;
        }
        /// <summary>
        /// 根据λ的值查询φ的值
        /// </summary>
        /// <param name="tens">十位</param>
        /// <param name="units">个位</param>
        /// <returns></returns>
        public double SearchFi(int tens,int units) 
        {
            string sqlCmd = "select [" + units + "] from tb_q345fi where λ=" + tens;
            SQLiteConnection conn = new SQLiteConnectionBase().connectToDatabase();
            DataTable dt = SQLiteHelper.ExecuteDataSet(conn, sqlCmd, null).Tables[0];
            double fi = (double)dt.Rows[0][0];
            return fi;
        }

        /// <summary>
        /// 封装在TFS_
        /// </summary>
        /// <param name="province">省份</param>
        /// <param name="city">城市</param>
        /// <returns>KN/M2</returns>
        public double Searchω0(string province, string city)
        {
            double _ω0 = -1;
            string sqlCmd = "select w0 from tb_windpress where con_province='" + province + "' and  con_city='" + city+"'";
            SQLiteConnection conn = new SQLiteConnectionBase().connectToDatabase();
            DataTable dt = SQLiteHelper.ExecuteDataSet(conn, sqlCmd, null).Tables[0];
            if (dt.Columns.Count > 0)
            {
                _ω0 = (double)dt.Rows[0][0];
            }
            return _ω0;
        }


        public DataTable SearchAnchorFromGSteel(string anchorModel) 
        {
            SQLiteConnection conn = new SQLiteConnectionBase().connectToDatabase();
            string sql = "select A , radius from tb_gsteel where model ='"+anchorModel+"'";
            DataTable dt = SQLiteHelper.ExecuteDataSet(conn, sql, null).Tables[0];
            return dt;
        }

        public DataTable SearchAnchorFromJSteel(string anchorModel)
        {
            SQLiteConnection conn = new SQLiteConnectionBase().connectToDatabase();
            string sql = "select A , radius from tb_jsteel where model ='" + anchorModel + "'";
            DataTable dt = SQLiteHelper.ExecuteDataSet(conn, sql, null).Tables[0];
            return dt;
        }

        public DataTable SearchAnchorFromCSteel(string anchorModel)
        {
            SQLiteConnection conn = new SQLiteConnectionBase().connectToDatabase();
            string sql = "select A , radius from tb_csteel where model ='" + anchorModel + "'";
            DataTable dt = SQLiteHelper.ExecuteDataSet(conn, sql, null).Tables[0];
            return dt;
        }

        public DataTable SearchAnchorFromTube(string anchorModel)
        {
            SQLiteConnection conn = new SQLiteConnectionBase().connectToDatabase();
            string sql = "select A , radius from tb_tubeCharacter where model ='" + anchorModel + "'";
            DataTable dt = SQLiteHelper.ExecuteDataSet(conn, sql, null).Tables[0];
            return dt;
        }


    }
}
