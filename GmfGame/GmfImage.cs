using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GmfGame
{
    public class GmfImage
    {
        public static Bitmap background = new Bitmap("Image/background.png");
        public static Bitmap wall = new Bitmap("Image/wall.png");
        public static Bitmap wall_flip = new Bitmap("Image/wall_flip.png");
        public static Bitmap bird = new Bitmap("Image/bird.png");
        public static Bitmap die = new Bitmap("Image/die.png");

        static GmfImage()
        {
        }
    }
}
