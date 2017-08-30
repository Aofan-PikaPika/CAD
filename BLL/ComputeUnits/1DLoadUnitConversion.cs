using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.ComputeUnits
{
    public class _1DLoadUnitConversion
    {
        private double kNperM;

        /// <summary>
        /// KN/M
        /// </summary>
        public double KNperM 
        {
            set { kNperM = value; }
            get { return kNperM; }
        }

        /// <summary>
        /// N/MM
        /// </summary>
        public double NperMM 
        {
            set { kNperM = value; }
            get { return kNperM; }
        }

    }
}
