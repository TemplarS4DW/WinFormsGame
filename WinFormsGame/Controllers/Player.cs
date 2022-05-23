using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsGame
{
    public enum moveDirection
    {
        Right = 0,
        Left = 1,
        Up = 2,
        Down = 3,
    }

    public class Player
    {
         //Эти координаты - позициия на экране, не в мире. Было бы хорошо засунуть их в одну структуру.
         public int x;
         public int y;
    }
}
