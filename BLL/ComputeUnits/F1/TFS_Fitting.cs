﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;


namespace BLL.ComputeUnits.F1
{
    public class TFS_Fitting : Table<DataTable>
    {
        int la;
        int lb;
        int h;
        string fitting_model;
        public TFS_Fitting(int la ,int lb ,int h ,string fitting_model)
        {
            this.la = la;
            this.lb = lb;
            this.h = h;
            this.fitting_model = fitting_model;
        }


        public override DataTable Search()
        {
            DataTable dt = null;
            try
            {
                dt = new CheckTableHandle().SearchFitting(la, lb, h, fitting_model);

            }
            catch { }
            if (dt.Rows.Count == 5)
            {
                _targetValue = dt;
                _isSearched = true;
            }
            return dt;
        }

        public double FindMaterialPara(string name, string colName)
        {
            if (_isSearched)
            {
                for (int i = 0; i < _targetValue.Rows.Count; i++)
                {
                    if (_targetValue.Rows[i]["name"].ToString().Equals(name))
                    {
                        return (double)_targetValue.Rows[i][colName];
                    }
                }
            }
            return -1.0;
        }
        
    }
}
