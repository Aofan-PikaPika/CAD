using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.ComputeUnits.F1;

namespace BLL.ComputeUnits.F3
{
    public class Controller3
    {
        //出计算书要调用到这几个公式
        public static F_q2 f_q2 = null;
        public static F_Mh f_Mh = null;
        public static F_σ f_σ = null;


        //公式3单项依赖公式1
        private bool TestController1Para()
        {
            if (string.IsNullOrEmpty(Controller1.lString) || string.IsNullOrEmpty(Controller1.rString))
                return false;
            else
                return true;
        }
        private void Calcσ()
        {
            
        }

        public void Compare()
        {
            bool isController1Finish = TestController1Para();
            if (!isController1Finish) return;//由于F3和F2有着耦合关系，如果F1未经计算，不可能计算F2
            Calcσ();

        }
        

    }
}
