using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel
{
 
    public class A
    {
        protected int i;
        public int I
        {
            get { return i; }
        }
    }
    public class B : A
    {
        public void change()
        {
            i = 100000;
        }
    }
    public class C : A
    {
        
    }
}
