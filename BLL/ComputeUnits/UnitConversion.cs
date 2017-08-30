using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.ComputeUnits
{
    public class 长度换算类
    {
        private double m_毫米;

        public double 毫米
        {
            set { m_毫米 = value; }
            get { return m_毫米; }
        }
        public double 厘米
        {
            set { m_毫米 = value * 10; }
            get { return m_毫米 / 10; }
        }
        public double 分米
        {
            set { m_毫米 = value * 100; }
            get { return m_毫米 / 100; }
        }
        public double 米
        {
            set { m_毫米 = value * 1000; }
            get { return m_毫米 / 1000; }
        }
    }
}
