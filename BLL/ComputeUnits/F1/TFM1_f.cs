using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.ComputeUnits.F1
{
    //假设这个类是二维表
    public class TFM1_f : TableFromMemoryTwoDim
    {
        double h;
        double la;

        public TFM1_f(double h, double la)
        {
            this.h = h;
            this.la = la;
        }
        public override double Search()
        {
            _hArray = new double[]{ 1.2, 1.5, 1.8, 2.0 };
            _vArray = new double[] { 1.5, 2.0 };
            _twoDimTable = new double[,]{{0.8726,0.8697,0.8678,0.8669},
                                           {0.8698,0.8669,0.8650,0.8640}};
            int i;
            for (i = 0; i < _hArray.Length; i++)
            {
                if (_hArray[i] == la)
                {
                    _hIndex = i;
                    break;
                }
            }
            int j;
            for(j = 0 ; j < _vArray.Length;j++)
            {
                if (_vArray[j] == h)
                {
                    _vIndex = j;
                    break;
                }
            }
            if (i == _hArray.Length || j == _vArray.Length)
                return -1;
            _targetValue = _twoDimTable[_vIndex, _hIndex];
            _isSearched = true;
            return _targetValue;


        }
    }
}
