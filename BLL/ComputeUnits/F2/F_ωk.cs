using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.ComputeUnits.F2
{
    public class F_ωk : Formula<double>
    {
        double _μz = -1;//风压高度变化系数
        double _μs = -1;//支架风荷载体型系数
        double _ω0 = -1;//基本风压 KN/M2

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_μz">风压高度变化系数</param>
        /// <param name="_μs">支架风荷载体型系数</param>
        /// <param name="_ω0">KN/M2</param>
        public F_ωk(double _μz, double _μs, double _ω0)
        {
            this._μz = _μz;
            this._μs = _μs;
            this._ω0 = _ω0;
        }

        public override double ComputeValue()
        {
            _targetValue = _μz * _μs * _ω0;
            if (_targetValue > 0)
            {
                _isComputed = true;
            }
            return _targetValue;
        }

        public override string ToString()
        {
            if (_isComputed)
                return _μz.ToString("#0.000") + "×" + _μs.ToString("#0.000") + "×" + _ω0.ToString("#0.000") + "=" + _targetValue.ToString("#0.00");
            else
                return "";
        }
    }
}
