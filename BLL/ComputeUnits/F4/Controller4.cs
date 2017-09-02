using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.ComputeUnits.F1;

namespace BLL.ComputeUnits.F4
{
    public class Controller4
    {
      private void CalcV()
        {
            double I = Controller1.tfs_Fitting.FindMaterialPara("横向水平杆", "I");
            double E = 2.06 * Math.Pow(10, 5);
        }
      private void CalcQ1()
        {
          double the_weight = Controller1.tfs_Fitting.FindMaterialPara("横向水平杆", "the_weight");
          double q=F1.TFM1_qConsLoad.
        }
     
    }
}
