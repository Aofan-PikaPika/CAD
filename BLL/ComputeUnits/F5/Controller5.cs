using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Entity;
using BLL.ComputeUnits.F1;
using BLL.ComputeUnits.F2;

namespace BLL.ComputeUnits.F5
{
    public class Controller5
    {
        /// <summary>
        /// 支架立杆轴向力设计值
        /// </summary>
        public static  double N1 = -1.0;
        /// <summary>
        /// 连墙件净截面面积
        /// </summary>
        public static  double An = -1.0;

        /// <summary>
        /// f抗拉弯设计值
        /// </summary>
        public static  double  f=-1.0;

        /// <summary>
        /// 公开连墙件查询类
        /// </summary>
        public static TFS_Anchor tfs_anchor = null;

        /// <summary>
        /// 支架立杆轴向力设计值
        /// </summary>
        public void CalcN1()
        {
            //跨数
            int stride=0;
            //步数
            int step=0;
            string anchorStyle = ScaffoldPara.Anchor_Style;
            switch (anchorStyle)
            {
                case "2步2跨": 
                    {
                        stride = 2;
                        step = 2;
                    }
                    break;
                case "2步3跨":
                    {
                        stride = 3;
                        step = 2;
                    }
                    break;
                case "3步3跨":
                    {
                        stride = 3;
                        step = 3;
                    }
                    break;
            }
            //连墙件水平间距M
            double L1 = stride * ScaffoldPara.La;
            //连墙件垂直间距M
            double H1 = step * ScaffoldPara.H;
            //风荷载标准值KN/M2
            //从公式2获取
            double wk = Controller2.f_ωk.TargetValue;
            F_N1W f_n1w = new F_N1W(L1,H1,wk);
            f_n1w.ComputeValue();
            //变形所产生的轴向力3KN；
             const double  N0=3.0;
             F_N1 f_n1 = new F_N1(f_n1w.TargetValue,N0);
             f_n1.ComputeValue();
             N1 = f_n1.TargetValue;
          
        }
        /// <summary>
        /// 连墙件净截面面积
        /// </summary>
        public void CalcAn()
        {
            string anchorType = ScaffoldPara.Anchor_Type;
            string anchorModel = ScaffoldPara.Anchor_Model;
            TFS_Anchor tfs_anchor = new TFS_Anchor(anchorType, anchorModel);
            An = tfs_anchor.FindAnchorPara("A");
        }

        /// <summary>
        /// 抗压拉弯设计值
        /// </summary>
        public void Calcf() 
        {
            TFM1_f tfm1_f = new TFM1_f("Q235");
            f = tfm1_f.Search();
        }

        public void Compare()
        {
            CalcN1();
            CalcAn();
            Calcf();
            //公式转换
            _2DLoadUnitConversion newN1 = new _2DLoadUnitConversion();
            newN1.KNperM2 = N1;
            N1 = newN1.NperMM2;
            if ((N1 / An) <= f)
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
