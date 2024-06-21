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
        //players exist
        Player fireboy, watergirl;

        //buttons are not pressed by default
        bool wDown, aDown, dDown, upDown, leftDown, rightDown = false;

        //variables for game function
        public static int x, y, gsWidth, gsHeight, width, height, ySpeed, timer, score;
        public static string id, type, fDirection, wDirection, wXDirection, fXDirection;

        //players are neither jumping, in the air, or falling by default
        public static bool fJump, wJump, fAble, wAble, fFall, wFall = false;

        //creating obstacle wall and platform variables
        List<Obstacle> obstacles = new List<Obstacle>();
        List<Wall> walls = new List<Wall>();
        List<Wall> platforms = new List<Wall>();

        Wall floor, left, right, roof, fCollided, wCollided;
        Obstacle fbDoor, wgDoor;

        //create colour brushes
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
            //set game screen width and height variables to the width and height
            gsWidth = this.Width;
            gsHeight = this.Height;

            timer = 0;

            //players are able to jump
            fAble = true;
            wAble = true;

            //so that they are facing the right way
            wDirection = "start";
            fDirection = "start";

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

            //sets the current level
            LevelReader(Form1.currentLevel);
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                //keys are not pressed
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
                //watergirl movements
                case Keys.Left:
                    wXDirection = "l";
                    leftDown = true;
                    break;
                case Keys.Right:
                    wXDirection = "r";
                    rightDown = true;
                    break;
                case Keys.Up:
                    //allow up arrow to be pressed when player is able to jump
                    if (wAble)
                    {
                        wXDirection = "u";
                        upDown = true;
                        wJump = true;
                    }
                    break;
                    //fireboy movements
                case Keys.A:
                    fXDirection = "l";
                    aDown = true;
                    break;
                case Keys.D:
                    fXDirection = "r";
                    dDown = true;
                    break;
                case Keys.W:
                    //allow w to be pressed when player is able to jump
                    if (fAble)
                    {
                        fXDirection = "u";
                        wDown = true;
                        fJump = true;
                    }
                    break;
                    //pause game
                case Keys.Escape:
                    
                    break;
            }
        }

        #region Level Reader
        public void LevelReader(int levelNumber)
        {
            //create the level based on information from specific xml file based on level number
            string path = "Resources/level" + levelNumber + ".xml";
            XmlReader reader = XmlReader.Create(path);

            //gather info from xml
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

                    if (type == "playerF")
                    {
                        fireboy = new Player("fb", x, y);
                    }
                    if (type == "playerW")
                    {
                        watergirl = new Player("wg", x, y);
                    }
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
            //stop the game
            gameTimer.Stop();
            Form1.ChangeScreen(this, new DeathScreen());
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //increase the time every second and display
            timer++;
            timerLabel.Text = Convert.ToString(timer / 30);

            #region Movements
            //watergirl movements
            //left
            if (leftDown == true && watergirl.x > 20)
            {
                wDirection = "l";
                watergirl.Move("left");
            }
            //move right
            if (rightDown == true && watergirl.x < gsWidth - 20)
            {
                wDirection = "r";
                watergirl.Move("right");
            }
            //jump
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
            //fall if in the ceiling
            if (watergirl.y <= 0)
            {
                watergirl.Move("down");
            }

            //fireboy movements
            //left
            if (aDown == true && fireboy.x > 20)
            {
                fDirection = "l";
                fireboy.Move("left");
            }
            //move right
            if (dDown == true && fireboy.x < gsWidth - 20)
            {
                fDirection = "r";
                fireboy.Move("right");
            }
            //jump
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
            //fall if in the ceiling
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
                            fireboy.ySpeed = 0;
                            fireboy.y = p.y + p.ySize;
                            fFall = true;
                        }
                        if (fireboy.y < p.y)
                        {
                            fireboy.ySpeed = 0;
                            fAble = true;
                            fJump = false;
                            fireboy.y = p.y - fireboy.playerHeight;
                        }
                    }
                    if (fFall)
                    {
                        if (fireboy.y < fCollided.y)
                        {
                            fireboy.ySpeed = 0;
                            fAble = true;
                            fJump = false;
                            fireboy.y = p.y - fireboy.playerHeight;
                        }
                    }

                }
                if (fDirection == "r")
                {
                    fXDirection = "r";
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
                    fXDirection = "l";
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
                //watergirl platform collisions
                if (watergirl.WallCollision(p))
                {
                    wCollided = p;
                    if (wDirection == "up")
                    {
                        if (watergirl.y > p.y)
                        {
                            watergirl.ySpeed = 0;
                            watergirl.y = p.y + p.ySize;
                            wFall = true;
                        }
                        if (watergirl.y < p.y)
                        {
                            watergirl.ySpeed = 0;
                            wAble = true;
                            wJump = false;
                            watergirl.y = p.y - watergirl.playerHeight;
                        }
                    }
                    if (wFall)
                    {
                        if (watergirl.y < wCollided.y)
                        {
                            watergirl.ySpeed = 0;
                            wAble = true;
                            wJump = false;
                            watergirl.y = p.y - watergirl.playerHeight;
                        }
                    }
                }
                if (wDirection == "r")
                {
                    wXDirection = "r";
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
                    wXDirection = "l";
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
                        fireboy.x = w.x + 30;
                    }
                    if (fireboy.x < w.x)
                    {
                        fireboy.x = w.x - fireboy.playerWidth;
                    }
                }
                //watergirl wall collisions
                if (watergirl.WallCollision(w))
                {
                    if (wXDirection == "l")
                    {
                        watergirl.x = w.x + 30;
                    }
                    if (wXDirection == "r")
                    {
                        watergirl.x = w.x - watergirl.playerWidth - 10;
                    }
                }
            }

            foreach (Obstacle o in obstacles)
            {
                //fireboy obstacle collisions
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
                //watergirl obstacle collisions
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
            //make sure players do not go out of bounds
            if (watergirl.x >= gsWidth)
            {
                watergirl.x = gsWidth - 30;
            }
            if (fireboy.x >= gsWidth)
            {
                fireboy.x = gsWidth - 30;
            }

            //make players stop at their doors
            if (fireboy.DoorCollision(fbDoor))
            {
                fXDirection = "no";

            }

            //end the game if both players are in contact with their corresponding door
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
            e.Graphics.DrawImage(Properties.Resources.stones, 0, 0, gsWidth, gsHeight);
            //draw doors
            e.Graphics.DrawImage(Properties.Resources.fireDoor, fbDoor.x, fbDoor.y, fbDoor.xSize, fbDoor.ySize);
            e.Graphics.DrawImage(Properties.Resources.waterDoor, wgDoor.x, wgDoor.y, wgDoor.xSize, wgDoor.ySize);

            //draw players
            //watergirl
            if (wXDirection == "r")
            {
                e.Graphics.DrawImage(Properties.Resources.wgRight, watergirl.x - 30, watergirl.y + 10);
            }
            else if (wXDirection == "l")
            {
                e.Graphics.DrawImage(Properties.Resources.wgLeft, watergirl.x - 30, watergirl.y + 10);
            }
            else 
            {
                e.Graphics.DrawImage(Properties.Resources.watergirl, watergirl.x - 20, watergirl.y);
            }

            //draw fireboy
            if (fDirection == "r")
            {
                e.Graphics.DrawImage(Properties.Resources.fbRight, fireboy.x - 40, fireboy.y + 20);
            }
            else if (fDirection == "l")
            {
                e.Graphics.DrawImage(Properties.Resources.fbLeft, fireboy.x, fireboy.y + 20);
            }
            else
            {
                e.Graphics.DrawImage(Properties.Resources.fireboy, fireboy.x - 20, fireboy.y);
            }

            //draw base walls and platforms
            foreach (Wall w in walls)
            {
                e.Graphics.DrawImage(Properties.Resources.caveTextureVert, w.x, w.y, w.xSize, w.ySize);
                if (w.ySize > 500)
                {
                    e.Graphics.DrawImage(Properties.Resources.caveTextureVert, w.x, w.y + 500, w.xSize, w.ySize - 500);
                }
            }
            foreach (Wall p in platforms)
            {
                e.Graphics.DrawImage(Properties.Resources.caveTexture, p.x, p.y, p.xSize, p.ySize);
                if (p.xSize > 500)
                {
                    e.Graphics.DrawImage(Properties.Resources.caveTexture, p.x + 500, p.y, p.xSize - 500, p.ySize);
                }
            }

            //draw obstacles
            foreach (Obstacle o in obstacles)
            {
                if (o.obstacleType == "water")
                {
                    e.Graphics.DrawImage(Properties.Resources.water, o.x, o.y, o.xSize, o.ySize);
                }
                if (o.obstacleType == "lava")
                {
                    e.Graphics.DrawImage(Properties.Resources.lava, o.x, o.y, o.xSize, o.ySize);
                }
                if (o.obstacleType == "goo")
                {
                    e.Graphics.DrawImage(Properties.Resources.greenGoo, o.x, o.y, o.xSize, o.ySize);
                }
            }
        }
    }
}
