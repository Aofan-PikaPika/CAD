using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.ComputeUnits.F3
{
    //封装了计算作用在横向水平杆上的荷载设计值的公式
    public class F_q2 : Formula<double>
    {
        double m = -1;
        double lb = -1;
        double la = -1;
        int qConsload = -1;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m">kg</param>
        /// <param name="lb">m</param>
        /// <param name="la">m</param>
        /// <param name="qConsload">kN/M2</param>
        public F_q2(double m, double lb, double la, int qConsload)
        {
            this.m = m;
            this.lb = lb;
            this.la = la;
            this.qConsload = qConsload;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>KN/M</returns>
        public override double ComputeValue()
        {
            PowerUnitConversion GHLedger = new PowerUnitConversion();
            //这里涉及到了横向水平杆自重的换算
            GHLedger.N = m * 9.8;
            _targetValue = 1.2 * (GHLedger.KN / lb + 0.35 * la) + 1.4 * qConsload * la;
            if (_targetValue > 0)
            {
                _isComputed = true;
            }
            return _targetValue;
        }

        public override string ToString()
        {
            if (_isComputed)
                return "1.2×((" + m.ToString("#0.000") + "×9.8/1000)/" + lb.ToString("#0.000") + "+0.35×" + la.ToString("#0.000") + ")+1.4×" + qConsload.ToString("#0.000") + "×" + la.ToString("#0.000");
            else
                return "";
        }
    }
}
