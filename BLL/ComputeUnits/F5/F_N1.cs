using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.ComputeUnits.F5
{
    public class F_N1:Formula<double>
    {
        /// <summary>
        /// 风荷载产生的连墙件轴向力设计值
        /// </summary>
        private double N1W;
        /// <summary>
        /// 变形产生的轴力，取3KN
        /// </summary>
        private double N0;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="N1w">KN</param>
        /// <param name="N0">KN</param>
        public F_N1(double N1w,double N0) 
        {
            this.N1W = N1w;
            this.N0 = N0;
        }

        public override double ComputeValue()
        {
            _targetValue = N1W + N0;
            _isComputed = true;
            return _targetValue;
        }

        public override string ToString()
        {
            return N1W.ToString() + "+" + N0.ToString() + "=" + _targetValue.ToString("0.000");
        }

    }
}
