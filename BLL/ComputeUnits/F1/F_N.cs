using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.ComputeUnits.F1
{
    //计算支架立杆轴向力设计值N的公式
    //单位：千牛
    public class F_N : Formula<double>
    {
        //将公式需要的所有变量封装，目的是不在窗体或控制类中出现过多的变量
        //以下是公式中三个私有化的变量
        //单位：千牛
        private double NG1K;
        private double NG2K;
        private double NQK;
        //公式的传值仅通过构造器传值，不给出空参构造器
        //一旦new 则表示此公式可以执行ComputeValue方法，计算得出的值有意义
        public F_N(double NG1K, double NG2K, double NQK)
        {
            this.NG1K = NG1K;
            this.NG2K = NG2K;
            this.NQK = NQK;
        }
        //重写父类Formula的抽象方法，在其中写一个公式具体的算法
        //不能忘记结果要赋给_targetValue和_isComputed标志位置true
        public override double ComputeValue()
        {
            _targetValue = 1.2 * (NG1K + NG2K) + 1.4 * NQK;
            _isComputed = true;
            return _targetValue;//单位：千牛
        }
        //考虑到计算书需要给出具体的代数过程，重写系统的ToString方法，在其中拼凑公式的字符串
        //字符串会根据外界传入的参数变化，输出具体的值
        public override string ToString()
        {
            if (_isComputed)
                return "1.2×(" + NG1K.ToString("#0.0") + "+" + NG2K.ToString("#0.0") + ")+1.4×" + NQK.ToString("#0.0");
            else
                return "";
        }
    }
}
