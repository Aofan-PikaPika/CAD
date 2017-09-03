using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.ComputeUnits.F1;
using Model.Entity;

namespace BLL.ComputeUnits.F3
{
    public class Controller3
    {
        //出计算书要调用到这几个公式
        public static F_q2 f_q2 = null;
        public static F_Mh f_Mh = null;
        public static F_σ f_σ = null;

        //本控制类特有的最终变量
        public static double _σ = -1;
        public static double fh = -1;//这里是横向水平杆的f，和controller1中的f不一样

        //公式3单项依赖公式1
        private bool TestController1Para()
        {
            if (string.IsNullOrEmpty(Controller1.lString) || string.IsNullOrEmpty(Controller1.rString))
                return false;
            else
                return true;
        }
        private void Calcσ()
        {
            //自Controller1中已经查好的表，取出横向水平杆的m  单位:kg
            double m = Controller1.tfs_Fitting.FindMaterialPara("横向水平杆","the_weight");
            //自Controller1中中已经查好的表，取出施工均布活荷载标准值
            int q = Controller1.tfm1_qConsLoad.TargetValue;
            //计算作用在横向水平杆上的荷载设计值 单位：KN/M
            f_q2 = new F_q2(m, ScaffoldPara.Lb, ScaffoldPara.La, q);
            f_q2.ComputeValue();
            //计算水平横杆所承受的弯矩 单位：KN×M
            f_Mh = new F_Mh(f_q2.TargetValue, ScaffoldPara.Lb);
            f_Mh.ComputeValue();
            //计算正应力前需要统一KN为N，统一CM为MM
            //将上一步f_Mh的弯矩换算
            BendingMomentUnitConversion Mh = new BendingMomentUnitConversion();
            Mh.KNmultiplyM = f_Mh.TargetValue;
            //将Controller1中的W换算
            //自Controller1中的表取得横向水平杆的截面模量
            double Wcm3 = Controller1.tfs_Fitting.FindMaterialPara("横向水平杆","W");
            double Wmm3 = Wcm3 * 10 * 10 * 10;
            //计算横向水平杆因弯矩而承受的正应力 单位
            f_σ = new F_σ(Mh.NmultiplyMM, Wmm3);
            f_σ.ComputeValue();
            _σ = f_σ.TargetValue;
        }
        private void Calcfh()
        {
            //因为F1中已经存在TFM1_f，这里new出他的引用
            TFM1_f tfm3_f = new TFM1_f("Q235");
            tfm3_f.Search();
            if(tfm3_f.IsSearched)
                fh = tfm3_f.TargetValue;
        }

        public void Compare()
        {
            bool isController1Finish = TestController1Para();
            if (!isController1Finish) return;//由于F3和F2有着耦合关系，如果F1未经计算，不可能计算F2
            Calcσ();
            Calcfh();
            if (_σ <= 0 || fh <= 0) return;
            if (_σ <= fh)
            {
                lString = _σ.ToString("#0.00");
                rString = fh.ToString("#0.00");
            }
            else 
            {
                throw new Exception("横向水平杆承载力验算未通过");
            }
        }
        public static string lString = "";
        public static string rString = "";

    }
}
