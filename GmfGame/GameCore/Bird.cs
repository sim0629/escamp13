using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GmfGame.GameCore
{
    public class Bird
    {
        private SizeF size_img = new SizeF(85f, 90f);
        private SizeF size = new SizeF(65f, 50f);
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

        public void ApplyVelocity(SizeF velocity)
        {
            this.velocity = velocity;
        }

        public void Update()
        {
            position += velocity;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(GmfImage.bird, position.X - 0.5f * size_img.Width, position.Y - 0.5f * size_img.Height, size_img.Width, size_img.Height);
        }
    }
}
