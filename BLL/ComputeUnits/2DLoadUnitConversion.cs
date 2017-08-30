using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.ComputeUnits
{
    public class _2DLoadUnitConversion
    {
        private double kNperM2;

        /// <summary>
        /// KN/M2
        /// </summary>
        public double KNperM2 
        {
            set { kNperM2 = value; }
            get { return kNperM2; }
        }

        /// <summary>
        /// N/MM2
        /// </summary>
        public double NperMM2 
        {
            set { kNperM2 = value / 1000; }
            get { return kNperM2 * 1000; }
        }


    }
}
