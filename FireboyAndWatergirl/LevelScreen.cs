using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FireboyAndWatergirl
{
    public partial class LevelScreen : UserControl
    {
        public LevelScreen()
        {
            InitializeComponent();
        }

        private void level1Button_Click(object sender, EventArgs e)
        {
            Form1.currentLevel = 1;
            Form1.ChangeScreen(this, new GameScreen());
        }

        private void level2Button_Click(object sender, EventArgs e)
        {
            Form1.currentLevel = 2;
            Form1.ChangeScreen(this, new GameScreen());
        }

        private void level3Button_Click(object sender, EventArgs e)
        {
            Form1.currentLevel = 3;
            Form1.ChangeScreen(this, new GameScreen());
        }

        private void level4Button_Click(object sender, EventArgs e)
        {
            Form1.currentLevel = 4;
            Form1.ChangeScreen(this, new GameScreen());
        }

        private void level5Button_Click(object sender, EventArgs e)
        {
            Form1.currentLevel = 5;
            Form1.ChangeScreen(this, new GameScreen());
        }

        private void level6Button_Click(object sender, EventArgs e)
        {
            Form1.currentLevel = 6;
            Form1.ChangeScreen(this, new GameScreen());
        }

        private void level7Button_Click(object sender, EventArgs e)
        {
            Form1.currentLevel = 7;
            Form1.ChangeScreen(this, new GameScreen());
        }

        private void level8Button_Click(object sender, EventArgs e)
        {
            Form1.currentLevel = 8;
            Form1.ChangeScreen(this, new GameScreen());
        }

        private void level9Button_Click(object sender, EventArgs e)
        {
            Form1.currentLevel = 9;
            Form1.ChangeScreen(this, new GameScreen());
        }
    }
}
