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

        public Bird Bird { get { return bird; } }

        public World()
        {
            bird = new Bird(new PointF(size.Width * 0.1f, size.Height * 0.5f));
            gravity = new SizeF(0f, 1f);
        }

        public void Update()
        {
            if (GmfKey.IsKeyPressed(Keys.Space))
            {
                bird.ApplyForce(new SizeF(0f, -4f));
            }
            bird.ApplyForce(gravity);
            bird.Update();
        }

        public void Draw(Graphics g)
        {
            bird.Draw(g);
        }
    }
}
