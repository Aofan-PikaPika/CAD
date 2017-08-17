using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace DEMO.Class
{
    public static class XmlTool
    {
        private static XmlDocument doc;

        //获得xml文件实例
        public static XmlDocument GetInstance() 
        {

            if (doc==null)//若不存在，创建实例
            {
                doc = new XmlDocument();               
            }
            return doc;//若存在，返回已经创建的实例。
        }
    }
}
