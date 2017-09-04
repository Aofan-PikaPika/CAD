using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Entity;
using BLL.ComputeUnits.F1;

namespace BLL.ComputeUnits.F8
{
    public class Controller8
    {
        public static F_PCF f_pcf = null;
        
        //计算出pk的值
        private void Calcpk()
        {
            double NG1K = Controller1.f_NG1K.TargetValue;
            double NG2K = Controller1.f_NG2K.TargetValue;
            double NQK = Controller1.f_NQK.TargetValue;
            double NK = NG1K + NG2K + NQK;
            f_pcf = new F_PCF(NG1K, NG2K, NQK, NK,ScaffoldPara.Pad_Area , f_pcf.TargetValue);
            f_pcf.ComputeValue();
        }
        
        public static string lString = "";
        public static string rString = "";
        //比较pk与与fg的大小，符合要求输出不符合抛出异常
        public void Compare()
        {
            if(f_pcf.TargetValue<=ScaffoldPara.Cha_Value)
            {
                double fg = ScaffoldPara.Cha_Value;
                lString = f_pcf.TargetValue.ToString("#0.00");
                rString = fg.ToString("#0.00");
            }
            else
                throw new Exception("地基承载力验算未通过");

        }
    }
}
