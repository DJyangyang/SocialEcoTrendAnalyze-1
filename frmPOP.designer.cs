namespace SocialEcoTrendAnalyze
{
    partial class frmPOP
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPOP));
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgDataSource = new System.Windows.Forms.DataGridView();
            this.btnSimulate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEndYear = new System.Windows.Forms.NumericUpDown();
            this.txtInflexionYear = new System.Windows.Forms.NumericUpDown();
            this.txtIncreaseRate = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.zedGraphControl2 = new ZedGraph.ZedGraphControl();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.zedGraphControl3 = new ZedGraph.ZedGraphControl();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.zedGraphControl4 = new ZedGraph.ZedGraphControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDataSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInflexionYear)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.BackColor = System.Drawing.Color.White;
            this.zedGraphControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControl1.Location = new System.Drawing.Point(3, 3);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(685, 533);
            this.zedGraphControl1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 17);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(699, 565);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.zedGraphControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(691, 539);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "模拟图";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgDataSource);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(691, 539);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "数据";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgDataSource
            // 
            this.dgDataSource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDataSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgDataSource.Location = new System.Drawing.Point(3, 3);
            this.dgDataSource.Name = "dgDataSource";
            this.dgDataSource.RowTemplate.Height = 23;
            this.dgDataSource.Size = new System.Drawing.Size(685, 533);
            this.dgDataSource.TabIndex = 0;
            // 
            // btnSimulate
            // 
            this.btnSimulate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSimulate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSimulate.Font = new System.Drawing.Font("宋体", 9F);
            this.btnSimulate.Image = ((System.Drawing.Image)(resources.GetObject("btnSimulate.Image")));
            this.btnSimulate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSimulate.Location = new System.Drawing.Point(97, 97);
            this.btnSimulate.Name = "btnSimulate";
            this.btnSimulate.Size = new System.Drawing.Size(57, 21);
            this.btnSimulate.TabIndex = 8;
            this.btnSimulate.Text = "模拟";
            this.btnSimulate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSimulate.UseVisualStyleBackColor = false;
            this.btnSimulate.Click += new System.EventHandler(this.btnSimulate_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(111, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "‰";
            // 
            // txtEndYear
            // 
            this.txtEndYear.Location = new System.Drawing.Point(273, 44);
            this.txtEndYear.Maximum = new decimal(new int[] {
            2040,
            0,
            0,
            0});
            this.txtEndYear.Minimum = new decimal(new int[] {
            2010,
            0,
            0,
            0});
            this.txtEndYear.Name = "txtEndYear";
            this.txtEndYear.Size = new System.Drawing.Size(96, 21);
            this.txtEndYear.TabIndex = 5;
            this.txtEndYear.Value = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            // 
            // txtInflexionYear
            // 
            this.txtInflexionYear.Location = new System.Drawing.Point(135, 42);
            this.txtInflexionYear.Maximum = new decimal(new int[] {
            2040,
            0,
            0,
            0});
            this.txtInflexionYear.Minimum = new decimal(new int[] {
            2010,
            0,
            0,
            0});
            this.txtInflexionYear.Name = "txtInflexionYear";
            this.txtInflexionYear.Size = new System.Drawing.Size(96, 21);
            this.txtInflexionYear.TabIndex = 5;
            this.txtInflexionYear.Value = new decimal(new int[] {
            2030,
            0,
            0,
            0});
            // 
            // txtIncreaseRate
            // 
            this.txtIncreaseRate.BackColor = System.Drawing.Color.White;
            this.txtIncreaseRate.Location = new System.Drawing.Point(9, 41);
            this.txtIncreaseRate.Name = "txtIncreaseRate";
            this.txtIncreaseRate.Size = new System.Drawing.Size(96, 21);
            this.txtIncreaseRate.TabIndex = 4;
            this.txtIncreaseRate.Text = "2.07";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStart.Font = new System.Drawing.Font("宋体", 9F);
            this.btnStart.Image = ((System.Drawing.Image)(resources.GetObject("btnStart.Image")));
            this.btnStart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStart.Location = new System.Drawing.Point(15, 97);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(57, 21);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "开始";
            this.btnStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            this.btnStart.MouseEnter += new System.EventHandler(this.btnStart_MouseEnter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(271, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "人口模拟结束年份：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(130, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "人口增长拐点年份：";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "2010人口增长率：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tabControl1);
            this.groupBox2.Location = new System.Drawing.Point(12, 68);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(705, 585);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "整体走势";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.zedGraphControl2);
            this.groupBox3.Location = new System.Drawing.Point(723, 440);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(480, 216);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "城市人口";
            // 
            // zedGraphControl2
            // 
            this.zedGraphControl2.BackColor = System.Drawing.Color.White;
            this.zedGraphControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControl2.Location = new System.Drawing.Point(3, 17);
            this.zedGraphControl2.Name = "zedGraphControl2";
            this.zedGraphControl2.ScrollGrace = 0D;
            this.zedGraphControl2.ScrollMaxX = 0D;
            this.zedGraphControl2.ScrollMaxY = 0D;
            this.zedGraphControl2.ScrollMaxY2 = 0D;
            this.zedGraphControl2.ScrollMinX = 0D;
            this.zedGraphControl2.ScrollMinY = 0D;
            this.zedGraphControl2.ScrollMinY2 = 0D;
            this.zedGraphControl2.Size = new System.Drawing.Size(474, 196);
            this.zedGraphControl2.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.zedGraphControl3);
            this.groupBox4.Location = new System.Drawing.Point(726, 222);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(472, 216);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "总人口";
            // 
            // zedGraphControl3
            // 
            this.zedGraphControl3.BackColor = System.Drawing.Color.White;
            this.zedGraphControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControl3.Location = new System.Drawing.Point(3, 17);
            this.zedGraphControl3.Name = "zedGraphControl3";
            this.zedGraphControl3.ScrollGrace = 0D;
            this.zedGraphControl3.ScrollMaxX = 0D;
            this.zedGraphControl3.ScrollMaxY = 0D;
            this.zedGraphControl3.ScrollMaxY2 = 0D;
            this.zedGraphControl3.ScrollMinX = 0D;
            this.zedGraphControl3.ScrollMinY = 0D;
            this.zedGraphControl3.ScrollMinY2 = 0D;
            this.zedGraphControl3.Size = new System.Drawing.Size(466, 196);
            this.zedGraphControl3.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.zedGraphControl4);
            this.groupBox6.Location = new System.Drawing.Point(729, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(465, 216);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "GDP总量";
            // 
            // zedGraphControl4
            // 
            this.zedGraphControl4.BackColor = System.Drawing.Color.White;
            this.zedGraphControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControl4.Location = new System.Drawing.Point(3, 17);
            this.zedGraphControl4.Name = "zedGraphControl4";
            this.zedGraphControl4.ScrollGrace = 0D;
            this.zedGraphControl4.ScrollMaxX = 0D;
            this.zedGraphControl4.ScrollMaxY = 0D;
            this.zedGraphControl4.ScrollMaxY2 = 0D;
            this.zedGraphControl4.ScrollMinX = 0D;
            this.zedGraphControl4.ScrollMinY = 0D;
            this.zedGraphControl4.ScrollMinY2 = 0D;
            this.zedGraphControl4.Size = new System.Drawing.Size(459, 196);
            this.zedGraphControl4.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("splitContainer1.Panel1.BackgroundImage")));
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.btnSimulate);
            this.splitContainer1.Panel1.Controls.Add(this.btnStart);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.txtEndYear);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox6);
            this.splitContainer1.Panel2.Controls.Add(this.txtInflexionYear);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.txtIncreaseRate);
            this.splitContainer1.Size = new System.Drawing.Size(1206, 785);
            this.splitContainer1.SplitterDistance = 125;
            this.splitContainer1.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("宋体", 9F);
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(189, 97);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(57, 21);
            this.button1.TabIndex = 9;
            this.button1.Text = "关闭";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmPOP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1206, 785);
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.Name = "frmPOP";
            this.Text = "人口增长趋势";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgDataSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInflexionYear)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgDataSource;
        private System.Windows.Forms.TextBox txtIncreaseRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown txtInflexionYear;
        private System.Windows.Forms.NumericUpDown txtEndYear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSimulate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox groupBox3;
        private ZedGraph.ZedGraphControl zedGraphControl2;
        private System.Windows.Forms.GroupBox groupBox4;
        private ZedGraph.ZedGraphControl zedGraphControl3;
        private System.Windows.Forms.GroupBox groupBox6;
        private ZedGraph.ZedGraphControl zedGraphControl4;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button1;
    }
}

