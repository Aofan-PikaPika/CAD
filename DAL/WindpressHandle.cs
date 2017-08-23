using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using DAL;

namespace DAL
{
    /// <summary>
    /// 这个是用来省市联动查询，查询基本风压的类
    /// </summary>
    public class WindpressHandle
    {
        private SQLiteConnectionBase _connBase = new SQLiteConnectionBase();

        //这个函数用来查询tb_windpress
        public DataTable SearchProvince()
        {
            SQLiteConnection conn = _connBase.connectToDatabase();
            //以con_province分组的原因是存在很多正常冗余的数据
            //以rowid大小排序的原因是要复现“省”一列在规范内出现的顺序
            string sqlSearchProvince = "select con_province from tb_windpress group by con_province order by rowid";
            //搜索不进行参数化
            DataTable dt = SQLiteHelper.ExecuteDataSet(conn, sqlSearchProvince, null).Tables[0];
            //检查表，一定能执行正确
            return dt;
        }

        public DataTable SearchCity_Windpress(string province)
        {
            SQLiteConnection conn = _connBase.connectToDatabase();
            string sql = "select con_city,w0 from tb_windpress where w0 not null and con_province='" + province + "'";
            DataTable dt = SQLiteHelper.ExecuteDataSet(conn, sql, null).Tables[0];
            return dt;
        }


    }
}
