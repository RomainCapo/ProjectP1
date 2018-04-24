using Simulateur.classes;
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
        Bluetooth bluetooth;
        const int LARGEURROBOT = 320;
        const int HAUTEURROBOT = 388;
        PlayTicTacToe ticTacToeGame;
        PlayMaze mazeGame;

        private void Form1_Load(object sender, EventArgs e)
        {
            robotXY = new Robot(this);
            bluetooth = new Bluetooth();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }

        private void btnTicTacToe_Click(object sender, EventArgs e)
        {
            Reset();
            ticTacToeGame = new PlayTicTacToe(this, robotXY, LARGEURROBOT, HAUTEURROBOT);
        }

        private void btnMaze_Click(object sender, EventArgs e)
        {
            Reset();
            mazeGame = new PlayMaze(this, robotXY, LARGEURROBOT, HAUTEURROBOT);
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
        }

        private void btnResetSheet_Click(object sender, EventArgs e)
        {
            robotXY.RemoveDrawing();
        }
    }
}
