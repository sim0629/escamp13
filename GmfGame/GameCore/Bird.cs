using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GmfGame.GameCore
{
    public class Bird
    {
        private SizeF size = new SizeF(60f, 60f);
        private PointF position;
        private SizeF velocity;

        public SizeF Size { get { return size; } }
        public PointF Position { get { return position; } }
        public SizeF Velocity { get { return velocity; } }

        public Bird(PointF initial_position)
        {
            position = initial_position;
            velocity = new SizeF();
        }

        public void ApplyForce(SizeF force)
        {
            velocity += force;
        }

        public void Update()
        {
            position += velocity;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(GmfImage.Get(0), position.X - 0.5f * size.Width, position.Y - 0.5f * size.Height, size.Width, size.Height);
        }
    }
}
