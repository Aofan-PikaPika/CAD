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

        /// <summary>
        /// 在新建并保存文件时，ID号未知，但此时实体类已经被UI层填好
        /// 作用是调用函数填充数据库的同时向XMLOperation返回一个工程ID值
        /// 其中工程ID值已经在AddInfo中输入实体类
        /// 数据库的错误通过弹窗处理
        /// </summary>
        public int AddEntityToDatabase()
        {
            //将工程信息部分数据存入数据库，生成一个工程Id值
            ProjinfoHandle projinfoHandle = new ProjinfoHandle();
            int pro_Id = projinfoHandle.AddInfo();//程序调用这个函数时，实体类已经从窗体获取了数据
            if (pro_Id == -1)//判断插入数据库是否成功
            {
                ErrorService.Show("保存新数据发生错误");
            }

            //以下再写脚手架参数和材料库的添加逻辑。。。

            return pro_Id;
        }


        /// <summary>
        /// 在保存文件时，已知工程ID，根据工程ID更新其所对应的记录
        /// </summary>
        /// <param name="pro_Id"></param>
        public void UpdateDatabaseFromEntity(int pro_Id)
        {
            ProjinfoHandle projinfoHandle = new ProjinfoHandle();
            bool isSuccess = projinfoHandle.UpdateInfo(pro_Id);
            if (!isSuccess)
            {
                ErrorService.Show("刷新数据时出现问题");
                return;
            }

            //以下再写更新脚手架参数和材料库的更新逻辑。。。。
        }


        /// <summary>
        /// 这个函数的作用就是打开文件时，将数据库中的所有记录填写到窗体上
        /// </summary>
        /// <param name="pro_Id"></param>
        public void SearchDatabaseFillEntity(int pro_Id)
        {
            ProjinfoHandle projinfoHandle = new ProjinfoHandle();
            DataTable dt = projinfoHandle.SearchInfo(pro_Id);
            //判断dt的合理性
            if (dt.Rows.Count == 1)//正确的dt会只查询出一行
            {
                try
                {
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
                }
                catch
                {
                    ErrorService.Show("写入了不合法字符");
                    return;
                }
            }
            else
            {
                ErrorService.Show("本机数据库与工程文件不匹配");
                return;
            }
        }


        #region 以下是针对最近打开时间功能封装的函数
        //不需要任何参数，获取tb_projlog中时间最近的前五项
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
            if (projlogHandle.AddLog(pro_Id, pro_Name, sto_Path, rec_Time))
            {
                ErrorService.Show("最近文件添加错误");
            }
        }
        #endregion

        #region 封装DAL层级联查询省市和对应城市风压的函数
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
    }
}
