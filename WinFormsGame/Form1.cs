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
        private int currentAnimFrame = 2;
        private int currentAnimation = 1;
        private bool isPressedAnyKey = false;
        public Form1()
        {
            InitializeComponent();
            playerImage = new Bitmap("yukari.png");
            timer1.Interval = 150;
            timer1.Tick += new EventHandler(update);
            timer1.Start();
            this.KeyDown += new KeyEventHandler(keyboard);
            this.KeyUp += new KeyEventHandler(freeKey);
        }

        private void freeKey(object sender, KeyEventArgs e)
        {
            isPressedAnyKey = false;
            switch (e.KeyCode.ToString())
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
                    break; ;
            }
        }

        private void keyboard(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {

                case "A":
                    currentAnimation = 1;
                    isPressedAnyKey = true;
                    break;
                case "D":
                    currentAnimation = 2;
                    isPressedAnyKey = true;
                    break;
                case "S":
                    currentAnimation = 0;
                    isPressedAnyKey = true;
                    break;
                case "W":
                    currentAnimation = 3;
                    isPressedAnyKey = true;
                    break;
            }
        }

        private void update(object sender, EventArgs e)
        {
            if (isPressedAnyKey)
            {
                playAnimationMovement();
                currentAnimFrame++;
                if (currentAnimFrame > 2)
                    currentAnimFrame = 0;
            }
            else
            {
                currentAnimFrame = 1;
                playAnimationMovement();

            }
        }

        private void playAnimationMovement()
        {
            if (currentAnimation != -1 && currentAnimation <= 4)
            {
                Image part = new Bitmap(96, 256);
                pictureBox2.Image = playerImage;
                Graphics graph = Graphics.FromImage(part);
                graph.DrawImage(playerImage, 0, 0, new Rectangle(new Point(32 * currentAnimFrame, 64 * currentAnimation), new Size(32, 64)), GraphicsUnit.Pixel);
                pictureBox2.Size = new Size(50, 108);
                pictureBox2.Image = part;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
