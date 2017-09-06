using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.ComputeUnits.F5;
using Model.Entity;

namespace BLL.ComputeUnits.F7
{
    public class Controller7
    {
        /// <summary>
        /// 扣件抗滑移设计值
        /// </summary>
        public double Rc;

        /// <summary>
        /// 连墙件轴向力设计值
        /// </summary>
        public double N1 = -1.0;

        public void Calc() 
        {
            int fast_num = ScaffoldPara.Fast_Num;
            //根据连墙件类型确定一个常数的值，查一个一维表
            int value = 8;
            F_Rc f_rc = new F_Rc(fast_num,value);
            f_rc.ComputeValue();
            Rc = f_rc.TargetValue;

        }
        public void Compare() 
        {

            N1 = Controller5.N1;

            if (N1 <= Rc)
            {
                //验算成功
            }
            else 
            {
                //验算失败
            }

        }
    }
}
