using Simulateur.classes;
using Simulateur.classes.maze;
using Simulateur.classes.morpion;
using Simulateur.formes;
using System;
using System.Windows.Forms;

namespace Simulateur
{
    public partial class Form1 : Form
    {
        string strJeu;
        int parametre1;
        int parametre2;
        public Form1(string _strJeu, int _parametre1, int _parametre2)
        {
            InitializeComponent();
            strJeu = _strJeu;
            parametre1 = _parametre1;
            parametre2 = _parametre2;
        }

        Robot robotXY;
        Bluetooth bluetooth;
        const int LARGEURROBOT = 320;
        const int HAUTEURROBOT = 388;
        PlayTicTacToe ticTacToeGame;
        PlayMaze mazeGame;

        private void Form1_Load(object sender, EventArgs e)
        {
            btnExit.Left = this.Width - 30;
            btnExit.Top = 10;

            robotXY = new Robot(this);
            bluetooth = new Bluetooth();

            switch(strJeu)
            {
                case "Maze":
                    Reset();
                    mazeGame = new PlayMaze(this, robotXY, LARGEURROBOT, HAUTEURROBOT);
                    break;

                case "Tic-Tac-Toe":
                    Reset();
                    ticTacToeGame = new PlayTicTacToe(this, robotXY, LARGEURROBOT, HAUTEURROBOT);
                    break;

                case "Dame":
                    Reset();
                    break;

                default:
                    MessageBox.Show("une erreur s'est produite");
                    break;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Environment.Exit(Environment.ExitCode);
        }

        private void btnTicTacToe_Click(object sender, EventArgs e)
        {
            
        }

        private void btnMaze_Click(object sender, EventArgs e)
        {
            
        }

        private void Reset()
        {
            robotXY.RemoveDrawing();
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
        }

        private void btnResetSheet_Click(object sender, EventArgs e)
        {
            Reset();
            //MenuTicTacToe mttt = new MenuTicTacToe();
            this.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
