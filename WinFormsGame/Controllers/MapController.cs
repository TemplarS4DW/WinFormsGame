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
    //Произошёл взлом жопы
    public class MapController
    {
        public Bitmap mapImage;
        public int mapScale;
        public MapController(Bitmap mapImg, int mapScl)
        {
            mapImage = mapImg;
            mapScale = mapScl;
        }

        public bool checkCollision(Point point_high, Point point_low, moveDirection direction)
        {
            if (mapImage == null)
                return true;

            int heightDiff = 0;
            int widthDiff = 0;
            int scaled_x = 0;
            int scaled_y = 0;

            heightDiff = (point_high.Y - point_low.Y) / mapScale;
            widthDiff = -(point_high.X - point_low.X) / mapScale;
            scaled_x = -point_high.X / mapScale;
            scaled_y = -point_high.Y / mapScale;

            switch (direction)
            {
                case moveDirection.Left:
                    for (int i = 0; i < heightDiff; i++)
                    {
                        Color pixel = mapImage.GetPixel(scaled_x, scaled_y + i);
                        if (pixel.Name == "ff000000")
                            return true;
                    }
                    return false;
                case moveDirection.Right:
                    for (int i = 0; i < heightDiff; i++)
                    {
                        Color pixel = mapImage.GetPixel(scaled_x, scaled_y + i);
                        if (pixel.Name == "ff000000")
                            return true;
                    }
                    return false;
                case moveDirection.Up:
                    for (int i = 0; i < widthDiff; i++)
                    {
                        Color pixel = mapImage.GetPixel(scaled_x + i, scaled_y);
                        if (pixel.Name == "ff000000")
                            return true;
                    }
                    return false;
                case moveDirection.Down:
                    for (int i = 0; i < widthDiff; i++)
                    {
                        Color pixel = mapImage.GetPixel(scaled_x + i, scaled_y);
                        if (pixel.Name == "ff000000")
                            return true;
                    }
                    return false;

            }

            return false;
        }
    }
}
