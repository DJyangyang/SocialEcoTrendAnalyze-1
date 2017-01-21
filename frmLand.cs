using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ZedGraph;

namespace SocialEcoTrendAnalyze
{
    public partial class frmLand : DevComponents.DotNetBar.OfficeForm
    {
        private string sConn = null;
        private OleDbConnection pConn = null;
        //  int time = 0;//时间累加器
        private DataTable dt = null;

        private PointPairList list1 = null, list3 = null, list2 = null, list = null;
        private PointPairList lista = null, listb = null, listc = null;
        public frmLand()
        {
            InitializeComponent();
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

        private void frmLand_Load(object sender, EventArgs e)
        {
            LoadData();
            CreateMutiLineChart();
        }

        private void CreateMutiLineChart()
        {
            dgDataSource2.DataSource = dt;

            GraphPane myPane = zedGraphControl1.GraphPane;

            myPane.CurveList.Clear();
            myPane.GraphObjList.Clear();
            LineItem myCurve1 = null, myCurve2 = null,  myCurvea = null, myCurveb = null;

            #region 城市人口
            GraphPane myPane1 = zedGraphControl2.GraphPane;
            myPane1.CurveList.Clear();
            myPane1.GraphObjList.Clear();
            myPane1.Title.Text = "城市建成区面积";
            myPane1.Title.FontSpec.Size = 25;
            myPane1.XAxis.Title.Text = "年份";
            myPane1.YAxis.Title.Text = "面积  平方公里";
            myPane1.YAxis.Title.FontSpec.Size = 25;
         //   myPane1.YAxis.Scale.FontSpec.Size = 500;
         //   myPane1.YAxis.Title.FontSpec.Size = 500;
            lista = new PointPairList();
            listb = new PointPairList();
            myCurvea = myPane1.AddCurve("城市建成区面积",
               lista, Color.Red, SymbolType.Diamond);
            myPane1.Title.FontSpec.FontColor = Color.Green;

            // Add gridlines to the plot, and make them gray
            myPane1.XAxis.MajorGrid.IsVisible = true;
            myPane1.YAxis.MajorGrid.IsVisible = true;
            myPane1.XAxis.MajorGrid.Color = Color.LightGray;
            myPane1.YAxis.MajorGrid.Color = Color.LightGray;

            // Move the legend location
            myPane1.Legend.FontSpec.Size = 25;
            myPane1.Legend.Position = ZedGraph.LegendPos.Bottom;
            myCurvea.Line.Width = 1.0F;

            // Increase the symbol sizes, and fill them with solid white
            myCurvea.Symbol.Size = 2.0F;
            myCurvea.Symbol.Fill = new Fill(Color.White);

            // Add a background gradient fill to the axis frame
            //myPane1.Chart.Fill = new Fill(Color.White,
            //    Color.FromArgb(255, 255, 210), -45F);
            myPane1.Chart.Fill = new Fill(Color.White,
                Color.White, -45F);
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
            myPane2.Title.Text = "城镇化率";
            myPane2.Title.FontSpec.Size = 25;
            myPane2.XAxis.Title.Text = "年份";
            myPane2.YAxis.Title.Text = "率  %";
            myPane2.YAxis.Title.FontSpec.Size = 25;

            listb = new PointPairList();
            myCurveb = myPane2.AddCurve("城镇化率",
               listb, Color.Blue, SymbolType.Diamond);
            myPane2.Title.FontSpec.FontColor = Color.Green;

            // Add gridlines to the plot, and make them gray
            myPane2.XAxis.MajorGrid.IsVisible = true;
            myPane2.YAxis.MajorGrid.IsVisible = true;
            myPane2.XAxis.MajorGrid.Color = Color.LightGray;
            myPane2.YAxis.MajorGrid.Color = Color.LightGray;

            // Move the legend location
            myPane2.Legend.FontSpec.Size = 25;
            myPane2.Legend.Position = ZedGraph.LegendPos.Bottom;
 
            myCurveb.Line.Width = 1.0F;

            // Increase the symbol sizes, and fill them with solid white
            myCurveb.Symbol.Size = 2.0F;
            myCurveb.Symbol.Fill = new Fill(Color.White);

            // Add a background gradient fill to the axis frame
            myPane2.Chart.Fill = new Fill(Color.White,
                Color.White, -45F);

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

            // Set up the title and axis labels
            myPane.Title.Text = "土地利用变化趋势";
            myPane.XAxis.Title.Text = "年份";
            myPane.YAxis.Title.Text = "土地  平方公里";

            //PointPairList list1 = null, list3 = null, list2 = null, list = null;
            // Make up some data arrays based on the Sine function
            list1 = new PointPairList();
            //list3 = new PointPairList();
            list2 = new PointPairList();
            list = new PointPairList();

            // Generate a red curve with diamond
            // symbols, and "apop" in the legend
            myCurve1 = myPane.AddCurve("年末耕地面积",
                list1, Color.Red, SymbolType.Diamond);

            // Generate a blue curve with circle
            // symbols, and "napop" in the legend
            //myCurve2 = myPane.AddCurve("城市建成区面积",
            //    list2, Color.Blue, SymbolType.Circle);
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
          //  myCurve2.Line.Width = 1.0F;
            //myCurve3.Line.Width = 1.0F;
            //myCurve.Line.Width = 1.0F;

            // Increase the symbol sizes, and fill them with solid white
            myCurve1.Symbol.Size = 2.0F;
          //  myCurve2.Symbol.Size = 2.0F;
            //myCurve3.Symbol.Size = 2.0F;
            //myCurve.Symbol.Size = 2.0F;

            myCurve1.Symbol.Fill = new Fill(Color.White);
           // myCurve2.Symbol.Fill = new Fill(Color.White);
            //myCurve3.Symbol.Fill = new Fill(Color.White);
            //myCurve.Symbol.Fill = new Fill(Color.White);

            // Add a background gradient fill to the axis frame
            myPane.Chart.Fill = new Fill(Color.White,
                 Color.White, -45F);

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

        private void LoadData()
        {
            sConn = @"Provider = Microsoft.Jet.OLEDB.4.0;Data Source =" + Application.StartupPath + @"\Data\dqhp.mdb;Jet OLEDB:Database Password=dqhpdata";
            if (pConn == null)
                pConn = new OleDbConnection(sConn);
            if (pConn.State == ConnectionState.Closed)
                pConn.Open();
            OleDbCommand cmd = pConn.CreateCommand();
            cmd.CommandText = "Select id,年份,年末耕地面积,土地面积,城市建成区面积,城镇化率 From Land";
            OleDbDataAdapter oda = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            oda.Fill(ds, "Land");
            if (dt == null)
                dt = new DataTable();
            dt = ds.Tables["Land"];
        }

        private void btnSimulate_Click(object sender, EventArgs e)
        {
            LoadSimulationData();
            btnStart.Enabled = false;           //把开始按钮false掉，以免再点开始出现BUG。
            btnSimulate.Enabled = false;
        }

        private void LoadSimulationData()
        {
            //加载数据库的原始数据
            //id=1-17	year=1996-2012
            int iRowCount = dt.Rows.Count - 1;
            if (iRowCount > 6)
            {
                for (int i = iRowCount; i >= 6; i--)
                {
                    dt.Rows.RemoveAt(i);
                    //list.RemoveAt(i);
                    list1.RemoveAt(i);
                   // list2.RemoveAt(i);
                    //list3.RemoveAt(i);
                    lista.RemoveAt(i);
                    listb.RemoveAt(i);
                    //listc.RemoveAt(i);
                }
            }
            //修改数据源dt中的值
            //id	year	gdp1	gdp2	gdp3	apop	napop	citypop	gdp	pop
            double rate = 0.00207;//变化率
            //try
            //{
            //    //rate = double.Parse(txtIncreaseRate.Text.Trim()) / 1000;
            //}
            //catch
            //{
            //    MessageBox.Show("人口增长率必须是数值！");
            //    return;
            //}

            //拐点年份
            //Int32 iInflexionYear = (Int32)txtInflexionYear.Value;
            Int32 iInflexionYear = 2030;
            //模拟结束年份
            //Int32 iEndYear = (Int32)txtEndYear.Value;
            Int32 iEndYear = 2020;
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
                dr["年份"] = int.Parse(dt.Rows[iRowMaxIndex]["年份"].ToString().Trim()) + 1;
                // dr["总人口"] = double.Parse(dt.Rows[iRowMaxIndex]["总人口"].ToString().Trim()) * (1 + dRate);
                dr["年末耕地面积"] = double.Parse(dt.Rows[iRowMaxIndex]["年末耕地面积"].ToString().Trim()) * (1-0.014);

                dr["城市建成区面积"] = double.Parse(dt.Rows[iRowMaxIndex]["城市建成区面积"].ToString().Trim()) * (1 + 0.039431);
                dr["城镇化率"] = double.Parse(dt.Rows[iRowMaxIndex]["城镇化率"].ToString().Trim()) * (1 + 0.034685);
                // dr["pop"] = double.Parse(dt.Rows[iRowMaxIndex]["pop"].ToString().Trim()) * (1 + dRate);
                //dr["gdp"] = double.Parse(dt.Rows[iRowMaxIndex]["gdp"].ToString().Trim()) * (1 + dRate);
                dt.Rows.Add(dr);

                //创建曲线图

                double x = double.Parse(dt.Rows[iRowMaxIndex]["年份"].ToString().Trim());
                double y1 = double.Parse(dt.Rows[iRowMaxIndex]["年末耕地面积"].ToString().Trim());
                double y3 = double.Parse(dt.Rows[iRowMaxIndex]["城市建成区面积"].ToString().Trim());
                double y2 = double.Parse(dt.Rows[iRowMaxIndex]["城镇化率"].ToString().Trim());
                //  double y = double.Parse(dt.Rows[iRowMaxIndex]["pop"].ToString().Trim());
                //double y5 = double.Parse(dt.Rows[iRowMaxIndex]["gdp"].ToString().Trim());

                //list.Add(x, y);
                list1.Add(x, y1);
              //  list2.Add(x, y3);
                //list3.Add(x, y3);
                lista.Add(x, y3);
                listb.Add(x, y2);
                //listc.Add(x, y5);
                zedGraphControl1.GraphPane.XAxis.Scale.MaxAuto = true;
                this.zedGraphControl1.AxisChange();
                this.zedGraphControl1.Refresh();

                zedGraphControl2.GraphPane.XAxis.Scale.MaxAuto = true;
                this.zedGraphControl2.AxisChange();
                this.zedGraphControl2.Refresh();

                zedGraphControl3.GraphPane.XAxis.Scale.MaxAuto = true;
                this.zedGraphControl3.AxisChange();
                this.zedGraphControl3.Refresh();

                //zedGraphControl4.GraphPane.XAxis.Scale.MaxAuto = true;
                //this.zedGraphControl4.AxisChange();
                //this.zedGraphControl4.Refresh();

                this.dgDataSource2.DataSource = dt;
                this.dgDataSource2.Refresh();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            LoadHistoryData();
            btnSimulate.Enabled = true;
        }

        private void LoadHistoryData()
        {
            //加载数据库的原始数据
            while (list.Count > 1)
            {
                //list.RemoveAt(1);
                list1.RemoveAt(1);
               // list2.RemoveAt(1);
                //list3.RemoveAt(1);
                lista.RemoveAt(1);
                listb.RemoveAt(1);
                //listc.RemoveAt(1);
            }
            //修改数据源dt中的值
            //id	year	gdp1	gdp2	gdp3	apop	napop	citypop	gdp	pop

            for (int i = 1; i < 6; i++)
            {
                Thread.Sleep(100);
                double x = double.Parse(dt.Rows[i]["年份"].ToString().Trim());
                double y1 = double.Parse(dt.Rows[i]["城市建成区面积"].ToString().Trim());
                double y3 = double.Parse(dt.Rows[i]["年末耕地面积"].ToString().Trim());
                double y2 = double.Parse(dt.Rows[i]["城镇化率"].ToString().Trim());
                //  double y = double.Parse(dt.Rows[i]["pop"].ToString().Trim());
                //double y5 = double.Parse(dt.Rows[i]["gdp"].ToString().Trim());
                //list.Add(x, y);
                list1.Add(x, y3);
               // list2.Add(x, y1);
                //list3.Add(x, y3);
                lista.Add(x, y1);//非农业人口
                listb.Add(x, y2);//人口自然增长率
                //listc.Add(x,y5);
                zedGraphControl1.GraphPane.XAxis.Scale.MaxAuto = true;
                this.zedGraphControl1.AxisChange();
                this.zedGraphControl1.Refresh();

                zedGraphControl2.GraphPane.XAxis.Scale.MaxAuto = true;
                this.zedGraphControl2.AxisChange();
                this.zedGraphControl2.Refresh();

                zedGraphControl3.GraphPane.XAxis.Scale.MaxAuto = true;
                this.zedGraphControl3.AxisChange();
                this.zedGraphControl3.Refresh();

                //zedGraphControl4.GraphPane.XAxis.Scale.MaxAuto = true;
                //this.zedGraphControl4.AxisChange();
                //this.zedGraphControl4.Refresh();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
