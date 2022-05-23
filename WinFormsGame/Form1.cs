using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Forms;

namespace WinFormsGame
{
    public partial class Form1 : Form
    {
        static Bitmap playerImage = new Bitmap("yukari.png");
        static Bitmap mapImage = new Bitmap("floorandwall.png");

        Size playerSize = new Size(50, 90); //По совместительству - размер коллайдера
        static int mapScale = 3; //Увеличение карты

        Player player = new Player();
        MapController mapController = new MapController(mapImage, mapScale);

        private int currentAnimFrame = 2;
        private int currentAnimation = 1;
        private bool isPressedAnyKey = false;

        public Form1()
        {
            InitializeComponent();

            //Player
            playerBox.Image = playerImage;
            playerBox.BackColor = Color.Transparent; //Закомментируй, чтобы показать коллайдер игрока
            playerBox.Parent = BackgroundMap;
            playerBox.Size = playerSize;

            player.x = playerBox.Location.X;
            player.y = playerBox.Location.Y;

            //Map
            BackgroundMap.Image = mapImage;
            BackgroundMap.Location = new Point(0, 0);
            BackgroundMap.Size = mapImage.Size * mapScale;
            BackgroundMap.BackColor = Color.Black;
            BackgroundMap.SizeMode = PictureBoxSizeMode.StretchImage;

            this.BackColor = Color.Black; //Фон out-of-bounds
            //Timers and events
            timer2.Interval = 1;
            timer2.Tick += new EventHandler(updateMovement);
            timer1.Interval = 100;
            timer1.Tick += new EventHandler(update);
            timer1.Start();
            timer2.Start();
            this.KeyDown += new KeyEventHandler(keyboard);
            this.KeyUp += new KeyEventHandler(freeKey);
        }

        public void Init()
        {
           
        }
        
        private void updateMovement(object sender, EventArgs e)
        {
            if (isPressedAnyKey)
            {
                switch (currentAnimation)
                {
                    case 1:
                        if (mapController.checkCollision(new Point(BackgroundMap.Location.X - player.x, BackgroundMap.Location.Y - player.y - 1), new Point(BackgroundMap.Location.X - player.x, BackgroundMap.Location.Y - player.y - playerSize.Height + 1), moveDirection.Left))
                            return;
                        if (player.x <= 100)
                        {
                            BackgroundMap.Location = new Point(BackgroundMap.Location.X + 2, BackgroundMap.Location.Y);
                            playerBox.Location = new Point(playerBox.Location.X - 2, playerBox.Location.Y);
                        }
                        else
                        {
                            playerBox.Location = new Point(playerBox.Location.X - 2, playerBox.Location.Y);  //left
                            player.x -= 2;
                        }
                        break;
                    case 2:
                        if (mapController.checkCollision(new Point(BackgroundMap.Location.X - player.x - playerSize.Width, BackgroundMap.Location.Y - player.y - 1), new Point(BackgroundMap.Location.X - player.x - playerSize.Width, BackgroundMap.Location.Y - player.y - playerSize.Height + 1), moveDirection.Right))
                            return;
                        if (player.x + 42 >= this.Width - 100)
                        {
                            BackgroundMap.Location = new Point(BackgroundMap.Location.X - 2, BackgroundMap.Location.Y);
                            playerBox.Location = new Point(playerBox.Location.X + 2, playerBox.Location.Y);
                        }
                        else
                        {
                            playerBox.Location = new Point(playerBox.Location.X + 2, playerBox.Location.Y);  //right
                            player.x += 2;
                        }
                        break;
                    case 0:
                        if (mapController.checkCollision(new Point(BackgroundMap.Location.X - player.x - 1, BackgroundMap.Location.Y - player.y - playerSize.Height), new Point(BackgroundMap.Location.X - player.x + playerSize.Width - 1, BackgroundMap.Location.Y - player.y - playerSize.Height), moveDirection.Down))
                            return;
                        if (player.y + 100 >= this.Height - 50)
                        {
                            BackgroundMap.Location = new Point(BackgroundMap.Location.X, BackgroundMap.Location.Y - 2);
                            playerBox.Location = new Point(playerBox.Location.X, playerBox.Location.Y + 2);
                        }
                        else
                        {
                            playerBox.Location = new Point(playerBox.Location.X, playerBox.Location.Y + 2);  //down
                            player.y += 2;
                        }
                        break;
                    case 3:
                        if (mapController.checkCollision(new Point(BackgroundMap.Location.X - player.x - 1, BackgroundMap.Location.Y - player.y), new Point(BackgroundMap.Location.X - player.x + playerSize.Width - 1, BackgroundMap.Location.Y - player.y), moveDirection.Up))
                            return;
                        if (player.y <= 100)
                        {
                            BackgroundMap.Location = new Point(BackgroundMap.Location.X, BackgroundMap.Location.Y + 2);
                            playerBox.Location = new Point(playerBox.Location.X, playerBox.Location.Y - 2);
                        }
                        else
                        {
                            playerBox.Location = new Point(playerBox.Location.X, playerBox.Location.Y - 2);  //up
                            player.y -= 2;
                        }
                        break;
                }
            }
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
                    break;
                default:
                    currentAnimation = 5; //Idle
                    break;
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
                Graphics graph = Graphics.FromImage(part);
                graph.DrawImage(playerImage, 0, 0, new Rectangle(new Point(32 * currentAnimFrame, 64 * currentAnimation), new Size(32, 64)), GraphicsUnit.Pixel);
                playerBox.Image = part;
            }
        }
        
        //Фикс от дрожания(Херня, просаживает производительность в нули при большом окне)
        /*
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }
        */
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
