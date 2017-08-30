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
        private double q;//单位：千牛/米
        private int con_layers;//同时施工层数
        public F_NQK(double la, double lb, double q, int con_layers)
        {
            this.la=la;
            this.lb=lb;
            this.q=q; //单位：千牛/米
            this.con_layers = con_layers;//同时施工层数
        }
        public override double ComputeValue()
        {
            _targetValue = la * lb * q * con_layers / 2;
            _isComputed = true;
            return _targetValue;//单位：千牛
        }
        public override string ToString()
        {
            if (_isComputed)
                return  la.ToString("#0.0") + "×" + lb.ToString("#0.0") + "×" + q.ToString("#0.0") + "×" + con_layers.ToString("#0") + "÷2";
            else
                return "";
        }
    }
}
