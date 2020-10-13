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
        static public void Line(Button[,]buttons,int x0,int y0,int x1,int y1) 
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
                buttons[x, y].BackColor = Color.Black;
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
                    buttons[x, y].BackColor = Color.Black;
                }
            }
            else 
            {
                double m = dx / dy;
                double e = m - 0.5;
                buttons[x, y].BackColor = Color.Black;
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
                    buttons[x, y].BackColor = Color.Black;
                }
            }
        }
        static public void Circle(Button[,] buttons, int x0, int y0, int x1, int y1)
        {
            for (int x = x1 - x0; x <= x0 + x1; x++) 
            {
                buttons[x, y0 + (int)Math.Sqrt(x1 * x1 + Math.Pow(x - x0, 2))].BackColor = Color.Black;
            }
        }
        static public void Fill(Button[,] buttons, int x0, int y0)
        {
            Stack<int> X = new Stack<int>();
            Stack<int> Y = new Stack<int>();
            X.Push(x0);
            Y.Push(y0);
            while(X.Count != 0 && Y.Count != 0) 
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
        static public void Easer(Button[,] buttons) 
        {
        
        }
    }
}
