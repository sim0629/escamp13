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
        private SizeF size = new SizeF(GameCore.Constant.WIDTH, GameCore.Constant.HEIGHT);
        private Bird bird;
        private SizeF gravity;
        private Map map;

        public Bird Bird { get { return bird; } }

        public World()
        {
            bird = new Bird(new PointF(size.Width * 0.1f, size.Height * 0.5f));
            gravity = new SizeF(0f, 1f);
            map = new Map();
        }

        public bool Update()
        {
            if (GmfKey.IsKeyPressed(Keys.Space))
            {
                bird.ApplyForce(new SizeF(0f, -4f));
            }
            bird.ApplyForce(gravity);
            bird.Update();
            map.Update();

            if (bird.Position.Y < 0f || bird.Position.Y > size.Height)
                return false;

            return true;
        }

        public void Draw(Graphics g)
        {
            bird.Draw(g);
            map.Draw(g);
        }
    }
}
