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
    public class XMLOperation
    {
        private XmlDocument doc;
        public XMLOperation(XmlDocument xml) 
        {
            doc = xml;
        }

        XMLHandle xmlstore = new XMLHandle();
        
        public bool XmlAddNode() 
        {
            if (ProjectInfo.Pro_Name!= null)
            {
                doc = xmlstore.XmlConstruction(doc);
                XmlNode project = doc.SelectSingleNode("Project");
                XmlNode infoNode = doc.CreateElement("Info");
                XmlNode nameNode = doc.CreateElement("Name");
                XmlNode typeNode = doc.CreateElement("Type");
                nameNode.InnerText = ProjectInfo.Pro_Name;
                typeNode.InnerText = ProjectInfo.Pro_Type;
                infoNode.AppendChild(nameNode);
                infoNode.AppendChild(typeNode);
                project.AppendChild(infoNode);
                return true;
            }
            else 
            {
                return false;
            }
            
                     
        }
    }
}
