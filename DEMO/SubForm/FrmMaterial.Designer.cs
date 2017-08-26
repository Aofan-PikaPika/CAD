namespace DEMO.SubForm
{
    partial class FrmMaterial
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMaterial));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.skinTabControl1 = new CCWin.SkinControl.SkinTabControl();
            this.skinTabPage1 = new CCWin.SkinControl.SkinTabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.skinTabPage2 = new CCWin.SkinControl.SkinTabPage();
            this.skinTabPage3 = new CCWin.SkinControl.SkinTabPage();
            this.skinComboBox1 = new CCWin.SkinControl.SkinComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.skinButton2 = new CCWin.SkinControl.SkinButton();
            this.skinButton1 = new CCWin.SkinControl.SkinButton();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.specifications = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.material = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.the_weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inventory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skinTabControl1.SuspendLayout();
            this.skinTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // skinTabControl1
            // 
            this.skinTabControl1.AnimatorType = CCWin.SkinControl.AnimationType.HorizSlide;
            this.skinTabControl1.CloseRect = new System.Drawing.Rectangle(2, 2, 12, 12);
            this.skinTabControl1.Controls.Add(this.skinTabPage1);
            this.skinTabControl1.Controls.Add(this.skinTabPage2);
            this.skinTabControl1.Controls.Add(this.skinTabPage3);
            this.skinTabControl1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinTabControl1.HeadBack = null;
            this.skinTabControl1.ImgTxtOffset = new System.Drawing.Point(0, 0);
            this.skinTabControl1.ItemSize = new System.Drawing.Size(100, 36);
            this.skinTabControl1.Location = new System.Drawing.Point(7, 35);
            this.skinTabControl1.Name = "skinTabControl1";
            this.skinTabControl1.PageArrowDown = ((System.Drawing.Image)(resources.GetObject("skinTabControl1.PageArrowDown")));
            this.skinTabControl1.PageArrowHover = ((System.Drawing.Image)(resources.GetObject("skinTabControl1.PageArrowHover")));
            this.skinTabControl1.PageCloseHover = ((System.Drawing.Image)(resources.GetObject("skinTabControl1.PageCloseHover")));
            this.skinTabControl1.PageCloseNormal = ((System.Drawing.Image)(resources.GetObject("skinTabControl1.PageCloseNormal")));
            this.skinTabControl1.PageDown = ((System.Drawing.Image)(resources.GetObject("skinTabControl1.PageDown")));
            this.skinTabControl1.PageDownTxtColor = System.Drawing.Color.DeepSkyBlue;
            this.skinTabControl1.PageHover = ((System.Drawing.Image)(resources.GetObject("skinTabControl1.PageHover")));
            this.skinTabControl1.PageImagePosition = CCWin.SkinControl.SkinTabControl.ePageImagePosition.Left;
            this.skinTabControl1.PageNorml = null;
            this.skinTabControl1.SelectedIndex = 0;
            this.skinTabControl1.Size = new System.Drawing.Size(834, 398);
            this.skinTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.skinTabControl1.TabIndex = 0;
            // 
            // skinTabPage1
            // 
            this.skinTabPage1.BackColor = System.Drawing.Color.White;
            this.skinTabPage1.Controls.Add(this.dataGridView1);
            this.skinTabPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTabPage1.Location = new System.Drawing.Point(0, 36);
            this.skinTabPage1.Name = "skinTabPage1";
            this.skinTabPage1.Size = new System.Drawing.Size(834, 362);
            this.skinTabPage1.TabIndex = 0;
            this.skinTabPage1.TabItemImage = null;
            this.skinTabPage1.Text = "支架构配件";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.model,
            this.specifications,
            this.material,
            this.the_weight,
            this.inventory});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(834, 362);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CurrentCellChanged += new System.EventHandler(this.dataGridView1_CurrentCellChanged);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // skinTabPage2
            // 
            this.skinTabPage2.BackColor = System.Drawing.Color.White;
            this.skinTabPage2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTabPage2.Location = new System.Drawing.Point(0, 36);
            this.skinTabPage2.Name = "skinTabPage2";
            this.skinTabPage2.Size = new System.Drawing.Size(834, 362);
            this.skinTabPage2.TabIndex = 1;
            this.skinTabPage2.TabItemImage = null;
            this.skinTabPage2.Text = "主次楞";
            // 
            // skinTabPage3
            // 
            this.skinTabPage3.BackColor = System.Drawing.Color.White;
            this.skinTabPage3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTabPage3.Location = new System.Drawing.Point(0, 36);
            this.skinTabPage3.Name = "skinTabPage3";
            this.skinTabPage3.Size = new System.Drawing.Size(834, 362);
            this.skinTabPage3.TabIndex = 2;
            this.skinTabPage3.TabItemImage = null;
            this.skinTabPage3.Text = "模板";
            // 
            // skinComboBox1
            // 
            this.skinComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skinComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skinComboBox1.FormattingEnabled = true;
            this.skinComboBox1.Location = new System.Drawing.Point(272, 439);
            this.skinComboBox1.Name = "skinComboBox1";
            this.skinComboBox1.Size = new System.Drawing.Size(124, 22);
            this.skinComboBox1.TabIndex = 1;
            this.skinComboBox1.WaterText = "";
            this.skinComboBox1.SelectionChangeCommitted += new System.EventHandler(this.skinComboBox1_SelectionChangeCommitted);
            this.skinComboBox1.Leave += new System.EventHandler(this.skinComboBox1_Leave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DEMO.Properties.Resources.add_96px_1206665_easyicon_net;
            this.pictureBox1.Location = new System.Drawing.Point(29, 450);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(62, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DEMO.Properties.Resources.cancel_96px_1206674_easyicon_net;
            this.pictureBox2.Location = new System.Drawing.Point(109, 450);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(62, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // skinButton2
            // 
            this.skinButton2.BackColor = System.Drawing.Color.Transparent;
            this.skinButton2.BaseColor = System.Drawing.Color.White;
            this.skinButton2.BorderColor = System.Drawing.Color.Silver;
            this.skinButton2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton2.DownBack = null;
            this.skinButton2.DownBaseColor = System.Drawing.Color.SteelBlue;
            this.skinButton2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinButton2.ForeColor = System.Drawing.Color.Black;
            this.skinButton2.IsDrawGlass = false;
            this.skinButton2.Location = new System.Drawing.Point(680, 460);
            this.skinButton2.MouseBack = null;
            this.skinButton2.MouseBaseColor = System.Drawing.Color.DodgerBlue;
            this.skinButton2.Name = "skinButton2";
            this.skinButton2.NormlBack = null;
            this.skinButton2.Radius = 10;
            this.skinButton2.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinButton2.Size = new System.Drawing.Size(108, 30);
            this.skinButton2.TabIndex = 8;
            this.skinButton2.Text = "取  消";
            this.skinButton2.UseVisualStyleBackColor = false;
            this.skinButton2.Click += new System.EventHandler(this.skinButton2_Click);
            // 
            // skinButton1
            // 
            this.skinButton1.BackColor = System.Drawing.Color.Transparent;
            this.skinButton1.BaseColor = System.Drawing.Color.DodgerBlue;
            this.skinButton1.BorderColor = System.Drawing.Color.Silver;
            this.skinButton1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton1.DownBack = null;
            this.skinButton1.DownBaseColor = System.Drawing.Color.SteelBlue;
            this.skinButton1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinButton1.ForeColor = System.Drawing.Color.White;
            this.skinButton1.IsDrawGlass = false;
            this.skinButton1.Location = new System.Drawing.Point(516, 460);
            this.skinButton1.MouseBack = null;
            this.skinButton1.MouseBaseColor = System.Drawing.Color.DodgerBlue;
            this.skinButton1.Name = "skinButton1";
            this.skinButton1.NormlBack = null;
            this.skinButton1.Radius = 10;
            this.skinButton1.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinButton1.Size = new System.Drawing.Size(108, 30);
            this.skinButton1.TabIndex = 7;
            this.skinButton1.Text = "确  定";
            this.skinButton1.UseVisualStyleBackColor = false;
            this.skinButton1.Click += new System.EventHandler(this.skinButton1_Click);
            // 
            // name
            // 
            this.name.FillWeight = 73.09645F;
            this.name.HeaderText = "名称";
            this.name.MinimumWidth = 100;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // model
            // 
            this.model.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.model.FillWeight = 234.5178F;
            this.model.HeaderText = "型号";
            this.model.MinimumWidth = 120;
            this.model.Name = "model";
            this.model.ReadOnly = true;
            this.model.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.model.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // specifications
            // 
            this.specifications.FillWeight = 73.09645F;
            this.specifications.HeaderText = "规格";
            this.specifications.MinimumWidth = 80;
            this.specifications.Name = "specifications";
            this.specifications.ReadOnly = true;
            this.specifications.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.specifications.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // material
            // 
            this.material.FillWeight = 73.09645F;
            this.material.HeaderText = "材质";
            this.material.Name = "material";
            this.material.ReadOnly = true;
            this.material.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.material.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // the_weight
            // 
            this.the_weight.FillWeight = 73.09645F;
            this.the_weight.HeaderText = "理论重量(kg)";
            this.the_weight.Name = "the_weight";
            this.the_weight.ReadOnly = true;
            this.the_weight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // inventory
            // 
            this.inventory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.inventory.FillWeight = 73.09645F;
            this.inventory.HeaderText = "库存(根)";
            this.inventory.Name = "inventory";
            this.inventory.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.inventory.Width = 97;
            // 
            // FrmMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 513);
            this.Controls.Add(this.skinButton2);
            this.Controls.Add(this.skinButton1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.skinComboBox1);
            this.Controls.Add(this.skinTabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMaterial";
            this.ShowInTaskbar = false;
            this.Text = "材料库";
            this.Load += new System.EventHandler(this.FrmMaterial_Load);
            this.skinTabControl1.ResumeLayout(false);
            this.skinTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinTabControl skinTabControl1;
        private CCWin.SkinControl.SkinTabPage skinTabPage1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private CCWin.SkinControl.SkinTabPage skinTabPage2;
        private CCWin.SkinControl.SkinTabPage skinTabPage3;
        private CCWin.SkinControl.SkinComboBox skinComboBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private CCWin.SkinControl.SkinButton skinButton2;
        private CCWin.SkinControl.SkinButton skinButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn model;
        private System.Windows.Forms.DataGridViewTextBoxColumn specifications;
        private System.Windows.Forms.DataGridViewTextBoxColumn material;
        private System.Windows.Forms.DataGridViewTextBoxColumn the_weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn inventory;
    }
}