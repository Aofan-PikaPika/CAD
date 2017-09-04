using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.ComputeUnits.F6
{
    public  class TFS_FiAnchor:Table<double>
    {
        //lamda的个位
        int units;
        //lamda的十位
        int tens;

        public TFS_FiAnchor(int lamda) 
        {
            this.tens = (lamda / 10) * 10;
            this.units = (lamda) % 10;
        }

        public override double Search()
        {
            double fi = 0.0;
            try
            {
                //在DAL查询

            }
            catch (Exception)
            {
            }
            if (fi != 0.0)
            {
                _targetValue = fi;
                _isSearched = true;
            }
            return fi;
        }


    }
}
