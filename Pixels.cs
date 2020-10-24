using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    class Pixels
    {
        private int Height { get; set; }

        private int Width { get; set; }

        private Button[,] Buttons;

        public string[,] ClickButton = new string[2, 2];

        public bool[,] Buttons_Action;

        public Pixels(int width, int height)
        {
            Width = width;
            Height = height;
            Buttons = new Button[Width, Height];
            Buttons_Action = new bool[Width, Height];

        }

        public void CreateAreaPixels(Form form)
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Buttons[x, y] = new Button
                    {
                        Size = new System.Drawing.Size(form.Width / Width, form.Height / Height),
                        Location = new System.Drawing.Point(form.Width / Width * x, form.Height / Height * y),
                        BackColor = Color.White
                    };
                    form.Controls.Add(Buttons[x, y]);
                    Buttons[x, y].Click += new EventHandler(PressButton);
                }
            }
        }

        private void PressButton(object sender, EventArgs e)
        {
            Button pressbutton = sender as Button;
            Calculate(pressbutton);
        }

        private void Calculate(Button button)
        {
            bool FindedNeedButton = false;
            int x = 0;
            int y = 0;
            while (!FindedNeedButton && x < Width)
            {
                y = 0;
                while (!FindedNeedButton && y < Height)
                {
                    if (Buttons[x, y] == button)
                    {
                        FindedNeedButton = true;
                        break;
                    }
                    y++;
                }
                x++;
            }
            Buttons_Action[x - 1, y] = true;
            MouseClick(x - 1, y);

        }

        private void MouseClick(int x, int y)
        {
            if (ClickButton[0, 0] == null)
            {
                ClickButton[0, 0] = x.ToString();
                ClickButton[0, 1] = y.ToString();
            }
            else if (ClickButton[1, 0] == null)
            {
                ClickButton[1, 0] = x.ToString();
                ClickButton[1, 1] = y.ToString();
                Draw.Drawing(Buttons, ClickButton);
                ClickButton[0, 0] = null;
                ClickButton[0, 1] = null;
                ClickButton[1, 0] = null;
                ClickButton[1, 1] = null;
            }
        }
    }
}
