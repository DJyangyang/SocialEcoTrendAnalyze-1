using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using System.Data.OleDb;
using System.Configuration;
using System.Threading;

namespace SocialEcoTrendAnalyze
{
    public partial class frmPOP : DevComponents.DotNetBar.OfficeForm
    {
        private string sConn = null;
        private OleDbConnection pConn = null;

        private DataTable dt = null;

        private PointPairList list1 = null, list3 = null, list2 = null, list = null;
        private PointPairList lista = null, listb = null,listc=null;
        public frmPOP()
        {
            InitializeComponent();
            this.dgDataSource.ReadOnly = true;
            this.dgDataSource.AllowUserToAddRows = false;
            //禁用Glass主题
            this.EnableGlass = false;
            //不显示最大化最小化按钮
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            //去除图标
            this.ShowIcon = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
            CreateMutiLineChart();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (pConn.State == ConnectionState.Open)
                pConn.Close();
            if (pConn != null)
                pConn =null;
            
        }
        private void LoadData1()
        {
 
        }
        private void LoadData()
        {
           
            sConn = @"Provider = Microsoft.Jet.OLEDB.4.0;Data Source =" + Application.StartupPath + @"\Data\dqhp.mdb;Jet OLEDB:Database Password=dqhpdata";
            if (pConn == null)
                pConn = new OleDbConnection(sConn);
            if (pConn.State == ConnectionState.Closed)
                pConn.Open();
            OleDbCommand cmd = pConn.CreateCommand();
            cmd.CommandText = "Select id,year,pop,apop,napop,citypop ,gdp From tbTrend";
            OleDbDataAdapter oda = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            oda.Fill(ds, "dtTrend"); 
            if (dt == null)
                dt = new DataTable();
            dt = ds.Tables["dtTrend"];
        }

        private void CreateMutiLineChart()
        {
            dgDataSource.DataSource = dt;

            GraphPane myPane = zedGraphControl1.GraphPane;
        
            myPane.CurveList.Clear();
            myPane.GraphObjList.Clear();
            LineItem myCurve1 = null, myCurve2 = null, myCurve3 = null, myCurve = null, myCurvea = null, myCurveb = null,myCurvec=null;

            #region 城市人口
            GraphPane myPane1 = zedGraphControl2.GraphPane;
            myPane1.CurveList.Clear();
            myPane1.GraphObjList.Clear();
            myPane1.Title.Text = "城市人口";
            myPane1.XAxis.Title.Text = "年份";
            myPane1.YAxis.Title.Text = "人口  万人";
            lista = new PointPairList();
            listb = new PointPairList();
            myCurvea = myPane1.AddCurve("citypop",
               lista, Color.Red, SymbolType.Diamond);
            myPane1.Title.FontSpec.FontColor = Color.Green;

            // Add gridlines to the plot, and make them gray
            myPane1.XAxis.MajorGrid.IsVisible = true;
            myPane1.YAxis.MajorGrid.IsVisible = true;
            myPane1.XAxis.MajorGrid.Color = Color.LightGray;
            myPane1.YAxis.MajorGrid.Color = Color.LightGray;

            // Move the legend location
            myPane1.Legend.Position = ZedGraph.LegendPos.Bottom;
            myCurvea.Line.Width = 1.0F;

            // Increase the symbol sizes, and fill them with solid white
            myCurvea.Symbol.Size = 2.0F;
            myCurvea.Symbol.Fill = new Fill(Color.White);

            // Add a background gradient fill to the axis frame
            myPane1.Chart.Fill = new Fill(Color.White,
                Color.FromArgb(255, 255, 210), -45F);

            // Add a caption and an arrow
            TextObj myText1 = new TextObj("Interesting\nPoint", 230F, 70F);
            myText1.FontSpec.FontColor = Color.Red;
            myText1.Location.AlignH = AlignH.Center;
            myText1.Location.AlignV = AlignV.Top;
            myPane1.GraphObjList.Add(myText1);
            ArrowObj myArrow1 = new ArrowObj(Color.Red, 12F, 230F, 70F, 280F, 55F);
            myPane1.GraphObjList.Add(myArrow1);

            myPane1.AxisChange();
            zedGraphControl2.Refresh();

            #endregion
            #region 总人口
            GraphPane myPane2 = zedGraphControl3.GraphPane;
            myPane2.CurveList.Clear();
            myPane2.GraphObjList.Clear();
            myPane2.Title.Text = "总人口";
            myPane2.XAxis.Title.Text = "年份";
            myPane2.YAxis.Title.Text = "人口  万人";

            listb = new PointPairList();
            myCurveb = myPane2.AddCurve("pop",
               listb, Color.Blue, SymbolType.Diamond);
            myPane2.Title.FontSpec.FontColor = Color.Green;

            // Add gridlines to the plot, and make them gray
            myPane2.XAxis.MajorGrid.IsVisible = true;
            myPane2.YAxis.MajorGrid.IsVisible = true;
            myPane2.XAxis.MajorGrid.Color = Color.LightGray;
            myPane2.YAxis.MajorGrid.Color = Color.LightGray;

            // Move the legend location
            myPane2.Legend.Position = ZedGraph.LegendPos.Bottom;
            myCurveb.Line.Width = 1.0F;

            // Increase the symbol sizes, and fill them with solid white
            myCurveb.Symbol.Size = 2.0F;
            myCurveb.Symbol.Fill = new Fill(Color.White);

            // Add a background gradient fill to the axis frame
            myPane2.Chart.Fill = new Fill(Color.White,
                Color.FromArgb(255, 255, 210), -45F);

            // Add a caption and an arrow
            TextObj myText2 = new TextObj("Interesting\nPoint", 230F, 70F);
            myText2.FontSpec.FontColor = Color.Red;
            myText2.Location.AlignH = AlignH.Center;
            myText2.Location.AlignV = AlignV.Top;
            myPane2.GraphObjList.Add(myText2);
            ArrowObj myArrow2 = new ArrowObj(Color.Red, 12F, 230F, 70F, 280F, 55F);
            myPane2.GraphObjList.Add(myArrow2);

            myPane2.AxisChange();
            zedGraphControl3.Refresh();

            #endregion
            #region  总GDP
            GraphPane myPane3 = zedGraphControl4.GraphPane;
            myPane3.CurveList.Clear();
            myPane3.GraphObjList.Clear();
            myPane3.Title.Text = "总GDP";
            myPane3.XAxis.Title.Text = "年份";
            myPane3.YAxis.Title.Text = "人民币 万元  ";

            listc = new PointPairList();
            myCurvec = myPane3.AddCurve("gdp",
               listc, Color.Green, SymbolType.Diamond);
            myPane3.Title.FontSpec.FontColor = Color.Green;

            // Add gridlines to the plot, and make them gray
            myPane3.XAxis.MajorGrid.IsVisible = true;
            myPane3.YAxis.MajorGrid.IsVisible = true;
            myPane3.XAxis.MajorGrid.Color = Color.LightGray;
            myPane3.YAxis.MajorGrid.Color = Color.LightGray;

            // Move the legend location
            myPane3.Legend.Position = ZedGraph.LegendPos.Bottom;
            myCurvec.Line.Width = 1.0F;

            // Increase the symbol sizes, and fill them with solid white
            myCurvec.Symbol.Size = 2.0F;
            myCurvec.Symbol.Fill = new Fill(Color.White);

            // Add a background gradient fill to the axis frame
            myPane3.Chart.Fill = new Fill(Color.White,
                Color.FromArgb(255, 255, 210), -45F);

            // Add a caption and an arrow
            TextObj myText3 = new TextObj("Interesting\nPoint", 230F, 70F);
            myText3.FontSpec.FontColor = Color.Red;
            myText3.Location.AlignH = AlignH.Center;
            myText3.Location.AlignV = AlignV.Top;
            myPane3.GraphObjList.Add(myText3);
            ArrowObj myArrow3 = new ArrowObj(Color.Red, 12F, 230F, 70F, 280F, 55F);
            myPane3.GraphObjList.Add(myArrow3);

            myPane3.AxisChange();
            zedGraphControl4.Refresh();

            #endregion
            // Set up the title and axis labels
            myPane.Title.Text = "人口增长趋势";
			myPane.XAxis.Title.Text = "年份";
			myPane.YAxis.Title.Text = "人口  万人";

            //PointPairList list1 = null, list3 = null, list2 = null, list = null;
			// Make up some data arrays based on the Sine function
			list1 = new PointPairList();
            list3 = new PointPairList();
            list2 = new PointPairList();
            list = new PointPairList();

           

         
            // Generate a red curve with diamond
            // symbols, and "apop" in the legend
            myCurve1 = myPane.AddCurve("apop",
                list1, Color.Red, SymbolType.Diamond);

            // Generate a blue curve with circle
            // symbols, and "napop" in the legend
            myCurve2 = myPane.AddCurve("napop",
                list2, Color.Blue, SymbolType.Circle);

            // Generate a blue curve with circle
            // symbols, and "citypop" in the legend
            myCurve3 = myPane.AddCurve("citypop",
                list3, Color.Green, SymbolType.Star);

            // Generate a blue curve with circle
            // symbols, and "pop" in the legend
            myCurve = myPane.AddCurve("pop",
                list, Color.Orange, SymbolType.Square);


            // Change the color of the title
            myPane.Title.FontSpec.FontColor = Color.Green;

            // Add gridlines to the plot, and make them gray
            myPane.XAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.MajorGrid.IsVisible = true;
            myPane.XAxis.MajorGrid.Color = Color.LightGray;
            myPane.YAxis.MajorGrid.Color = Color.LightGray;

            // Move the legend location
            myPane.Legend.Position = ZedGraph.LegendPos.Bottom;

            // Make both curves thicker
            myCurve1.Line.Width = 1.0F;
            myCurve2.Line.Width = 1.0F;
            myCurve3.Line.Width = 1.0F;
            myCurve.Line.Width = 1.0F;

            // Increase the symbol sizes, and fill them with solid white
            myCurve1.Symbol.Size = 2.0F;
            myCurve2.Symbol.Size = 2.0F;
            myCurve3.Symbol.Size = 2.0F;
            myCurve.Symbol.Size = 2.0F;

            myCurve1.Symbol.Fill = new Fill(Color.White);
            myCurve2.Symbol.Fill = new Fill(Color.White);
            myCurve3.Symbol.Fill = new Fill(Color.White);
            myCurve.Symbol.Fill = new Fill(Color.White);

            // Add a background gradient fill to the axis frame
            myPane.Chart.Fill = new Fill(Color.White,
                Color.FromArgb(255, 255, 210), -45F);

            // Add a caption and an arrow
            TextObj myText = new TextObj("Interesting\nPoint", 230F, 70F);
            myText.FontSpec.FontColor = Color.Red;
            myText.Location.AlignH = AlignH.Center;
            myText.Location.AlignV = AlignV.Top;
            myPane.GraphObjList.Add(myText);
            ArrowObj myArrow = new ArrowObj(Color.Red, 12F, 230F, 70F, 280F, 55F);
            myPane.GraphObjList.Add(myArrow);

            myPane.AxisChange();
            zedGraphControl1.Refresh();
        }

        private void CreateMasterPane()
        {
            dgDataSource.DataSource = dt;
            int iRow = dt.Rows.Count;
            MasterPane myMaster = zedGraphControl1.MasterPane;

            // Remove the default GraphPane that comes with ZedGraphControl
            myMaster.PaneList.Clear();

            // Set the masterpane title
            myMaster.Title.Text = "pop 趋势模拟";
            myMaster.Title.IsVisible = true;

            // Fill the masterpane background with a color gradient
            myMaster.Fill = new Fill(Color.White, Color.MediumSlateBlue, 45.0F);

            // Set the margins to 10 points
            myMaster.Margin.All = 10;

            // Enable the masterpane legend
            myMaster.Legend.IsVisible = true;
            myMaster.Legend.Position = LegendPos.TopCenter;


            // Initialize a color and symbol type rotator
            ColorSymbolRotator rotator = new ColorSymbolRotator();

            // Create some new GraphPanes

            //apop - pop 1

            // Create a new graph - rect dimensions do not matter here, since it
            // will be resized by MasterPane.AutoPaneLayout()
            //GraphPane myPane = new GraphPane(new Rectangle(10, 10, 10, 10),
            GraphPane myPane = new GraphPane(new Rectangle(10, 10, 10, 10),
                "黑龙江GDP",
                "年份",
                "GDP,亿元");

            // Fill the GraphPane background with a color gradient
            myPane.Fill = new Fill(Color.White, Color.LightYellow, 45.0F);
            myPane.BaseDimension = 6.0F;

            // Make up some data arrays based on the Sine function
            PointPairList list = new PointPairList();
            for (int i = 0; i < iRow - 1; i++)
            {
                double x = double.Parse(dt.Rows[i]["year"].ToString());
                double y = double.Parse(dt.Rows[i]["gdp1"].ToString());
                list.Add(x, y);
            }

            // Add a curve to the Graph, use the next sequential color and symbol
            LineItem myCurve = myPane.AddCurve("Type 1",
                list, rotator.NextColor, rotator.NextSymbol);
            // Fill the symbols with white to make them opaque
            myCurve.Symbol.Fill = new Fill(Color.White);

            // Add the GraphPane to the MasterPane
            myMaster.Add(myPane);
            using (Graphics g = this.zedGraphControl1.CreateGraphics())
            {
                // Tell ZedGraph to auto layout the new GraphPanes
                myMaster.SetLayout(g, PaneLayout.SquareColPreferred);
                myMaster.AxisChange(g);
                //g.Dispose();
            }
        }
        //加载历史数据
        private void LoadHistoryData()
        {
            //加载数据库的原始数据
            while (list.Count > 1)
            {
                list.RemoveAt(1);
                list1.RemoveAt(1);
                list2.RemoveAt(1);
                list3.RemoveAt(1);
                lista.RemoveAt(1);
                listb.RemoveAt(1);
                listc.RemoveAt(1);
            }
            //修改数据源dt中的值
            //id	year	gdp1	gdp2	gdp3	apop	napop	citypop	gdp	pop

            for (int i = 1; i < 17; i++)
            {
                Thread.Sleep(100);
                double x = double.Parse(dt.Rows[i]["year"].ToString().Trim());
                double y1 = double.Parse(dt.Rows[i]["apop"].ToString().Trim());
                double y3 = double.Parse(dt.Rows[i]["napop"].ToString().Trim());
                double y2 = double.Parse(dt.Rows[i]["citypop"].ToString().Trim());
                double y = double.Parse(dt.Rows[i]["pop"].ToString().Trim());
                double y5 = double.Parse(dt.Rows[i]["gdp"].ToString().Trim());
                list.Add(x, y);
                list1.Add(x, y1);
               list2.Add(x, y2);
                list3.Add(x, y3);
                lista.Add(x, y2);
                listb.Add(x,y);
                listc.Add(x,y5);
                zedGraphControl1.GraphPane.XAxis.Scale.MaxAuto = true;
                this.zedGraphControl1.AxisChange();
                this.zedGraphControl1.Refresh();

                zedGraphControl2.GraphPane.XAxis.Scale.MaxAuto = true;
                this.zedGraphControl2.AxisChange();
                this.zedGraphControl2.Refresh();

                zedGraphControl3.GraphPane.XAxis.Scale.MaxAuto = true;
                this.zedGraphControl3.AxisChange();
                this.zedGraphControl3.Refresh();

                zedGraphControl4.GraphPane.XAxis.Scale.MaxAuto = true;
                this.zedGraphControl4.AxisChange();
                this.zedGraphControl4.Refresh();

            }
            #region
            //for (int i = 1; i < 17; i++)
            //{
            //    Thread.Sleep(100);
            //    double x = double.Parse(dt.Rows[i]["year"].ToString().Trim());
            //    double y1 = double.Parse(dt.Rows[i]["apop"].ToString().Trim());
            //    double y3 = double.Parse(dt.Rows[i]["napop"].ToString().Trim());
            //    double y2 = double.Parse(dt.Rows[i]["citypop"].ToString().Trim());
            //    double y = double.Parse(dt.Rows[i]["pop"].ToString().Trim());
            //    list.Add(x, y);
            //    list1.Add(x, y1);
            //    list2.Add(x, y2);
            //    list3.Add(x, y3);
            //    zedGraphControl2.GraphPane.XAxis.Scale.MaxAuto = true;

            //    this.zedGraphControl2.AxisChange();
            //    this.zedGraphControl2.Refresh();
            //}
            #endregion
        }
        //加载模拟数据
        private void LoadSimulationData()
        {
            //加载数据库的原始数据
            //id=1-17	year=1996-2012
            int iRowCount = dt.Rows.Count - 1;
            if (iRowCount > 17)
            {
                for (int i = iRowCount; i >= 17; i--)
                {
                    dt.Rows.RemoveAt(i);
                    list.RemoveAt(i);
                    list1.RemoveAt(i);
                    list2.RemoveAt(i);
                    list3.RemoveAt(i);
                    lista.RemoveAt(i);
                    listb.RemoveAt(i);
                    listc.RemoveAt(i);
                }
            }
            //修改数据源dt中的值
            //id	year	gdp1	gdp2	gdp3	apop	napop	citypop	gdp	pop
            double rate = 0;
            try
            {
                rate = double.Parse(txtIncreaseRate.Text.Trim()) / 1000;
            }
            catch
            {
                MessageBox.Show("人口增长率必须是数值！");
                return;
            }

            //拐点年份
            Int32 iInflexionYear = (Int32)txtInflexionYear.Value;
            //模拟结束年份
            Int32 iEndYear = (Int32)txtEndYear.Value;
            double dRateTemp = rate / (iInflexionYear - 2012);
            double dRate = rate;

            for (int i = 0; i < iEndYear - 2012 + 1; i++)
            {
                Thread.Sleep(200);
                //产生模拟数据
                dRate = dRate - dRateTemp;
                int iRowMaxIndex = dt.Rows.Count - 1;
                DataRow dr = dt.NewRow();
                dr["id"] = int.Parse(dt.Rows[iRowMaxIndex]["id"].ToString().Trim()) + 1;
                dr["year"] = int.Parse(dt.Rows[iRowMaxIndex]["year"].ToString().Trim()) + 1;
                dr["apop"] = double.Parse(dt.Rows[iRowMaxIndex]["apop"].ToString().Trim()) * (1 + dRate);
                dr["citypop"] = double.Parse(dt.Rows[iRowMaxIndex]["citypop"].ToString().Trim()) * (1 + dRate);
                dr["napop"] = double.Parse(dt.Rows[iRowMaxIndex]["napop"].ToString().Trim()) * (1 + dRate);
                dr["pop"] = double.Parse(dt.Rows[iRowMaxIndex]["pop"].ToString().Trim()) * (1 + dRate);
                dr["gdp"] = double.Parse(dt.Rows[iRowMaxIndex]["gdp"].ToString().Trim()) * (1 + dRate);
                dt.Rows.Add(dr);

                //创建曲线图

                double x = double.Parse(dt.Rows[iRowMaxIndex]["year"].ToString().Trim());
                double y1 = double.Parse(dt.Rows[iRowMaxIndex]["apop"].ToString().Trim());
                double y3 = double.Parse(dt.Rows[iRowMaxIndex]["citypop"].ToString().Trim());
                double y2 = double.Parse(dt.Rows[iRowMaxIndex]["napop"].ToString().Trim());
                double y = double.Parse(dt.Rows[iRowMaxIndex]["pop"].ToString().Trim());
                double y5 = double.Parse(dt.Rows[iRowMaxIndex]["gdp"].ToString().Trim());

                list.Add(x, y);
                list1.Add(x, y1);
                list2.Add(x, y2);
                list3.Add(x, y3);
                lista.Add(x, y3);
                listb.Add(x,y);
                listc.Add(x, y5);
                zedGraphControl1.GraphPane.XAxis.Scale.MaxAuto = true;
                this.zedGraphControl1.AxisChange();
                this.zedGraphControl1.Refresh();

                zedGraphControl2.GraphPane.XAxis.Scale.MaxAuto = true;
                this.zedGraphControl2.AxisChange();
                this.zedGraphControl2.Refresh();

                zedGraphControl3.GraphPane.XAxis.Scale.MaxAuto = true;
                this.zedGraphControl3.AxisChange();
                this.zedGraphControl3.Refresh();

                zedGraphControl4.GraphPane.XAxis.Scale.MaxAuto = true;
                this.zedGraphControl4.AxisChange();
                this.zedGraphControl4.Refresh();

                this.dgDataSource.DataSource = dt;
                this.dgDataSource.Refresh();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            LoadHistoryData();
            btnSimulate.Enabled = true;
        }

        private void btnSimulate_Click(object sender, EventArgs e)
        {
            LoadSimulationData();
            btnStart.Enabled = false;           //把开始按钮false掉，以免再点开始出现BUG。
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnStart_MouseEnter(object sender, EventArgs e)
        {
            ToolTip p = new ToolTip();
            p.ShowAlways = true;
            p.SetToolTip(this.btnStart,"请先设置2010年的人口增长率,人口增长出现拐点的年份,人口模拟结束的年份,然后点击"+"模拟按钮，开始人口模拟。");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}