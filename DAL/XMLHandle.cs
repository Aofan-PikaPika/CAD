using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Xml;
using Model;

namespace DAL
{
    /// <summary>
    /// XML数据操作类
    /// </summary>
    public class XMLHandle
    {
        /// <summary>
        /// XML文档建立
        /// </summary>
        /// <returns></returns>
        public bool XmlConstruction() 
        {
            if (XmlDoc.doc == null)
            {
                XmlDoc.doc = new XmlDocument();//创建XML的实例
                XmlNode project = XmlDoc.doc.CreateElement("Project");//创建根节点
                XmlDoc.doc.AppendChild(project);//添加根节点     
                return true;
            }
            else 
            {
                return false;
            }
           
        }


        /// <summary>
        /// XML文档打开
        /// </summary>
        /// <param name="XMLPath"></param>
        /// <returns></returns>
        public bool XmlOpen(string XMLPath) 
        {
            if (XmlDoc.doc == null)
            {
                XmlDoc.doc = new XmlDocument();
                try
                {
                    XmlDoc.doc.Load(XMLPath);
                    return true;
                }
                catch (Exception)
                {
                    XmlDoc.doc = null;
                    return false;
                    
                }               
            }
            else 
            {
                return false;
            }
        }

        /// <summary>
        /// XML文档保存
        /// </summary>
        /// <param name="XMLPath"></param>
        /// <returns></returns>
        public bool XmlSave(string XMLPath) 
        {
            if (XmlDoc.doc != null)
            {
                try
                {
                    XmlDoc.doc.Save(XMLPath);
                }
                catch (Exception)
                {

                    throw;
                }
                return true;
            }
            else 
            {
                return false;
            }
        }



    }
}
