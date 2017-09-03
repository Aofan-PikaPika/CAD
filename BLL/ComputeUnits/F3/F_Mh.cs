using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.ComputeUnits.F3
{
    //封装了计算均布荷载设计值产生弯矩(水平横杆)的公式
    public class F_Mh : Formula<double>
    {

        double q2 = -1;
        double lb = -1;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="q2">KN/M</param>
        /// <param name="lb">M</param>
        public F_Mh(double q2, double lb)
        {
            this.q2 = q2;
            this.lb = lb;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>KN×M</returns>
        public override double ComputeValue()
        {
            _targetValue = q2 * lb * lb / 8;
            if (_targetValue > 0)
                _isComputed = true;
            return _targetValue;
        }

        public override string ToString()
        {
            if (_isComputed)
                return "(" + q2.ToString("#0.000") + "×" + lb.ToString("#0.000") + "^2)/8" + "=" + _targetValue.ToString("#0.00");
            else
                return "";
        }
    }
}
