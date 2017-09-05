using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Entity;
using DAL;
using System.Data;
using BLL.Service;

namespace BLL
{
    /// <summary>
    /// 数据库控制类
    /// </summary>
    public class SQLOperations
    {

        #region 打开，保存时，向下调用数据库crud实现窗体内容复现的逻辑
        /// <summary>
        /// 在新建并保存文件时，ID号未知，但此时实体类已经被UI层填好
        /// 作用是调用函数填充数据库的同时向XMLOperation返回一个工程ID值
        /// 其中工程ID值已经在AddInfo中输入实体类
        /// 数据库的错误通过弹窗处理
        /// </summary>
        public void AddEntityToDatabase()
        {
            //将工程信息部分数据存入数据库，生成一个工程Id值
            ProjinfoHandle projinfoHandle = new ProjinfoHandle();
            ScaffordParaHandle scafdparaHandle = new ScaffordParaHandle();
            int pro_Id = projinfoHandle.AddInfo();//程序调用这个函数时，实体类已经从窗体获取了数据
            if (pro_Id == -1)//判断插入数据库是否成功
            {
                ErrorService.Show("添加新数据发生错误,保存失败！");
            }
            else
            {
                //脚手架参数
                scafdparaHandle.AddPara(pro_Id);
                //材料库
                AddAllMaterialInfo(pro_Id);
            }
            //无论如何也要往外传值，-1也要往外传
            ProjectInfo.Pro_Id = pro_Id;
           
            
        }


        /// <summary>
        /// 在保存文件时，已知工程ID，根据工程ID更新其所对应的记录
        /// </summary>
        /// <param name="pro_Id"></param>
        public void UpdateDatabaseFromEntity(int pro_Id)
        {
            ProjinfoHandle projinfoHandle = new ProjinfoHandle();
            ScaffordParaHandle scaf = new ScaffordParaHandle();
            bool isSuccess = projinfoHandle.UpdateInfo(pro_Id);
            bool isSuccessPara = scaf.UpdatePara(pro_Id);
            AddAllMaterialInfo(pro_Id);
            //材料库
            if (!isSuccess&&!isSuccessPara)
            {
                ErrorService.Show("刷新数据时出现问题");
                return;
            }
        }


        /// <summary>
        /// 这个函数的作用就是打开文件时，将数据库中的所有记录填写到窗体上
        /// </summary>
        /// <param name="pro_Id"></param>
        public bool SearchDatabaseFillEntity(int pro_Id)
        {
            ProjinfoHandle projinfoHandle = new ProjinfoHandle();
            ScaffordParaHandle scaf = new ScaffordParaHandle();
            DataTable dt = projinfoHandle.SearchInfo(pro_Id);
            DataTable dtPara = scaf.SearchPara(pro_Id);
            //判断dt的合理性
            if (dt.Rows.Count == 1&&dtPara.Rows.Count==1)//正确的dt会只查询出一行
            {
                try
                {
                    //工程信息
                    ProjectInfo.Clear();
                    ProjectInfo.Pro_Id = pro_Id;
                    ProjectInfo.Pro_Name = dt.Rows[0]["pro_name"].ToString();
                    ProjectInfo.Pro_Type = dt.Rows[0]["pro_type"].ToString();
                    ProjectInfo.Con_Province= dt.Rows[0]["con_province"].ToString();
                    ProjectInfo.Con_City = dt.Rows[0]["con_city"].ToString();
                    ProjectInfo.Unit = dt.Rows[0]["unit"].ToString();
                    ProjectInfo.Con_Unit = dt.Rows[0]["con_unit"].ToString();
                    ProjectInfo.Sup_Unit = dt.Rows[0]["sup_unit"].ToString();
                    ProjectInfo.Con_Area = double.Parse(dt.Rows[0]["con_area"].ToString());
                    ProjectInfo.Con_Height = double.Parse(dt.Rows[0]["con_height"].ToString());
                    ProjectInfo.Des_Unit = dt.Rows[0]["des_unit"].ToString();

                    //脚手架参数
                    ScaffoldPara.Clear();
                    ScaffoldPara.Sca_Type = dtPara.Rows[0]["sca_type"].ToString();
                    ScaffoldPara.Con_Layers = (int)dtPara.Rows[0]["con_layers"];
                    ScaffoldPara.Act_Layers = (int)dtPara.Rows[0]["act_layers"];
                    ScaffoldPara.Soil_Types = dtPara.Rows[0]["soil_types"].ToString();
                    ScaffoldPara.Rough_Level = dtPara.Rows[0]["rough_level"].ToString();
                    ScaffoldPara.Cha_Value = (double)dtPara.Rows[0]["cha_value"];
                    ScaffoldPara.Pad_Area = (double)dtPara.Rows[0]["pad_area"];
                    ScaffoldPara.Anchor_Style = dtPara.Rows[0]["anchor_style"].ToString();
                    ScaffoldPara.Anchor_Type = dtPara.Rows[0]["anchor_type"].ToString();
                    ScaffoldPara.Anchor_Model = dtPara.Rows[0]["anchor_model"].ToString();
                    ScaffoldPara.Anchor_Connect = dtPara.Rows[0]["anchor_connect"].ToString();
                    ScaffoldPara.Sca_Situation = dtPara.Rows[0]["sca_situation"].ToString();
                    ScaffoldPara.Bui_Status = dtPara.Rows[0]["bui_status"].ToString();
                    ScaffoldPara.Bui_Distance = (double)dtPara.Rows[0]["bui_distance"];
                    ScaffoldPara.Per_Brace = (int)dtPara.Rows[0]["per_brace"];
                    ScaffoldPara.Per_Level = (int)dtPara.Rows[0]["per_level"];
                    ScaffoldPara.Per_Set = (int)dtPara.Rows[0]["per_set"];
                    ScaffoldPara.La = (double)dtPara.Rows[0]["la"];
                    ScaffoldPara.Lb = (double)dtPara.Rows[0]["lb"];
                    ScaffoldPara.H = (double)dtPara.Rows[0]["h"];
                    ScaffoldPara.Fast_Num = (int)dtPara.Rows[0]["fast_num"];
                    ScaffoldPara.Fitting_Model = dtPara.Rows[0]["fitting_model"].ToString();
                    ScaffoldPara.Step_Num = (int)dtPara.Rows[0]["step_num"];

                    //材料库
                    MaterialLib.clearMaterialLib();
                    MaterialLib.dtMaterial = new SQLOperations().GetMateriallib(ProjectInfo.Pro_Id);//为复现dgv中的内容，于数据库查询dt
                    new SQLOperations().FillValidArray(MaterialLib.dtMaterial);//为解决不打开材料库时数据消失的问题，复现validArray
                    return true;
                }
                catch
                {
                    ErrorService.Show("写入了不合法字符");
                    return false;
                }
            }
            else
            {
                ErrorService.Show("本机数据库与工程文件不匹配");
                return false;
            }
        }

        #endregion

        #region 以下是针对最近打开时间功能封装的函数
        //不需要任何参数，获取tb_projlog中时间最近的前五项
        //由于最近打开时间的增删改查需要用到不同的地方，所以四种均单独简单地封装了底层DAL的
        //CRUD功能。分别供其他地方调用
        public DataTable GetLog()
        {
            //UI层的列表框需要一个DataTable来表示文件名和文件路径
            ProjlogHandle projlogHandle = new ProjlogHandle();
            DataTable dt = projlogHandle.SearchLog();
            return dt;
        }

        //需要传入工程ID 工程名 文件路径，程序生成的最近打开时间.XML部分进行pro_name：文件名的切分
        public void AddLog(int pro_Id, string pro_Name,string sto_Path, string rec_Time)
        {
            ProjlogHandle projlogHandle = new ProjlogHandle();
            if (!projlogHandle.AddLog(pro_Id, pro_Name, sto_Path, rec_Time))
            {
                ErrorService.Show("添加最近文件记录错误");
            }
        }

        public void UpdateLog(int pro_Id,string pro_Name, string sto_Path, string rec_Time)
        {
            ProjlogHandle projlogHandle = new ProjlogHandle();
            if (!projlogHandle.UpdateLog(pro_Id, pro_Name, sto_Path, rec_Time))
            {
                //更新失败说明记录已经被删除，重新添加
                AddLog(pro_Id, pro_Name, sto_Path, rec_Time);
            }
        }

        public void DeleteLog(string sto_path)
        {
            ProjlogHandle projlogHandle = new ProjlogHandle();
            if (!projlogHandle.DeleteLog(sto_path))
            {
                ErrorService.Show("删除最近文件记录错误");
            }
        }

        #endregion

        #region 封装DAL层级联查询省市的函数
        public string[] GetProvince()
        {
            WindpressHandle windpressHandle = new WindpressHandle();
            DataTable dt = windpressHandle.SearchProvince();
            string[] provinceArr = new string[dt.Rows.Count];
            //遍历填充数组
            for (int i = 0; i < provinceArr.Length; i++)
            {
                provinceArr[i] = dt.Rows[i][0].ToString();
            }
            return provinceArr;
        }

        //这里直接返回了datatable 然后在主窗体上调节skinComboBox3.DisplayMember = "con_city";即可
        public DataTable GetCity(string province)
        {
            WindpressHandle windpressHandle = new WindpressHandle();
            DataTable dt = windpressHandle.SearchCity(province);
            if (dt.Rows.Count < 1)
            {
                ErrorService.Show("省份输入错误");
            }
            return dt;
        }
        #endregion

        #region 连墙件型号查询

        public DataTable GetSteelModel(string anchorType) 
        {
            AnchorHandle anchorhandle = new AnchorHandle();
            DataTable dt = null;
            switch (anchorType)
            {
                case "钢管":
                    {
                        dt = anchorhandle.GetAnchorModelFromTubeCharacter();
                    }
                    break;
                case "角钢": 
                    {
                        dt = anchorhandle.GetAnchorModelFromJSteel();
                    }
                    break;
                case "槽钢": 
                    {
                        dt = anchorhandle.GetAnchorModelFromCSteel();
                    }
                    break;
                case "工字钢": 
                    {
                        dt = anchorhandle.GetAnchorModelFromGSteel();
                    }
                    break;
            }
            return dt;
                  

        }

        #endregion

        #region 封装DAL层与材料库查询有关的函数
        /**
         * 其中一部分函数要直接供窗体层调用，显示对应杆件的值
         */
        public DataTable GetModelList(string name)
        {
            MateriallibHandle materiallibHandle = new MateriallibHandle();
            return materiallibHandle.SearchModel(name);//简单封装
            //return给界面，产生可选的下拉菜单
        }

        //获取一条整体记录的函数，返回一个DataTable
        public DataTable GetMeterialInfo(string name, string model)
        {
            MateriallibHandle materiallibHandle = new MateriallibHandle();
            return materiallibHandle.SearchAll(name, model);//简单封装
            //不存在错误的情况，因为值都是于检查表中查到的
        }
  
        public void AddAllMaterialInfo(int pro_Id)
        {
            MateriallibHandle materiallibHandle = new MateriallibHandle();
            //数组下标即为材料标号
            //大于零说明被设置过材料的数量
            materiallibHandle.DeleteRecord(pro_Id);
            for (int i = 0; i < MaterialLib.validArray.Length; i++)
            {
                if (MaterialLib.validArray[i] > 0)
                    materiallibHandle.InsertRecord(i, pro_Id, MaterialLib.validArray[i]);
            }

        }
        public DataTable GetMateriallib(int pro_Id)
        {
            MateriallibHandle materiallibHandle = new MateriallibHandle();
            return materiallibHandle.SearchMateriallibRec(pro_Id);
        }

        public void FillValidArray(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count;i++ )
                MaterialLib.validArray[int.Parse(dt.Rows[i]["fitting_id"].ToString())] = int.Parse(dt.Rows[i]["inventory"].ToString());
        }
        

        #endregion 

    }
}
