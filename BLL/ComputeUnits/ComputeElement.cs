using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.ComputeUnits
{
    //顶层的父类：计算单元
    public abstract class ComputeElement<T>
    {
        //每个计算单元的目的是运算出其目标值
        //执行每个运算方法之后都为这个字段赋值
        protected T _targetValue;
        //对应目标值的属性，为public 可以供外界调用
        public T TargetValue { get { return _targetValue; } }
    }
}
