using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CCWin;
using Model.Entity;
using BLL.Service;

namespace DEMO.SubForm
{
    public partial class FrmInfo : Skin_Mac
    {
        /// <summary>
        /// 窗体初始化数据
        /// </summary>
        /// <param name="projectState"></param>
        public FrmInfo(int projectState)
        {
            InitializeComponent();
            switch (projectState)
            {
                case 1: 
                    {
                        skinTextBox1.Text = ProjectInfo.Pro_Name;
                        label1.Text = ProjectInfo.Pro_Type;
                    }
                    break;
                case 2: 
                    {
                        skinTextBox1.Text = ProjectInfo.Pro_Name;
                        label1.Text = ProjectInfo.Pro_Type;
                        skinComboBox1.Text = ProjectInfo.Con_Province;
                        skinComboBox3.Text = ProjectInfo.Con_City;
                        skinTextBox2.Text = ProjectInfo.Unit;
                        skinTextBox4.Text = ProjectInfo.Con_Unit;
                        skinTextBox6.Text = ProjectInfo.Sup_Unit;
                        skinTextBox3.Text = ProjectInfo.Con_Area.ToString();
                        skinTextBox5.Text = ProjectInfo.Con_Height.ToString();
                        skinTextBox7.Text = ProjectInfo.Des_Unit;                 
                    }
                    break;
                case 0:
                    break;
            }

        }

        #region 按钮控制

        ErrorService es = new ErrorService();
        private void skinButton1_Click(object sender, EventArgs e)
        {
            if (!(es.textboxValidating(skinTextBox3.Text)) || skinTextBox3.Text == "")
            {
                this.errorProvider1.SetError(this.skinTextBox3, "请输入数字");
            }
            else 
            {
                this.errorProvider1.SetError(this.skinTextBox3, "");
            }
            if (!(es.textboxValidating(skinTextBox5.Text)) || skinTextBox5.Text == "")
            {
                this.errorProvider2.SetError(this.skinTextBox5, "请输入数字");
            }
            else 
            {
                this.errorProvider2.SetError(this.skinTextBox5, "");
            }
            if (es.textboxValidating(skinTextBox3.Text) && es.textboxValidating(skinTextBox5.Text) && skinTextBox3.Text != "" && skinTextBox5.Text != "")
            {
                ProjectInfo.Con_Area = double.Parse(skinTextBox3.Text);
                ProjectInfo.Con_Height = double.Parse(skinTextBox5.Text);
                ProjectInfo.Pro_Name = skinTextBox1.Text;
                ProjectInfo.Con_Province = skinComboBox1.Text;
                ProjectInfo.Con_City = skinComboBox3.Text;
                ProjectInfo.Unit = skinTextBox2.Text;
                ProjectInfo.Con_Unit = skinTextBox4.Text;
                ProjectInfo.Sup_Unit = skinTextBox6.Text;
                ProjectInfo.Des_Unit = skinTextBox7.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();

            }

        }
        private void skinButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

       
      
       
    }
}
