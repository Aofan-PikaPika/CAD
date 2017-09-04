using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.ComputeUnits.F7
{
    public class F_Rc:Formula<double>
    {
        private int fast_num;
        private int anchor_value;

        public F_Rc(int fast_num,int value) 
        {
            this.anchor_value = value;
            this.fast_num = fast_num;
        }

        public override double ComputeValue()
        {
            _targetValue = 0.85 * fast_num * anchor_value;
            _isComputed = true;
            return _targetValue;
        }

        public override string ToString()
        {
            if (_isComputed)
            {
                return "0.85×" + fast_num.ToString("#0.00") + "×" + anchor_value.ToString("#0.00") + "=" + _targetValue.ToString("#0.00");
            }
            return "";
        }

    }
}
