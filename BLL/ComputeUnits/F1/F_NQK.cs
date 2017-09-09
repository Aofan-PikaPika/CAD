using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.ComputeUnits.F1
{
    //传入的应该是千牛，米
    public class F_NQK : Formula<double>
    {
        private double la;//单位：米
        private double lb;//单位：米
        private double q;//单位：千牛/平方米
        private int con_layers;//同时施工层数

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="la">m</param>
        /// <param name="lb">m</param>
        /// <param name="q">KN/m2</param>
        /// <param name="con_layers"></param>
        public F_NQK(double la, double lb, double q, int con_layers)
        {
            this.la=la;
            this.lb=lb;
            this.q=q; 
            this.con_layers = con_layers;//同时施工层数
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>KN</returns>
        public override double ComputeValue()
        {
            _targetValue = la * lb * q * con_layers / 2;
            _isComputed = true;
            return _targetValue;//单位：千牛
        }
        public override string ToString()
        {
            if (_isComputed)
                return  la.ToString() + "×" + lb.ToString() + "×" + q.ToString() + "×" + con_layers.ToString() + "/2="+_targetValue.ToString();
            else
                return "";
        }
    }
}
