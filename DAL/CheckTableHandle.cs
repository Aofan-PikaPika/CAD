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

        public DataTable SearchFitting(double la, double lb, double h ,string fitting_model)
        {
            string sqlCommand = " select m.[name],m.[model],m.[specifications],m.[material],m.[the_weight],c.[A],c.[I],c.[W],c.[radius] " +
                                " from tb_materialkind m ,tb_tubeCharacter c " +
                                " where m.[model] like '"+fitting_model+"%' and( " +
                                "   (m.[name] = '立杆' and m.[model] like '%-"+h+"' )or " +
                                "   (m.[name] = '竖向斜杆' and m.[model] like '%-"+la+"×"+h+"') or " +
                                "   (m.[name] = '纵向水平杆' and m.[model] like '%-"+la+"') or  " +
                                "   (m.[name] = '横向水平杆' and m.[model] like '%-"+lb+"')   or  " +
                                "   (m.[name] = '水平斜杆' and m.[model] like '%-"+lb+"×"+la+"') " +
                                "  ) and m.[character_id] = c.[character_id] ";
            SQLiteConnection conn = new SQLiteConnectionBase().connectToDatabase();
            DataTable dt = SQLiteHelper.ExecuteDataSet(conn, sqlCommand, null).Tables[0];
            return dt;
        }
    }
}
