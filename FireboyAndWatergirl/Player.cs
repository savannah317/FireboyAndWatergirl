﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FireboyAndWatergirl
{
    internal class Player
    {
        string playerType;
        public int x, y;
        public int playerWidth = 30;
        public int playerHeight = 80;
        public static int ySpeed = 30;
        public int xSpeed = 14;
        public int counter = 0;

        public Player(string playerType, int x, int y)
        { 
            this.playerType = playerType;
            this.x = x;
            this.y = y;
        }
        
        public void Move(string direction)
        {
            
            if (direction == "left")
            {
                x -= xSpeed;
            }
            if (direction == "right")
            {
                x += xSpeed;
            }
            if (direction == "up")
            {
                y -= ySpeed;
                ySpeed -= 5;
            }
            if (direction == "down")
            {
                y += ySpeed;
                ySpeed += 5;
            }
            if (direction == "no")
            {
                ySpeed = 0;
                y += ySpeed;
            }
        }

        public bool WallCollision(Wall w, string direction)
        {
            Rectangle playerRec = new Rectangle(x, y, playerWidth, playerHeight);
            Rectangle wallRec = new Rectangle(w.x, w.y, w.xSize, w.ySize);

            if (playerRec.IntersectsWith(wallRec))
            {
                return true;
            }

            return false;
        }

        public bool Collision(Obstacle o, string playerType)
        {
            Rectangle playerRec = new Rectangle(x, y, playerWidth, playerHeight);
            Rectangle obstacleRec = new Rectangle(o.x, o.y, o.xSize, o.ySize);

            if (playerRec.IntersectsWith(obstacleRec))
            {
                return true;
            }

            return false;
        }
    }
}
