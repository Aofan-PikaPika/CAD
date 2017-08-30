using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.ComputeUnits
{
    //横(h),纵(v)列的值都是double，目标值也是double的抽象二维表
    //仅用于风荷载体型系数的查询、
    //查询具体风荷载体型系数时重写此表并赋予数组具体的值，重写Search()方法
    public abstract class TableFromMemoryTwoDim : Table<double>
    {
        protected int _hIndex;
        protected int _vIndex;
        protected double[] _hArray;
        protected double[] _vArray;
        protected double [,] _twoDimTable;
    }
}
