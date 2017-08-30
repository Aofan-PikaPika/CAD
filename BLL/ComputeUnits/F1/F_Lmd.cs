using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.ComputeUnits.F1
{
    public class F_Lmd: Formula<int>
    {
        //立杆长度系数
        private double μ;
        //步距 cm
        private double h;
        //回转半径 cm
        private double i;

        private double Lmd;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="u">cm</param>
        /// <param name="h">cm</param>
        /// <param name="i">cm</param>
        public F_Lmd(double u,double h, double i) 
        {
            this.μ = u;
            this.h = h;
            this.i = i;
        }

        /// <summary>
        /// 重写ComputeValue方法，返回int型
        /// </summary>
        /// <returns></returns>
        public override int ComputeValue()
        {
            //计算lmd的值
            Lmd = (μ * h) / i;
            //将lmd的计算值上取整，并给属性赋值
            _targetValue = (int)Math.Ceiling(Lmd);
            //计算标志位
            _isComputed = true;
            //返回该计算单元的目标值
            return _targetValue;         
        }

        /// <summary>
        /// 重写ToString方法
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (_isComputed)
            {
                return "(" + μ.ToString("#0.0") + "*" + h.ToString("#0.0") + ")/" + i.ToString("#0.0") + "=" + _targetValue.ToString();
            }
            else 
            {
                return "";
            }
        }


    }
}
