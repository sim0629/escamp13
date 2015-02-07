using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GmfGame.GameCore
{
    public class Wall
    {
        private float smaller_y, larger_y;
        private float x;
        private float width = 20;
        private float v;

        public float X { get { return x; } }

        public Wall(float x, float smaller_y, float larger_y)
        {
            this.x = x;
            this.smaller_y = smaller_y;
            this.larger_y = larger_y;
        }

        public void ApplyVelocity(float v)
        {
            this.v = v;
        }

        public void Update()
        {
            x += v;
        }

        public void Draw(Graphics g)
        {
            var brush = Brushes.Black;
            g.FillRectangle(brush, x - 0.5f * width, 0, width, smaller_y);
            g.FillRectangle(brush, x - 0.5f * width, larger_y, width, Constant.HEIGHT);
        }
    }
}
