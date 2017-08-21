using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace DEMO
{
    public partial class Splash : Form
    {
       /// <summary>
       /// 软件载入界面
       /// </summary>
        public Splash()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 中止该界面的进程
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        public void KillMe(object o, EventArgs e) 
        {
            this.Close();
        }



        /// <summary>
        /// 开启新的线程，当主程序加载完毕后，调用killMe关闭当前界面，显示主界面
        /// </summary>
        /// <param name="form">主界面的引用</param>

        public static void LoadAndRun(Form form) 
        {
            form.HandleCreated += delegate
            {
                new Thread(new ThreadStart(delegate
                    {
                        Splash splash = new Splash();
                        form.Shown += delegate
                        {
                            splash.Invoke(new EventHandler(splash.KillMe));
                            splash.Dispose();
                        };
                        Application.Run(splash);
                    })).Start();
            };
            Application.Run(form);
        }
        
       
    }
}
