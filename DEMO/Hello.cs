using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CCWin;


namespace DEMO
{
    public delegate void setFunctionHandle();
    public partial class Hello :Form
    {
        
        public setFunctionHandle setFuction;
        public Hello()
        {
            InitializeComponent();
        }

        private void Hello_Load(object sender, EventArgs e)
        {
            panel1.Left = (this.ParentForm.Width - panel1.Width) / 2;
            panel1.Top = (int)Math.Ceiling((this.ParentForm.Height - 1.5*panel1.Height) / 2.0);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            setFuction();
            
        }
        public void resize() 
        {
            panel1.Left = (this.ParentForm.Width - panel1.Width) / 2;
            panel1.Top = (int)Math.Ceiling((this.ParentForm.Height - 1.5 * panel1.Height) / 2.0);
        }
    }
}
