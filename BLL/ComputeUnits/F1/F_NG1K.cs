using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.ComputeUnits.F1
{
    public class F_NG1K:Formula<double>
    {
        //立杆自重
        private double GStandingTube;
        //纵向水平杆自重
        private double GVLedger;
        //横向水平杆自重
        private double GHLedger;
        //竖向斜杆自重
        private double GVBrace;
        //水平斜杆自重
        private double GHBrace;

        private int Step;

       /// <summary>
        /// 构造函数
       /// </summary>
       /// <param name="GStandingTube">KN</param>
       /// <param name="GVLedger">KN</param>
       /// <param name="GHLedger">KN</param>
       /// <param name="GVBrace">KN</param>
       /// <param name="GHBrace">KN</param>
       /// <param name="Step">步数</param>
        
        public F_NG1K(double GStandingTube, double GVLedger,double GHLedger,double GVBrace,double GHBrace,int Step)
        {
            this.GStandingTube = GStandingTube;
            this.GVLedger = GVLedger;
            this.GHLedger = GHLedger;
            this.GVBrace = GVBrace;
            this.GHBrace = GHBrace;
            this.Step = Step;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>KN</returns>
        public override double ComputeValue()
        {
            _targetValue = (GStandingTube + GVLedger + (GHLedger + GVBrace + GHBrace) * 0.5) * Step;
            _isComputed = true;
            return _targetValue;
        }

        public override string ToString()
        {
            if (_isComputed)
            {
                return "[" + GStandingTube.ToString() + "+" + GVLedger.ToString() + "+(" + GHLedger.ToString() + "+" + GVBrace.ToString() + "+" + GHBrace.ToString() + ")×0.5]×" + Step.ToString() + "=" + _targetValue.ToString();
            }
            else
                return "";
        }



    }
}
