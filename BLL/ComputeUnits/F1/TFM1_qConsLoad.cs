using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.ComputeUnits.F1
{
    public class TFM1_qConsLoad : Table<int>
    {
   
        private string sca_type;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sca_type">只能是"防护脚手架"，"装修脚手架"，"结构脚手架"三种</param>
        public TFM1_qConsLoad(string sca_type)
        {
            this.sca_type = sca_type;
        }
        /// <summary>
        /// 查询活荷载的函数
        /// </summary>
        /// <returns>KN/M2</returns>
        public override int Search()
        {
            int N= -1;
            switch (sca_type)
            {
                case "防护脚手架": N = 1;break;
                case "装修脚手架": N = 2;break;
                case "结构脚手架": N = 3 ;break;
            }
            if (N > 0)
            {
                _isSearched = true;
                _targetValue = N;
            }
            return N;
        }
    }
}
