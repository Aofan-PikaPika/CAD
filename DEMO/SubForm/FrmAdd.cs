using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CCWin;
using System.Xml;
using DEMO.Class;
using DEMO.Entity;

namespace DEMO.SubForm
{
    public  delegate void setToolBarHandle(string text);
    public partial class FrmAdd : Skin_Mac
    {
        public setToolBarHandle setToolBar;
        private XmlDocument doc = XmlTool.GetInstance();//获得已经实例化的实例
        public FrmAdd()
        {
            InitializeComponent();
        }

        private void FrmAdd_Load(object sender, EventArgs e)
        {
            skinComboBox1.SelectedIndex = 0;          
        }

        //创建工程信息节点
        private void CreateInfoNode(ref XmlNode node) 
        {
            XmlNode infoNode = doc.CreateElement("Info");
            XmlNode nameNode = doc.CreateElement("Name");
            XmlNode typeNode = doc.CreateElement("Type");
            nameNode.InnerText = skinTextBox1.Text;
            typeNode.InnerText = skinComboBox1.SelectedItem.ToString();
            infoNode.AppendChild(nameNode);
            infoNode.AppendChild(typeNode);
            node.AppendChild(infoNode);
        }

        //确定按钮
        private void skinButton1_Click(object sender, EventArgs e)
        {
            switch (skinComboBox1.SelectedIndex)
            {
                case 0: Entity.Project.Type = 0;
                    break;
                case 1: Entity.Project.Type = 1;
                    break;
                case 2: Entity.Project.Type = 2;
                    break;
            }
            XmlNode project = doc.SelectSingleNode("Project");
            CreateInfoNode(ref project);
            setToolBar(skinTextBox1.Text);
            this.Close();
        }

        
        

    }
}
