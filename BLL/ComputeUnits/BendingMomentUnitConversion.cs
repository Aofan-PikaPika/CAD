using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.ComputeUnits
{
    public class BendingMomentUnitConversion
    {
        private double nmultiplyMM;

        /// <summary>
        /// N*MM
        /// </summary>
        public double NmultiplyMM
        {
            set { nmultiplyMM = value; }
            get { return nmultiplyMM; }
        }

        /// <summary>
        /// KN*M
        /// </summary>
        public double KNmultiplyM
        {
            set { nmultiplyMM = value * 1000000; }
            get { return nmultiplyMM / 1000000 ; }
        }
    }
}
