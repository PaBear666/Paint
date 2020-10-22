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
    public partial class Tools : Form
    { 
        public Tools()
        {
            InitializeComponent();
        }
       
        

        private void Line_Click(object sender, EventArgs e)
        {
            FalseActive();
            Draw.ActiveButton[0] = true;
        }

        private void Circle_Click(object sender, EventArgs e)
        {
            FalseActive();
            Draw.ActiveButton[1] = true;
        }

        private void Fill_Click(object sender, EventArgs e)
        {
            FalseActive();
            Draw.ActiveButton[2] = true;
        }

        private void Bezier_Click(object sender, EventArgs e)
        {
            FalseActive();
            Draw.ActiveButton[3] = true;
        }

        private void FalseActive() 
        {
            for (int i = 0; i < Draw.ActiveButton.Length; i++)
            {
                Draw.ActiveButton[i] = false;
            }
        }
        
    }
}
