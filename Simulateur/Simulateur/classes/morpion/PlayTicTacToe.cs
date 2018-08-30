using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulateur.classes.morpion
{
    class PlayTicTacToe
    {
        Form1 form;
        GroupBox gbTicTacToe;
        Robot robotXY;
        TicTacToe ticTacToe;
        Minmax ia;
        readonly double LENGTH;
        readonly double MARGIN;

        public PlayTicTacToe(Form1 _form,  Robot _robot, DetectionImage _di, double X, double Y)
        {
            form = _form;
            ticTacToe = new TicTacToe(_di);
            ia = new Minmax(2, 1);

            AddTicTacToeControls();

            robotXY = _robot;
            if(X <= Y)
            {
                LENGTH = X;
            }
            else
            {
                LENGTH = Y;
            }

            MARGIN = LENGTH / 3 * 0.1;

            DrawGrid();
        }

        public void Remove()
        {
            form.Controls.RemoveByKey("gbTicTacToe");
        }

        private void AddTicTacToeControls()
        {
            gbTicTacToe = new GroupBox();
            gbTicTacToe.Name = "gbTicTacToe";
            gbTicTacToe.Text = "TicTacToe";
            gbTicTacToe.Top = 420;
            gbTicTacToe.Left = 10;
            gbTicTacToe.Width = 150;

            NumericUpDown numX = new NumericUpDown();
            numX.Name = "numX";
            numX.Width = 50;
            numX.Left = 10;
            numX.Top = 20;
            numX.Maximum = 2;
            gbTicTacToe.Controls.Add(numX);

            NumericUpDown numY = new NumericUpDown();
            numY.Name = "numY";
            numY.Width = 50;
            numY.Left = 10;
            numY.Top = 43;
            numY.Maximum = 2;
            gbTicTacToe.Controls.Add(numY);

            Button btn = new Button();
            btn.Name = "btnPlace";
            btn.Text = "Placer";
            btn.Left = 9;
            btn.Top = 66;
            btn.Click += new EventHandler(Play);
            gbTicTacToe.Controls.Add(btn);

            form.Controls.Add(gbTicTacToe);
        }

        private bool DrawGrid()
        {
            try
            {
                robotXY.PenUp();
                robotXY.Move(LENGTH / 3, 0);
                robotXY.PenDown();
                robotXY.Move(LENGTH / 3, LENGTH);
                robotXY.PenUp();

                robotXY.Move(LENGTH / 3 * 2, LENGTH);
                robotXY.PenDown();
                robotXY.Move(LENGTH / 3 * 2, 0);
                robotXY.PenUp();

                robotXY.Move(LENGTH, LENGTH / 3);
                robotXY.PenDown();
                robotXY.Move(0, LENGTH / 3);
                robotXY.PenUp();

                robotXY.Move(0, LENGTH / 3 * 2);
                robotXY.PenDown();
                robotXY.Move(LENGTH, LENGTH / 3 * 2);
                robotXY.PenUp();

                robotXY.ResetPosition();

                return true;
            }
            catch
            {
                return false;
            }
        }

        private void Play(Object sender, EventArgs e)
        {
            DrawCross();
            if (ticTacToe.CheckGrid() == 0)
            {
                DrawCircle(ia.Play(ticTacToe.getGrid()));

                if (ticTacToe.CheckGrid() != 0)
                {
                    MessageBox.Show("Partie terminée");
                    Remove();
                }
            }
            else
            {
                if (ticTacToe.CheckGrid() != 0)
                {
                    MessageBox.Show("Partie terminée");
                    Remove();
                }
            }
        }

        private bool DrawCircle(Point pCell)
        {
            try
            {
                ticTacToe.PlaceCicle(pCell);

                double rayon = (LENGTH / 6 - MARGIN);
                double centerX = (LENGTH / 3 * pCell.X + LENGTH / 6);
                double centerY = (LENGTH / 3 * pCell.Y + LENGTH / 6);
                double convert = Math.PI / 180;

                robotXY.Move(centerX + rayon * Math.Cos(0), centerY + rayon * Math.Sin(0));
                robotXY.PenDown();
                for(int angle = 10; angle <= 360; angle += 20)
                {
                    robotXY.Move(centerX + rayon * Math.Cos(convert * angle), centerY + rayon * Math.Sin(convert * angle));
                }
                robotXY.Move(centerX + rayon * Math.Cos(0), centerY + rayon * Math.Sin(0));
                robotXY.PenUp();
                robotXY.ResetPosition();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool DrawCross()
        {
            try
            {
                Point pCell = ticTacToe.PlaceCross();

                /*robotXY.Move(LENGTH / 3 * pCell.X + MARGIN, LENGTH / 3 * pCell.Y + MARGIN);
                robotXY.PenDown();
                robotXY.Move(LENGTH / 3 * (pCell.X + 1) - MARGIN, LENGTH / 3 * (pCell.Y + 1) - MARGIN);
                robotXY.PenUp();

                robotXY.Move(LENGTH / 3 * (pCell.X + 1) - MARGIN, LENGTH / 3 * pCell.Y + MARGIN);
                robotXY.PenDown();
                robotXY.Move(LENGTH / 3 * pCell.X + MARGIN, LENGTH / 3 * (pCell.Y + 1) - MARGIN);
                robotXY.PenUp();

                robotXY.ResetPosition();*/

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
