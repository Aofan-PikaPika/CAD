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
        /// fi值公开
        /// </summary>
        public static  double fi = -1.0;

        public static double N1 = -1.0;
        /// <summary>
        /// 连墙件净截面面积
        /// </summary>
        public static double An = -1.0;

        /// <summary>
        /// f抗拉弯设计值
        /// </summary>
        public static double f = -1.0;

        /// <summary>
        /// 连墙件抗滑移设计值
        /// </summary>
        public static double FAF = -1.0;


        public void CalcFi() 
        {
            //确定i值cm，使用公式5公开的方法
            double  i = Controller5.tfs_anchor.FindAnchorPara("radius");

            //步距公式转换
            LengthUnitConversion h = new LengthUnitConversion();
            h.M = ScaffoldPara.H;
            F_LmdAnchor f_lmdanchor = new F_LmdAnchor(h.CM,i);
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

        public void Compare() 
        {
            CalcFi();

            //公式5已经把单位转换好 N/mm
             N1 = Controller5.N1;
             An = Controller5.An;
             f = Controller5.f;
             FAF = fi * An * f;
            if (N1 <= FAF)
            {
                //通过返回字符串
            }
            else 
            {
                //不通过，抛出异常
            }
        }


    }
}
