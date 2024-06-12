using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireboyAndWatergirl
{
    internal class Obstacle
    {
        public string obstacleType;
        public int x, y, xSize, ySize;

        public Obstacle(string obstacleType, int x, int y, int xSize, int ySize)
        {
            this.obstacleType = obstacleType;
            this.x = x;
            this.y = y;
            this.xSize = xSize;
            this.ySize = ySize;

            Rectangle hitbox = new Rectangle(x, y, xSize, ySize);
        }
    }
}
