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
        PlayDames damesGame;

        private void Form1_Load(object sender, EventArgs e)
        {
            robotXY = new Robot(this, iSizeX, iSizeY);
        }

        private void btnTicTacToe_Click(object sender, EventArgs e)
        {
            Reset();
            ticTacToeGame = new PlayTicTacToe(this, robotXY, iSizeX, iSizeY);
        }

        private void btnMaze_Click(object sender, EventArgs e)
        {
            Reset();
            mazeGame = new PlayMaze(this, robotXY, iSizeX, iSizeY);
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
            if (damesGame != null)
            {
                damesGame.Remove();
                damesGame = null;
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

        private void btnDames_Click(object sender, EventArgs e)
        {
            Reset();
            damesGame = new PlayDames(this, robotXY, iSizeX, iSizeY);
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
    }
}
