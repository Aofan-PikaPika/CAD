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
    public partial class FrmFrameInfo : Skin_Mac
    {
        /// <summary>
        /// 构造函数，为窗体赋值
        /// </summary>
        public FrmFrameInfo(int projectState)
        {
            InitializeComponent();
            switch (projectState)
            {
                case 1: 
                    {
                        initializePara();
                    }
                    break;
                case 2: 
                    {
                        initializePara();                        
                    }
                    break;
                case 0:
                    break;
            }
            
        }

        /// <summary>
        /// 初始化赋值函数
        /// </summary>
        private void initializePara() 
        {
            //基本参数

            //脚手架类型
            switch (ScaffoldPara.Sca_Type.ToString())
            {
                case "结构": skinComboBox1.SelectedIndex = 0;
                    break;
                case "防护": skinComboBox1.SelectedIndex = 1;
                    break;
                case "装修": skinComboBox1.SelectedIndex = 2;
                    break;
            }

            //同时施工层数
            if (ScaffoldPara.Con_Layers.ToString() != "0")
            {
                skinTextBox1.Text = ScaffoldPara.Con_Layers.ToString();
            }
            else
            {
                skinTextBox1.Text = "2";
            }


            //实际铺设脚手板层数
            switch (ScaffoldPara.Act_Layers.ToString())
            {
                case "2": skinComboBox2.SelectedIndex = 0;
                    break;
                case "3": skinComboBox2.SelectedIndex = 1;
                    break;
            }

            //地面粗糙程度
            switch (ScaffoldPara.Rough_Level.ToString())
            {
                case "A": skinComboBox5.SelectedIndex = 0;
                    break;
                case "B": skinComboBox5.SelectedIndex = 1;
                    break;
                case "C": skinComboBox5.SelectedIndex = 2;
                    break;
                case "D": skinComboBox5.SelectedIndex = 3;
                    break;
            }

            //地基土类型
            switch (ScaffoldPara.Soil_Types.ToString())
            {
                case "岩石": skinComboBox4.SelectedIndex = 0;
                    break;
                case "碎石土": skinComboBox4.SelectedIndex = 1;
                    break;
                case "粉土": skinComboBox4.SelectedIndex = 2;
                    break;
                case "粘性土": skinComboBox4.SelectedIndex = 3;
                    break;
                case "淤泥土": skinComboBox4.SelectedIndex = 4;
                    break;
                case "红黏土": skinComboBox4.SelectedIndex = 5;
                    break;
                case "素填土": skinComboBox4.SelectedIndex = 6;
                    break;
                case "砂土": skinComboBox4.SelectedIndex = 7;
                    break;
                case "卵石圆砾": skinComboBox4.SelectedIndex = 8;
                    break;
            }

            //地基承载力特征值
            skinTextBox2.Text = ScaffoldPara.Cha_Value.ToString();

            //垫板面积
            skinTextBox3.Text = ScaffoldPara.Pad_Area.ToString();

            //立杆纵距
            switch (ScaffoldPara.La.ToString())
            {
                case "1.2": skinComboBox13.SelectedIndex = 0;
                    break;
                case "1.5": skinComboBox13.SelectedIndex = 1;
                    break;
                case "1.8": skinComboBox13.SelectedIndex = 2;
                    break;
                case "2.0": skinComboBox13.SelectedIndex = 3;
                    break;
            }



            //立杆横距
            switch (ScaffoldPara.Lb.ToString())
            {
                case "0.9": skinComboBox14.SelectedIndex = 0;
                    break;
                case "1.2": skinComboBox14.SelectedIndex = 1;
                    break;
                case "1.5": skinComboBox14.SelectedIndex = 2;
                    break;
            }


            //水平杆步距
            switch (ScaffoldPara.H.ToString())
            {
                case "1.5": skinComboBox12.SelectedIndex = 0;
                    break;
                case "2.0": skinComboBox12.SelectedIndex = 1;
                    break;
            }


            //连墙件

            //连墙件的布置方式
            switch (ScaffoldPara.Anchor_Style.ToString())
            {
                case "2步2跨": skinComboBox6.SelectedIndex = 0;
                    break;
                case "2步3跨": skinComboBox6.SelectedIndex = 1;
                    break;
                case "3步3跨": skinComboBox6.SelectedIndex = 2;
                    break;
            }
            //连墙件类型
            switch (ScaffoldPara.Anchor_Type.ToString())
            {
                case "钢管": skinComboBox7.SelectedIndex = 0;
                    break;
                case "角钢": skinComboBox7.SelectedIndex = 1;
                    break;
                case "槽钢": skinComboBox7.SelectedIndex = 2;
                    break;
                case "工字钢": skinComboBox7.SelectedIndex = 3;
                    break;
            }

            //连墙件型号
            switch (ScaffoldPara.Anchor_Model.ToString())
            {
                case "结构": skinComboBox8.SelectedIndex = 0;
                    break;
                case "防护": skinComboBox8.SelectedIndex = 1;
                    break;
                case "装修": skinComboBox8.SelectedIndex = 2;
                    break;
            }

            //连墙件的连接方式     
            switch (ScaffoldPara.Anchor_Connect.ToString())
            {
                case "扣件": skinComboBox9.SelectedIndex = 0;
                    break;
                case "螺栓": skinComboBox9.SelectedIndex = 1;
                    break;
                case "焊接": skinComboBox9.SelectedIndex = 2;
                    break;
                case "膨胀螺栓": skinComboBox9.SelectedIndex = 3;
                    break;
                case "软接硬撑": skinComboBox9.SelectedIndex = 4;
                    break;
            }

            //荷载参数

            //脚手架状况
            switch (ScaffoldPara.Sca_Situation.ToString())
            {
                case "全封闭、半封闭": skinComboBox10.SelectedIndex = 0;
                    break;
                case "敞开": skinComboBox10.SelectedIndex = 1;
                    break;

            }
            //背靠建筑物状况
            switch (ScaffoldPara.Bui_Status.ToString())
            {
                case "全封闭墙": skinComboBox11.SelectedIndex = 0;
                    break;
                case "敞开、框架、开洞墙": skinComboBox11.SelectedIndex = 1;
                    break;

            }

            //脚手架内立杆距建筑物距离
            if (ScaffoldPara.Bui_Distance.ToString()!= "0")
            {
                skinTextBox4.Text = ScaffoldPara.Bui_Distance.ToString();
            }
            else
            {
                skinTextBox4.Text = "300";
            }
            //每X跨间设置扣件钢管剪力撑
            if (ScaffoldPara.Per_Brace.ToString() != "0")
            {
                skinTextBox5.Text = ScaffoldPara.Per_Brace.ToString();
            }
            else
            {
                skinTextBox5.Text = "5";
            }
            //每X跨设置水平斜杆
            if (ScaffoldPara.Per_Level.ToString() != "0")
            {
                skinTextBox6.Text = ScaffoldPara.Per_Brace.ToString();
            }
            else
            {
                skinTextBox6.Text = "5";
            }
            //脚手架铺设层数每隔X一设
            if (ScaffoldPara.Per_Set.ToString() != "0")
            {
                skinTextBox8.Text = ScaffoldPara.Per_Set.ToString();
            }
            else
            {
                skinTextBox8.Text = "2";
            }
        }

        /// <summary>
        /// 实体类赋值函数
        /// </summary>
        private void assignPara() 
        {
            //基本参数
            ScaffoldPara.Sca_Type = skinComboBox1.SelectedItem.ToString();
            ScaffoldPara.Con_Layers = int.Parse(skinTextBox1.Text);
            ScaffoldPara.Act_Layers = int.Parse(skinComboBox2.SelectedItem.ToString());
            ScaffoldPara.Rough_Level = skinComboBox5.SelectedItem.ToString();
            ScaffoldPara.Soil_Types = skinComboBox4.SelectedItem.ToString();
            ScaffoldPara.Cha_Value = double.Parse(skinTextBox2.Text);
            ScaffoldPara.Pad_Area = double.Parse(skinTextBox3.Text);
            ScaffoldPara.La = double.Parse(skinComboBox13.SelectedItem.ToString());
            ScaffoldPara.Lb = double.Parse(skinComboBox14.SelectedItem.ToString());
            ScaffoldPara.H = double.Parse(skinComboBox12.SelectedItem.ToString());

            //连墙件
            ScaffoldPara.Anchor_Style = skinComboBox6.SelectedItem.ToString();
            ScaffoldPara.Anchor_Type = skinComboBox7.SelectedItem.ToString();
            ScaffoldPara.Anchor_Model = skinComboBox8.SelectedItem.ToString();
            ScaffoldPara.Anchor_Connect = skinComboBox9.SelectedItem.ToString();

            //荷载参数
            ScaffoldPara.Sca_Situation = skinComboBox10.SelectedItem.ToString();
            ScaffoldPara.Bui_Status = skinComboBox11.SelectedItem.ToString();
            ScaffoldPara.Bui_Distance = double.Parse(skinTextBox4.Text);
            ScaffoldPara.Per_Brace = int.Parse(skinTextBox5.Text);
            ScaffoldPara.Per_Level = int.Parse(skinTextBox6.Text);
            ScaffoldPara.Per_Set = int.Parse(skinTextBox8.Text);

        }






        #region 折叠栏界面逻辑
        
       

        /// <summary>
        /// 第一个折叠窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 第二个折叠窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 第三个折叠窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

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
        #endregion

        #region 地基承载力特征值图片显示逻辑
        ShowPic sp;
        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            sp = new ShowPic();
            sp.Show();
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            if (sp != null)
            {
                sp.Close();
            }

        }
        #endregion

        #region 按钮逻辑
        /// <summary>
        /// 确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton1_Click(object sender, EventArgs e)
        {
            ErrorService es=new ErrorService();
            if (!es.textboxIntValidating(skinTextBox1.Text))
            {
                this.errorProvider1.SetError(this.skinTextBox1, "请输入正整数！");
            }
            else
            {
                this.errorProvider1.SetError(this.skinTextBox1, "");
            }
            if (!es.textboxIntValidating(skinTextBox2.Text))
            {
                this.errorProvider2.SetError(this.panel2, "请输入正整数！");
            }
            else
            {
                this.errorProvider2.SetError(this.panel2, "");
            }
            if (!es.textboxIntValidating(skinTextBox3.Text))
            {
                this.errorProvider3.SetError(this.skinTextBox3, "请输入正整数！");
            }
            else
            {
                this.errorProvider3.SetError(this.skinTextBox3, "");
            }

            if (es.textboxIntValidating(skinTextBox1.Text) && es.textboxIntValidating(skinTextBox2.Text) && es.textboxIntValidating(skinTextBox3.Text))
            {
                try
                {
                    assignPara();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception)
                {

                    MessageBoxEx.Show("脚手架参数不能为空！");
                }
            }
            
            
        }
       
        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
