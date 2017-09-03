using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.ComputeUnits.F3
{
    public class F_σ : Formula<double>
    {
        double Mh = -1;
        double W = -1;

        /// <summary>
        /// Mh上一步算的是KN×M
        /// W规范查得是CM3
        /// 都需要换算成正确的单位
        /// </summary>
        /// <param name="Mh">N×MM</param>
        /// <param name="W">MM3</param>
        public F_σ(double Mh, double W)
        {
            this.Mh = Mh;
            this.W = W;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>N/MM2</returns>
        public override double ComputeValue()
        {
            if (W != 0)
            {
                _targetValue = Mh / W;
            }
            if (_targetValue > 0)
                _isComputed = true;
            return _targetValue;
        }

        public override string ToString()
        {
            if (_isComputed)
                return Mh.ToString("#0.000") + "/" + W.ToString("#0.000") + "=" + _targetValue.ToString("#0.00");
            else
                return "";
        }
    }
}
