using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace DEMO
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //打开载入界面，并在另一线程加载主界面
           Splash.LoadAndRun(new FrmMain());

            //调试程序
           // Application.Run(new FrmMain());
            //Application.Run(new SubForm.FrmMaterial());
        }
    }
}
