using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.ComputeUnits.F5
{
    public class F_N1W:Formula<double>
    {
        /// <summary>
        /// 连墙件水平间距
        /// </summary>
        private double L1;
        /// <summary>
        /// 连墙件垂直间距
        /// </summary>
        private double H1;
        /// <summary>
        /// 风荷载标准值
        /// </summary>
        private double wk;

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="L1">M</param>
        /// <param name="H1">M</param>
        /// <param name="wk">KN/M2</param>
        public F_N1W(double L1,double H1,double wk) 
        {
            this.L1 = L1;
            this.H1 = H1;
            this.wk = wk;
        }

        public override double ComputeValue()
        {
            _targetValue = 1.4 * wk * L1 * H1;
            _isComputed = true;
            return _targetValue;
        }

        public override string ToString()
        {
            return "1.4×" + wk.ToString() + "×" + L1.ToString() + "×" + H1.ToString() + "=" + _targetValue.ToString("#0.000");
        }
    }
}
