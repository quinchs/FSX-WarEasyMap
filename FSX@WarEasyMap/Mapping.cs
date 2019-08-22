using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;

namespace FSX_WarEasyMap
{
    public partial class Mapping : UserControl
    {
        internal List<GMapProvider> mapList = new List<GMapProvider>();
        internal bool init = false;
        public Mapping()
        {
            InitializeComponent();
            this.SizeChanged += Mapping_SizeChanged;
        }

        private void Mapping_SizeChanged(object sender, EventArgs e)
        {
            if (init)
                gMapControl1.Size = new Size(new Point(this.Width - 175, this.Height));
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            mapList = GMapProviders.List;
            foreach (var item in mapList)
            {
                comboBox1.Items.Add(item);
            }
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 5000;
            gMapControl1.OnPositionChanged += posHandle;
            gMapControl1.DragButton = MouseButtons.Right;
            
            gMapControl1.MouseWheelZoomEnabled = true;
            gMapControl1.MouseWheelZoomType = MouseWheelZoomType.MousePositionAndCenter;
            init = true;
        }

        
        private void posHandle(PointLatLng point)
        {
            textBox1.Text = point.Lat.ToString();
            textBox2.Text = point.Lng.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = mapList[comboBox1.SelectedIndex];
        }
    }
}
