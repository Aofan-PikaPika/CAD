using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Xml;

namespace DAL
{
    public class XMLHandle
    {
        public XmlDocument XmlConstruction(XmlDocument doc) 
        {
            if (doc==null)
            {
                doc = XmlDoc.GetInstance() ;//获得xml文件实例
                XmlNode project = doc.CreateElement("Project");//创建根节点
                doc.AppendChild(project);//添加根节点            
            }

            return doc;
        }
    }
}
