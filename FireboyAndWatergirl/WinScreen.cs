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
    public partial class WinScreen : UserControl
    {
        public WinScreen()
        {
            InitializeComponent();

            BackgroundImage = Properties.Resources.bkgdFbWg;
            scoreOutput.Text = Convert.ToString(GameScreen.score) + "seconds";
            if (Form1.currentLevel == 3)
            {
                nextButton.Enabled = false;
                nextButton.Visible = false;
            }
            else
            {
                Form1.currentLevel++;
                Form1.completeLevel++;
            }
            
        }

        private void titleButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new MenuScreen());
        }

        private void levelButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new LevelScreen());
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
                Form1.ChangeScreen(this, new GameScreen());
        }
    }
}
