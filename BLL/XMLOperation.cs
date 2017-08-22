using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;
using System.Xml;
using Model.Entity;

namespace BLL
{
    /// <summary>
    /// XML的控制类
    /// </summary>
    public class XMLOperation
    {
        
        XMLHandle xmlstore = new XMLHandle();//实例化xml数据操作类
        
        /// <summary>
        /// 判断是否添加完子节点
        /// </summary>
        /// <returns></returns>
        public bool XmlAddNode() 
        {
            if (xmlstore.XmlConstruction())//判断xml是否建立了根节点
            {
                #region 为xml文档添加子节点并赋值
                XmlNode project = XmlDoc.doc.SelectSingleNode("Project");
                XmlNode infoNode = XmlDoc.doc.CreateElement("Info");
                XmlNode nameNode = XmlDoc.doc.CreateElement("Name");
                XmlNode typeNode = XmlDoc.doc.CreateElement("Type");
                XmlNode idNode = XmlDoc.doc.CreateElement("ID");
                nameNode.InnerText = ProjectInfo.Pro_Name;
                typeNode.InnerText = ProjectInfo.Pro_Type;
                infoNode.AppendChild(nameNode);
                infoNode.AppendChild(typeNode);
                infoNode.AppendChild(idNode);
                project.AppendChild(infoNode);
                #endregion
                
                return true;
            }
            else 
            {
                return false;
            }
            
                     
        }


        /// <summary>
        /// 获得已经打开的xml
        /// </summary>
        /// <param name="path">文档路径</param>
        /// <returns></returns>
        public string  XmlOpen(string path) 
        {
            int  projectID=0;
            string projectName = "";
            if (xmlstore.XmlOpen(path))
            {
                XmlNode root = XmlDoc.doc.SelectSingleNode("Project");
                XmlNode infoNode = root.FirstChild;
                XmlElement xe = (XmlElement)infoNode;
                XmlNodeList list = xe.ChildNodes;
                projectID = int.Parse(list.Item(2).InnerText);
                projectName = list.Item(0).InnerText;
                //根据ID，填充实体类。。。

            }
            return projectName;        
        }


        private void XmlAddIDValue(int projectState) 
        {
            if (XmlDoc.doc!=null)
            {
                XmlNode root = XmlDoc.doc.SelectSingleNode("Project");
                XmlNode infoNode = root.FirstChild;
                XmlElement xe = (XmlElement)infoNode;
                XmlNodeList list = xe.ChildNodes;
                //将所有数据保存到数据库
                if (projectState==2)
                {
                    //更新数据...
                }
                else if (projectState == 1)
                {
                    //添加数据...

                    //将工程id值写入XML文档
                    list.Item(2).InnerText = ProjectInfo.Pro_Id.ToString();
                }
                else 
                {

                }
                                           
            }
        }




        public bool XmlSave(string path,int projectState) 
        {
            XmlAddIDValue(projectState);
            string localFileName = "";
            if (xmlstore.XmlSave(path))
            {
                //获得当前保存xml文件的路径
                localFileName = path.ToString();

                //调用 插入“工程日志”。。。

                return true;
            }
            else 
            {
                return false;
            }
        }

        public void XmlClear() 
        {
            if (XmlDoc.doc!=null)
            {
                XmlDoc.doc.RemoveAll();
                XmlDoc.doc = null;
            }
        }




    }
}
