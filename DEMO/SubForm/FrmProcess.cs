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

            return -1;
        }

        /// <summary>
        /// 后台线程结束后该执行的动作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CompleteWork(object sender, RunWorkerCompletedEventArgs e)
        {
 
        }

        /// <summary>
        /// 后台线程的更新函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ProgessChanged(object sender, ProgressChangedEventArgs e)
        { 

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

        }







    }
}
