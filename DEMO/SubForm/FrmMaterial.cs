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
    public partial class FrmMaterial : Skin_Mac
    {
        public FrmMaterial()
        {
            InitializeComponent();
        }

        List<string> ListData1 = new List<string> { "立杆", "横杆", "斜杆" };
        List<string> ListData21 = new List<string> { "A-LG-200", "A-LG-300", "A-LG-400" };
        List<string> ListData22 = new List<string> { "B-LG-200", "B-LG-300", "B-LG-400" };
        List<string> ListData23 = new List<string> { "C-LG-200", "C-LG-300", "C-LG-400" };
        List<string> ListData41 = new List<string> { "Q245A", "Q345A" };
        List<string> ListData42 = new List<string> { "Q245B", "Q345B" };
        List<string> ListData43 = new List<string> { "Q245C", "Q345C" };

        List<string> Data = new List<string> { "立杆", "A-LG-200", "48*3.2*2000", "Q345A", "9.90", "1000" };

        


        private void FrmMaterial_Load(object sender, EventArgs e)
        {

            skinComboBox1.Visible = false;
            skinComboBox1.Width = 0;
            dataGridView1.Rows.Add("立杆", "A-LG-200", "48*3.2*2000", "Q345A", "9.90", "1000");            
            dataGridView1.Controls.Add(this.skinComboBox1);

           
           
          
           
           
           
        }
        int removed = 0;

   
        private void skinComboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell.Value = ((ComboBox)sender).SelectedItem.ToString();
            skinComboBox1.Visible =false;
            skinComboBox1.Width = 0;

            //AI-1
            if (dataGridView1.CurrentCell.ColumnIndex!=1)
            {
                if (dataGridView1.CurrentRow.Cells[0].Value.ToString() == "立杆")
                {
                    dataGridView1.CurrentRow.Cells[1].Value = ListData21[0].ToString();
                }
                else if (dataGridView1.CurrentRow.Cells[0].Value.ToString() == "横杆")
                {
                    dataGridView1.CurrentRow.Cells[1].Value = ListData22[0].ToString();
                }
                else if (dataGridView1.CurrentRow.Cells[0].Value.ToString() == "斜杆")
                {
                    dataGridView1.CurrentRow.Cells[1].Value = ListData23[0].ToString();
                }
                
            }
           

            //AI-2
            if (dataGridView1.CurrentCell.ColumnIndex != 3)
            {
                if (dataGridView1.CurrentRow.Cells[1].Value.ToString() == "A-LG-200")
                {
                    dataGridView1.CurrentRow.Cells[3].Value = ListData41[0].ToString();
                }
                else if (dataGridView1.CurrentRow.Cells[1].Value.ToString() == "B-LG-200")
                {
                    dataGridView1.CurrentRow.Cells[3].Value = ListData42[0].ToString();
                }
                else if (dataGridView1.CurrentRow.Cells[1].Value.ToString() == "C-LG-200")
                {
                    dataGridView1.CurrentRow.Cells[3].Value = ListData43[0].ToString();
                }
            }

            
            
        }

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (skinTabControl1.SelectedIndex==0)
            {
                dataGridView1.Rows.Add("立杆", "A-LG-200", "48*3.2*2000", "Q345A", "9.90", "1000");
            }
            else 
            {
                MessageBox.Show("敬请期待！");
            }

            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dataGridView1.SelectedRows)
            {
                if (!r.IsNewRow)
                {
                    removed = 1;
                    dataGridView1.Rows.Remove(r);
                    skinComboBox1.Visible = false;
                }
            }
        }

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

                                skinComboBox1.DataSource = ListData1;
                                skinComboBox1.Text = dataGridView1.CurrentCell.Value.ToString();

                            }
                            break;
                        case 1:
                            {
                                skinComboBox1.DataSource = null;
                                skinComboBox1.Items.Clear();
                                fun_combo();

                                if (dataGridView1.CurrentRow.Cells[0].Value.ToString() == "立杆")
                                {
                                    skinComboBox1.DataSource = ListData21;
                                    skinComboBox1.Text = dataGridView1.CurrentCell.Value.ToString();
                                }
                                else if (dataGridView1.CurrentRow.Cells[0].Value.ToString() == "横杆")
                                {
                                    skinComboBox1.DataSource = ListData22;
                                    skinComboBox1.Text = dataGridView1.CurrentCell.Value.ToString();
                                }
                                else if (dataGridView1.CurrentRow.Cells[0].Value.ToString() == "斜杆")
                                {
                                    skinComboBox1.DataSource = ListData23;
                                    skinComboBox1.Text = dataGridView1.CurrentCell.Value.ToString();
                                }


                            }
                            break;
                        case 3:
                            {
                                skinComboBox1.DataSource = null;
                                skinComboBox1.Items.Clear();
                                fun_combo();

                                if (dataGridView1.CurrentRow.Cells[1].Value.ToString() == "A-LG-200")
                                {
                                    skinComboBox1.DataSource = ListData41;
                                    skinComboBox1.Text = dataGridView1.CurrentCell.Value.ToString();
                                }
                                else if (dataGridView1.CurrentRow.Cells[1].Value.ToString() == "A-LG-300")
                                {
                                    skinComboBox1.DataSource = ListData42;
                                    skinComboBox1.Text = dataGridView1.CurrentCell.Value.ToString();
                                }
                                else if (dataGridView1.CurrentRow.Cells[1].Value.ToString() == "A-LG-400")
                                {
                                    skinComboBox1.DataSource = ListData43;
                                    skinComboBox1.Text = dataGridView1.CurrentCell.Value.ToString();
                                }

                            }
                            break;

                    }

                }
                removed = 0;

            }
            catch (Exception)
            {

                throw;
            }
        }

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


       

        

       


      
        
      

    }
}
