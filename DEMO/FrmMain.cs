using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CCWin;
using System.Threading;
using System.Xml;
using DEMO.Class;
using DEMO.SubForm;
using System.Reflection;
using System.Diagnostics;

namespace DEMO
{
    public partial class FrmMain : Skin_Mac
    {
        public FrmMain()
        {
            InitializeComponent();            
        }
        Hello hello = new Hello();
        private void Form1_Load(object sender, EventArgs e)
        {
            Thread.Sleep(1000);
            //Hello FrmHello = new Hello();
            //FrmHello.MdiParent = this;
            //FrmHello.Parent = this.panel1;
            //FrmHello.Show();
            skinTabControl1.SelectedIndex = 1;
           
            skinTabControl1.Enabled = false;
            
            hello.TopLevel = false;
            this.panel1.Controls.Add(hello);
            hello.setFuction += new setFunctionHandle(hello_setFunction);
            hello.Show();
            
        }
        void hello_setFunction() 
        {
            skinTabControl1.Enabled = true;
            skinButton1_Click(this,null);
            flag = 1;
        }

        //主界面标志位
        int flag = 0;
        void add_setToolBar(string label) 
        {
            toolStripLabel2.Text = label;
        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            if (flag==0)
            {
                hello.resize();
            }
           
        }

        #region 文件模块
        private  XmlDocument doc = null;

        //新建工程
        private void skinButton1_Click(object sender, EventArgs e)
        {
            if (doc == null)
            {
                doc = XmlTool.GetInstance();//获得xml文件实例
                XmlNode project = doc.CreateElement("Project");//创建节点
                doc.AppendChild(project);//添加节点
                
                FrmAdd add = new FrmAdd();
                add.setToolBar += new setToolBarHandle(add_setToolBar);
                add.ShowDialog();
            }
            else 
            {
                MessageBoxEx.Show("不允许重复创建工程，请先保存！","提示",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        //打开工程
        private void skinButton2_Click(object sender, EventArgs e)
        {
            if (doc == null)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.FileName = "工程文档";
                ofd.Filter = "工程文档(*.xml)|*.xml";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    doc = XmlTool.GetInstance();
                    doc.Load(ofd.FileName);
                    toolStripLabel2.Text = ofd.FileName;
                }

            }
            else 
            {
                MessageBoxEx.Show("已有工程打开！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        //保存工程
        private void skinButton3_Click(object sender, EventArgs e)
        {
            if (doc!=null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.FileName = "工程文档";
                sfd.Filter = "工程文档(*.xml)|*.xml";
                if (sfd.ShowDialog()==DialogResult.OK)
                {
                    doc.Save(sfd.FileName);
                    MessageBoxEx.Show("保存完毕！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    doc.RemoveAll();
                    doc = null;
                    toolStripLabel2.Text = sfd.FileName;
                }
                
            }
            else
            {
                MessageBoxEx.Show("工程未建立，无法保存！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //关闭工程
        private void skinButton4_Click(object sender, EventArgs e)
        {
            SaveAlert();
            Application.Exit();
        }

        private void SaveAlert()
        {
            if (doc != null)
            {
                if (MessageBoxEx.Show("尚未保存工程，是否立刻保存？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                {
                    skinButton3_Click(this, null);
                }
            }
        }
        #endregion

        #region 工程设置

        //工程信息
        private void skinButton5_Click(object sender, EventArgs e)
        {
            FrmInfo info = new FrmInfo();
            info.ShowDialog();
        }
       

        private void skinButton6_Click(object sender, EventArgs e)
        {
            FrmMaterial frmM = new FrmMaterial();
            frmM.ShowDialog();
        }
        #endregion

        #region 脚手架
        private void skinButton7_Click(object sender, EventArgs e)
        {
            FrmFrameInfo f = new FrmFrameInfo();
            f.ShowDialog();
        }

        #endregion







        private void skinButton8_Click(object sender, EventArgs e)
        {
                    
        }












    }

}
