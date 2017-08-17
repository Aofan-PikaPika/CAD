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
            Splash.LoadAndRun(new FrmMain());
            // Application.Run(new FrmMain());
           // Application.Run(new SubForm.FrmFrameInfo());
        }
    }
}
