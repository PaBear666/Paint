using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    static class Draw
    {
        static public bool[] ActiveButton = new bool[4];

        static public void Drawing(Button[,] buttons,string[,] coor) 
        {
            switch (SendActiveButton()) 
            {
                case 0:
                    Algorithms.Line(buttons, int.Parse(coor[0, 0]), int.Parse(coor[0, 1]), int.Parse(coor[1, 0]), int.Parse(coor[1, 1]));
                    break;
                case 1:
                    Algorithms.Circle(buttons, int.Parse(coor[0, 0]), int.Parse(coor[0, 1]), int.Parse(coor[1, 0]), int.Parse(coor[1, 1]));
                    break;
                case 2:
                    Algorithms.Fill(buttons, int.Parse(coor[0, 0]), int.Parse(coor[0, 1]));
                    break;
                case 3:
                    break;

            }
        }

        static private int SendActiveButton()
        {
            int i = 0;
            while (i < ActiveButton.Length && !ActiveButton[i])
            {
                i++;
            }
            return i;
        }
    }
}
