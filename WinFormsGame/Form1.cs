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
    public partial class Form1 : Form
    {
        Image playerImage;
        private int currentAnimFrame = 1;
        private int currentAnimation = -1;
        public Form1()
        {
            InitializeComponent();
            playerImage = new Bitmap("yukari.png");
            timer1.Interval = 200;
            timer1.Tick += new EventHandler(update);
            timer1.Start();
            this.KeyDown += new KeyEventHandler(keyboard);
        }

        private void keyboard(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode.ToString())
            {

                case "A":
                    currentAnimation = 1;
                    break;
                case "D":
                    currentAnimation = 2;
                    break;
                case "S":
                    currentAnimation = 0;
                    break;
                case "W":
                    currentAnimation = 3;
                    break;
            }
        }

        private void update(object sender, EventArgs e)
        {
            playAnimation();
            currentAnimFrame++;
            if (currentAnimFrame == 3)
                currentAnimFrame = 0;
        }

        private void playAnimation()
        {
            if (currentAnimation != -1)
            {
                Image part = new Bitmap(96, 256);
                pictureBox2.Image = playerImage;
                Graphics graph = Graphics.FromImage(part);
                graph.DrawImage(playerImage, 0, 0, new Rectangle(new Point(32 * currentAnimFrame, 64 * currentAnimation), new Size(31, 108)), GraphicsUnit.Pixel);
                pictureBox2.Size = new Size(50, 108);
                pictureBox2.Image = part;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
