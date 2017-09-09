using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.ComputeUnits.F4
{
    public class F_Q1:Formula<double>
    {
        //将公式需要的所有变量封装
        private double m;
        private double lb;
        private double la;
        private double q;
        public F_Q1(double m, double lb, double la,double q)
        {
            this.m = m;
            this.lb = lb;
            this.la = la;
            this.q = q;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>N/MM</returns>
        //结果要赋给_targetValue和_isComputed标志位置true
        public override double ComputeValue()
        {
            _targetValue = m * 9.8/1000 / lb + 0.35 * la + q * la;//结果为N除以1000换成KN
            _isComputed = true;
            return _targetValue;
        }
        //输出拼凑字符串
        public override string ToString()
        {
            if(_isComputed)
                return "" + m.ToString() + "×9.8/" + lb.ToString() + "+0.35×" + la.ToString() + "+" + q.ToString() + "×" + la.ToString() + "=" + _targetValue.ToString("#0.000");
            else
                return "";
        }
    }

      
}
