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
        Timer timerScreenShot;

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

            //timerScreenShot.Start();
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
            gbTicTacToe.Top = 400;
            gbTicTacToe.Left = 5;
            gbTicTacToe.Width = 150;
            gbTicTacToe.Height = 60;

            Button btnVerifier = new Button();
            btnVerifier.Left = 5;
            btnVerifier.Top = 15;
            btnVerifier.Height = 33;
            btnVerifier.Width = 93;
            btnVerifier.Text = "Detection croix";
            btnVerifier.Click += new EventHandler(DrawCross);
            gbTicTacToe.Controls.Add(btnVerifier);

            timerScreenShot = new Timer();
            timerScreenShot.Tick += new EventHandler(DrawCross);
            timerScreenShot.Interval = 1000;

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

        private void Play(Point pCross)
        {
            if(pCross != Point.Empty)
            {
                if (ticTacToe.CheckGrid() == 0)
                {
                    DrawCircle(ia.Play(ticTacToe.getGrid()));

                    if (ticTacToe.CheckGrid() != 0)
                    {
                        MessageBox.Show("Partie terminée");
                        //timerScreenShot.Stop();
                        Remove();
                    }
                }
                else
                {
                    if (ticTacToe.CheckGrid() != 0)
                    {
                        MessageBox.Show("Partie terminée");
                        //timerScreenShot.Stop();
                        Remove();
                    }
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
                for(int angle = 10; angle <= 360; angle += 17)
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

        private void DrawCross(Object sender, EventArgs e)
        {
            Point pCell = ticTacToe.PlaceCross();
            //Application.DoEvents();

            if (pCell != Point.Empty)
            {
                robotXY.SwitchBluetooth(false);
                robotXY.Move(LENGTH / 3 * pCell.X + MARGIN, LENGTH / 3 * pCell.Y + MARGIN);
                robotXY.PenDown();
                robotXY.Move(LENGTH / 3 * (pCell.X + 1) - MARGIN, LENGTH / 3 * (pCell.Y + 1) - MARGIN);
                robotXY.PenUp();

                robotXY.Move(LENGTH / 3 * (pCell.X + 1) - MARGIN, LENGTH / 3 * pCell.Y + MARGIN);
                robotXY.PenDown();
                robotXY.Move(LENGTH / 3 * pCell.X + MARGIN, LENGTH / 3 * (pCell.Y + 1) - MARGIN);
                robotXY.PenUp();

                robotXY.ResetPosition();
                robotXY.SwitchBluetooth(true);
            }

            Play(pCell);
        }
    }
}
