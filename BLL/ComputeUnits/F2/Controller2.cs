using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.ComputeUnits.F1;//F2的控制类用到了F1中已经含有的变量

namespace BLL.ComputeUnits.F2
{
    /// <summary>
    /// 现实中F1和F2的功能一部分，本来就是耦合的，在这里F2单项依赖F1,将他们写耦合
    /// </summary>
    public class Controller2
    {
        public static double Mw = -1;
        public static double W = -1;

        private bool TestController1Para()
        {
            if (string.IsNullOrEmpty(Controller1.lString) || string.IsNullOrEmpty(Controller1.rString))
                return false;
            else
                return true;
        }
        private void CalcMw()
        {

        }
        private void CalcW()
        {

        }
        public void Compare()
        {

            
        }
    }
}
