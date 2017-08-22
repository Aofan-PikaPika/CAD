using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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
    }
}
