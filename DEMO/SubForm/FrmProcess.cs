using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CCWin;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using BLL.ComputeUnits.F1;
using BLL.ComputeUnits.F2;
using BLL.ComputeUnits.F3;
using BLL.ComputeUnits.F4;
using BLL.ComputeUnits.F5;
using BLL.ComputeUnits.F6;
using BLL.ComputeUnits.F7;
using BLL.ComputeUnits.F8;
using BLL.ComputeUnits;
using BLL;
using BLL.Service;
using System.IO;
using Model.Entity;

namespace DEMO.SubForm
{
    public partial class FrmProcess : Skin_DevExpress
    {
        public FrmProcess()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 声明一个后台线程实例
        /// </summary>

        private BackgroundWorker bkWorker = new BackgroundWorker();

        /// <summary>
        /// 定义系统计时器
        /// </summary>
        Stopwatch sw = new Stopwatch();

        /// <summary>
        /// 定义时间格式
        /// </summary>
        TimeSpan ts;

    



        private void FrmProcess_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            //后台线程报告进度
            bkWorker.WorkerReportsProgress = true;

            //后台线程支持取消操作
            bkWorker.WorkerSupportsCancellation = true;

            //绑定后台线程的若干方法
            bkWorker.DoWork += new DoWorkEventHandler(DoWork);
            bkWorker.ProgressChanged += new ProgressChangedEventHandler(ProgessChanged);
            bkWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(CompleteWork);

            //初始化时间显示标签
            timelabel.Text = string.Format("{0}:{1}:{2}:{3}", 0, 0, 0, 0);
            //开启线程
            if (!bkWorker.IsBusy)
            {
                //开启后台工作线程
                bkWorker.RunWorkerAsync();
                //初始化
                infolabel.Text = "正在进行准备工作...";
                timer1.Enabled = true;
                //开始计时
                sw.Start();
                timer1.Start();
            }
        }

        /// <summary>
        /// 后台工作线程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = ProcessProgress(bkWorker, e);
        }

        /// <summary>
        /// 后台线程处理模块
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private int ProcessProgress(object sender, DoWorkEventArgs e)
        {
            if (bkWorker.CancellationPending)
            {
                e.Cancel = true;
                return -1;
            }
            else
            {
                Controller1 c1 =null;
                Controller2 c2 = null;
                Controller3 c3 = null;
                Controller4 c4 = null;
                Controller5 c5 = null;
                Controller6 c6 = null;
                Controller7 c7 = null;
                Controller8 c8 = null;
                RecommendService rs = new RecommendService();
                for (int i = 0; i < 4; i++)
                {
                    //调用推荐服务
                    //杆件不全时由推荐服务按顺序获取相应杆件尺寸
                    //填全时直接计算 
                    rs.Recommend();

                    #region  计算模块
                    //开始计算公式
                    c1 = new Controller1();
                    c2 = new Controller2();
                    c3 = new Controller3();
                    c4 = new Controller4();
                    c5 = new Controller5();
                    c6 = new Controller6();
                    c7 = new Controller7();
                    c8 = new Controller8();
                    try
                    {
                        c1.Compare();
                        bkWorker.ReportProgress(10);
                        Thread.Sleep(500);
                        c2.Compare();
                        bkWorker.ReportProgress(20);
                        Thread.Sleep(500);
                        c3.Compare();
                        bkWorker.ReportProgress(30);
                        Thread.Sleep(500);
                        c4.Compare();
                        bkWorker.ReportProgress(40);
                        Thread.Sleep(500);
                        c5.Compare();
                        bkWorker.ReportProgress(50);
                        Thread.Sleep(500);
                        c6.Compare();
                        bkWorker.ReportProgress(60);
                        Thread.Sleep(500);
                        c7.Compare();
                        bkWorker.ReportProgress(70);
                        Thread.Sleep(500);
                        c8.Compare();
                        bkWorker.ReportProgress(80);
                        Thread.Sleep(500);
                        e.Cancel = false;
                        //通过计算，跳出循环
                        break;
                    }
                    catch (Exception ex)
                    {
                        ErrorMessage = ex.Message;
                        e.Cancel = true;
                        if (rs.DeCode == 7)
                        {
                            return -1;
                        }
                        else 
                        {
                            continue;
                        }
                       
                    }
                 
                    #endregion
                }
               
               
                if (bkWorker.CancellationPending||e.Cancel==true)
                {
                    e.Cancel = true;
                    return -1;
                }
                else 
                {
                    #region 导出计算书
                    //以下是生成计算书的代码
                    WordController outScaffBook = new WordController();
                    //保存路径为程序根目录下的tmp文件夹
                    Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath + "\\tmp");
                    string path = System.Windows.Forms.Application.StartupPath + "\\tmp\\计算书.docx";

                    //未处理的计算书目录为程序根目录下的rawBook文件夹，在这里复制它
                    if (!outScaffBook.CopyTo(System.Windows.Forms.Application.StartupPath + "\\rawBook\\OutScaffCalcBook.docx", path))
                    {
                        ErrorService.Show("计算书不存在");
                        e.Cancel = true;
                        //源计算书未找到停止计时
                        sw.Stop();
                        timer1.Stop();
                        return -1;
                    }
                    //复制完毕后打开计算书，这里如果设定为true，可以看到程序替换word的过程
                    if (!outScaffBook.OpenDoc(path, false))
                    {
                        ErrorService.Show("计算书无法打开");
                        e.Cancel = true;
                        //计算书未打开停止计时
                        sw.Stop();
                        timer1.Stop();
                        return -1;
                    }
                    //处理计算书的内容
                    outScaffBook.PushKeyObjValueObj(ScaffoldPara.GetKeyArray(), ScaffoldPara.GetValArray());
                    outScaffBook.PushKeyObjValueObj(ProjectInfo.GetKeyArray(), ProjectInfo.GetValArray());
                    outScaffBook.PushDictionary(c1.solveDic, c2.solveDic, c3.solveDic, c4.solveDic, c5.C5Dic, c6.C6Dic, c8.solveDic);
                    //因WPS与WORD会引起冲突，所以这里不加自动保存功能
                    //将计算书导出后的任何文件保存，打开的问题，抛给WORD或WPS
                    //这样一来，重复写计算书也不会有抛异常的问题
                    bkWorker.ReportProgress(90);
                    Thread.Sleep(100);
                    bkWorker.ReportProgress(100);
                    outScaffBook.SeeWord();
                    #endregion
                }

            }

            return -1;
        }

        private string ErrorMessage = ""; 


        /// <summary>
        /// 后台线程结束后该执行的动作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CompleteWork(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                infolabel.Text = ErrorMessage;
                infolabel.ForeColor = Color.Red;
            }
            else 
            {
                infolabel.Text = "已生成计算书";          
            }
            skinButton1.Text = "关  闭";
            sw.Stop();
            timer1.Stop();
        }

        /// <summary>
        /// 后台线程的更新函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ProgessChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage)
            {
                case 10: SetNotifyInfo(10,"已完成无风荷载立杆承载力验算");
                    break;
                case 20: SetNotifyInfo(20, "已完成组合风荷载立杆承载力验算");
                    break;
                case 30: SetNotifyInfo(30,"已完成水平杆承载力验算");
                    break;
                case 40: SetNotifyInfo(40, "已完成水平杆变形验算");
                    break;
                case 50: SetNotifyInfo(50, "已完成连墙件抗拉承载力验算");
                    break;
                case 60: SetNotifyInfo(60, "已完成连墙件稳定性验算");
                    break;
                case 70: SetNotifyInfo(70, "已完成连墙件抗滑移验算");
                    break;
                case 80: SetNotifyInfo(80, "已完成地基承载力验算");
                    break;
                case 90: SetNotifyInfo(100, "已生成计算书");
                    break;
                case 0: SetNotifyInfo(0,e.UserState.ToString());
                    break;
            }
        }

        /// <summary>
        /// 窗体信息刷新方法
        /// </summary>
        /// <param name="percent"></param>
        /// <param name="message"></param>
        private void SetNotifyInfo(int percent, string message)
        {
            infolabel.Text = message;
            skinProgressBar1.Value = percent;
        }

        /// <summary>
        /// 定义计时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            ts = sw.Elapsed;
            timelabel.Text = string.Format("{0}:{1}:{2}:{3}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
        }

        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton1_Click(object sender, EventArgs e)
        {
            bkWorker.CancelAsync();
            infolabel.Text = "取消";
            timelabel.Text = string.Format("{0}:{1}:{2}:{3}", 0, 0, 0, 0);
            sw.Stop();
            timer1.Stop();
            this.Close();
            this.Dispose();
            
        }







    }
}
