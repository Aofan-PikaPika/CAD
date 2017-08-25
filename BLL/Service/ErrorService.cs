using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CCWin;


namespace BLL.Service
{
    /// <summary>
    /// 匹配数值
    /// </summary>
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
        /// 匹配整数
        /// </summary>
        const string patternInt = @"^[0-9]*[1-9][0-9]*$";

        public bool textboxIntValidating(string content)
        {
            if (!(Regex.IsMatch(content, patternInt)))
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
            MessageBoxEx.Show("错误：" + errStr, "错误提示");
        }


        #region 横距限制逻辑
        public bool lbValid(int indexH,int indexLb)
        {
            if (indexH == 1)
            {
                if (indexLb == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        #endregion

        #region 内立杆最大值限制逻辑
        public bool distanceValid(int distanceValue)
        {
            if (distanceValue<= 300)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        #endregion

    }
}
