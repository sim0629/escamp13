using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GmfGame
{
    public class GmfImage
    {
        public static Bitmap Get(int index)
        {
            if (index < 0 || index >= images.Length)
                return null;

            return images[index];
        }

        static Bitmap[] images = new Bitmap[20];

        static GmfImage()
        {
            using (Bitmap whole = new Bitmap("Image/items.png"))
            {
                for (int i = 0; i < images.Length; ++i)
                {
                    Bitmap b = new Bitmap(64, 64);
                    using (Graphics g = Graphics.FromImage(b))
                    {
                        Point sourcePoint = new Point((int)((64 + 236.0f / 9) * (i % 10)), 66 * (i / 10));
                        g.DrawImage(whole, new Rectangle(0, 0, 64, 64), new Rectangle(sourcePoint, new Size(64, 64)), GraphicsUnit.Pixel);
                        g.Flush();
                    }

                    images[i] = b;
                }
            }
        }        
    }
}
