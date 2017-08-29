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
    }
}
