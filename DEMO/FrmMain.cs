﻿using System;
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
using DEMO.SubForm;
using System.Reflection;
using System.Diagnostics;
using Model;

namespace DEMO
{
    public partial class FrmMain : Skin_Mac
    {
        /// <summary>
        /// 软件主界面
        /// </summary>
        public FrmMain()
        {
            InitializeComponent();            
        }

        //创建hello界面的全局实例。
        Hello hello = new Hello();
        private void Form1_Load(object sender, EventArgs e)
        {
            //线程休眠1秒，暂时模拟主程序加载过程。
            Thread.Sleep(1000);
            //设置默认打开“工程设置”面板
            skinTabControl1.SelectedIndex = 1;

           //设置面板不可用
            skinTabControl1.Enabled = false;
            
            //设置hello为子窗口
            hello.TopLevel = false;
            this.panel1.Controls.Add(hello);

            //为hello中定义的委托变量赋值-“新建工程”
            hello.setNewProjectFuction += new setNewFunctionHandle(hello_setNewFunction);

            //为hello中定义的委托变量赋值-“打开工程”
            hello.setOpenProjectFuntion += new setOpenFunctionHandle(hello_setOpenFuntion);
            //显示子窗口
            hello.Show();
            
        }

        //hello界面标志位，值为0表示hello界面已经打开，值为1表示hello界面已经关闭
        int flag = 0;

        /// <summary>
        /// 委托指向的函数-新建工程
        /// </summary>
        private void hello_setNewFunction() 
        {
            skinTabControl1.Enabled = true;
            //点击“新建”按钮，同时关闭了子窗口
            skinButton1_Click(this,null);
            flag = 1;
        }

        /// <summary>
        /// 委托指向的函数-打开工程
        /// </summary>
        private void hello_setOpenFuntion() 
        {
            skinTabControl1.Enabled = true;
            //点击“打开”按钮，同时关闭了子窗口
            skinButton2_Click(this, null);
            flag = 1;
        }

        /// <summary>
        /// 设置底部状态栏的工程名
        /// </summary>
        /// <param name="label"></param>
        void add_setToolBar(string label) 
        {
            toolStripLabel2.Text = label;
        }

        /// <summary>
        /// 重绘主界面时，hello子窗口的变化情况
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Resize(object sender, EventArgs e)
        {
            if (flag==0)
            {
                hello.resize();
            }          
        }


        #region 文件模块
        private XmlDocument doc = null;

        //新建工程
        private void skinButton1_Click(object sender, EventArgs e)
        {
            if (doc == null)
            {
                FrmAdd add = new FrmAdd(doc);
                add.ShowDialog();
                if (add.DialogResult==DialogResult.OK)
                {
                    doc = XmlDoc.GetInstance();                      
                }
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
                    doc = XmlDoc.GetInstance();
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

        #region 外架设计
        private void skinButton7_Click(object sender, EventArgs e)
        {
            FrmFrameInfo f = new FrmFrameInfo();
            f.ShowDialog();
        }

        private void skinButton8_Click(object sender, EventArgs e)
        {

        }

        #endregion

    }

}
