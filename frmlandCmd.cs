using MyPluginEngine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SocialEcoTrendAnalyze
{
    class frmlandCmd:MyPluginEngine.ICommand
    {
        private MyPluginEngine.IApplication hk;
        private System.Drawing.Bitmap m_hBitmap;
        private ESRI.ArcGIS.SystemUI.ICommand cmd = null;
        frmLand pfrmLand;

        public frmlandCmd()
        {
            string str = @"..\Data\Image\TrendAnalyze\land.jpg";
            if (System.IO.File.Exists(str))
                m_hBitmap = new Bitmap(str);
            else
                m_hBitmap = null;
        }
        #region ICommand 成员
        public System.Drawing.Bitmap Bitmap
        {
            get { return m_hBitmap; }
        }

        public string Caption
        {
            get { return "用地需求趋势"; }
        }

        public string Category
        {
            get { return "SocialEcoTrendAnalyzeMenu"; }
        }

        public bool Checked
        {
            get { return false; }
        }

        public bool Enabled
        {
            get { return true; }
        }

        public int HelpContextId
        {
            get { return 0; }
        }

        public string HelpFile
        {
            get { return ""; }
        }

        public string Message
        {
            get { return "用地需求趋势"; }
        }

        public string Name
        {
            get { return "frmLand"; }
        }

        public void OnClick()
        {
            //System.Windows.Forms.MessageBox.Show("模块正在开发中！");
            pfrmLand = new frmLand();
            pfrmLand.ShowDialog();
        }

        public void OnCreate(IApplication hook)
        {
            if (hook != null)
            {
                this.hk = hook;
                pfrmLand = new frmLand();
                pfrmLand.Visible = false;
            }
        }

        public string Tooltip
        {
            get { return "用地需求趋势"; }
        }
        #endregion   
    }
}
