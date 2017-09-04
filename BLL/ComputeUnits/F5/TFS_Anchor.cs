using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;

namespace BLL.ComputeUnits.F5
{
    public class TFS_Anchor:Table<DataTable>
    {
        /// <summary>
        /// 连墙件类型
        /// </summary>
        string anchorType;
        /// <summary>
        /// 连墙件型号
        /// </summary>
        string anchorModel;

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="Type"></param>
        /// <param name="Model"></param>
        public TFS_Anchor(string Type,string Model) 
        {
            this.anchorType = Type;
            this.anchorModel = Model;
        }

        public override DataTable Search()
        {
            DataTable dt = null;
            try
            {
                CheckTableHandle cth = new CheckTableHandle();
                switch (anchorType)
                {
                    case "钢管":
                        {
                            dt = cth.SearchAnchorFromTube(anchorModel);
                        }
                        break;
                    case "角钢":
                        {
                            dt = cth.SearchAnchorFromJSteel(anchorModel);
                        }
                        break;
                    case "槽钢":
                        {
                            dt = cth.SearchAnchorFromCSteel(anchorModel);
                        }
                        break;
                    case "工字钢":
                        {
                            dt = cth.SearchAnchorFromGSteel(anchorModel);
                        }
                        break;
                }
            }
            catch 
            { }
            if (dt!=null)
            {
                _targetValue = dt;
                _isSearched = true;
            }
            return dt;
        }

        /// <summary>
        /// 查询函数
        /// </summary>
        /// <param name="colName">A的单位cm；i的单位cm</param>
        /// <returns></returns>
        public double FindAnchorPara(string colName) 
        {
            if (_isSearched)
            {
                return (double)_targetValue.Rows[0][colName];
            }
            return -1.0;
        }


    }
}
