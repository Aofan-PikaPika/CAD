using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL.ComputeUnits.F1
{
    public class TFS_FiQ345:Table<double>
    {
        //lamda的个位
        int units;
        //lamda的十位
        int tens;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="lamda"></param>
        public TFS_FiQ345(int lamda) 
        {
            this.tens = (lamda / 10) * 10;
            this.units = (lamda % 10);
        }

        public override double Search()
        {
            double fi=0.0;
            try
            {
                fi = new CheckTableHandle().SearchFi(tens,units);
               
            }
            catch (Exception)
            {
            }
            if (fi!=0.0)
            {
                _targetValue = fi;
                _isSearched = true;
            }
            return fi;
        }



    }
}
