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
using DEMO.SubForm;
using System.Reflection;
using System.Diagnostics;
using Model.Entity;
using Model;
using BLL;
using BLL.ComputeUnits.F1;
using BLL.ComputeUnits;

namespace DEMO
{
    public partial class FrmMain : Skin_Mac
    {
        string _fileName = "工程01";
        /// <summary>
        /// 软件主界面
        /// </summary>
        public FrmMain()
        {
            InitializeComponent();            
        }
        #region 界面窗口控制
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

            //为hello中定义的委托变量赋值-“最近工程”
            hello.setRecentProjectFuntion += new setRecentFunctionHandle(hello_setRecentFuntion);

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
            skinButton1_Click(this, null);
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
        /// 委托指向的函数-最近工程
        /// </summary>
        private void hello_setRecentFuntion(string filePath,string proName) 
        {
            skinTabControl1.Enabled = true;         
            flag = 1;
            ProjectSate = 2;
            _fileName = filePath.Substring(filePath.LastIndexOf("\\") + 1);
            toolStripLabel2.Text = proName;
            _filePath = filePath;
        }

        private string _filePath = "";



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
            if (flag == 0)
            {
                hello.resize();
            }
        }
        #endregion
        
        #region 文件模块

        //实例化XML操作控制类
        XMLOperation xo = new XMLOperation();

        /// <summary>
        /// 工程状态标志位，0：无工程， 1：，新建的工程   2：打开的工程
        /// </summary>
        private int ProjectSate = 0;

        //新建工程
        private void skinButton1_Click(object sender, EventArgs e)
        {
            if ( XmlDoc.doc== null)
            {
                FrmAdd add = new FrmAdd();
                add.ShowDialog();
                if (add.DialogResult==DialogResult.OK)
                {
                    //给窗体状态栏赋值
                    toolStripLabel2.Text = ProjectInfo.Pro_Name;

                    //设置工程状态位为：打开
                    ProjectSate = 1;
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
            string ProjectName="";
            if (XmlDoc.doc == null)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                
                ofd.FileName = "工程文档";
                ofd.Filter = "工程文档(*.xml)|*.xml";
                if (ofd.ShowDialog() == DialogResult.OK)
                {    //从XML中获取工程名称          
                     ProjectName= xo.XmlOpen(ofd.FileName);
                     if (ProjectName != "无")
                     {
                         //设置工程状态位为：打开
                         ProjectSate = 2;
                         //获取保存路径
                         _filePath = ofd.FileName;
                     }
                     else 
                     {
                         //设置工程状态位为：无工程
                         ProjectSate = 0; 
                     }                   
                    //给窗体状态栏赋值
                     toolStripLabel2.Text = ProjectName;

                    _fileName=ofd.FileName.Substring(ofd.FileName.LastIndexOf("\\") + 1);

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
            if (XmlDoc.doc != null)
            {
                if (ProjectSate==1)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.FileName = _fileName;
                    sfd.Filter = "工程文档(*.xml)|*.xml";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        if (xo.XmlSave(sfd.FileName, ProjectSate))
                        {
                            MessageBoxEx.Show("保存完毕！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //清空XML文档
                            xo.XmlClear();
                            //修改状态栏
                            toolStripLabel2.Text = "无";
                            //修改工程状态位
                            ProjectSate = 0;
                            //重置实体类
                            ProjectInfo.Clear();
                            ScaffoldPara.Clear();
                            MaterialLib.clearMaterialLib();
                        }
                    }
                }
                else if (ProjectSate==2)
                {
                     if (xo.XmlSave(_filePath, ProjectSate))
                        {
                            MessageBoxEx.Show("保存完毕！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //清空XML文档
                            xo.XmlClear();
                            //修改状态栏
                            toolStripLabel2.Text = "无";
                            //修改工程状态位
                            ProjectSate = 0;
                            //重置实体类
                            ProjectInfo.Clear();
                            ScaffoldPara.Clear();
                            MaterialLib.clearMaterialLib();
                        }
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
            if (XmlDoc.doc != null)
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
            FrmInfo info = new FrmInfo(ProjectSate);
            //主窗体订阅委托
            info.toolbartextFunction += new toolbartextHandle(toolbartxt);
            info.ShowDialog();
        }

        //由子窗体的委托得到工程名称。
        private void toolbartxt(string txt) 
        {
            toolStripLabel2.Text = txt;
        }
       
        //材料库
        private void skinButton6_Click(object sender, EventArgs e)
        {
            FrmMaterial frmM = new FrmMaterial(ProjectSate);
            frmM.ShowDialog();
        }
        #endregion

        #region 外架设计

        //脚手架参数
        private void skinButton7_Click(object sender, EventArgs e)
        {
            FrmFrameInfo f = new FrmFrameInfo(ProjectSate);
            f.ShowDialog();
        }

        //计算书
        private void skinButton8_Click(object sender, EventArgs e)
        {
            Controller1 c1 = new Controller1();
            c1.CalcLeft();
        }

        //用料统计
        private void skinButton12_Click(object sender, EventArgs e)
        {

        }

        //施工图
        private void skinButton11_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void skinButton13_Click(object sender, EventArgs e)
        {
            
        }

    }

}
