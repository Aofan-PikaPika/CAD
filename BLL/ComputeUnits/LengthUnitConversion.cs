using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.ComputeUnits
{
    public class LengthUnitConversion
    {
        private double millimeter;

        /// <summary>
        /// 毫米
        /// </summary>
        public double MM
        {
            set { millimeter = value; }
            get { return millimeter; }
        }
        /// <summary>
        /// 厘米
        /// </summary>
        public double CM
        {
            set { millimeter = value * 10; }
            get { return millimeter / 10; }
        }

        /// <summary>
        /// 分米
        /// </summary>
        public double DM
        {
            set { millimeter = value * 100; }
            get { return millimeter / 100; }
        }

        /// <summary>
        /// 米
        /// </summary>
        public double M
        {
            set { millimeter = value * 1000; }
            get { return millimeter / 1000; }
        }
    }
}
