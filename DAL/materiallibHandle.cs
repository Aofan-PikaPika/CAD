using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;
using System.Data.SQLite;

namespace DAL
{
    public class MateriallibHandle
    {
        
        private SQLiteConnectionBase sqliteConnectionBase = new SQLiteConnectionBase();

        //这是根据“立杆”“横杆”等名称查询可选杆件类型的函数，返回一个dataset
        //一定执行成功
        public DataTable SearchModel(string name)
        {
            string str = string.Format("select model from tb_materialkind where name = '{0}'", name.Trim());//trim防止空格出现
            SQLiteConnection conn = sqliteConnectionBase.connectToDatabase();
            DataTable dt = null;
            dt = SQLiteHelper.ExecuteDataSet(conn, str, null).Tables[0];//给定的string表是写死的，只要写界面的人脑洞不大，一定可以执行成功
            return dt;
        }


        //根据工程ID删除材料库列表中“脏数据”的函数
        public void DeleteRecord(int pro_id)
        {
            string str = string.Format("delete from tb_materiallib where pro_id={0}", pro_id);
            SQLiteConnection conn = sqliteConnectionBase.connectToDatabase();
            SQLiteHelper.ExecuteNonQuery(conn, str, null);
            //仅仅是删除脏数据，脏数据的行数并不关心
            //表名正确，sql格式正确，一定能执行成功
            //这里不打算返回值，定义为void类型
        }

        //根据名称，型号，查询与一个杆件相关的一行所有记录，返回一个datatab
        public DataTable SearchAll(string Name, string Model)
        {
            string sqlSearch = "select fitting_id,name,model,specifications,material,the_weight from tb_materialkind where name='" + Name + "' and model='" + Model + "'";
            SQLiteConnection conn = sqliteConnectionBase.connectToDatabase();
            DataTable dt = SQLiteHelper.ExecuteDataSet(conn, sqlSearch, null).Tables[0];
            return dt;

        }


        //插入到材料库里一条记录，已经在内部进行了try-catch
        public bool InsertRecord(int fitting_Id, int pro_Id, int Inventory)
        {
            try
            {
                string sqlInsert = "insert into tb_materiallib(fitting_id,pro_id,inventory) values(" + fitting_Id + "," + pro_Id + "," + Inventory + ")";
                SQLiteConnection conn = sqliteConnectionBase.connectToDatabase();
                SQLiteHelper.ExecuteNonQuery(conn, sqlInsert);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
