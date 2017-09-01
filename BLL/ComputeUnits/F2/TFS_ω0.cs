using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;//这里查询基本风压要根据DAL中的函数以及得到的省市直接查询

namespace BLL.ComputeUnits.F2
{
    public class TFS_ω0 : Table<double>
    {
        string province = null;
        string city = null;
        /// <summary>
        /// 构造器要求输入所在的省份和城市
        /// </summary>
        /// <param name="province">字符串，在scaffpara实体类中取</param>
        /// <param name="city">字符串</param>
        public TFS_ω0(string province ,string city)
        {
            this.province = province;
            this.city = city;
        }

        /// <summary>
        /// 查询基本风压ω0
        /// </summary>
        /// <returns>KN/M2</returns>
        public override double Search()
        {
            _targetValue = -1;
            CheckTableHandle cTableHandle = new CheckTableHandle();
            double ω0 = cTableHandle.Searchω0(province, city);
            if (ω0 > 0)
            {
                _targetValue = ω0;
                _isSearched = true;
            }
            return _targetValue;
        }
    }
}
