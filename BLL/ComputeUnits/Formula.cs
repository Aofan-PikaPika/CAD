using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.ComputeUnits
{
    //抽象的公式类，代表需要计算并获取左值的公式
    public abstract class Formula<T> : ComputeElement<T>
    {
        //判断是否计算过，计算方法结束之后要将这一位置为true
        protected bool _isComputed = false;
        public bool IsComputed { get { return _isComputed; } }
        //每当有需要计算的公式就重写此抽象类，然后重写此抽象方法，在子类的抽象方法中写具体的算法
        public abstract T ComputeValue();
        //公式最后面还要求重写Object类的ToString方法
        //要依据“过程量比结果量精确，由精确到粗略的输出原则”
        //double 的四舍五入方法为.ToString("#0.00..这里保留几位小数就写几位")
        public abstract override string ToString();
    }
}
