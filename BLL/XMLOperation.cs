using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;
using System.Xml;
using Model.Entity;
using BLL.Service;

namespace BLL
{
    /// <summary>
    /// XML的控制类
    /// </summary>
    public class XMLOperation
    {
        
        XMLHandle xmlstore = new XMLHandle();//实例化xml数据操作类
        SQLOperations sqlo = new SQLOperations();
        
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
            string projectName = "无";
            if (xmlstore.XmlOpen(path))
            {
                XmlNode root = XmlDoc.doc.SelectSingleNode("Project");
                XmlNode infoNode = root.FirstChild;
                XmlElement xe = (XmlElement)infoNode;
                XmlNodeList list = xe.ChildNodes;
                projectID = int.Parse(list.Item(2).InnerText);
                projectName = list.Item(0).InnerText;
                //根据ID，填充实体类
                if (!sqlo.SearchDatabaseFillEntity(projectID)) 
                {
                    XmlDoc.doc = null;
                    return "无";
                }
            }
            return projectName;        
        }

        /// <summary>
        /// 私有方法，为XML添加ID
        /// </summary>
        /// <param name="projectState"></param>
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
                    //更新数据
                    sqlo.UpdateDatabaseFromEntity(ProjectInfo.Pro_Id);

                }
                if (projectState == 1)
                {
                    //添加数据
                    sqlo.AddEntityToDatabase();
                    //将工程id值写入XML文档
                    //底层DAL失败返回-1，在BLL层将实体赋值-1
                    list.Item(2).InnerText = ProjectInfo.Pro_Id.ToString();
                }               
                                           
            }
        }



        /// <summary>
        /// xml文档保存
        /// </summary>
        /// <param name="path"></param>
        /// <param name="projectState"></param>
        /// <returns></returns>
        public bool XmlSave(string path,int projectState) 
        {
            XmlAddIDValue(projectState);
            string localFilePath = "";
            string localTime = "";
            string fileName = "";
            if (xmlstore.XmlSave(path)&&ProjectInfo.Pro_Id != -1)
            {
                //获得当前保存xml文件的路径
                localFilePath = path.ToString();
                //获取当前系统时间
                localTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                //获取保存的文件名
                fileName = path.Substring(path.LastIndexOf("\\") + 1);
                //调用 “工程日志”。。。
                if (projectState==1)
                {
                    //插入日志
                    sqlo.AddLog(ProjectInfo.Pro_Id,fileName,localFilePath,localTime);
                }
                if (projectState==2)
                {
                    //更新日志
                    sqlo.UpdateLog(ProjectInfo.Pro_Id, fileName, localFilePath, localTime);
                    
                }

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
