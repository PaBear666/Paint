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
            Color color = buttons[x0, y0].BackColor;
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
                    if (buttons[x0, y0].BackColor == color)
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
                int xR = 0;
                //Идем вправо
                while(buttons[x0 + xR,y0].BackColor == colorarea)
                {
                    if (xR != 0)
                    {
                        buttons[x0 + xR, y0].BackColor = color;
                    }
                    xR++;
                }
                int xL = 0;
                //Идем влево
                while (buttons[x0 - xL, y0].BackColor == colorarea)
                {
                    buttons[x0 - xL, y0].BackColor = color;
                    xL++;
                }
                xL--;
                //Анализируем слева направо
                for (int k = 0; k < xR + xL; k++)
                {
                    //Вверхняя линия
                    if(buttons[x0 - xL + k,y0 - 1].BackColor == colorarea && buttons[x0 - xL + k + 1, y0 - 1].BackColor != colorarea) 
                    {
                        X.Push(x0 - xL + k);
                        Y.Push(y0 - 1);
                    }
                    if(k + 1 == xR + xL && (buttons[x0 - xL + k, y0 - 1].BackColor == colorarea))
                    {
                        X.Push(x0 - xL + k);
                        Y.Push(y0 - 1);
                    }
                    //Нижняя Линия
                    if (buttons[x0 - xL + k, y0 + 1].BackColor == colorarea && buttons[x0 - xL + k + 1, y0 + 1].BackColor != colorarea)
                    {
                        X.Push(x0 - xL + k);
                        Y.Push(y0 + 1);
                    }
                    if (k + 1 == xR + xL && (buttons[x0 - xL + k, y0 + 1].BackColor == colorarea))
                    {
                        X.Push(x0 - xL + k);
                        Y.Push(y0 + 1);
                    }
                }
                
            }
        }
        static public void FillPattern( Button[,] buttons, Color[,] pattern,int x, int y, int w, int h)
        {
            Stack<int> X = new Stack<int>();
            Stack<int> Y = new Stack<int>();
            X.Push(x);
            Y.Push(y);
            Color backcolor = buttons[x,y].BackColor;
            while (X.Count != 0 && Y.Count != 0)
            {
                x = X.Pop();
                y = Y.Pop();
                int i = 0;
                //Идем вправо
                while (buttons[x + i, y].BackColor == backcolor)
                {
                    if (i != 0)
                    {
                        buttons[x + i, y].BackColor = pattern[(x + i) % w, y % h];
                    }
                    i++;
                }
                int j = 0;
                //Идем влево
                while (buttons[x - j, y].BackColor == backcolor)
                {

                    buttons[x - j, y].BackColor = pattern[(x - j) % w, y % h];
                    j++;
                }
                j--;

                for (int k = 0; k < Math.Abs(i + j); k++)
                {
                    //Проверяем верхнюю линию
                    if (buttons[x - j + k, y - 1].BackColor == backcolor && buttons[x - j + k + 1, y - 1].BackColor != backcolor)
                    {
                            
                        X.Push(x - j + k);
                        Y.Push(y - 1);
                    }
                    if (k + 1 == i + j && (buttons[x - j + k, y - 1].BackColor == backcolor))
                    {
                        
                        X.Push(x - j + k);
                        Y.Push(y - 1);
                    }
                    //Проверяем нижниюю линию
                    if (buttons[x - j + k, y + 1].BackColor == backcolor && buttons[x - j + k + 1, y + 1].BackColor != backcolor)
                    {
                        X.Push(x - j + k);
                        Y.Push(y + 1);
                    }
                    if (k + 1 == i + j && (buttons[x - j + k, y + 1].BackColor == backcolor))
                    {
                       
                        X.Push(x - j + k);
                        Y.Push(y + 1);
                    }
                }

            }
        }
        static public void Eazier(Button[,] buttons,int w,int h) 
        {
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    buttons[i, j].BackColor = Color.White;
                }
            }
        }
        static public void Bezier(Button[,] buttons, Color color, int x0, int y0, int x1, int y1)
        {
            Line(buttons, color, x0, y0, x1, y1);
            if (x0 == x1 && y0 == y1)
            { 
                float t = 0;
                while (t < 1)
                {
                    //bufferPointsOfBesye.Push(FindCoorBesye(t));
                    
                    FindCoorBesye(t);
                    t += 0.01f;
                }
                FindCoorBesye(t);
                UniteBesyePoints(buttons, Color.Red);
                BufferLines.Clear();
            }
            else
            {
                AddBufferLines(x0, y0, x1, y1);
            }

        }
        #region Bezier
        /// <summary>
        /// Буфер для линий в безье
        /// </summary>
        private static List<string> BufferLines = new List<string>();
        /// <summary>
        /// Буфер получившихся точек безье
        /// </summary>
        private static Stack<string> BufferPointsOfBesye = new Stack<string>();
        /// <summary>
        /// Добавляет в буфер линий безье линию
        /// </summary>
        /// <param name="x0">Координата x для первой точки</param>
        /// <param name="y0">Координата y для первой точки</param>
        /// <param name="x1">Координата x для второй точки</param>
        /// <param name="y1">Координата y для второй точки</param>
        static private void AddBufferLines(int x0, int y0, int x1, int y1)
        {
            BufferLines.Add($"{x0} {y0} {x1} {y1}");
        }
        /// <summary>
        /// Находит точку безье
        /// </summary>
        /// <param name="t">Шаг</param>
        /// <returns>Координаты точки</returns>
        static private void FindCoorBesye(float t)
        {
            // Тип для хранения Double
            // Опорных точек больше
            // Шаг меньще
            // Алгоритм Брезенхама для окружности
            int Px = P('x', BufferLines.Count(),t);
            int Py = P('y', BufferLines.Count(),t);
            BufferPointsOfBesye.Push($"{Px} {Py}");
        }
        /// <summary>
        /// Соединяет линями получившиеся точки
        /// </summary>
        /// <param name="buttons">Рабочее поле</param>
        /// <param name="color">Цвет рисовки линии</param>
        static private void UniteBesyePoints(Button[,] buttons, Color color)
        {

            while (BufferPointsOfBesye.Count != 1)
            {
                string[] coor0 = BufferPointsOfBesye.Pop().Split(new char[] { ' ' });
                string[] coor1 = BufferPointsOfBesye.Peek().Split(new char[] { ' ' });
                Line(buttons, color, int.Parse(coor0[0]), int.Parse(coor0[1]), int.Parse(coor1[0]), int.Parse(coor1[1]));
            }
            //foreach (var coor in BufferPointsOfBesye) 
            //{
            //    string[] coor0 = coor.Split(new char[] { ' ' });
            //    buttons[int.Parse(coor0[0]), int.Parse(coor0[1])].BackColor = Color.Red; 
            //}
            BufferPointsOfBesye.Clear();
        }
        /// <summary>
        /// Вычисляет факториал
        /// </summary>
        /// <param name="n">Начальное число</param>
        /// <returns>Факториал</returns>
        static private double Factorial(int n)
        {
            double r = 1;
            for (int i = 2; i <= n; ++i)
                r *= i;
            return r;
        }
        /// <summary>
        /// Вычисляет координаты Точки Безье
        /// </summary>
        /// <param name="xORy">Какую Координату точки безье вернуть</param>
        /// <param name="m">Количество отрезков</param>
        /// <param name="t">Шаг</param>
        /// <returns>Координата точки безье</returns>
        static private int P(char xORy,int m,float t) 
        {
            switch (xORy) 
            {
                case 'x':
                    double x = 0;
                    for (int i = 0; i <= m ; i++)
                    {
                        x += C(m, i) * Math.Pow(t, i) * Math.Pow(1 - t, m - i) * GetNeedCoorFromBufferLines(xORy,i,m);
                    }
                    return (int)x;
                case 'y':
                    double y = 0;
                    for (int i = 0; i <= m; i++)
                    {
                        y += C(m, i) * Math.Pow(t, i) * Math.Pow(1 - t, m - i) * GetNeedCoorFromBufferLines(xORy, i,m);
                    }
                    return (int)y;
                default:
                    return -1;
            }
        }
        /// <summary>
        /// Вычисляет Сочетание
        /// </summary>
        /// <param name="m"></param>
        /// <param name="i"></param>
        /// <returns>Сочетание m по i</returns>
        static private double C(int m ,int i) 
        {
            double result = Factorial(m) / (Factorial(i) * Factorial(m - i));
            return result;
        }
        /// <summary>
        /// Возвращает нужную точку отрезка
        /// </summary>
        /// <param name="xORy">Какую координату точки вернуть</param>
        /// <param name="i">Количество точек</param>
        /// <param name="m">Количество прямых</param>
        /// <returns></returns>
        static private int GetNeedCoorFromBufferLines(char xORy, int i,int m) 
        {
            switch (xORy) 
            {
                case 'x':
                    if (i != m)
                    {
                        string[] coor0 = BufferLines.ElementAt(i).Split(new char[] { ' ' });
                        return int.Parse(coor0[0]);
                    }
                    else
                    {
                        string[] coor0 = BufferLines.ElementAt(i - 1).Split(new char[] { ' ' });
                        return int.Parse(coor0[2]);
                    }

                case 'y':
                    if (i != m)
                    {
                        string[] coor0 = BufferLines.ElementAt(i).Split(new char[] { ' ' });
                        return int.Parse(coor0[1]);
                    }
                    else
                    {
                        string[] coor0 = BufferLines.ElementAt(i - 1).Split(new char[] { ' ' });
                        return int.Parse(coor0[3]);
                    }
                default:
                    return -1;
            }
        }
        #endregion
    }
}

