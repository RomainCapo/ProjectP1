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
        int jeu = -1;

        PlayDames damesGame;
        DetectionImageMaze diMaze;
        DetectionImageMorpion diMorpion;
        DetectionImageDames diDames;

        public Menu _menu = null;


        private void Form1_Load(object sender, EventArgs e)
        {
            robotXY = new Robot(this, iSizeX, iSizeY);
            //diDames = new DetectionImageDames(this);
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
            if(jeu == 0)
            {
                diMorpion.Debug();
            }
            if(jeu == 1)
            {
                diMaze.PrintScreen();
            }
        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this._menu.Show(); 
        }

        private void numericX_ValueChanged(object sender, EventArgs e)
        {
            if(jeu == 0)
            {
                diMorpion.Debug();
            }
            if(jeu == 1)
            {
                diMaze.Debug();
            }
        }

        private void numericY_ValueChanged(object sender, EventArgs e)
        {
            if (jeu == 0)
            {
                diMorpion.Debug();
            }
            if (jeu == 1)
            {
                diMaze.Debug();
            }
        }

        private void numericWidth_ValueChanged(object sender, EventArgs e)
        {
            if (jeu == 0)
            {
                diMorpion.Debug();
            }
            if (jeu == 1)
            {
                diMaze.Debug();
            }
        }

        private void numericHeight_ValueChanged(object sender, EventArgs e)
        {
            if (jeu == 0)
            {
                diMorpion.Debug();
            }
            if (jeu == 1)
            {
                diMaze.Debug();
            }
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
                diMorpion = new DetectionImageMorpion(this);
                ticTacToeGame = new PlayTicTacToe(this, robotXY, diMorpion, iSizeX, iSizeY);
                this.Text = "Morpion";
                
                jeu = 0;
            }
            if(num==1)
            {
                Reset();
                diMaze = new DetectionImageMaze(this);
                mazeGame = new PlayMaze(this, robotXY, iSizeX, iSizeY);
                this.Text = "Labyrinthe";
                
                jeu = 1;
            }
        }

        
    }
}
