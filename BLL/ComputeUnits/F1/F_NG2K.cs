using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.ComputeUnits.F1
{
    public class F_NG2K : Formula<double>
    {
        double la;//纵距
        double lb;//横距
        int act_layers;//实际铺设脚手板层数
        double height;//脚手架架体高度
        
        /// <summary>
        /// 其中height需要控制类以步距×步数来传入
        /// </summary>
        /// <param name="la">m</param>
        /// <param name="lb">m</param>
        /// <param name="act_layers">层</param>
        /// <param name="height">m</param>
        public F_NG2K(double la,double lb ,int act_layers,double height)
        {
            this.la = la;
            this.lb = lb;
            this.act_layers = act_layers;
            this.height = height;
        }

        /// <summary>
        /// 返回以千牛为单位的 构配件自重产生的立杆轴力
        /// </summary>
        /// <returns>kn</returns>
        public override double ComputeValue()
        {
            double Njsb = 0.35 * act_layers * la * lb / 2;
            double Nlgdjb = 0.17 * act_layers * la * lb;
            double Naqw = 0.01 * la * height;
            _targetValue = Njsb + Nlgdjb + Naqw;
            _isComputed = true;
            return _targetValue;
        }

        public override string ToString()
        {
            if (_isComputed)
                return "0.35×" + act_layers.ToString("#0.0") + "×" + la.ToString("#0.0") + "×" + lb.ToString("#0.0") + "/2+0.17×" + act_layers.ToString("#0.0") + "×" + la.ToString("#0.0") + "×" + lb.ToString("#0.0") + "×+0.01×" + la.ToString("#0.0") + "×" + height.ToString("#0.0") + "=" + _targetValue.ToString("#0.0");
            else
                return "";
        }
    }
}
