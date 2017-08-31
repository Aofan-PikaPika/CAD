using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.ComputeUnits.F1;
using Model.Entity;

namespace BLL.ComputeUnits.F1
{
    public class Controller1
    {
        private double lValue;
        private double rValue;
        private string solve;
        private Dictionary<string, Object> Process;

        public double CalcLeft()
        {
            //查询材料表
            LengthUnitConversion la = new LengthUnitConversion();
            LengthUnitConversion lb = new LengthUnitConversion();
            LengthUnitConversion h = new LengthUnitConversion();
            la.M = ScaffoldPara.La;//进来是米
            lb.M = ScaffoldPara.Lb;
            h.M = ScaffoldPara.H;
            TFS_Fitting tfs_Fitting = new TFS_Fitting((int)la.MM,(int)lb.MM, (int)h.MM, ScaffoldPara.fitting_model);//需要换算成厘米
            tfs_Fitting.Search();
            if (!tfs_Fitting.IsSearched) return -1;
            //计算脚手架结构自重标准值产生的轴力：单位kN
            PowerUnitConversion GStandintTube = new PowerUnitConversion();
            PowerUnitConversion GVLedger = new PowerUnitConversion();
            PowerUnitConversion GHLedget = new PowerUnitConversion();
            PowerUnitConversion GVBrace = new PowerUnitConversion ();
            PowerUnitConversion GHBrace = new PowerUnitConversion();
            GStandintTube.N = tfs_Fitting.FindMaterialPara("立杆", "the_weight") * 9.8;
            GVLedger.N = tfs_Fitting.FindMaterialPara("纵向水平杆","the_weight") * 9.8;
            GHLedget.N = tfs_Fitting.FindMaterialPara("横向水平杆","the_weight") * 9.8;
            GVBrace.N = tfs_Fitting.FindMaterialPara("竖向斜杆","the_weight") * 9.8;
            GHBrace.N = tfs_Fitting.FindMaterialPara("水平斜杆","the_weight")*9.8;
            F_NG1K f_NG1K = new F_NG1K(GStandintTube.KN,GVLedger.KN,GHLedget.KN,GVBrace.KN,GHBrace.KN,ScaffoldPara.step_num);
            f_NG1K.ComputeValue();
            //计算构配件自重标准值产生的轴力：单位kN
            F_NG2K f_NG2K = new F_NG2K(la.M,lb.M,ScaffoldPara.Act_Layers,h.M*ScaffoldPara.step_num);
            f_NG2K.ComputeValue();
            //计算施工均布荷载标准值产生的轴力：单位kN
            //F_NQK f_NQK = new F_NQK(la.M,lb.M,)
            return 0.0;
            
        }
        public double CalcRight()
        {
            return 0.0;
        }
        public string Compare()
        {
            return "";
        }
     
    }
}
