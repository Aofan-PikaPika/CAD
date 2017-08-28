using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Entity
{
    public static class ScaffoldPara
    {
       // public static int Pro_Id { get; set; }//工程ID
        //工程信息实体类中已经有pro_id这一项
        public static string Sca_Type { get; set; }//脚手架类型
        public static int Con_Layers { get; set; }//同时施工的层数
        public static int Act_Layers { get; set; }//实际铺设脚手板层数
        public static string Base_Type { get; set; }//基础类型
        public static string Soil_Types { get; set; }//地基土类型
        public static string Rough_Level { get; set; }//地面粗糙层度
        public static double Cha_Value { get; set; }//地基承载力特征值
        public static double Pad_Area { get; set; }//垫板面积
        public static string Anchor_Style { get; set; }//连墙件的布置方式
        public static string Anchor_Type { get; set; }//连墙件类型
        public static string Anchor_Model { get; set; }//连墙件型号
        public static string Anchor_Connect { get; set; }//连墙件的连接方式
        public static string Sca_Situation { get; set; }//脚手架状况
        public static string Bui_Status { get; set; }//背靠建筑物状况
        public static double Bui_Distance { get; set; }//脚手架内立杆距建筑物距离
        public static int Per_Brace { get; set; }//每x跨间设置扣件钢管剪力撑
        public static int Per_Level { get; set; }//每x跨设置水平斜杆
        public static int Per_Set { get; set; }//脚手板铺设层数每隔x一设
        public static double La { get; set; }//立杆纵距
        public static double Lb { get; set; }//立杆横距
        public static double H { get; set; }//相邻水平杆竖向步距
        public static int fast_num { get; set; }//扣件个数
        public static string fitting_model { get; set; }//构配件型号
        public static int step_num { get; set; }//步数
        public static void Clear()
        {
            //Pro_Id = 0;
            Sca_Type = null;
            Act_Layers=0;
            Con_Layers = 0;
            Base_Type=null;
            Soil_Types=null;
            Rough_Level=null;
            Cha_Value=0.0;
            Pad_Area=0.0;
            Anchor_Style=null;
            Anchor_Type=null;
            Anchor_Model=null;
            Anchor_Connect=null;
            Sca_Situation=null;
            Bui_Status=null;
            Bui_Distance =0.0;
            Per_Brace=0;
            Per_Level=0;
            Per_Set=0;
            La=0.0;
            Lb=0.0;
            H = 0.0;
            fast_num=0;
            fitting_model=null;
            step_num = 0;
        }
    }


}
