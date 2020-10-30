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
        /// <summary>
        /// Количество пикселей в высоту
        /// </summary>
        public int Height { get; private set; }
        /// <summary>
        /// Количество пикселей в ширину
        /// </summary>
        public int Width { get; private set; }
        /// <summary>
        /// Свойство для работы с полем
        /// </summary>
        public Button[,] Buttons { get; private set; }
        /// <summary>
        /// Буфер нажатых кнопок (MAX=2)
        /// </summary>
        public string[,] ClickButton = new string[2, 2];
        public Color ColorOfButton { get; private set; }
        //public bool[,] Buttons_Action;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="width">Ширина</param>
        /// <param name="height">Высота</param>
        public Pixels(int width, int height,Color colorOfButton)
        {
            Width = width;
            Height = height;
            Buttons = new Button[Width, Height];
            ColorOfButton = colorOfButton;
            //Buttons_Action = new bool[Width, Height];

        }
        /// <summary>
        /// Создает рабочие пространство
        /// </summary>
        /// <param name="form">Форма для рабочего пространства</param>
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
                        BackColor = ColorOfButton,
                        Text = $"{x} {y}"
                    };
                    form.Controls.Add(Buttons[x, y]);
                    //Buttons[x, y].MouseClick += new MouseEventHandler(PressButton);
                    Buttons[x, y].MouseUp += new MouseEventHandler(PressButton);
                }
            }
        }
        /// <summary>
        /// Событие (Нажатие кнопки)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PressButton(object sender, MouseEventArgs e)
        {
            Button pressbutton = sender as Button;
            switch (e.Button.ToString()) 
            {
                case "Left":
                    Calculate(pressbutton,"Left");
                    break;
                case "Right":
                    Calculate(pressbutton, "Right");
                    break;
            }
        }
        /// <summary>
        /// Высчитывает координату кнопки
        /// </summary>
        /// <param name="button"></param>
        /// <param name="onbutton"></param>
        private void Calculate(Button button,string onbutton)
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
            //Buttons_Action[x - 1, y] = true;
            if (onbutton == "Left")
                MouseClick(x - 1, y);
            if (onbutton == "Right")
                SetColorOneButton(x - 1, y);

        }
        /// <summary>
        /// Заносит в буфер координаты нажатой кнопки
        /// </summary>
        /// <param name="x">Координата x</param>
        /// <param name="y">Координата y</param>
        private void MouseClick(int x, int y)
        {   
            if(Draw.ActiveRightOff)
            {
                ClickButton[0, 0] = x.ToString();
                ClickButton[0, 1] = y.ToString();
                Draw.Drawing(Buttons, ClickButton);
                Draw.ActiveRightOff = false;
                
            }
            else if (ClickButton[0, 0] == null )
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
        /// <summary>
        /// Красит кнопку в черный цвет при нажатии MouseRight
        /// </summary>
        /// <param name="x">Координата x</param>
        /// <param name="y">Координата y</param>
        private void SetColorOneButton(int x,int y) 
        {
            Buttons[x, y].BackColor = Color.Blue;
        }

    }
}
