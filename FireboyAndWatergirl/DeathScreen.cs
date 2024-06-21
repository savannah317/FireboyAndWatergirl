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
    public partial class DeathScreen : UserControl
    {
        public DeathScreen()
        {
            InitializeComponent();
            BackgroundImage = Properties.Resources.bkgdFbWg;
        }

        private void backButton_Click(object sender, EventArgs e)
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

        private void replayButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new GameScreen());
        }
    }
}
