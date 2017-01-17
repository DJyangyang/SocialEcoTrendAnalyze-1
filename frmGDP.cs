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
    public partial class frmGDP : DevComponents.DotNetBar.OfficeForm
    {
        private string sConn = null;
        private OleDbConnection pConn = null;
        private DataTable dt = null;

        private PointPairList list1 = null, list3 = null, list2 = null, list = null;
        private PointPairList lista = null, listb = null, listc = null;
        public frmGDP()
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

            btnSimulate.Enabled = false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (pConn.State == ConnectionState.Open)
                pConn.Close();
            if (pConn != null)
                pConn =null;
            
        }

        private void LoadData()
        {
            //sConn = ConfigurationSettings.AppSettings["Provider"];
            //sConn += Application.StartupPath;
            //sConn += ConfigurationSettings.AppSettings["DataSource"];
            //sConn += ConfigurationSettings.AppSettings["Pwd"];
            sConn = @"Provider = Microsoft.Jet.OLEDB.4.0;Data Source =" + Application.StartupPath + @"\Data\dqhp.mdb;Jet OLEDB:Database Password=dqhpdata";
            if (pConn == null)
                pConn = new OleDbConnection(sConn);
            if (pConn.State == ConnectionState.Closed)
                pConn.Open();
            OleDbCommand cmd = pConn.CreateCommand();
            cmd.CommandText = "Select id,年份,生产总值,财政总收入,人均生产总值,第一产业,第二产业,第三产业 From YNTable";
            OleDbDataAdapter oda = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            oda.Fill(ds, "YNTable");
            if (dt == null)
                dt = new DataTable();
            dt = ds.Tables["YNTable"];
        }
        private void CreateMutiLineChart()
        {
            dgDataSource.DataSource = dt;

            int iRow = dt.Rows.Count;

            GraphPane myPane = zedGraphControl1.GraphPane;
           
            myPane.CurveList.Clear();
            myPane.GraphObjList.Clear();
			// Set up the title and axis labels
            myPane.Title.Text = "GDP 趋势模拟";
			myPane.XAxis.Title.Text = "年份";
			myPane.YAxis.Title.Text = "GDP 亿元";

            //PointPairList list1 = null, list3 = null, list2 = null, list = null;
			// Make up some data arrays based on the Sine function
			list1 = new PointPairList();
			list3 = new PointPairList();
            list2 = new PointPairList();
            list = new PointPairList();
			
            //double x = double.Parse(dt.Rows[0]["year"].ToString().Trim());
            //double y1 = double.Parse(dt.Rows[0]["gdp1"].ToString().Trim());
            //double y3 = double.Parse(dt.Rows[0]["gdp3"].ToString().Trim());
            //double y2 = double.Parse(dt.Rows[0]["gdp2"].ToString().Trim());
            //double y = double.Parse(dt.Rows[0]["gdp"].ToString().Trim());
            //list.Add(x, y);
            //list1.Add( x, y1);
            //list2.Add( x, y2 );
            //list3.Add(x, y3);

            LineItem myCurve1=null, myCurve2=null, myCurve3=null, myCurve=null, myCurvea = null, myCurveb = null;


            #region 财政总收入
            GraphPane myPane1 = zedGraphControl2.GraphPane;
            myPane1.CurveList.Clear();
            myPane1.GraphObjList.Clear();
            myPane1.Title.Text = "财政总收入";
            myPane1.XAxis.Title.Text = "年份";
            myPane1.YAxis.Title.Text = "金额  万元";
            lista = new PointPairList();
            listb = new PointPairList();
            myCurvea = myPane1.AddCurve("财政总收入",
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
            #region 城镇化率
            GraphPane myPane2 = zedGraphControl3.GraphPane;
            myPane2.CurveList.Clear();
            myPane2.GraphObjList.Clear();
            myPane2.Title.Text = "人均生产总值";
            myPane2.XAxis.Title.Text = "年份";
            myPane2.YAxis.Title.Text = "金额  元/人";

            listb = new PointPairList();
            myCurveb = myPane2.AddCurve("人均生产总值",
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

            // Generate a red curve with diamond
            // symbols, and "GDP1" in the legend
            myCurve1 = myPane.AddCurve("第一产业",
                list1, Color.Red, SymbolType.Diamond);

            // Generate a blue curve with circle
            // symbols, and "GDP2" in the legend
            myCurve2 = myPane.AddCurve("第二产业",
                list2, Color.Blue, SymbolType.Circle);

            // Generate a blue curve with circle
            // symbols, and "GDP3" in the legend
            myCurve3 = myPane.AddCurve("第三产业",
                list3, Color.Green, SymbolType.Star);

            // Generate a blue curve with circle
            // symbols, and "GDP" in the legend
            myCurve = myPane.AddCurve("生产总值",
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

            // Fill the area under the curves

            //myCurve1.Line.Fill = new Fill(Color.White, Color.Red, 45F );
            //myCurve2.Line.Fill = new Fill( Color.White, Color.Blue, 45F );
            //myCurve3.Line.Fill = new Fill(Color.White, Color.Green, 45F);

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

        private void loadHistoryData()
        {
            //加载数据库的原始数据
            while (list.Count > 1)
            {
                list.RemoveAt(1);
                list1.RemoveAt(1);
                list2.RemoveAt(1);
                list3.RemoveAt(1);
            }
            

            for (int i = 0; i < 6; i++)
            {
                Thread.Sleep(100);
               
                //创建曲线图

                double x = double.Parse(dt.Rows[i]["年份"].ToString().Trim());
                double y1 = double.Parse(dt.Rows[i]["第一产业"].ToString().Trim());
                double y3 = double.Parse(dt.Rows[i]["第二产业"].ToString().Trim());
                double y2 = double.Parse(dt.Rows[i]["第三产业"].ToString().Trim());
                double y = double.Parse(dt.Rows[i]["生产总值"].ToString().Trim());
                double y4 = double.Parse(dt.Rows[i]["财政总收入"].ToString().Trim());
                double y5 = double.Parse(dt.Rows[i]["人均生产总值"].ToString().Trim());
                list.Add(x, y);
                list1.Add(x, y1);
                list2.Add(x, y2);
                list3.Add(x, y3);
                lista.Add(x, y4);
                listb.Add(x, y5);
                zedGraphControl1.GraphPane.XAxis.Scale.MaxAuto = true;

                this.zedGraphControl1.AxisChange();
                this.zedGraphControl1.Refresh();

                zedGraphControl2.GraphPane.XAxis.Scale.MaxAuto = true;

                this.zedGraphControl2.AxisChange();
                this.zedGraphControl2.Refresh();

                zedGraphControl3.GraphPane.XAxis.Scale.MaxAuto = true;

                this.zedGraphControl3.AxisChange();
                this.zedGraphControl3.Refresh();
            }
        }

        private void loadSimulationData()
        {
            //加载数据库的原始数据
            //id=1-17	year=1996-2012
            int iRowCount = dt.Rows.Count - 1;
            if (iRowCount > 6)
            {
                for (int i = iRowCount; i >= 6; i--)
                {
                    dt.Rows.RemoveAt(i);
                    list.RemoveAt(i);
                    list1.RemoveAt(i);
                    list2.RemoveAt(i);
                    list3.RemoveAt(i);
                }
            }
            //修改数据源dt中的值
            //id	year	gdp1	gdp2	gdp3	pop1	pop2	pop3	gdp	pop
            double dRate = 9.5 / 100;
            //try
            //{
            //    dRate =;
            //}
            //catch
            //{
            //    MessageBox.Show("增长率必须是数值！");
            //    return;
            //}

            //模拟结束年份
            Int32 iEndYear = 2020;

            for (int i = 0; i < iEndYear - 2012 + 1; i++)
            {
                Thread.Sleep(200);
                //产生模拟数据
                int iRowMaxIndex = dt.Rows.Count - 1;
                DataRow dr = dt.NewRow();
                dr["id"] = int.Parse(dt.Rows[iRowMaxIndex]["id"].ToString().Trim()) + 1;
                dr["年份"] = int.Parse(dt.Rows[iRowMaxIndex]["年份"].ToString().Trim()) + 1;
                dr["第一产业"] = double.Parse(dt.Rows[iRowMaxIndex]["第一产业"].ToString().Trim()) * (1 + dRate);
                dr["第二产业"] = double.Parse(dt.Rows[iRowMaxIndex]["第二产业"].ToString().Trim()) * (1 + dRate);
                dr["第三产业"] = double.Parse(dt.Rows[iRowMaxIndex]["第三产业"].ToString().Trim()) * (1 + dRate);
                dr["生产总值"] = double.Parse(dt.Rows[iRowMaxIndex]["生产总值"].ToString().Trim()) * (1 + dRate);
                dr["财政总收入"] = double.Parse(dt.Rows[iRowMaxIndex]["财政总收入"].ToString().Trim()) * (1 + dRate);
                dr["人均生产总值"] = double.Parse(dt.Rows[iRowMaxIndex]["人均生产总值"].ToString().Trim()) * (1 + dRate);
                dt.Rows.Add(dr);
                //创建曲线图

                double x = double.Parse(dt.Rows[iRowMaxIndex]["年份"].ToString().Trim());
                double y1 = double.Parse(dt.Rows[iRowMaxIndex]["第一产业"].ToString().Trim());
                double y3 = double.Parse(dt.Rows[iRowMaxIndex]["第二产业"].ToString().Trim());
                double y2 = double.Parse(dt.Rows[iRowMaxIndex]["第三产业"].ToString().Trim());
                double y = double.Parse(dt.Rows[iRowMaxIndex]["生产总值"].ToString().Trim());
                double y4 = double.Parse(dt.Rows[iRowMaxIndex]["财政总收入"].ToString().Trim());
                double y5 = double.Parse(dt.Rows[iRowMaxIndex]["人均生产总值"].ToString().Trim());
                list.Add(x, y);
                list1.Add(x, y1);
                list2.Add(x, y2);
                list3.Add(x, y3);
                lista.Add(x, y4);
                listb.Add(x,y5);
                zedGraphControl1.GraphPane.XAxis.Scale.MaxAuto = true;

                this.zedGraphControl1.AxisChange();
                this.zedGraphControl1.Refresh();

                zedGraphControl2.GraphPane.XAxis.Scale.MaxAuto = true;
                this.zedGraphControl2.AxisChange();
                this.zedGraphControl2.Refresh();

                zedGraphControl3.GraphPane.XAxis.Scale.MaxAuto = true;
                this.zedGraphControl3.AxisChange();
                this.zedGraphControl3.Refresh();

                this.dgDataSource.DataSource = dt;
                this.dgDataSource.Refresh();
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            loadHistoryData();
            btnSimulate.Enabled = true;
        }

        private void btnSimulate_Click(object sender, EventArgs e)
        {
            loadSimulationData();
            btnStart.Enabled = false;           //把开始按钮false掉，以免再点开始出现BUG。
            btnSimulate.Enabled = false;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}