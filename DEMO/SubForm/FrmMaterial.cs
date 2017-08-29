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
using BLL.Service;
using Model.Entity;

namespace DEMO.SubForm
{
    public partial class FrmMaterial : Skin_Mac
    {

        /// <summary>
        /// 验证数组
        /// </summary>
        //private int[] validArray = Enumerable.Repeat(-1, 105).ToArray();

        private int pjState = 0;
        public FrmMaterial(int projectState)
        {
            InitializeComponent();

            pjState = projectState;

            

           
        }

        List<string> ListDataName = new List<string> { "立杆", "竖向斜杆", "水平斜杆","可调托座","横向水平杆","纵向水平杆" };

        private void FrmMaterial_Load(object sender, EventArgs e)
        {

            skinComboBox1.Visible = false;
            skinComboBox1.Width = 0;
            if (pjState == 1)//新建
            {

                DataTable dt = MaterialLib.dtMaterial;
                if (dt != null)//第二次打开
                {
                    FillDgv(dt);
                }
                else //第一次打开
                {
                    dataGridView1.Rows.Add("立杆", "", "", "", "", "1000");
                }
                //向单元格添加下拉列表控件
                dataGridView1.Controls.Add(this.skinComboBox1);
            }
            else if (pjState == 2)//打开工程
            {     
                /*
                 * 这里的dt在第一次打开材料库窗体时，是在数据库中获取到的
                 * 第二次打开材料库窗体时，是在dgv中获取到的
                 */
                DataTable dt = MaterialLib.dtMaterial;
                FillDgv(dt);
                //向表格添加下拉列表控件
                dataGridView1.Controls.Add(this.skinComboBox1);
            }      
        }

        private void FillDgv(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //为datagridview的每一行赋值
                string name = dt.Rows[i]["name"].ToString();
                string model = dt.Rows[i]["model"].ToString();
                string specifications = dt.Rows[i]["specifications"].ToString();
                string material = dt.Rows[i]["material"].ToString();
                string the_weight = dt.Rows[i]["the_weight"].ToString();
                string inventory = dt.Rows[i]["inventory"].ToString();
                dataGridView1.Rows.Add(name, model, specifications, material, the_weight, inventory);
                //打开时复现每行的tag，用在确定按钮，保存inventory时遍历，提供validArray的下标值
                dataGridView1.Rows[i].Tag = int.Parse(dt.Rows[i]["fitting_id"].ToString());
            }
        }


        /// <summary>
        /// 删除标志位
        /// </summary>
        int removed = 0;



       
        /// <summary>
        /// 下拉列表提交事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
   
        private void skinComboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //当数据源为list<String>时，用selectedItem.ToString()
            //当数据源为DataTable时，用.Text属性
            dataGridView1.CurrentCell.Value = ((ComboBox)sender).Text;        
            if (dataGridView1.CurrentCell.ColumnIndex == 1)
            {
                DataTable dt = null;
                SQLOperations sqlo = new SQLOperations();
                dt = sqlo.GetMeterialInfo(dataGridView1.CurrentRow.Cells[0].Value.ToString(), dataGridView1.CurrentRow.Cells[1].Value.ToString());
                for (int i = 2; i < 5; i++)
                {
                    dataGridView1.CurrentRow.Cells[i].Value = dt.Rows[0][i + 1];
                }

                //验证数组赋值
                int thisFitting_id = int.Parse(dt.Rows[0]["fitting_id"].ToString());
                //int thisInventory = int.Parse(dataGridView1.CurrentRow.Cells[5].Value.ToString());
                if (MaterialLib.validArray[thisFitting_id] > 0)
                {
                    //massagebox
                    ErrorService.Show("出现了重复的材料");
                    removed = 1;
                    dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                    removed = 0;
                    skinComboBox1_Leave(this, null);
                    
                }
                else
                {
                    //在model对应的conbobox提交时，不涉及将库存往数组录入
                    //仅将数组对应标志位置1，表示有材料
                    MaterialLib.validArray[thisFitting_id] = 1;
                    dataGridView1.CurrentRow.Tag = thisFitting_id;                   
                }             
            }        
        }

        /// <summary>
        /// 在当前单元格绘制combobox控件
        /// </summary>
        private void fun_combo() 
        {
            skinComboBox1.Visible = false;
            skinComboBox1.Width = 0;
            skinComboBox1.Left = dataGridView1.GetCellDisplayRectangle(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex, true).Left;
            skinComboBox1.Top = dataGridView1.GetCellDisplayRectangle(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex, true).Top;
            skinComboBox1.Width = dataGridView1.GetCellDisplayRectangle(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex, true).Width;
            string content = dataGridView1.CurrentCell.Value.ToString();
            skinComboBox1.Text = content;
            skinComboBox1.Visible = true;
        }

        /// <summary>
        /// 添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (skinTabControl1.SelectedIndex==0)
            {
                dataGridView1.Rows.Add("立杆", "", "", "", "", "1000");
            }
            else 
            {
                MessageBoxEx.Show("敬请期待！");
            }

            
        }

        /// <summary>
        /// 删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dataGridView1.SelectedRows)
            {
                if (!r.IsNewRow)
                {                  
                    //删除数组中相应的材料数量
                    if (dataGridView1.CurrentRow.Tag != null)
                    {
                        int tag = int.Parse(dataGridView1.CurrentRow.Tag.ToString());
                        if (MaterialLib.validArray[tag] >0)
                        {
                            MaterialLib.validArray[tag] = -1;
                        }
                    }
                    removed = 1;
                    dataGridView1.Rows.Remove(r);
                    skinComboBox1.Visible = false;
                }
            }
            removed = 0;
        }


        /// <summary>
        /// datagridview获得model
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (removed == 0)
                {
                    int index = dataGridView1.CurrentCell.ColumnIndex;
                    switch (index)
                    {
                        case 0:
                            {
                                skinComboBox1.DataSource = null;
                                skinComboBox1.Items.Clear();
                                fun_combo();
                                skinComboBox1.DataSource = ListDataName;
                                skinComboBox1.Text = dataGridView1.CurrentCell.Value.ToString();
                            }
                            break;
                        case 1:
                            {
                                skinComboBox1.DataSource = null;
                                skinComboBox1.Items.Clear();
                                fun_combo();
                                DataTable dt = null;
                                SQLOperations sqlo = new SQLOperations();
                                dt = sqlo.GetModelList(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                                skinComboBox1.DataSource = dt;
                                skinComboBox1.DisplayMember = "model";
                                skinComboBox1.Text = dataGridView1.CurrentCell.Value.ToString();
                            }
                            break;
                        default: 
                            {
                                skinComboBox1_Leave(this, null);
                            }
                            break;
                    }
                   
                }
               
            }
            catch (Exception)
            {
                MessageBoxEx.Show("存在错误！");
            }
        }

        /// <summary>
        /// COMBOBOX的布局方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers  
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);  
        }

        //BLL.ComputeUnits.F1.F_Lmd = null;
        /// <summary>
        /// 确定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton1_Click(object sender, EventArgs e)
        {
            dataGridView1.Refresh();
            MaterialLib.clearMaterialLib();
            MaterialLib.dtMaterial = GetDgvToTable(dataGridView1);
            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    int fitting_idFromTag = 0;
            //    if (dataGridView1.Rows[i].Tag == null)
            //        continue;
            //    else                   
            //        fitting_idFromTag = int.Parse(dataGridView1.Rows[i].Tag.ToString());
            //    int thisInventory = int.Parse(dataGridView1.Rows[i].Cells["inventory"].Value.ToString());
            //    MaterialLib.validArray[fitting_idFromTag] = thisInventory;
            //}
            new SQLOperations().FillValidArray(MaterialLib.dtMaterial);
            this.Close();
            this.Dispose();
            //BLL.ComputeUnits.F1.F_Lmd = new BLL.ComputeUnits.F1.F_Lmd(ScaffoldPara.Act_Layers,ScaffoldPara.fast_num);
            //double lambda = BLL.ComputeUnits.F1.F_Lmd.ComputeValue();
            //BLL.ComputeUnits.F1.F_N F_N = new BLL.ComputeUnits.F1.F_N(2, 3, 4);
            //double N =  F_N.ComputeValue();
            //if (F_N.IsComputed) { 
            //    double z = F_N.TargetValue;
            
            //}
            //string s = F_N.ToString();


        }

        /// <summary>
        /// 绑定DataGridView数据到DataTable
        /// </summary>
        /// <param name="dgv">复制数据的DataGridView</param>
        /// <returns>返回的绑定数据后的DataTable</returns>
        public DataTable GetDgvToTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();
            // 列强制转换
            for (int count = 0; count < dgv.Columns.Count; count++)
            {
                DataColumn dc = new DataColumn(dgv.Columns[count].Name.ToString());
                dt.Columns.Add(dc);
            }
            //
            DataColumn tagToCol = new DataColumn("fitting_id");
            dt.Columns.Add(tagToCol);
            //
            // 循环行
            for (int count = 0; count < dgv.Rows.Count; count++)
            {
                DataRow dr = dt.NewRow();
                int countsub = 0;
                for ( countsub = 0; countsub < dgv.Columns.Count; countsub++)
                {
                    dr[countsub] = Convert.ToString(dgv.Rows[count].Cells[countsub].Value);
                }
                if (dgv.Rows[count].Tag!=null&&int.Parse(dgv.Rows[count].Cells["inventory"].Value.ToString())>0)
                {
                    dr[countsub] = dgv.Rows[count].Tag.ToString();
                    dt.Rows.Add(dr);
                }
                
            }
            return dt;
        }


        /// <summary>
        /// combobox失去焦点，自行消失
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinComboBox1_Leave(object sender, EventArgs e)
        {
            skinComboBox1.Visible =false;
            skinComboBox1.Width = 0;           
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


       

        

       


      
        
      

    }
}
