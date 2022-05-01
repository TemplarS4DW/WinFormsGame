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
        private int nowFrame = 0;
        public Form1()
        {
            InitializeComponent();
            playerImage = new Bitmap("C:\\Users\\TemplarS4DW\\Desktop\\Characters\\$yukari.png");
            timer1.Interval = 100;
            timer1.Tick += new EventHandler(update);
            timer1.Start();
        }

        private void update(object sender, EventArgs e)
        {
            playAnimation();
            nowFrame++;
        }

        private void playAnimation()
        {
            Image part = new Bitmap(48, 92);
            pictureBox1.Image = playerImage;
            Graphics graph = Graphics.FromImage(part);
            graph.DrawImage(playerImage, 0, 0, new Rectangle(new Point(0, 0), new Size(50 * nowFrame, 100)), GraphicsUnit.Pixel);
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.Image = part;
        }
    }
}
