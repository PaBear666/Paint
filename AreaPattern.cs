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
    public partial class AreaPattern : Form
    {
        Pixels Pixels { get; set; }
        public Color[,] FillArea { get; private set; } 
        public AreaPattern()
        {
            InitializeComponent();
            FillArea = new Color[5, 5];
            Pixels = new Pixels(5, 5);
        }

        private void AreaPattern_Load(object sender, EventArgs e)
        {
            
            Pixels.CreateAreaPixels(this);
        }

        private void AreaPattern_FormClosed(object sender, FormClosedEventArgs e)
        {  
            MoveThePic();
            MessageBox.Show("Рисунок сохранен");
          
        }
        private void MoveThePic() 
        {
            for (int i = 0; i < Pixels.Width; i++)
            {
                for (int j = 0; j < Pixels.Height; j++)
                {
                    FillArea[i,j] = Pixels.Buttons[i, j].BackColor;
                }
            }
        }
    }
}
