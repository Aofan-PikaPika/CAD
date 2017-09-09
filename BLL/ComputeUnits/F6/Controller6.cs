using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.ComputeUnits.F5;
using Model.Entity;

namespace BLL.ComputeUnits.F6
{
    public class Controller6
    {
        /// <summary>
        /// fi值
        /// </summary>
        public  double fi = -1.0;

        public double N1 = -1.0;
        /// <summary>
        /// 连墙件净截面面积
        /// </summary>
        public double An = -1.0;

        /// <summary>
        /// f抗拉弯设计值
        /// </summary>
        public  double f = -1.0;

        /// <summary>
        /// 私有lmda
        /// </summary>
        private F_LmdAnchor f_lmdanchor = null;

        public void CalcFi() 
        {
            //确定i值cm，使用公式5公开的方法
            double  i = Controller5.tfs_anchor.FindAnchorPara("radius");

            //脚手架距建筑物距离l0公式转换
            LengthUnitConversion l0 = new LengthUnitConversion();
            l0.MM = ScaffoldPara.Bui_Distance;
            f_lmdanchor = new F_LmdAnchor(l0.CM,i);
            f_lmdanchor.ComputeValue();
            if (f_lmdanchor.TargetValue <= 230)
            {
                TFS_FiAnchor tfs_fianchor = new TFS_FiAnchor(f_lmdanchor.TargetValue,ScaffoldPara.Anchor_Type);
                tfs_fianchor.Search();
                fi = tfs_fianchor.TargetValue;
            }
            else 
            {
                //lamda大于230，运算不通过
                fi = -1.0;
            }
           
        }

        public static string lString = "";//这个是表达公式左边连墙件轴向力设计值的字符串 
        public static string rString = "";//这个表达公式右边fiAf的字符串
        public void Compare() 
        {
            CalcFi();

            //公式5已经把单位转换好 N/mm
             N1 = Controller5.N1;
             An = Controller5.An;
             f = Controller5.f;
             if (N1 <= fi * An * f)
            {
                lString = N1.ToString("#0.000");
                rString = fi.ToString() + "*" + An.ToString() + "*" + f.ToString() + "=" + (fi * An * f).ToString("#0.000");
                InputDic();
            }
            else 
            {
                throw new Exception("连墙件稳定性计算未通过");
            }
        }


        /// <summary>
        /// 声明一个dictionary
        /// </summary>
        public Dictionary<string, string> C6Dic = new Dictionary<string, string>();

        /// <summary>
        /// 向dictionary插入信息
        /// </summary>
        private void InputDic()
        {
            C6Dic.Add("@F_lmdanchor@", f_lmdanchor.ToString());
            C6Dic.Add("@Tfs_fianchor@", fi.ToString());
            C6Dic.Add("@Anchor_A@",An.ToString());
            C6Dic.Add("@Anchor_f@",f.ToString());
            C6Dic.Add("@C6_LString@", lString);
            C6Dic.Add("@C6_RString@", rString);
        }


    }
}
