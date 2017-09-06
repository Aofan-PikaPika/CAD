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
using BLL.ComputeUnits.F2;
using BLL.ComputeUnits.F3;
using BLL.ComputeUnits.F4;
using BLL.ComputeUnits.F5;
using BLL.ComputeUnits.F6;
using BLL.ComputeUnits.F7;
using BLL.ComputeUnits.F8;
using BLL.ComputeUnits;
using BLL.Service;
using System.IO;
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
            Controller2 c2 = new Controller2();
            Controller3 c3 = new Controller3();
            Controller4 c4 = new Controller4();
            Controller5 c5 = new Controller5();
            Controller6 c6 = new Controller6();
            Controller7 c7 = new Controller7();
            Controller8 c8 = new Controller8();
            try
            {
                c1.Compare();
                c2.Compare();
                c3.Compare();
                c4.Compare();
                c5.Compare();
                c6.Compare();
                c7.Compare();
                c8.Compare();

            }
            catch (Exception ex)
            {
                ErrorService.Show(ex.Message);
            }
            //这些弹窗都是测试用代码
            //MessageBox.Show(Controller1.lString);
            //MessageBox.Show(Controller1.rString);
            // MessageBox.Show(Controller2.lString);
            //MessageBox.Show(Controller2.rString);

            //以下是生成计算书的代码
            WordController outScaffBook = new WordController();
            //保存路径为程序根目录下的tmp文件夹
            Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath + "\\tmp");
            string path = System.Windows.Forms.Application.StartupPath + "\\tmp\\计算书.docx";
            //未处理的计算书目录为程序根目录下的rawBook文件夹，在这里复制它
            if (!outScaffBook.CopyTo(System.Windows.Forms.Application.StartupPath + "\\rawBook\\OutScaffCalcBook.docx", path))
            {
                ErrorService.Show("计算书不存在");
                return;
            }
            //复制完毕后打开计算书，这里如果设定为true，可以看到程序替换word的过程
            if (!outScaffBook.OpenDoc(path, true))
            {
                ErrorService.Show("计算书无法打开");
                return;
            }
            //处理计算书的内容
            outScaffBook.PushKeyObjValueObj(ScaffoldPara.GetKeyArray(), ScaffoldPara.GetValArray());
            outScaffBook.PushKeyObjValueObj(ProjectInfo.GetKeyArray(), ProjectInfo.GetValArray());
            outScaffBook.PushDictionary(c1.solveDic,c2.solveDic,c3.solveDic,c4.solveDic,c5.C5Dic,c6.C6Dic,c8.solveDic);
            //因WPS与WORD会引起冲突，所以这里不加自动保存功能
            //将计算书导出后的任何文件保存，打开的问题，抛给WORD或WPS
            //这样一来，重复写计算书也不会有抛异常的问题

            #region
            //保存关闭后再打开
            //outScaffBook.SaveDocFile(path);
            //outScaffBook.CloseDoc();
            //outScaffBook.OpenDoc(path, true);
            #endregion



            
        }
        #endregion


        //用料统计
        private void skinButton12_Click(object sender, EventArgs e)
        {
            Controller1 c1 = new Controller1();
            Controller2 c2 = new Controller2();
      
            Controller5 c5 = new Controller5();
            Controller6 c6 = new Controller6();
            Controller8 c8 = new Controller8();
            try
            {

                c1.Compare();
                c2.Compare();

                c5.Compare();
                c6.Compare();
                c8.Compare();


            }
            catch (Exception ex)
            {
                ErrorService.Show(ex.Message);
            }
           
            MessageBox.Show(Controller5.lString);
            MessageBox.Show(Controller5.rString);
            MessageBox.Show(Controller6.lString);
            MessageBox.Show(Controller6.rString);
        }

        //施工图
        private void skinButton11_Click(object sender, EventArgs e)
        {

        }

       

        private void skinButton13_Click(object sender, EventArgs e)
        {
            
        }

    }

}
