using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BLL.ComputeUnits.F2
{
    public class TFM_μs :TableFromMemoryTwoDim
    {
        string sca_situation = null;//脚手架状况
        string bui_status = null; //背靠建筑物状况
        string fitting_model = null;//脚手架类型A,B
        double la = -1;
        double h = -1;

        /// <summary>
        /// 前三个字符串是要判断查哪个表，后la和h是要用来检索二维的表
        /// </summary>
        /// <param name="sca_situation"></param>
        /// <param name="bui_status"></param>
        /// <param name="fitting_model"></param>
        /// <param name="la">M</param>
        /// <param name="h">M</param>
        public TFM_μs(string sca_situation, string bui_status, string fitting_model,double la,double h)
        {
            this.sca_situation = sca_situation;
            this.bui_status = bui_status;
            this.fitting_model = fitting_model;
            this.la = la;
            this.h = h;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>μs系数没有单位</returns>
        public override double Search()
        {
            bool isSetTable = JudgeMemoryTable(this.sca_situation, this.bui_status, this.fitting_model);
            //无线性内插，查询内存中二维表的算法
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
            for (j = 0; j < _vArray.Length; j++)
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


        #region μs根据不同的情况可能要查询四个表，这里用封装好的方法,嵌套两个switch，根据外界传来的数组决定用哪个表
        private bool JudgeMemoryTable(string sca_situation, string bui_status, string fitting_model)
        {
            bool isSetTable = false;
            switch (sca_situation)
            {
                case "全封闭、半封闭":
                    {
                        isSetTable = HasNet(bui_status);
                    }
                    break;
                case "敞开":
                    {
                        isSetTable = WithOutNet(fitting_model);
                    }
                    break;
            }

            return isSetTable;
        }


        /// <summary>
        /// 如果有密目网，检查背靠建筑物状况 bui_status
        /// </summary>
        /// <param name="bui_status"></param>
        private bool HasNet(string bui_status)
        {
            bool isSetTable = false;
            switch (bui_status)
            {
                case "全封闭墙":
                    {
                        _hArray = new double[] { 1.2, 1.5, 1.8, 2.0 };
                        _vArray = new double[] { 1.5, 2.0 };
                        _twoDimTable = new double[,]{
                                    {0.8726	,0.8697,0.8678,0.8669},
                                    {0.8698,0.8669,0.8650,0.8640},
                             };
                        isSetTable = true;
                    }
                    break;
                case "敞开、框架、开洞墙":
                    {
                        _hArray = new double[] { 1.2, 1.5, 1.8, 2.0 };
                        _vArray = new double[] { 1.5, 2.0 };
                        _twoDimTable = new double[,]{
                                    {1.1344,1.1306,	1.1281,	1.1270},
                                    {1.1307,1.1270,	1.1245,	1.1232}
                        };
                        isSetTable = true;
                    }
                    break;
            }
            return isSetTable;            
        }

        /// <summary>
        /// 如果没有密目网，就检查杆件的A，B：fitting_model
        /// </summary>
        /// <param name="fitting_model"></param>
        private bool WithOutNet(string fitting_model)
        {
            bool isSetTable = false;
            switch (fitting_model)
            {
                case "A":
                    {
                        _hArray = new double[] { 1.2, 1.5, 1.8, 2.0 };
                        _vArray = new double[] { 1.5, 2.0 };
                        _twoDimTable = new double[,]{
                                    {0.117,	0.105,	0.0971,	0.0931},
                                    {0.107,	0.955,	0.0875,	0.0835}

                             };
                        isSetTable = true;
                    }
                    break;
                case "B":
                    {
                        _hArray = new double[] { 1.2, 1.5, 1.8, 2.0 };
                        _vArray = new double[] { 1.5, 2.0 };
                        _twoDimTable = new double[,]{
                                    {0.0945,0.0849,	0.0785,	0.0628},
                                    {0.0861,0.0765,	0.0701,	0.0669}
                        };
                        isSetTable = true;
                    }
                    break;
            }
            return isSetTable;
        }
        #endregion
    }

}
