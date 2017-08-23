using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CCWin;
using BLL;


namespace DEMO
{
    /// <summary>
    /// 声明几个委托，实现“新建工程”、“打开工程”的功能
    /// </summary>
    public delegate void setNewFunctionHandle();
    public delegate void setOpenFunctionHandle();
    public delegate void setRecentFunctionHandle(string path,string name);

    public partial class Hello :Form
    {
        //定义几个委托变量，实现“新建工程”、“打开工程”、"最近工程"的功能
        public setNewFunctionHandle setNewProjectFuction;
        public setOpenFunctionHandle setOpenProjectFuntion;
        public setRecentFunctionHandle setRecentProjectFuntion;

        /// <summary>
        /// 快捷开始界面
        /// </summary>
        public Hello()
        {
            InitializeComponent();
        }

        DataTable dt = null;
        /// <summary>
        /// 设置文字显示区域panel1的位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hello_Load(object sender, EventArgs e)
        {
            panel1.Left = (this.ParentForm.Width - panel1.Width) / 2;
            panel1.Top = (int)Math.Ceiling((this.ParentForm.Height - 1.5*panel1.Height) / 2.0);


            //最近
            //listBox1.Items.Clear();
            SQLOperations sqlo = new SQLOperations();
            dt = sqlo.GetLog();
            listBox1.DataSource = dt;
            listBox1.DisplayMember = "pro_name";
            listBox1.ValueMember = "sto_path";

           
            
        }


        /// <summary>
        /// 新建按钮；点击该按钮，相当于在主界面单击“新建工程”按钮，此功能通过一个委托方法实现。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            setNewProjectFuction();           
        }


        /// <summary>
        /// 窗口重绘时，实现文字区域的居中显示。
        /// </summary>
        public void resize() 
        {
            panel1.Left = (this.ParentForm.Width - panel1.Width) / 2;
            panel1.Top = (int)Math.Ceiling((this.ParentForm.Height - 1.5 * panel1.Height) / 2.0);
        }


        /// <summary>
        /// 打开按钮；点击该按钮，相当于在主界面单击“打开工程”按钮，此功能通过一个委托方法实现。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            setOpenProjectFuntion();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            int index = this.listBox1.IndexFromPoint(e.Location);
            if (index!=System.Windows.Forms.ListBox.NoMatches)
            {
                string name = "";
                XMLOperation xmlo = new XMLOperation();
                name=xmlo.XmlOpen(listBox1.SelectedValue.ToString());
                if (name != "")
                {
                    this.Close();
                    this.Dispose();
                    setRecentProjectFuntion(listBox1.SelectedValue.ToString(),name);
                }
                else 
                {
                    DialogResult dr = MessageBoxEx.Show("未能打开\"" + (listBox1.Items[index] as DataRowView)[listBox1.DisplayMember].ToString() + "\". 是否从最近使用工程列表中移除对它的引用？","提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    if (dr == DialogResult.OK)
                    {
                        SQLOperations sqlo = new SQLOperations();
                        sqlo.DeleteLog(listBox1.SelectedValue.ToString());
                        dt.Rows.RemoveAt(index);
                        listBox1.DataSource = dt;
                        listBox1.DisplayMember = "pro_name";
                        listBox1.ValueMember = "sto_path";
                        listBox1.Refresh();
                        
                    }
                }
                
            }
        }
    }
}
