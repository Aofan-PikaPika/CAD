using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.ComputeUnits.F1
{
    public static class TFM1_ConsLoad 
    {
        private const int q_defence = 1;
        private const int q_decoration = 2;
        private const int q_structure = 3;

        /// <summary>
        /// 防护脚手架 施工均布活荷载标准值 单位：kN/m2
        /// </summary>
        public static  int Q_Defence { get { return q_defence; } }
        /// <summary>
        /// 装修脚手架 施工均布活荷载标准值 单位：kN/m2
        /// </summary>
        public static  int Q_Decoration { get { return q_decoration; } }
        /// <summary>
        /// 结构脚手架 施工均布活荷载标准值 单位：kN/m2
        /// </summary>
        public static int Q_Structure { get { return q_structure; } }

    }
}
