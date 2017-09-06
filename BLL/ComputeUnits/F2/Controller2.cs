using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Entity;//需要用到ScaffPara全局实体类中的参数
using BLL.ComputeUnits.F1;//F2的控制类用到了F1中已经含有的变量
using BLL.ComputeUnits;

namespace BLL.ComputeUnits.F2
{
    /// <summary>
    /// 现实中F1和F2的功能一部分，本来就是耦合的，在这里F2单项依赖F1,将他们写耦合
    /// </summary>
    public class Controller2
    {
        public double Mw = -1;//KN * M
        public double W = -1;//mm3
        //生成计算书需要的公式
        public static F_ωk f_ωk = null;//C5需要用
        public F_Mw f_Mw = null;
        public F_NWind f_NWind = null;//这个是组合了风荷载的公式，值比F_N小，所以没用在计算中，只在这里输出一下
        //生成计算书需要的查表结果
        public TFS_ω0 tfs_ω0 = null;

        //公式2单项依赖公式1
        //测试controller1有没有计算完毕的函数

        public Dictionary<string, string> solveDic = new Dictionary<string, string>();
        private bool TestController1Para()
        {
            if (string.IsNullOrEmpty(Controller1.lString) || string.IsNullOrEmpty(Controller1.rString))
                return false;
            else
                return true;
        }

        private void CalcMw()
        {
            //由粗糙程度查μz,无单位
            TFM_μzStandingTube tfm_μzStandingTube = new TFM_μzStandingTube(ScaffoldPara.Rough_Level);
            tfm_μzStandingTube.Search();
            //由界面上输入的脚手架信息，步距，纵距，查μs，无单位
            //由于脚手架的步距和纵距在输入时都是m为单位。无需进行单位换算
            TFM_μs tfm_μs = new TFM_μs(ScaffoldPara.Sca_Situation,ScaffoldPara.Bui_Status,ScaffoldPara.Fitting_Model,ScaffoldPara.La,ScaffoldPara.H);
            tfm_μs.Search();
            //查询当地基本风压ω0
            //城市和省份由级联查询得到，
            tfs_ω0 = new TFS_ω0(ProjectInfo.Con_Province,ProjectInfo.Con_City);
            tfs_ω0.Search();
            //计算风荷载标准值ωk，单位：KN/M2
            f_ωk = new F_ωk(tfm_μzStandingTube.TargetValue,tfm_μs.TargetValue,tfs_ω0.TargetValue);
            f_ωk.ComputeValue();
            //计算风荷载设计值产生的弯矩
            f_Mw = new F_Mw(f_ωk.TargetValue, ScaffoldPara.La, ScaffoldPara.H);
            f_Mw.ComputeValue();
            //这里的单位是千牛*米
            //换算成牛每毫米
            BendingMomentUnitConversion ConvertMw = new BendingMomentUnitConversion();
            ConvertMw.KNmultiplyM = f_Mw.TargetValue;
            Mw = ConvertMw.NmultiplyMM;
        }
        private void CalcW()
        {
            if (!Controller1.tfs_Fitting.IsSearched) return;
            //规范查到的是以cm3为单位的截面模量W，
            double Wcm3 = Controller1.tfs_Fitting.FindMaterialPara("立杆", "W");
            //要将其手工换算为以mm3为单位
            double Wmm3 = Wcm3 * 10 * 10 * 10;
            W = Wmm3;//mm3
        }
        public void Compare()
        {
            bool isController1Finish = TestController1Para();
            if (!isController1Finish) return;//由于F1和F2有着耦合关系，如果F1未经计算，不可能计算F2
            CalcMw();
            CalcW();
            if (Mw < 0 || W < 0 || (Controller1.N / (Controller1.A * Controller1.φ)) + Mw / W <= Controller1.f)
            {
                lString = Controller1.N.ToString("#0.000") + "/(" + Controller1.A.ToString("#0.000") + "×" + Controller1.φ.ToString("#0.000") + ")+" + Mw.ToString("#0.000") + "/" + W.ToString("#0.000") + "=" + ((Controller1.N / (Controller1.A * Controller1.φ)) + Mw / W).ToString("#0.00");
                rString = Controller1.rString;//直接就是F
                f_NWind = new F_NWind(Controller1.f_NG1K.TargetValue, Controller1.f_NG2K.TargetValue, Controller1.f_NQK.TargetValue);
                f_NWind.ComputeValue();
                InputDic();
            }
            else
            {
                throw new Exception("立杆组合风荷载稳定性计算未通过");
            }
        }

        public static string  lString = "";
        public static string  rString = "";

        private void InputDic()
        {
            solveDic.Add("@F_Mw@", f_Mw.ToString());
            solveDic.Add("@F_ωk@", f_ωk.ToString());
            solveDic.Add("@TFS_ω0@", tfs_ω0.TargetValue.ToString());
            solveDic.Add("@F_NWind@", f_NWind.ToString());
            solveDic.Add("@C2_LString@", lString);
            solveDic.Add("@C2_RString@", rString);
        }


    }
}
