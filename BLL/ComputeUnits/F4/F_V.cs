using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.ComputeUnits.F4
{
    public class F_V : Formula<double>
    {
        //输出拼凑字符串
        private double q1;
        private double lb;
        private double E;
        private double I;
        public F_V(double q1, double lb, double E,double I)
        {
            this.q1 = q1;
            this.lb = lb;
            this.E = E;
            this.I = I;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>MM</returns>
        //结果要赋给_targetValue和_isComputed标志位置true
        public override double ComputeValue()
        {
            double a=Math.Pow(lb, 4);
            _targetValue = 5 * q1 * a / (384 * E * I);
            _isComputed = true;
            return _targetValue;
        }
        //输出拼凑字符串
        public override string ToString()
        {
            if (_isComputed)
                return "(5×" + q1.ToString("#0.00") + "×" + lb.ToString("#0.00") + "\u2074)/(384×" + E.ToString("#0.00") + "×" + I.ToString("#0.00") + ")=" + _targetValue.ToString("#0.00");
            else
                return "";
        }
    }


}
