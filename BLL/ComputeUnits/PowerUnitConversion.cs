using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.ComputeUnits
{
    public class PowerUnitConversion
    {
        private double n;

        /// <summary>
        /// 牛
        /// </summary>
        public double N 
        {
            set { n = value; }
            get { return n; }
        }

        /// <summary>
        /// 千牛
        /// </summary>
        public double KN
        {
            set { n = value * 1000; }
            get { return n/1000; }

        }
    }
}
