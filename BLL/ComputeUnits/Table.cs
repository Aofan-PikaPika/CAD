using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.ComputeUnits
{
    //抽象的表
    //内存中一维的表和需要查SQL的表都继承此抽象类
    public abstract class Table<T> : ComputeElement<T>
    {
        protected bool _isSearched = false;
        public bool IsSearched { get { return _isSearched; } }

        //内存中的一维表可以用switch - case逻辑实现，只需要写在子类中的Search()方法中
        //数据库查表的BLL层逻辑也写在子类中的Search()方法中
        public abstract T Search();
    }
}
