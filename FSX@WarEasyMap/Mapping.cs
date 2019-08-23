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
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace FSX_WarEasyMap
{
    public partial class Mapping : UserControl
    {
        internal List<GMapProvider> mapList = new List<GMapProvider>();
        internal bool init = false;
        internal PointLatLng latLng;
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
            gMapControl1.MapProvider = GMapProviders.GoogleSatelliteMap;
            comboBox1.SelectedItem = GMapProviders.GoogleSatelliteMap;
            
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 5000;
            gMapControl1.OnPositionChanged += posHandle;
            gMapControl1.DragButton = MouseButtons.Right;
            
            gMapControl1.MouseWheelZoomEnabled = true;
            gMapControl1.MouseWheelZoomType = MouseWheelZoomType.MousePositionAndCenter;
            gMapControl1.ShowCenter = false;
            init = true;
        }

        
        private void posHandle(PointLatLng point)
        {
            latLng = point;
            textBox1.Text = point.Lat.ToString();
            textBox2.Text = point.Lng.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = mapList[comboBox1.SelectedIndex];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text != "")
            {
                double lat = 0;
                double lng = 0;
                try
                {
                    lat = Convert.ToDouble(textBox1.Text);
                    lng = Convert.ToDouble(textBox2.Text);
                    gMapControl1.Position = new PointLatLng(lat, lng);
                }
                catch(Exception ex) { MessageBox.Show("Error: " + ex.Message, "Uh Oh!"); }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Bitmap btm = new Bitmap(Image.FromFile(@"C:\Users\plynch\Downloads\EKKF_-_Copy.bmp"));
            GMarkerGoogle mk = new GMarkerGoogle(latLng, btm);
            GMapMarker m = mk;
            //m.Size = new Size(new Point(50, 50));
            GMapOverlay markers = new GMapOverlay("Objects");
            markers.Markers.Add(m);
            markers.IsZoomSignificant = true;
            gMapControl1.Overlays.Add(markers);
        }

        private void Mapping_Load(object sender, EventArgs e)
        {
            
        }
    }
}
