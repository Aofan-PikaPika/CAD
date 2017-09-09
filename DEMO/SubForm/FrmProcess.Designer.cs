namespace DEMO.SubForm
{
    partial class FrmProcess
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
            this.skinProgressBar1 = new CCWin.SkinControl.SkinProgressBar();
            this.skinButton1 = new CCWin.SkinControl.SkinButton();
            this.infolabel = new System.Windows.Forms.Label();
            this.gifBox1 = new CCWin.SkinControl.GifBox();
            this.timelabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // skinProgressBar1
            // 
            this.skinProgressBar1.Back = null;
            this.skinProgressBar1.BackColor = System.Drawing.Color.AliceBlue;
            this.skinProgressBar1.BarBack = null;
            this.skinProgressBar1.BarGlass = false;
            this.skinProgressBar1.BarRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.skinProgressBar1.Border = System.Drawing.Color.AliceBlue;
            this.skinProgressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.skinProgressBar1.ForeColor = System.Drawing.Color.Red;
            this.skinProgressBar1.Glass = false;
            this.skinProgressBar1.InnerBorder = System.Drawing.Color.AliceBlue;
            this.skinProgressBar1.Location = new System.Drawing.Point(4, 181);
            this.skinProgressBar1.Name = "skinProgressBar1";
            this.skinProgressBar1.RadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.skinProgressBar1.Size = new System.Drawing.Size(692, 15);
            this.skinProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.skinProgressBar1.TabIndex = 0;
            this.skinProgressBar1.TextFormat = CCWin.SkinControl.SkinProgressBar.TxtFormat.None;
            this.skinProgressBar1.TrackBack = System.Drawing.Color.AliceBlue;
            this.skinProgressBar1.TrackFore = System.Drawing.Color.LightSkyBlue;
            this.skinProgressBar1.Value = 50;
            // 
            // skinButton1
            // 
            this.skinButton1.BackColor = System.Drawing.Color.Transparent;
            this.skinButton1.BaseColor = System.Drawing.Color.LightGray;
            this.skinButton1.BorderColor = System.Drawing.Color.LightGray;
            this.skinButton1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton1.DownBack = null;
            this.skinButton1.DownBaseColor = System.Drawing.Color.DarkGray;
            this.skinButton1.FadeGlow = false;
            this.skinButton1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinButton1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.skinButton1.IsDrawBorder = false;
            this.skinButton1.IsDrawGlass = false;
            this.skinButton1.Location = new System.Drawing.Point(556, 85);
            this.skinButton1.MouseBack = null;
            this.skinButton1.MouseBaseColor = System.Drawing.Color.Gainsboro;
            this.skinButton1.Name = "skinButton1";
            this.skinButton1.NormlBack = null;
            this.skinButton1.Radius = 10;
            this.skinButton1.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinButton1.Size = new System.Drawing.Size(121, 34);
            this.skinButton1.TabIndex = 1;
            this.skinButton1.Text = "取  消";
            this.skinButton1.UseVisualStyleBackColor = false;
            this.skinButton1.Click += new System.EventHandler(this.skinButton1_Click);
            // 
            // infolabel
            // 
            this.infolabel.AutoSize = true;
            this.infolabel.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.infolabel.Location = new System.Drawing.Point(135, 85);
            this.infolabel.Name = "infolabel";
            this.infolabel.Size = new System.Drawing.Size(219, 31);
            this.infolabel.TabIndex = 2;
            this.infolabel.Text = "正在处理公式1……";
            // 
            // gifBox1
            // 
            this.gifBox1.BorderColor = System.Drawing.Color.Transparent;
            this.gifBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.gifBox1.Image = global::DEMO.Properties.Resources.cpu1;
            this.gifBox1.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.gifBox1.Location = new System.Drawing.Point(28, 62);
            this.gifBox1.Name = "gifBox1";
            this.gifBox1.Size = new System.Drawing.Size(89, 79);
            this.gifBox1.TabIndex = 3;
            this.gifBox1.Text = "gifBox1";
            // 
            // timelabel
            // 
            this.timelabel.AutoSize = true;
            this.timelabel.Location = new System.Drawing.Point(465, 100);
            this.timelabel.Name = "timelabel";
            this.timelabel.Size = new System.Drawing.Size(53, 12);
            this.timelabel.TabIndex = 4;
            this.timelabel.Text = "00:00:00";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.BorderColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(700, 200);
            this.CloseBoxSize = new System.Drawing.Size(0, 0);
            this.Controls.Add(this.timelabel);
            this.Controls.Add(this.gifBox1);
            this.Controls.Add(this.infolabel);
            this.Controls.Add(this.skinButton1);
            this.Controls.Add(this.skinProgressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.InnerBorderColor = System.Drawing.Color.AliceBlue;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmProcess";
            this.Shadow = true;
            this.ShadowColor = System.Drawing.Color.Silver;
            this.ShadowWidth = 15;
            this.ShowBorder = false;
            this.ShowDrawIcon = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.Load += new System.EventHandler(this.FrmProcess_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinProgressBar skinProgressBar1;
        private CCWin.SkinControl.SkinButton skinButton1;
        private System.Windows.Forms.Label infolabel;
        private CCWin.SkinControl.GifBox gifBox1;
        private System.Windows.Forms.Label timelabel;
        private System.Windows.Forms.Timer timer1;
    }
}