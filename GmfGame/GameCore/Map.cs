using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GmfGame.GameCore
{
    public class Map
    {
        private int frame_count;
        private List<Wall> walls = new List<Wall>();
        private Random random = new Random();

        public List<Wall> Walls { get { return walls; } }

        public Map()
        {
        }

        private Wall GenerateWall()
        {
            var len = 0.3f;
            var pos = (float)random.NextDouble();
            pos = pos * (1f - len) + len / 2f;
            return new Wall(Constant.WIDTH, (pos - len / 2f) * Constant.HEIGHT, (pos + len / 2f) * Constant.HEIGHT);
        }

        public void Update()
        {
            if (frame_count % 1000 == 0)
            {
                walls.Add(GenerateWall());
            }
            frame_count++;

            walls.RemoveAll(wall => wall.X < 0);

            foreach (var wall in walls)
            {
                wall.ApplyVelocity(-1f);
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
