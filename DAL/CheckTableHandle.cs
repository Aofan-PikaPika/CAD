﻿using System;
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
    }
}
