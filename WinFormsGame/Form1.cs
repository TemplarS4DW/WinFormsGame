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
        private int currentAnimFrame = 0;
        public Form1()
        {
            InitializeComponent();
            playerImage = new Bitmap("yukari.png");
            timer1.Interval = 100;
            timer1.Tick += new EventHandler(update);
            timer1.Start();
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
            Image part = new Bitmap(96, 256);
            pictureBox2.Image = playerImage;
            Graphics graph = Graphics.FromImage(part);
            graph.DrawImage(playerImage, 0, 0, new Rectangle(new Point(31 * currentAnimFrame, 0), new Size(31, 92)), GraphicsUnit.Pixel);
            pictureBox2.Size = new Size(50, 92);
            pictureBox2.Image = part;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
