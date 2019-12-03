using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacMan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Key_Down(object sender, KeyEventArgs e)//movement w/ bounds
        {
            int x, y, d;
            d = 0;
            x = pac.Location.X;
            y = pac.Location.Y;

            if (e.KeyCode == Keys.Down) { y += 3; d = 1; }
            if (e.KeyCode == Keys.Up) { y -= 3; d = 2; }
            if (e.KeyCode == Keys.Left) { x -= 3; d = 3; }
            if (e.KeyCode == Keys.Right) { x += 3; d = 4; }

            if ( check_direction(x, y, d))
            {
                pac.Location = new Point(x, y);
                //call New_Score send in location
            }
        }

        private void Key_Up(object sender, KeyEventArgs e)
        {
        }

        bool check_direction(int _x, int _y, int _d)
        {
            if (_x > 18 && _x < 405 && _y < 218 && _y > 21)
            {
                if (_d == 1 || _d == 2)//vertical
                {
                    if (_x > 130 && _x < 133) //left of pen
                        return true;
                    else if (_x > 290 && _x < 293) //right of pen
                        return true;
                    else if (_x > 65 && _x < 68 && _y > 69 && _y < 169 || _x > 354 && _x < 358 && _y > 69 && _y < 169) //left inside rec || right inside rec
                        return true;
                    else if (_x < 23 || _x > 399 && _x < 405) //far left || far right
                        return true;
                    else if (_x > 86 && _x < 90 && _y < 72 || _x > 86 && _x < 90 && _y > 163) //left small verticals
                        return true;
                    else if (_x > 330 && _x < 339 && _y < 72 || _x > 330 && _x < 339 && _y > 163) //right small verticals
                        return true;
                    else
                        return false;
                }
                else if (_d == 3 || _d == 4)//horizontal
                {
                    if (_y < 169 && _y > 163 && _x > 63 && _x < 358 || _y < 72 && _y > 69 && _x > 63 && _x < 358) //below pen || above pen
                        return true;
                    else if (_x > 130 && _x < 293 && _y > 215 || _x > 130 && _x < 293 && _y < 24) //bottom inside box || top inside box
                        return true;
                    else if (_y > 117 && _y < 121 && _x > 290 || _y > 117 && _y < 121 && _x < 133) //middle right of pen || left
                        return true;
                    else if (_x < 88 && _y < 24 || _x > 330 && _y < 24) //very top left || right
                        return true;
                    else if (_x < 88 && _y > 215 || _x > 330 && _y > 215) //very bottom
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }
    }

   /* public class Score
    {
        int score = 0;

        public void New_Score(object pac)
        {
            int x = pac.Location.X;
        }
    }*/
}
