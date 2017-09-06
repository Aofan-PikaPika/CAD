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
        //稳定性计算需要用到NφAf，全部公开
        public static double N = -1;
        public static double φ = -1;
        public static double A  = -1;
        public static double f = -1;
        public static TFS_Fitting tfs_Fitting = null;//公开查询到的材料表，很多计算都要用到杆件的资料
        public static TFM1_qConsLoad tfm1_qConsLoad = null;//公开施工均布活荷载标准值的表，3，4公式都要用到查出来的施工均布活荷载标准值
        public TFS_FiQ345 f_FiQ345;


        //controller8需要调用NG1K，NG2K，NQK的计算公式
        public static F_NG1K f_NG1K = null;
        public static F_NG2K f_NG2K = null;
        public static F_NQK f_NQK = null;
        public F_N f_N = null;
        public F_Lmd f_Lmd = null;

        public Dictionary<string, string> solveDic = new Dictionary<string, string>();
        private void CalcN()
        {
            //进行脚手架尺寸的单位换算
            LengthUnitConversion la = new LengthUnitConversion();
            LengthUnitConversion lb = new LengthUnitConversion();
            LengthUnitConversion h = new LengthUnitConversion();
            la.M = ScaffoldPara.La;
            lb.M = ScaffoldPara.Lb;
            h.M = ScaffoldPara.H;
            //根据纵距，横距步距查杆件
            tfs_Fitting = new TFS_Fitting((int)la.MM, (int)lb.MM, (int)h.MM, ScaffoldPara.Fitting_Model);
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
            f_NG1K = new F_NG1K(GStandingTube.KN, GVLedger.KN, GHLedger.KN, GVBrace.KN, GHBrace.KN, ScaffoldPara.Step_Num);
            f_NG1K.ComputeValue();
            //计算NG2k：构配件自重标准值产生的轴力 单位：KN
            f_NG2K = new F_NG2K(la.M, lb.M, ScaffoldPara.Act_Layers, ScaffoldPara.Step_Num * h.M);
            f_NG2K.ComputeValue();
            //查询施工均布活荷载标准值q 单位： KN / m2
            tfm1_qConsLoad = new TFM1_qConsLoad(ScaffoldPara.Sca_Type.Trim() + "脚手架");
            tfm1_qConsLoad.Search();
            //∑NQK：施工荷载标准值产生的轴向力总和
            f_NQK = new F_NQK(la.M, lb.M, tfm1_qConsLoad.TargetValue, ScaffoldPara.Con_Layers);
            f_NQK.ComputeValue();
            //计算N：支架立杆轴向力设计值 单位：KN
            f_N = new F_N(f_NG1K.TargetValue, f_NG2K.TargetValue, f_NQK.TargetValue);
            f_N.ComputeValue();
            N = f_N.TargetValue;
        }

        /// <summary>
        /// 计算立杆长度系数φ的公式，必须在计算完N之后再用，计算N的方
        /// </summary>
        private void Calcφ()
        {
            if (!tfs_Fitting.IsSearched) return;//没查到表就不算了
            //查询立杆的长度系数
            TFM1_Miu tfm1_Miu= new TFM1_Miu(ScaffoldPara.Anchor_Style);
            tfm1_Miu.Search();
            //计算立杆的柔度 没有单位
            LengthUnitConversion H = new LengthUnitConversion();
            H.M = ScaffoldPara.H;//这里要进行一步单位换算
            f_Lmd = new F_Lmd(tfm1_Miu.TargetValue,H.CM,tfs_Fitting.FindMaterialPara("立杆","radius"));
            f_Lmd.ComputeValue();
            //根据柔度查稳定系数 没有单位
            f_FiQ345 = new TFS_FiQ345(f_Lmd.TargetValue);
            φ = f_FiQ345.Search();
        }

        /// <summary>
        /// 计算立杆截面积的方法
        /// </summary>
        private void CalcA()
        {
            if (tfs_Fitting.IsSearched)
            {
                A = tfs_Fitting.FindMaterialPara("立杆", "A");//单位：平方厘米
            }
        }

        private void Calcf()
        {
            TFM1_f tfm1_f = new TFM1_f("Q345");
            f = tfm1_f.Search();
        }


        public void Compare()
        {
            CalcN();//这个因为包含查表的过程，永远在最前面，剩下几个的顺序可以变化的
            Calcφ();
            CalcA();
            Calcf();
            if (N < 0 || A < 0 || φ < 0 || f < 0) return;//设置一道坎，检测到运算失败时返回
            //转换单位
            N = N * 1000;//由千牛转换成牛
            A = A * 100;//由平方厘米转换为平方毫米
            if (N / (A * φ) <= f)
            {
                lString = N.ToString("#0.00") + "/(" + A.ToString("#0.00") + "×" + φ.ToString("#0.00") + ")=" + (N / (A * φ)).ToString("#0.00");
                rString = f.ToString("#0.00");
                InputDic();
            }
            else
            {
                throw new Exception("立杆不组合风荷载稳定性计算未通过");
            }
        }

        public static string lString = "";//这个是表达公式左边立杆承受应力的字符串 
        public static string rString = "";//这个表达公式右边f的字符串


        private void InputDic()
        {
            solveDic.Add("@F_NG1K@", f_NG1K.ToString());
            solveDic.Add("@F_NG2K@", f_NG2K.ToString());
            solveDic.Add("@F_NQK@", f_NQK.ToString());
            solveDic.Add("@F_N@", f_N.ToString());
            solveDic.Add("@C1_LString@", lString);
            solveDic.Add("@C1_RString@", rString);
            solveDic.Add("@TFM1_qConsload@", tfm1_qConsLoad.TargetValue.ToString());
            solveDic.Add("@HXSPGXH@", tfs_Fitting.FindMaterialModel("横向水平杆", "model"));
            solveDic.Add("@ZXSPGXH@", tfs_Fitting.FindMaterialModel("纵向水平杆", "model"));
            solveDic.Add("@SXXGXH@", tfs_Fitting.FindMaterialModel("水平斜杆", "model"));
            solveDic.Add("@SPXGXH@",tfs_Fitting.FindMaterialModel("水平斜杆","model"));
            solveDic.Add("@F_LmdLG@", f_Lmd.ToString());
            solveDic.Add("@F_LmdLGZHI@", f_Lmd.TargetValue.ToString("#0.00"));
            solveDic.Add("@TFM_FiQ345@", f_FiQ345.TargetValue.ToString());

        }

    }
}
