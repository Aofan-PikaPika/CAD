using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.ComputeUnits.F2
{
    /// <summary>
    /// 连墙件风荷载计算高度应取脚手架顶部离地面高度计算风压高度变化系数。
    /// 立杆稳定性风荷载计算高度，落地双排外脚手架应取离地面5M高度计算风压高度变化系数。
    /// 所以这里采用写死的一维表
    /// </summary>
    public class TFM_μzStandingTube : Table<double>
    {
        string rough_level = null;
        /// <summary>
        /// 立杆验算仅采用5m高度，只需要知道地面粗糙度类别ABCD即可查
        /// </summary>
        /// <param name="rough_level"></param>
        public TFM_μzStandingTube(string rough_level)
        {
            this.rough_level = rough_level;
        }
        public override double Search()
        {
            switch (rough_level)
            {
                case "A":_targetValue = 1.09; break;
                case "B": _targetValue = 1.00; break;
                case "C": _targetValue = 0.65; break;
                case "D": _targetValue = 0.51; break;
                default: _targetValue = -1; break;

            }
            if (_targetValue > 0)
                _isSearched = true;
            return _targetValue;
        }
    }
}
