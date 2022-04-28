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
        public Form1()
        {
            InitializeComponent();
            Bitmap playerImage = new Bitmap("C:\\Users\\TemplarS4DW\\Desktop\\Characters\\$yukari.png");
            Image part = new Bitmap(32, 92);
            pictureBox1.Image = playerImage;
            Graphics graph = Graphics.FromImage(part);
            graph.DrawImage(playerImage, 0, 0, new Rectangle(new Point(0, 0), new Size(50, 100)), GraphicsUnit.Pixel);
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.Image = part;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
