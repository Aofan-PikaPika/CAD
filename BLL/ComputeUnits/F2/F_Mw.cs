using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.ComputeUnits.F2
{
    public class F_Mw : Formula<double>
    {
        double _ωk = -1;
        double la = -1;
        double h = -1;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_ωk">kN/M2</param>
        /// <param name="la">M</param>
        /// <param name="h">M</param>
        public F_Mw(double _ωk ,double la ,double h)
        {
            this._ωk = _ωk;
            this.la = la;
            this.h = h;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>KN×M</returns>
        public override double ComputeValue()
        {
            _targetValue = (0.9 * 1.4 * _ωk * la * h * h) / 10;
            if (_targetValue > 0)
            {
                _isComputed = true;
            }
            return _targetValue;
        }

        public override string ToString()
        {
            if (_isComputed)
                return "(0.9×1.4×" + _ωk.ToString() + "×" + la.ToString() + "×" + h.ToString() + "^2)/10=" + _targetValue.ToString("#0.000");
            else
                return "";
        }
    }
}
