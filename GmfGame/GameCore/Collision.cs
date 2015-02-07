using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GmfGame.GameCore
{
    public static class Collision
    {
        public static bool BirdAndWall(Bird bird, Wall wall)
        {
            if (bird.Position.X + bird.Size.Width / 2f < wall.X - wall.Width / 2f
                || bird.Position.X - bird.Size.Width / 2f > wall.X + wall.Width / 2f)
                return false;

            return bird.Position.Y < wall.Smaller_Y || bird.Position.Y > wall.Larger_Y;
        }
    }
}
