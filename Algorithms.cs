
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    static class Algorithms
    {
        private static List<string> bufferLines = new List<string>();
        private static Stack<string> bufferPointsOfBesye = new Stack<string>();

        static public void Line(Button[,] buttons, Color color, int x0, int y0, int x1, int y1)
        {
            int x = x0;
            int y = y0;
            double dx;
            if (x1 > x0)
                dx = x1 - x0;
            else
                dx = x0 - x1;
            double dy;
            if (y1 < y0)
                dy = y0 - y1;
            else
                dy = y1 - y0;
            if (dy < dx)
            {
                double m = dy / dx;
                double e = m - 0.5;
                buttons[x, y].BackColor = color;
                for (int i = 0; i < dx; i++)
                {

                    if (e >= 0)
                    {
                        if (y1 < y0)
                            y -= 1;
                        else
                            y += 1;

                        e = e + m - 1;
                    }
                    else
                    {
                        e += m;
                    }
                    if (x1 > x0)
                        x += 1;
                    else
                        x -= 1;
                    buttons[x, y].BackColor = color;
                }
            }
            else
            {
                double m = dx / dy;
                double e = m - 0.5;
                buttons[x, y].BackColor = color;
                for (int i = 0; i < dy; i++)
                {

                    if (e >= 0)
                    {
                        if (x1 < x0)
                            x -= 1;
                        else
                            x += 1;

                        e = e + m - 1;
                    }
                    else
                    {
                        e += m;
                    }
                    if (y1 > y0)
                        y += 1;
                    else
                        y -= 1;
                    buttons[x, y].BackColor = color;
                }
            }
        }
        static public void Circle(Button[,] buttons, int x0, int y0, int x1, int y1)
        {
            if (x1 > x0)
            {
                int r = x1 - x0;
                for (int x = x0 - r; x <= x0 + r; x++)
                {
                    try
                    {
                        buttons[x, y0 + (int)Math.Sqrt(r * r - Math.Pow(x - x0, 2))].BackColor = Color.Black;
                        buttons[x, y0 - (int)Math.Sqrt(r * r - Math.Pow(x - x0, 2))].BackColor = Color.Black;
                    }
                    catch
                    { }
                }
            }
            else
            {
                int r = x0 - x1;
                for (int x = x0 - r; x <= x0 + r; x++)
                {
                    try
                    {
                        buttons[x, y0 + (int)Math.Sqrt(r * r - Math.Pow(x - x0, 2))].BackColor = Color.Black;
                        buttons[x, y0 - (int)Math.Sqrt(r * r - Math.Pow(x - x0, 2))].BackColor = Color.Black;
                    }
                    catch { }
                }
            }
        }
        static public void Fill(Button[,] buttons, int x0, int y0)
        {
            Stack<int> X = new Stack<int>();
            Stack<int> Y = new Stack<int>();
            X.Push(x0);
            Y.Push(y0);
            while (X.Count != 0 && Y.Count != 0)
            {
                x0 = X.Pop();
                y0 = Y.Pop();
                try
                {
                    if (buttons[x0, y0].BackColor != Color.Black)
                    {
                        buttons[x0, y0].BackColor = Color.Black;
                        X.Push(x0); Y.Push(y0 + 1);
                        X.Push(x0); Y.Push(y0 - 1);
                        X.Push(x0 + 1); Y.Push(y0);
                        X.Push(x0 - 1); Y.Push(y0);
                    }
                }
                catch
                {

                }
            }
        }

        static public void FillImproved(Button[,] buttons, Color color, int x0, int y0)
        {
            Stack<int> X = new Stack<int>();
            Stack<int> Y = new Stack<int>();
            X.Push(x0);
            Y.Push(y0);
            Color colorarea = buttons[x0, y0].BackColor;
            // Линия
            while (X.Count != 0 && Y.Count != 0)
            {
                x0 = X.Pop();
                y0 = Y.Pop();
                int i = 0;
                //Идем вправо
                while(buttons[x0 + i,y0].BackColor == colorarea)
                {
                    if (i != 0)
                    {
                        buttons[x0 + i, y0].BackColor = color;
                    }
                    i++;
                }
                int j = 0;
                //Идем влево
                while (buttons[x0 - j, y0].BackColor == colorarea)
                {
                    buttons[x0 - j, y0].BackColor = color;
                    j++;
                }
                j--;
                //Анализируем слева направо
                for (int k = 0; k < Math.Abs(i + j); k++)
                {
                    //Вверхняя линия
                    if(buttons[x0 - j + k,y0 - 1].BackColor == colorarea && buttons[x0 - j + k + 1, y0 - 1].BackColor != colorarea) 
                    {
                        X.Push(x0 - j + k);
                        Y.Push(y0 - 1);
                    }
                    if(k + 1 == i + j && (buttons[x0 - j + k, y0 - 1].BackColor == colorarea))
                    {
                        X.Push(x0 - j + k);
                        Y.Push(y0 - 1);
                    }
                    //Нижняя Линия
                    if (buttons[x0 - j + k, y0 + 1].BackColor == colorarea && buttons[x0 - j + k + 1, y0 + 1].BackColor != colorarea)
                    {
                        X.Push(x0 - j + k);
                        Y.Push(y0 + 1);
                    }
                    if (k + 1 == i + j && (buttons[x0 - j + k, y0 + 1].BackColor == colorarea))
                    {
                        X.Push(x0 - j + k);
                        Y.Push(y0 + 1);
                    }
                }
                
            }
        }
        #region Машкин
        //static public void ZatravkaMod(int x, int y, Button[,] buttons, Color color)

        //{

        //    Color backcolor = buttons[x,y].BackColor;

        //    int xl = x;

        //    int xr = x + 1;

        //    while ((xl >= 0) && (buttons[xl, y].BackColor == backcolor))

        //    {

        //        buttons[xl, y].BackColor = color; 

        //        xl--;

        //    }

        //    xl++;



        //    while ((xr < 60 - 1) && (buttons[xr, y].BackColor == backcolor))

        //    {

        //        buttons[xr, y].BackColor = color;

        //        xr++;

        //    }

        //    xr--;

        //    int tmp_x = xl;

        //    while ((tmp_x <= xr) && (y != 0))

        //    {

        //        while ((tmp_x <= xr) && (buttons[tmp_x, y - 1].BackColor != backcolor))

        //        {

        //            tmp_x++;

        //        }

        //        if (tmp_x <= xr) ZatravkaMod(tmp_x, y - 1,buttons, color);

        //        tmp_x++;

        //    }

        //    tmp_x = xl;

        //    while ((tmp_x <= xr) && (y + 1 != 60))

        //    {

        //        while ((tmp_x <= xr) && (buttons[tmp_x, y + 1].BackColor != backcolor))

        //        {

        //            tmp_x++;

        //        }

        //        if (tmp_x <= xr) ZatravkaMod(tmp_x, y + 1, buttons, color);

        //        tmp_x++;

        //    }

        //}
        #endregion



        static public void Bezier(Button[,] buttons, Color color, int x0, int y0, int x1, int y1)
        {
            Line(buttons, color, x0, y0, x1, y1);
            if (bufferLines.Count == 1)
            {
                AddBufferLines(x0, y0, x1, y1);
                float t = 0;
                while (t < 1)
                {
                    bufferPointsOfBesye.Push(FindCoorBesye(t));
                    t += 0.1f;
                }
                bufferPointsOfBesye.Push(FindCoorBesye(t));
                UniteBesyePoints(buttons, Color.Red);
                bufferLines.Clear();
            }
            else
            {
                AddBufferLines(x0, y0, x1, y1);
            }

        }

        static private void AddBufferLines(int x0, int y0, int x1, int y1)
        {
            bufferLines.Add($"{x0} {y0} {x1} {y1}");
        }
        static private string FindCoorBesye(float t)
        {
            string[] coor0 = bufferLines.First().Split(new char[] { ' ' });
            string[] coor1 = bufferLines.Last().Split(new char[] { ' ' });
            int P0x = int.Parse(coor0[0]);
            int P0y = int.Parse(coor0[1]);
            int P1x = int.Parse(coor0[2]);
            int P1y = int.Parse(coor0[3]);
            int P2x = int.Parse(coor1[2]);
            int P2y = int.Parse(coor1[3]);
            int Px = (int)((1 - t) * (1 - t) * P0x + 2 * t * (1 - t) * P1x + t * t * P2x);
            int Py = (int)((1 - t) * (1 - t) * P0y + 2 * t * (1 - t) * P1y + t * t * P2y);
            return $"{Px} {Py}";
        }
        static private void UniteBesyePoints(Button[,] buttons, Color color)
        {

            while (bufferPointsOfBesye.Count != 1)
            {
                string[] coor0 = bufferPointsOfBesye.Pop().Split(new char[] { ' ' });
                string[] coor1 = bufferPointsOfBesye.Peek().Split(new char[] { ' ' });
                Line(buttons, color, int.Parse(coor0[0]), int.Parse(coor0[1]), int.Parse(coor1[0]), int.Parse(coor1[1]));
            }
            bufferPointsOfBesye.Clear();
        }
    }
}

