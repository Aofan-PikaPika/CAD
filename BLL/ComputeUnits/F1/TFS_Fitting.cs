using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;


namespace BLL.ComputeUnits.F1
{
    public class TFS_Fitting : Table<DataTable>
    {
        double la;
        double lb;
        double h;
        string fitting_model;
        
        //接收数据的单位：毫米
        public TFS_Fitting(double la ,double lb ,double h ,string fitting_model)
        {
            this.la = la;
            this.lb = lb;
            this.h = h;
            this.fitting_model = fitting_model;
        }
        //返回单位：为规范里A-1和C-2直接能查到的单位
        public override DataTable Search()
        {
            DataTable dt = new CheckTableHandle().SearchFitting(la, lb, h, fitting_model);
            if (dt.Rows.Count == 5)
            {
                _isSearched = true;
                _targetValue = dt;
                return _targetValue ;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 函数按照对应表中的单位返回值
        /// </summary>
        /// <param name="name"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public double targetValueSearch(string name,string target)
        {
            if (_isSearched)
            {
                for (int i = 0; i < _targetValue.Rows.Count; i++)
                {
                    if (_targetValue.Rows[i]["name"].ToString().Equals(name))
                    {
                        return (double)_targetValue.Rows[i][target];
                    }
                }
            }
            return -1;
        }
    }
}
