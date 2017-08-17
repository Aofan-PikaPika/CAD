using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CCWin;

namespace DEMO.SubForm
{
    public partial class FrmFrameInfo : Skin_Mac
    {
        public FrmFrameInfo()
        {
            InitializeComponent();
        }
        
        private void splitContainer1_Panel1_MouseClick(object sender, MouseEventArgs e)
        {
            splitContainer1.Panel2Collapsed = !splitContainer1.Panel2Collapsed;
            if (splitContainer1.Size.Height < 50)
            {
                splitContainer1.Size = new Size(splitContainer1.Size.Width, 516);
                this.pictureBox1.Image = global::DEMO.Properties.Resources.up;
            }
            else 
            {
                splitContainer1.Size = new Size(splitContainer1.Size.Width,10);
                this.pictureBox1.Image = global::DEMO.Properties.Resources.down;
            }
        }

        private void splitContainer2_Panel1_MouseClick(object sender, MouseEventArgs e)
        {
            splitContainer2.Panel2Collapsed = !splitContainer2.Panel2Collapsed;
            if (splitContainer2.Size.Height < 50)
            {
                splitContainer2.Size = new Size(splitContainer2.Size.Width, 244);
                this.pictureBox2.Image = global::DEMO.Properties.Resources.up;
            }
            else
            {
                splitContainer2.Size = new Size(splitContainer2.Size.Width, 10);
                this.pictureBox2.Image = global::DEMO.Properties.Resources.down;
            }
        }

        private void splitContainer3_Panel1_MouseClick(object sender, MouseEventArgs e)
        {
            splitContainer3.Panel2Collapsed = !splitContainer3.Panel2Collapsed;
            if (splitContainer3.Size.Height < 50)
            {
                splitContainer3.Size = new Size(splitContainer3.Size.Width, 300);
                this.pictureBox3.Image = global::DEMO.Properties.Resources.up;
            }
            else
            {
                splitContainer3.Size = new Size(splitContainer3.Size.Width, 10);
                this.pictureBox3.Image = global::DEMO.Properties.Resources.down;
            }
        }

        private void label1_MouseClick(object sender, MouseEventArgs e)
        {
            splitContainer1_Panel1_MouseClick(this,null);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            splitContainer1_Panel1_MouseClick(this, null);
        }

        private void label2_MouseClick(object sender, MouseEventArgs e)
        {
            splitContainer2_Panel1_MouseClick(this, null);
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            splitContainer2_Panel1_MouseClick(this, null);
        }

        private void label3_MouseClick(object sender, MouseEventArgs e)
        {
            splitContainer3_Panel1_MouseClick(this, null);
        }

        private void pictureBox3_MouseClick(object sender, MouseEventArgs e)
        {
            splitContainer3_Panel1_MouseClick(this, null);
        }

        ShowPic sp;
        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            sp = new ShowPic();
            sp.Show();
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            if (sp!=null)
            {
                sp.Close();
            }
            
        }
    }
}
