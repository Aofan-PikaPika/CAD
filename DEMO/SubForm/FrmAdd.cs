using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CCWin;
using Model;
using Model.Entity;
using BLL;
using System.Xml;

namespace DEMO.SubForm
{
    public partial class FrmAdd : Skin_Mac
    {
        public FrmAdd()
        {
            InitializeComponent();
        }

        private XmlDocument doc;
        public FrmAdd(XmlDocument xml) 
        {
            InitializeComponent();
            doc = xml;
        }

        private void FrmAdd_Load(object sender, EventArgs e)
        {
            skinComboBox1.SelectedIndex = 0;          
        }

       
        //确定按钮
        private void skinButton1_Click(object sender, EventArgs e)
        {
           // Project proj = new Project();
            XMLOperation xmlop = new XMLOperation(doc);
            switch (skinComboBox1.SelectedIndex)
            {
                case 0:
                    {
                        ProjectInfo.Pro_Type = "盘扣式双排外脚手架";
                        ProjectInfo.Pro_Name = skinTextBox1.Text;
                    }
                    break;
                case 1:
                    {
                        ProjectInfo.Pro_Type = "盘扣式模板支架";
                        ProjectInfo.Pro_Name = skinTextBox1.Text;
                    }
                    break;
            }

            if (xmlop.XmlAddNode())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else 
            {
                MessageBox.Show("新建工程失败！");
            }                       
        }

        
        

    }
}
