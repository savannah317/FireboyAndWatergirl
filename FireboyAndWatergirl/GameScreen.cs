using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace FireboyAndWatergirl
{
    public partial class GameScreen : UserControl
    {
        Player fireboy, watergirl;

        bool wDown, aDown, dDown, upDown, leftDown, rightDown = false;

        public static int x, y, gsWidth, gsHeight, width, height, ySpeed, timer, score;
        public static string id, type, fDirection, wDirection;
        public static bool fJump, wJump, fAble, wAble, fFall, wFall = false;


        List<Obstacle> obstacles = new List<Obstacle>();
        List<Wall> walls = new List<Wall>();
        List<Wall> platforms = new List<Wall>();

        Wall floor, left, right, roof, fCollided, wCollided;
        Obstacle fbDoor, wgDoor;


        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush blueBrush = new SolidBrush(Color.Blue);
        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush grayBrush = new SolidBrush(Color.Gray);

        public GameScreen()
        {
            InitializeComponent();
            InitializeGame();
        }

        public void InitializeGame()
        {
            gsWidth = this.Width;
            gsHeight = this.Height;

            timer = 0;

            //player 1 exists
            fireboy = new Player("fb", 600, GameScreen.gsHeight - 80 - 20, 50);
            fAble = true;

            //player 2 exists
            watergirl = new Player("wg", 400, GameScreen.gsHeight - 80 - 20, 50);
            wAble = true;

            //constant walls
            floor = new Wall(0, gsHeight - 20, gsWidth, 20);
            platforms.Add(floor);
            left = new Wall(0, 0, 20, gsHeight);
            walls.Add(left);
            right = new Wall(gsWidth - 20, 0, 20, gsHeight);
            walls.Add(right);
            roof = new Wall(0, 0, gsWidth, 20);
            platforms.Add(roof);

            //update the last collided platform to floor
            fCollided = floor;
            wCollided = floor;

            LevelReader(Form1.currentLevel);
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upDown = false;
                    break;
                case Keys.Right:
                    rightDown = false;
                    break;
                case Keys.Left:
                    leftDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.W:
                    wDown = false;
                    break;
            }
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftDown = true;
                    break;
                case Keys.Right:
                    rightDown = true;
                    break;
                case Keys.Up:
                    if (wAble)
                    {
                        upDown = true;
                        wJump = true;
                    }
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.W:
                    if (fAble)
                    {
                        wDown = true;
                        fJump = true;
                    }
                    break;
                case Keys.Escape:
                    Application.Exit();
                    break;
            }
        }

        #region Level Reader
        public void LevelReader(int levelNumber)
        {
            Random random = new Random();

            string path = "Resources/level" + levelNumber + ".xml";
            XmlReader reader = XmlReader.Create(path);


            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                {
                    x = Convert.ToInt32(reader.ReadString());

                    reader.ReadToNextSibling("y");
                    y = Convert.ToInt32(reader.ReadString());

                    reader.ReadToNextSibling("width");
                    width = Convert.ToInt32(reader.ReadString());

                    reader.ReadToNextSibling("height");
                    height = Convert.ToInt32(reader.ReadString());

                    reader.ReadToNextSibling("type");
                    type = reader.ReadString();

                    if (type == "water")
                    {
                        //Create a new obstacle
                        Obstacle newObstacle = new Obstacle(type, x, y, width, height);
                        obstacles.Add(newObstacle);
                    }
                    if (type == "lava")
                    {
                        //Create a new obstacle
                        Obstacle newObstacle = new Obstacle(type, x, y, width, height);
                        obstacles.Add(newObstacle);
                    }
                    if (type == "goo")
                    {
                        //Create a new obstacle
                        Obstacle newObstacle = new Obstacle(type, x, y, width, height);
                        obstacles.Add(newObstacle);
                    }
                    if (type == "wall")
                    {
                        //create a new wall
                        Wall newWall = new Wall(x, y, width, height);
                        walls.Add(newWall);
                    }
                    if (type == "platform")
                    {
                        //create a new platforms
                        Wall newWall = new Wall(x, y, width, height);
                        platforms.Add(newWall);
                    }
                    if (type == "wg")
                    {
                        //create a door
                        Obstacle wDoor = new Obstacle(type, x, y, width, height);
                        wgDoor = wDoor;
                    }
                    if (type == "fb")
                    {
                        //create a door
                        Obstacle fDoor = new Obstacle(type, x, y, width, height);
                        fbDoor = fDoor;
                    }
                }
            }
        }

        #endregion

        public void Death()
        {
            gameTimer.Stop();
            Form1.ChangeScreen(this, new DeathScreen());
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            timer++;
            timerLabel.Text = Convert.ToString(timer / 30);

            #region Movements
            //watergirl movements
            if (leftDown == true && watergirl.x > 20)
            {
                wDirection = "l";
                watergirl.Move("left");
            }
            if (rightDown == true && watergirl.x < gsWidth - 20)
            {
                wDirection = "r";
                watergirl.Move("right");
            }
            if (upDown == true)
            {
                watergirl.ySpeed = 50;
                wAble = false;
                upDown = false;
            }
            if (wJump == true)
            {
                wDirection = "up";
                watergirl.Move("up");
            }
            if (watergirl.y <= 0)
            {
                watergirl.Move("down");
            }

            //fireboy movements
            if (aDown == true && fireboy.x > 20)
            {
                fDirection = "l";
                fireboy.Move("left");
            }
            if (dDown == true && fireboy.x < gsWidth - 20)
            {
                fDirection = "r";
                fireboy.Move("right");
            }
            if (wDown == true)
            {
                fireboy.ySpeed = 50;
                fAble = false;
                wDown = false;
            }
            if (fJump == true)
            {
                fDirection = "up";
                fireboy.Move("up");
            }
            if (fireboy.y <= 0)
            {
                fireboy.Move("down");
            }
            #endregion

            #region Collisions

            //fireboy platform collisions
            foreach (Wall p in platforms)
            {
                if (fireboy.WallCollision(p))
                {
                    fCollided = p;
                    if (fDirection == "up")
                    {
                        if (fireboy.y > p.y)
                        {
                            fireboy.y = p.y + fireboy.playerHeight;
                        }
                        if (fireboy.y < p.y)
                        {
                            fAble = true;
                            fJump = false;
                            fireboy.y = p.y - fireboy.playerHeight;
                        }
                    }
                    if (fFall)
                    {
                        if (fireboy.y < fCollided.y)
                        {
                            fAble = true;
                            fJump = false;
                            fireboy.y = p.y - fireboy.playerHeight;
                        }
                    }
                }
                if (fDirection == "r")
                {
                    if (fJump == false)
                    {
                        if (fireboy.x > fCollided.x + fCollided.xSize)
                        {
                            if (fireboy.WallCollision(p) == false)
                            {
                                fireboy.ySpeed = 5;
                                fFall = true;
                                fireboy.Move("down");
                            }

                        }
                    }
                }
                if (fDirection == "l")
                {
                    if (fJump == false)
                    {
                        if (fireboy.x < fCollided.x)
                        {
                            if (fireboy.WallCollision(p) == false)
                            {
                                fireboy.ySpeed = 5;
                                fFall = true;
                                fireboy.Move("down");
                            }
                        }
                    }
                }

                if (watergirl.WallCollision(p))
                {
                    wCollided = p;
                    if (wDirection == "up")
                    {
                        if (watergirl.y > p.y)
                        {
                            watergirl.y = p.y + watergirl.playerHeight;
                        }
                        if (watergirl.y < p.y)
                        {
                            wAble = true;
                            wJump = false;
                            watergirl.y = p.y - watergirl.playerHeight;
                        }
                    }
                    if (wFall)
                    {
                        if (watergirl.y < wCollided.y)
                        {
                            wAble = true;
                            wJump = false;
                            watergirl.y = p.y - watergirl.playerHeight;
                        }
                    }
                }
                if (wDirection == "r")
                {
                    if (wJump == false)
                    {
                        if (watergirl.x > wCollided.x + wCollided.xSize)
                        {
                            if (watergirl.WallCollision(p) == false)
                            {
                                watergirl.ySpeed = 5;
                                wFall = true;
                                watergirl.Move("down");
                            }

                        }
                    }
                }
                if (wDirection == "l")
                {
                    if (wJump == false)
                    {
                        if (watergirl.x < wCollided.x)
                        {
                            if (watergirl.WallCollision(p) == false)
                            {
                                watergirl.ySpeed = 5;
                                wFall = true;
                                watergirl.Move("down");
                            }
                        }
                    }
                }
            }
            foreach (Wall w in walls)
            {
                //fireboy wall collisions
                if (fireboy.WallCollision(w))
                {
                    if (fireboy.x > w.x)
                    {
                        fireboy.x = w.x + 20;
                    }
                    if (fireboy.x < w.x)
                    {
                        fireboy.x = w.x - fireboy.playerWidth;
                    }
                }
                //watergirl wall collisions
                if (watergirl.WallCollision(w))
                {
                    if (watergirl.x > w.x)
                    {
                        watergirl.x = w.x + 20;
                    }
                    if (watergirl.x < w.x)
                    {
                        watergirl.x = w.x - watergirl.playerWidth;
                    }
                }
            }

            foreach (Obstacle o in obstacles)
            {
                if (fireboy.Collision(o))
                {
                    if (o.obstacleType == "water")
                    {
                        Death();
                    }
                    if (o.obstacleType == "goo")
                    {
                        Death();
                    }
                }
                if (watergirl.Collision(o))
                {
                    if (o.obstacleType == "goo")
                    {
                        Death();
                    }
                    if (o.obstacleType == "lava")
                    {
                        Death();
                    }
                }
            }


            if (fireboy.DoorCollision(fbDoor) && watergirl.DoorCollision(wgDoor))
            {
                gameTimer.Stop();
                score = timer;
                Form1.ChangeScreen(this, new WinScreen());
            }

            #endregion

            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //draw players
            e.Graphics.FillRectangle(redBrush, fireboy.x, fireboy.y, fireboy.playerWidth, fireboy.playerHeight);
            e.Graphics.FillRectangle(blueBrush, watergirl.x, watergirl.y, watergirl.playerWidth, watergirl.playerHeight);

            //draw base walls
            foreach (Wall w in walls)
            {
                e.Graphics.FillRectangle(grayBrush, w.x, w.y, w.xSize, w.ySize);
            }
            foreach (Wall p in platforms)
            {
                e.Graphics.FillRectangle(grayBrush, p.x, p.y, p.xSize, p.ySize);
            }

            e.Graphics.FillRectangle(blueBrush, wgDoor.x, wgDoor.y, wgDoor.xSize, wgDoor.ySize);
            e.Graphics.FillRectangle(redBrush, fbDoor.x, fbDoor.y, fbDoor.xSize, fbDoor.ySize);

            foreach (Obstacle o in obstacles)
            {
                if (o.obstacleType == "water")
                {
                    e.Graphics.FillRectangle(blueBrush, o.x, o.y, o.xSize, o.ySize);
                }
                if (o.obstacleType == "lava")
                {
                    e.Graphics.FillRectangle(redBrush, o.x, o.y, o.xSize, o.ySize);
                }
                if (o.obstacleType == "goo")
                {
                    e.Graphics.FillRectangle(greenBrush, o.x, o.y, o.xSize, o.ySize);
                }
            }
        }
    }
}
