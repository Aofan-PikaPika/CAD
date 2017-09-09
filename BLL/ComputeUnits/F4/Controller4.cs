using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.ComputeUnits.F1;
using Model.Entity;

namespace BLL.ComputeUnits.F4
{
    public class Controller4
    {
        public static F_Q1 f_q1 = null;
        public static F_V f_v = null;

        public Dictionary<string, string> solveDic = new Dictionary<string, string>();

        //计算出q1（作用在横向水平杆上的荷载标准值）的值
        //不能在求q1的时候将单位都换算成N/MM^2，运算结果会出现错误
        private void CalcQ1()
        {
          double m = Controller1.tfs_Fitting.FindMaterialPara("横向水平杆", "the_weight");
          //_2DLoadUnitConversion q = new _2DLoadUnitConversion();//将q（施工均布荷载标准值）单位从KN/M^2换算成N/MM^2
          double q=Controller1.tfm1_qConsLoad.TargetValue;
         // LengthUnitConversion la = new LengthUnitConversion();
         // LengthUnitConversion lb = new LengthUnitConversion();
         // la.M = ScaffoldPara.La;//将la，lb的单位换成毫米
         // lb.M = ScaffoldPara.Lb;
          f_q1 = new F_Q1(m, ScaffoldPara.Lb, ScaffoldPara.La, q);
          f_q1.ComputeValue();//计算出q1的值
        }
         
        //计算出V的值
        //KN/M^2=N/MM^2
        private void CalcV()
        {
            double I = Controller1.tfs_Fitting.FindMaterialPara("横向水平杆", "I") * Math.Pow(10, 4);//将I的单位换成MM^4
            double E = 2.06 * Math.Pow(10, 5);
            LengthUnitConversion lb = new LengthUnitConversion();
            lb.M = ScaffoldPara.Lb;//将lb的单位换成毫米
            f_v = new F_V(f_q1.TargetValue, lb.MM, E, I);
            f_v.ComputeValue();
        }
        public void Compare()
        {
            LengthUnitConversion lb = new LengthUnitConversion();
            lb.M = ScaffoldPara.Lb;
            double minv = -1;
            CalcQ1();
            CalcV();
            if (lb.MM / 150 > 10)//计算出min[lb/150,10]的值
            {
                minv = 10;
            }
            else
            {
                minv = lb.MM / 150;
            }
            if (f_v.TargetValue < minv)//将V与min[lb/150,10]进行比较，符合要求输出，不符合抛出异常
            {
                lString = Controller4.f_v.TargetValue.ToString("#0.000") ;
                rString = minv.ToString("#0.000");
                InputDic();
            }  
            else      
            {
                throw new Exception("横向水平杆挠度验算未通过");
            }
        }
        public static string lString = "";
        public static string rString = "";

        private void InputDic()
        {
            solveDic.Add("@F_q1@", f_q1.ToString());
            solveDic.Add("@F_V@", f_v.ToString());
            solveDic.Add("@C4_rString@", rString);
        }
    }   
}