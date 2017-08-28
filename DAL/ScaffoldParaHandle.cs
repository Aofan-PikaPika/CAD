using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;
using Model.Entity;

namespace DAL
{
    public class ScaffordParaHandle
    {
 
        private SQLiteConnectionBase con = new SQLiteConnectionBase();
      
        public bool AddPara(int pro_Id)
        {
            //ScaffoldPara.Con_Layers=3;
            //ScaffoldPara.Sca_Type="dad";

            string sqlInsert = "insert into tb_scaffoldPara(pro_id,sca_type,con_layers,act_layers,soil_types,rough_level,cha_value,pad_area,anchor_style,anchor_type,anchor_model,anchor_connect,sca_situation,bui_status,bui_distance ,per_brace,per_level,per_set,la,lb,h,fast_num,fitting_model,step_num)"
+ "values(" + pro_Id + ",'" + ScaffoldPara.Sca_Type + "'," + ScaffoldPara.Con_Layers + "," + ScaffoldPara.Act_Layers + ",'" + ScaffoldPara.Soil_Types + "','" + ScaffoldPara.Rough_Level + "'," + ScaffoldPara.Cha_Value + "," + ScaffoldPara.Pad_Area + ",'" + ScaffoldPara.Anchor_Style + "','" + ScaffoldPara.Anchor_Type + "','" + ScaffoldPara.Anchor_Model + "','" + ScaffoldPara.Anchor_Connect + "','" + ScaffoldPara.Sca_Situation + "','" + ScaffoldPara.Bui_Status + "'," + ScaffoldPara.Bui_Distance + "," + ScaffoldPara.Per_Brace + "," + ScaffoldPara.Per_Level + "," + ScaffoldPara.Per_Set + "," + ScaffoldPara.La + "," + ScaffoldPara.Lb + "," + ScaffoldPara.H + "," + ScaffoldPara.fast_num + ",'"+ScaffoldPara.fitting_model+"',"+ScaffoldPara.step_num+")";
            SQLiteConnection conn = con.connectToDatabase();
            int i = SQLiteHelper.ExecuteNonQuery(conn,sqlInsert);
            if (i == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataTable SearchPara(int pro_Id)
        {
            string sqlSearch = "select sca_type,con_layers,act_layers,soil_types,rough_level,cha_value,pad_area,anchor_style,anchor_type,anchor_model,anchor_connect,sca_situation,bui_status,bui_distance ,per_brace,per_level,per_set,la,lb,h,fast_num,fitting_model,step_num from tb_scaffoldPara"
                                    + " where pro_id = " + pro_Id;
            SQLiteConnection conn = con.connectToDatabase();
            DataTable dt = SQLiteHelper.ExecuteDataSet(conn, sqlSearch, null).Tables[0];
            return dt;
        }

        public bool UpdatePara(int pro_Id)
        {

           // ScaffoldPara.Con_Layers =66;
            //ScaffoldPara.Sca_Type = "yyy";

            string sqlUpdate = "update tb_scaffoldPara set sca_type= '" + ScaffoldPara.Sca_Type +
                                "',con_layers=" + ScaffoldPara.Con_Layers +
                                ",act_layers=" + ScaffoldPara.Act_Layers +
                                ",soil_types='" + ScaffoldPara.Soil_Types +
                                "',rough_level='" + ScaffoldPara.Rough_Level +
                                "',cha_value=" + ScaffoldPara.Cha_Value +
                                ",pad_area=" + ScaffoldPara.Pad_Area +
                                ",anchor_style='" + ScaffoldPara.Anchor_Style +
                                "',anchor_type='" + ScaffoldPara.Anchor_Type +
                                "',anchor_model='" + ScaffoldPara.Anchor_Model +
                                "',anchor_connect='" + ScaffoldPara.Anchor_Connect +
                                "',sca_situation='" + ScaffoldPara.Sca_Situation +
                                "',bui_status='" + ScaffoldPara.Bui_Status +
                                "',bui_distance ='" + ScaffoldPara.Bui_Distance +
                                "',per_brace=" + ScaffoldPara.Per_Brace +
                                ",per_level=" + ScaffoldPara.Per_Level +
                                ",per_set=" + ScaffoldPara.Per_Set +
                                ",la=" + ScaffoldPara.La +
                                ",lb=" + ScaffoldPara.Lb +
                                ",h=" + ScaffoldPara.H +
                                ",fast_num="+ScaffoldPara.fast_num+
                                ",fitting_model='"+ScaffoldPara.fitting_model+
                                "',step_num="+ScaffoldPara.step_num+
                                " where  pro_id ="+pro_Id;
            SQLiteConnection conn =con.connectToDatabase();
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
