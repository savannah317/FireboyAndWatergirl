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

namespace FireboyAndWatergirl
{
    public partial class GameScreen : UserControl
    {
        Player fireboy, watergirl;

        bool wDown, aDown, dDown, upDown, leftDown, rightDown = false;

        public static int x, y, width, height;
        public static string id, type, fDirection, wDirection;
        public static bool fJump, wJump, fAble, wAble = false;

        List<Obstacle> obstacles = new List<Obstacle>();
        List<Wall> walls = new List<Wall>();

        Wall floor, left, right, roof;
        Obstacle testWater, testLava;

        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush blueBrush = new SolidBrush(Color.Blue);

        public GameScreen()
        {
            InitializeComponent();
            InitializeGame();
        }

        public void InitializeGame()
        {
            width = this.Width;
            height = this.Height;

            //player 1 exists
            fireboy = new Player("fb", 600, GameScreen.height - 80 - 20);
            fAble = true;

            //player 2 exists
            watergirl = new Player("wg", 400, GameScreen.height - 80 - 20);
            wAble = true;

            floor = new Wall(0, height - 20, width, 20);
            walls.Add(floor);
            left = new Wall(0, 0, 20, height);
            walls.Add(left);
            right = new Wall(width - 20, 0, 20, height);
            walls.Add(right);
            roof = new Wall(0, 0, width, 20);
            walls.Add(roof);

            //make a list in the future
            testWater = new Obstacle("water", 900, height - 22, 100, 20);
            obstacles.Add(testWater);
            testLava = new Obstacle("lava", 700, height - 22, 100, 20);
            obstacles.Add(testLava);

            //LevelReader(Form1.currentLevel);
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

            string path = "Resources/Level" + levelNumber + ".xml";
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

                    reader.ReadToNextSibling("id");
                    id = reader.ReadString();

                    reader.ReadToNextSibling("type");
                    type = reader.ReadString();

                    if (type == "obstacle")
                    {
                        //Create a new obstacle
                        Obstacle newObstacle = new Obstacle(id, x, y, width, height);
                        obstacles.Add(newObstacle);
                    }
                    if (type == "wall")
                    {
                        Wall newWall = new Wall(x, y, width, height);
                        walls.Add(newWall);
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
            //watergirl movements
            if (leftDown == true && watergirl.x > 20)
            {
                wDirection = "l";
                watergirl.Move("left");
            }
            if (rightDown == true && watergirl.x < width - 20)
            {
                wDirection = "r";
                watergirl.Move("right");
            }
            if (upDown == true)
            {
                Player.ySpeed = 30;
                wAble = false;
                upDown = false;
            }
            if (wJump == true)
            {
                wDirection = "up";
                watergirl.Move("up");
            }

            //fireboy movements
            if (aDown == true && fireboy.x > 20)
            {
                fDirection = "l";
                fireboy.Move("left");
            }
            if (dDown == true && fireboy.x < width - 20)
            {
                fDirection = "r";
                fireboy.Move("right");
            }
            if (wDown == true)
            {
                Player.ySpeed = 30;
                fAble = false;
                wDown = false;
            }
            if (fJump == true)
            {
                fDirection = "up";
                fireboy.Move("up");
            }

            foreach (Wall w in walls)
            {
                //fireboy wall collisions
                if (fireboy.WallCollision(w, "fb"))
                {
                    if (fDirection == "up")
                    {
                        if (fireboy.y > w.y && fireboy.x > w.x)
                        {
                            fireboy.y = w.y + fireboy.playerHeight;
                            fireboy.Move("down");
                        }
                        if (fireboy.x < w.x)
                        {
                            fDirection = "r";
                        }
                        if (fireboy.y < w.y)
                        {
                            fAble = true;
                            fJump = false;
                            fireboy.Move("no");
                            fireboy.y = w.y - fireboy.playerHeight;
                        }
                    }
                    if (fDirection == "l")
                    {
                        fireboy.x = w.x + 21;
                    }
                    if (fDirection == "r")
                    {
                        fireboy.x = w.x - fireboy.playerWidth;
                    }
                }

                //watergirl wall collisions
                if (watergirl.WallCollision(w, "wg"))
                {
                    if (wDirection == "up")
                    {
                        if (watergirl.y > w.y && watergirl.x > w.x)
                        {
                            watergirl.y = w.y + watergirl.playerHeight;
                            watergirl.Move("down");
                        }
                        if (watergirl.x < w.x)
                        {
                            wDirection = "r";
                        }
                        if (watergirl.y < w.y)
                        {
                            wAble = true;
                            wJump = false;
                            watergirl.Move("no");
                            watergirl.y = w.y - watergirl.playerHeight;
                        }
                    }
                    if (wDirection == "l")
                    {
                        watergirl.x = w.x + 21;
                    }
                    if (wDirection == "r")
                    {
                        watergirl.x = w.x - watergirl.playerWidth;
                    }
                }
            }


            //watergirl obstacle collisions

            //fireboy obstacle collisions
            foreach (Obstacle o in obstacles)
            {
                if (fireboy.Collision(o, "fb"))
                {
                    if (o.obstacleType == "water")
                    {
                        Death();
                    }
                    if (o.obstacleType == "goo")
                    {
                        Death();
                    }
                    if (o.obstacleType == "lava")
                    {

                    }
                }
                if (watergirl.Collision(o, "wg"))
                {
                    if (o.obstacleType == "water")
                    {

                    }
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
                e.Graphics.FillRectangle(redBrush, w.x, w.y, w.xSize, w.ySize);
            }

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

                }
            }

            //draw obstacles (make list soon)
            e.Graphics.FillRectangle(blueBrush, testWater.x, testWater.y, testWater.xSize, testWater.ySize);
        }
    }
}
