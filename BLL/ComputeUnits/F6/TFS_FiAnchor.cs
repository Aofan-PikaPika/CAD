using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL.ComputeUnits.F6
{
    public  class TFS_FiAnchor:Table<double>
    {
        //lamda的个位
        private int units;
        //lamda的十位
        private int tens;

        /// <summary>
        /// 连墙件类型
        /// </summary>
        private string anchorTpye;

        public TFS_FiAnchor(int lamda,string anchorTpye) 
        {
            this.tens = (lamda / 10) * 10;
            this.units = (lamda) % 10;
            this.anchorTpye = anchorTpye;
        }

        public override double Search()
        {
            CheckTableHandle cth = new CheckTableHandle();
            double fi = 0.0;
            try
            {
                switch (anchorTpye)
                {
                    case "钢管":
                        {
                            _targetValue= cth.GetAnchorTubeFi(tens,units);
                        }
                        break;
                    case "角钢":
                    case "槽钢":
                    case "工字钢": 
                        {
                            _targetValue = cth.GetAnchorSteelFi(tens,units);
                        }
                        break;
                }
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
