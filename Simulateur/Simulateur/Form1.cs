using Simulateur.classes;
using Simulateur.classes.dames;
using Simulateur.classes.maze;
using Simulateur.classes.morpion;
using System;
using System.Windows.Forms;

namespace Simulateur
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Robot robotXY;
        int iSizeX = 200, iSizeY = 200;
        PlayTicTacToe ticTacToeGame;
        PlayMaze mazeGame;
        DetectionImageMorpion di;
        public Menu _menu = null;

        private void Form1_Load(object sender, EventArgs e)
        {
            robotXY = new Robot(this, iSizeX, iSizeY);
            di = new DetectionImageMorpion(this);
        }

        private void Reset()
        {
            if (ticTacToeGame != null)
            {
                ticTacToeGame.Remove();
                ticTacToeGame = null;
            }
            if (mazeGame != null)
            {
                mazeGame.Remove();
                mazeGame = null;
            }

            robotXY.RemoveDrawing();
        }

        private void btnCursorUp_Click(object sender, EventArgs e)
        {
            robotXY.PenUp();
        }

        private void btnCursorDown_Click(object sender, EventArgs e)
        {
            robotXY.PenDown();
        }

        private void btnPrintScreen_Click(object sender, EventArgs e)
        {
            di.debug();
        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this._menu.Show(); 
        }

        private void numericX_ValueChanged(object sender, EventArgs e)
        {
            di.debug();
        }

        private void numericY_ValueChanged(object sender, EventArgs e)
        {
            di.debug();
        }

        private void numericWidth_ValueChanged(object sender, EventArgs e)
        {
            di.debug();
        }

        private void numericHeight_ValueChanged(object sender, EventArgs e)
        {
            di.debug();
        }

        private void btnAppliquer_Click(object sender, EventArgs e)
        {
            try
            {
                iSizeX = Convert.ToInt32(numX.Value);
                iSizeY = Convert.ToInt32(numY.Value);
                lblSizeState.Text = "Appliqué !";
            }
            catch
            {
                iSizeX = 200;
                iSizeY = 200;
                numX.Value = 200;
                numY.Value = 200;
                lblSizeState.Text = "Erreur ...";
            }
        }

        public void ChoixJeu(int num)
        {
            if(num == 0)
            {
                Reset();
                ticTacToeGame = new PlayTicTacToe(this, robotXY, di, iSizeX, iSizeY);
                this.Text = "Morpion";
            }
            if(num==1)
            {
                Reset();
                mazeGame = new PlayMaze(this, robotXY, iSizeX, iSizeY);
                this.Text = "Labyrinthe";

            }
        }

        
    }
}
