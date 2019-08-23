using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FSX_WarEasyMap
{
    public partial class Form1 : Form
    {
        internal static Point mappingCNTLSize = new Point(1261, 816);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void loadMapper(Point point)
        {
            mapping1.Dock = DockStyle.Fill;
            button1.Hide();
            button2.Hide();
            label1.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadMapper(mappingCNTLSize);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadMapper(mappingCNTLSize);
        }

        private void mapping1_Load(object sender, EventArgs e)
        {

        }
    }
}
