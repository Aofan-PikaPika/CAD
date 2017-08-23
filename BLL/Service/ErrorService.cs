using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace BLL.Service
{
    public class ErrorService
    {

        const string pattern = @"^[-]?\d+[.]?\d*$";
        public bool textboxValidating(string content) 
        {
            if (!(Regex.IsMatch(content, pattern)))
            {
                return false;
            }
            else 
            {
                return true;
            }
        }

        /// <summary>
        /// 弹框，提示消息，处理错误
        /// </summary>
        /// <param name="errorCondition"></param>
        public static void Show(string errStr)
        {
            MessageBox.Show("错误：" + errStr, "错误提示");
        }
    }
}
