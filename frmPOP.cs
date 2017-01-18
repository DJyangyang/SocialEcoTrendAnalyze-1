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
            //����Glass����
            this.EnableGlass = false;
            //����ʾ�����С����ť
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            //ȥ��ͼ��
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
            cmd.CommandText = "Select id,���,��ũҵ�˿�,���˿�,�˿���Ȼ������,ũҵ�˿� From People";
            OleDbDataAdapter oda = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            oda.Fill(ds, "People"); 
            if (dt == null)
                dt = new DataTable();
            dt = ds.Tables["People"];
        }

        private void CreateMutiLineChart()
        {
            dgDataSource.DataSource = dt;

            GraphPane myPane = zedGraphControl1.GraphPane;
        
            myPane.CurveList.Clear();
            myPane.GraphObjList.Clear();
            LineItem myCurve1 = null, myCurve2 = null, myCurve3 = null, myCurve = null, myCurvea = null, myCurveb = null,myCurvec=null;

            #region �����˿�
            GraphPane myPane1 = zedGraphControl2.GraphPane;
            myPane1.CurveList.Clear();
            myPane1.GraphObjList.Clear();
            myPane1.Title.Text = "ũҵ�˿�";
            myPane1.Title.FontSpec.Size = 25;
            myPane1.XAxis.Title.Text = "���";
            myPane1.YAxis.Title.Text = "�˿�  ��";
            myPane1.YAxis.Title.FontSpec.Size = 25;
            lista = new PointPairList();
            listb = new PointPairList();
            myCurvea = myPane1.AddCurve("ũҵ�˿�",
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
            #region ���˿�
            GraphPane myPane2 = zedGraphControl3.GraphPane;
            myPane2.CurveList.Clear();
            myPane2.GraphObjList.Clear();
            myPane2.Title.Text = "�˿���Ȼ������";
            myPane2.Title.FontSpec.Size = 25;
            myPane2.XAxis.Title.Text = "���";
            myPane2.YAxis.Title.Text = "������  ��";
            myPane2.YAxis.Title.FontSpec.Size = 25;
            listb = new PointPairList();
            myCurveb = myPane2.AddCurve("�˿���Ȼ������",
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
            myPane.Title.Text = "�˿���������";
           // myPane.Title.FontSpec.Size = 25;
			myPane.XAxis.Title.Text = "���";
			myPane.YAxis.Title.Text = "�˿�  ��";
           // myPane.YAxis.Title.FontSpec.Size = 25;
            //PointPairList list1 = null, list3 = null, list2 = null, list = null;
			// Make up some data arrays based on the Sine function
			list1 = new PointPairList();
            //list3 = new PointPairList();
            list2 = new PointPairList();
            list = new PointPairList();
 
            // Generate a red curve with diamond
            // symbols, and "apop" in the legend
            myCurve1 = myPane.AddCurve("���˿�",
                list1, Color.Red, SymbolType.Diamond);

            // Generate a blue curve with circle
            // symbols, and "napop" in the legend
            myCurve2 = myPane.AddCurve("��ũҵ�˿�",
                list2, Color.Blue, SymbolType.Circle);

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
            //myCurve3.Line.Width = 1.0F;
            //myCurve.Line.Width = 1.0F;

            // Increase the symbol sizes, and fill them with solid white
            myCurve1.Symbol.Size = 2.0F;
            myCurve2.Symbol.Size = 2.0F;
            //myCurve3.Symbol.Size = 2.0F;
            //myCurve.Symbol.Size = 2.0F;

            myCurve1.Symbol.Fill = new Fill(Color.White);
            myCurve2.Symbol.Fill = new Fill(Color.White);
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
  
        private void LoadHistoryData()
        {
            //�������ݿ��ԭʼ����
            while (list.Count > 1)
            {
                list1.RemoveAt(1);
                list2.RemoveAt(1);
                lista.RemoveAt(1);
                listb.RemoveAt(1);
        
            }
            //�޸�����Դdt�е�ֵ
            //id	year	gdp1	gdp2	gdp3	apop	napop	citypop	gdp	pop

            for (int i = 1; i <6; i++)
            {
                Thread.Sleep(100);
                double x = double.Parse(dt.Rows[i]["���"].ToString().Trim());
                double y1 = double.Parse(dt.Rows[i]["��ũҵ�˿�"].ToString().Trim());
                double y3 = double.Parse(dt.Rows[i]["���˿�"].ToString().Trim());
                double y2 = double.Parse(dt.Rows[i]["�˿���Ȼ������"].ToString().Trim());
                double y4 = double.Parse(dt.Rows[i]["ũҵ�˿�"].ToString().Trim());

                list1.Add(x, y3);
                list2.Add(x, y1);
                lista.Add(x, y4);//ũҵ�˿�
                listb.Add(x, y2);//�˿���Ȼ������
             
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
        //����ģ������
        private void LoadSimulationData()
        {
            //�������ݿ��ԭʼ����
            //id=1-17	year=1996-2012
            int iRowCount = dt.Rows.Count - 1;
            if (iRowCount > 6)
            {
                for (int i = iRowCount; i >= 6; i--)
                {
                    dt.Rows.RemoveAt(i);
                    //list.RemoveAt(i);
                    list1.RemoveAt(i);
                    list2.RemoveAt(i);
                    //list3.RemoveAt(i);
                    lista.RemoveAt(i);
                    listb.RemoveAt(i);
                    //listc.RemoveAt(i);
                }
            }
            //�޸�����Դdt�е�ֵ
            //id	year	gdp1	gdp2	gdp3	apop	napop	citypop	gdp	pop
            double rate = 0.00207;
            //try
            //{
            //    //rate = double.Parse(txtIncreaseRate.Text.Trim()) / 1000;
            //}
            //catch
            //{
            //    MessageBox.Show("�˿������ʱ�������ֵ��");
            //    return;
            //}

            //�յ����
            //Int32 iInflexionYear = (Int32)txtInflexionYear.Value;
            Int32 iInflexionYear = 2030;
            //ģ��������
            //Int32 iEndYear = (Int32)txtEndYear.Value;
            Int32 iEndYear = 2020;
            double dRateTemp = rate / (iInflexionYear - 2012);
            double dRate = rate;

            for (int i = 0; i < iEndYear - 2012 + 1; i++)
            {
                Thread.Sleep(200);
                //����ģ������
                dRate = dRate - dRateTemp;
                int iRowMaxIndex = dt.Rows.Count - 1;
                DataRow dr = dt.NewRow();
                dr["id"] = int.Parse(dt.Rows[iRowMaxIndex]["id"].ToString().Trim()) + 1;
                dr["���"] = int.Parse(dt.Rows[iRowMaxIndex]["���"].ToString().Trim()) + 1;
               // dr["���˿�"] = double.Parse(dt.Rows[iRowMaxIndex]["���˿�"].ToString().Trim()) * (1 + dRate);
                dr["���˿�"] = double.Parse(dt.Rows[iRowMaxIndex]["���˿�"].ToString().Trim()) * (1 + 0.0029325);
                dr["ũҵ�˿�"] = double.Parse(dt.Rows[iRowMaxIndex]["ũҵ�˿�"].ToString().Trim()) * (1 + dRate);
                dr["��ũҵ�˿�"] = double.Parse(dt.Rows[iRowMaxIndex]["��ũҵ�˿�"].ToString().Trim()) * (1 + dRate);
                dr["�˿���Ȼ������"] = double.Parse(dt.Rows[iRowMaxIndex]["�˿���Ȼ������"].ToString().Trim()) * (1 + dRate);
             
                dt.Rows.Add(dr);

                //��������ͼ

                double x = double.Parse(dt.Rows[iRowMaxIndex]["���"].ToString().Trim());
                double y1 = double.Parse(dt.Rows[iRowMaxIndex]["���˿�"].ToString().Trim());
                double y3 = double.Parse(dt.Rows[iRowMaxIndex]["��ũҵ�˿�"].ToString().Trim());
                double y2 = double.Parse(dt.Rows[iRowMaxIndex]["�˿���Ȼ������"].ToString().Trim());
                double y4 = double.Parse(dt.Rows[iRowMaxIndex]["ũҵ�˿�"].ToString().Trim());
            
               
                list1.Add(x, y1);
                list2.Add(x, y3);
              
                lista.Add(x, y4);
                listb.Add(x, y2);
              
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
          
            LoadHistoryData();
            btnSimulate.Enabled = true;
      }

        private void btnSimulate_Click(object sender, EventArgs e)
        {
            LoadSimulationData();
            btnStart.Enabled = false;           //�ѿ�ʼ��ťfalse���������ٵ㿪ʼ����BUG��
            btnSimulate.Enabled = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnStart_MouseEnter(object sender, EventArgs e)
        {
            ToolTip p = new ToolTip();
            p.ShowAlways = true;
            p.SetToolTip(this.btnStart,"�˿�ģ����������Ϊ2020��,���"+"ģ�ⰴť����ʼ�˿�ģ�⡣");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}