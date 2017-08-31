using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL.ComputeUnits.F1
{
    //脚手架立杆计算长度系数
    public class TFM1_Miu:Table<double>
    {
        string anchor_style;//连墙件布置
        public TFM1_Miu(string anchor_style)//构造函数
        {
            this.anchor_style = anchor_style;
        }
        public override double Search()
        {

            switch (anchor_style)//连墙件布置的一维表查询
            {
                case "2步2跨":
                    {
                        _targetValue = 1.2;
                        _isSearched = true;
                    }
                    break;
                case "2步3跨":
                    {
                        _targetValue = 1.45;
                        _isSearched = true;
                    }
                    break;
                case "3步3跨":
                    {
                        _targetValue = 1.70;
                        _isSearched = true;
                    }
                    break;
            }
            if (_isSearched)
                return _targetValue;
            else
                return 0.0;
        }
       
    }
}
