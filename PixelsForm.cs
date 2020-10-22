using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class PixelsForm : Form
    {
        public PixelsForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Pixels pixels = new Pixels(60,60);
            pixels.CreateAreaPixels(this);
            Tools tools = new Tools();
            tools.Show();
        }
    }
}
