using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Model.Entity
{
    public static class MaterialLib 
    {
        public static int[] validArray = Enumerable.Repeat(-1, 105).ToArray();
        //材料库窗体中有相应的数组，为一窗体类变量
        //不需要用之前清空。每次点击材料库的确定按钮，所获得的validArray是最新的
         public static void clearMaterialLib()
        {
            validArray = Enumerable.Repeat(-1, 105).ToArray();
            dtMaterial = null;
        }
      
        public static DataTable dtMaterial;
    }
}
