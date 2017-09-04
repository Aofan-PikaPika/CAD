using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.ComputeUnits.F8
{
    public class F_PCF:Formula<double>
    {
        //输出拼凑字符串
        private double NG1K;
        private double NG2K; 
        private double NQK;
        private double NK;
        private double Pad_Area;
        private double pk;
        public F_PCF(double NG1K, double NG2K, double NQK, double NK, double Pad_Area, double pk)
        {
            this.NG1K = NG1K;
            this.NG2K = NG2K;
            this.NQK = NQK;
            this.NK = NK;
            this.Pad_Area = Pad_Area;
            this.pk = pk;
        }
       /// <summary>
       /// 
       /// </summary>
       /// <returns>kpa</returns>
        /// //结果要赋给_targetValue和_isComputed标志位置true
        public override double ComputeValue()
        {
            NK = NG1K + NG2K + NQK;
            pk=NK / Pad_Area;
            _targetValue = pk;
            _isComputed = true;
            return _targetValue;
        }
    }
}

