using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GmfGame.GameCore
{
    public class Map
    {
        private long frames_per_wall = 150;
        private long frame_count;
        private List<Wall> walls = new List<Wall>();
        private Random random = new Random();
        private const float WALL_VELOCITY = 2f;

        public List<Wall> Walls { get { return walls; } }

        public Map()
        {
        }

        private Wall GenerateWall()
        {
            var len = 0.5f;
            var pos = (float)random.NextDouble();
            pos = pos * (1f - len) + len / 2f;
            return new Wall(Constant.WIDTH, (pos - len / 2f) * Constant.HEIGHT, (pos + len / 2f) * Constant.HEIGHT);
        }

        public void Update()
        {
            if (frame_count % (Math.Max(10, frames_per_wall - (10 * frame_count / 300))) == 0)
            {
                walls.Add(GenerateWall());
            }
            frame_count++;

            walls.RemoveAll(wall => wall.X < 0);

            foreach (var wall in walls)
            {
                wall.ApplyVelocity(-WALL_VELOCITY);
                wall.Update();
            }
        }

        public void Draw(Graphics g)
        {
            foreach (var wall in walls)
            {
                wall.Draw(g);
            }
        }
    }
}
