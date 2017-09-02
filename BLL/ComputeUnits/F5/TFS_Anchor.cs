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
                //  从dal 查表
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
