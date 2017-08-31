using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.ComputeUnits.F1;
using Model.Entity;
using CCWin;

namespace BLL.ComputeUnits.F1
{
    public class Controller1
    {
        public double N;
        public string CalculateSolve;
        public void CalcN()
        {
            //进行脚手架尺寸的单位换算
            LengthUnitConversion la = new LengthUnitConversion();
            LengthUnitConversion lb = new LengthUnitConversion();
            LengthUnitConversion h = new LengthUnitConversion();
            la.M = ScaffoldPara.La;
            lb.M = ScaffoldPara.Lb;
            h.M = ScaffoldPara.H;
            TFS_Fitting tfs_Fitting = new TFS_Fitting((int)la.MM, (int)lb.MM, (int)h.MM, ScaffoldPara.Fitting_Model);
            tfs_Fitting.Search();
            if (!tfs_Fitting.IsSearched) return;
            //进行各杆自重的单位换算
            PowerUnitConversion GStandingTube = new PowerUnitConversion(); //立杆自重
            PowerUnitConversion GVLedger = new PowerUnitConversion();//纵向水平杆自重
            PowerUnitConversion GHLedger = new PowerUnitConversion();//横向水平杆自重
            PowerUnitConversion GVBrace = new PowerUnitConversion();//竖向斜杆自重
            PowerUnitConversion GHBrace = new PowerUnitConversion();//水平斜杆自重N
            GStandingTube.N = tfs_Fitting.FindMaterialPara("立杆","the_weight") * 9.8;
            GVLedger.N = tfs_Fitting.FindMaterialPara("纵向水平杆","the_weight") * 9.8;
            GHLedger.N=tfs_Fitting.FindMaterialPara("横向水平杆","the_weight")*9.8;
            GVBrace.N=tfs_Fitting.FindMaterialPara("竖向斜杆","the_weight")*9.8;
            GHBrace.N=tfs_Fitting.FindMaterialPara("水平斜杆","the_weight")*9.8;
            //计算脚手架结构自重标准值产生的轴力 单位：KN
            F_NG1K f_NG1K = new F_NG1K(GStandingTube.KN, GVLedger.KN, GHLedger.KN, GVBrace.KN, GHBrace.KN, ScaffoldPara.Step_Num);
            f_NG1K.ComputeValue();
            //计算NG2k：构配件自重标准值产生的轴力 单位：KN
            F_NG2K f_NG2K = new F_NG2K(la.M, lb.M, ScaffoldPara.Act_Layers, ScaffoldPara.Step_Num * h.M);
            f_NG2K.ComputeValue();
            //查询施工均布活荷载标准值q 单位： KN / m2
            TFM1_qConsLoad tfm1_qConsLoad = new TFM1_qConsLoad(ScaffoldPara.Sca_Type.Trim() + "脚手架");
            tfm1_qConsLoad.Search();
            //∑NQK：施工荷载标准值产生的轴向力总和
            F_NQK f_NQK = new F_NQK(la.M, lb.M, tfm1_qConsLoad.TargetValue, ScaffoldPara.Con_Layers);
            f_NQK.ComputeValue();
            //计算N：支架立杆轴向力设计值 单位：KN
            F_N f_N = new F_N(f_NG1K.TargetValue, f_NG2K.TargetValue, f_NQK.TargetValue);
            f_N.ComputeValue();
            N = f_N.TargetValue;
            /*
            //测试效果
            string solve = "NG1K = " + f_NG1K.ToString() + "\n" +
                            "NG2K = " + f_NG2K.ToString() + "\n" +
                            "∑NQK = " + f_NQK.ToString() + "\n" +
                            "N =" + f_N.ToString() + "\n";
            MessageBoxEx.Show(solve);
            */
        }

        public void Compare()
        {
            
        }

    }
}
