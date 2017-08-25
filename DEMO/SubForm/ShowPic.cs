using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DEMO.SubForm
{
    public partial class ShowPic : Form
    {
        public ShowPic(int TypeSoil)
        {
            InitializeComponent();
            switch (TypeSoil)
            {
                case 0: pictureBox1.Image = Properties.Resources._1;
                    break;
                case 1: pictureBox1.Image = Properties.Resources._2;
                    break;
                case 2: pictureBox1.Image = Properties.Resources._3;
                    break;
                case 3: pictureBox1.Image = Properties.Resources._4;
                    break;
                case 4: pictureBox1.Image = Properties.Resources._5;
                    break;
                case 5: pictureBox1.Image = Properties.Resources._6;
                    break;
                case 6: pictureBox1.Image = Properties.Resources._7;
                    break;
                case 7: pictureBox1.Image = Properties.Resources._8;
                    break;
            }
        }
    }
}
