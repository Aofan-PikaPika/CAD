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
        private double fi = 0.0;

        private int Lmd = 0;

        

        public void CalcFi() 
        {
            //确定i值cm，使用公式5公开的方法
            double  i = Controller5.tfs_anchor.FindAnchorPara("i");

            //步距公式转换
            LengthUnitConversion h = new LengthUnitConversion();
            h.M = ScaffoldPara.H;
            F_LmdAnchor f_lmdanchor = new F_LmdAnchor(h.CM,i);
            f_lmdanchor.ComputeValue();           
            TFS_FiAnchor tfs_fianchor = new TFS_FiAnchor(f_lmdanchor.TargetValue);
            tfs_fianchor.Search();
            fi = tfs_fianchor.TargetValue;
        }

        public void Compare() 
        {
            CalcFi();

            //公式5已经把单位转换好 N/mm
            double N1 = Controller5.N1;
            double An = Controller5.An;
            double f = Controller5.f;

            if (N1 <= fi * An * f)
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
