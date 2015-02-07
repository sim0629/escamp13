using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GmfGame.GameCore
{
    public class World
    {
        Font drawFont = new Font("Arial", 16);
        StringFormat drawFormat = new StringFormat();
        private long frame_count;
        private SizeF size = new SizeF(GameCore.Constant.WIDTH, GameCore.Constant.HEIGHT);
        private Bird bird;
        //private SizeF gravity;
        private Map map;

        public Bird Bird { get { return bird; } }

        public World()
        {
            drawFormat.Alignment = StringAlignment.Center;
            drawFormat.LineAlignment = StringAlignment.Center;
            bird = new Bird(new PointF(size.Width * 0.1f, size.Height * 0.5f));
            //gravity = new SizeF(0f, 0.5f);
            map = new Map();
        }

        private void ApplyPower()
        {
            if (Encored.Instance.IsOn)
            {
                bird.ApplyVelocity(new SizeF(0f, -2f));
            }
            else
            {
                bird.ApplyVelocity(new SizeF(0f, 2f));
            }
        }

        public bool Update()
        {
            ApplyPower();
            //bird.ApplyForce(gravity);
            bird.Update();
            map.Update();

            frame_count++;

            if (bird.Position.Y < 0f || bird.Position.Y > size.Height)
                return false;

            foreach (var wall in map.Walls)
                if (Collision.BirdAndWall(bird, wall))
                    return false;

            return true;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(GmfImage.background, 0, 0, GameCore.Constant.WIDTH, GameCore.Constant.HEIGHT);
            bird.Draw(g);
            map.Draw(g);
            g.DrawString(frame_count.ToString(), drawFont, Brushes.Black, new RectangleF(0, 0, 110, 45), drawFormat);
        }
    }
}
