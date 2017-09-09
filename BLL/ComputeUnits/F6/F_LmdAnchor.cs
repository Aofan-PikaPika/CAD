using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.ComputeUnits.F6
{
    public class F_LmdAnchor:Formula<int>
    {
        //步距 cm
        private double h;
        //回转半径 cm
        private double i;

        private double Lmd;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="h">cm</param>
        /// <param name="i">cm</param>
        public F_LmdAnchor(double h,double i)
        {
            this.h = h;
            this.i = i;
        }

        public override int ComputeValue()
        {
            Lmd = h / i;
            _targetValue = (int)Math.Ceiling(Lmd);
            _isComputed = true;
            return _targetValue;
        }

        public override string ToString()
        {
            if (_isComputed)
            {
                return h.ToString() + "/" + i.ToString() + "=" + _targetValue.ToString("#0.000");
            }
            else
            {
                return "";
            }
        }
        


    }
}
