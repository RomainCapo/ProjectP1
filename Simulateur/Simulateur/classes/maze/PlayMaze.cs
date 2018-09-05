using Labyrinthe.Classes;
using System;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Simulateur.classes.maze
{
    class PlayMaze
    {
        Form1 form;
        Robot robotXY;
        readonly double MAXLENGTH;
        int iCellPerLine;
        GroupBox gbMaze;
        Maze maze;
        int iCellSize;

        public PlayMaze(Form1 _form, Robot _robot, double _width, double _height)
        {
            form = _form;
            robotXY = _robot;

            if(_width <= _height)
            {
               MAXLENGTH = _width;
            }
            else
            {
               MAXLENGTH = _height;
            }

            AddMazeControls();
        }

        public void Remove()
        {
            robotXY.ResetPosition();
            form.Controls.RemoveByKey("gbMaze");
        }

        private void AddMazeControls()
        {
            gbMaze = new GroupBox();
            gbMaze.Name = "gbMaze";
            gbMaze.Text = "Labyrinthe";
            gbMaze.Top = 250;
            gbMaze.Left = 10;
            gbMaze.Width = 150;

            NumericUpDown numLength = new NumericUpDown();
            numLength.Name = "numLength";
            numLength.Width = 50;
            numLength.Left = 10;
            numLength.Top = 20;
            numLength.Minimum = 1;
            numLength.Value = 10;
            gbMaze.Controls.Add(numLength);

            Button btnGenerate = new Button();
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Text = "Générer";
            btnGenerate.Left = 9;
            btnGenerate.Top = 43;
            btnGenerate.Click += new EventHandler(Generate);
            gbMaze.Controls.Add(btnGenerate);

            Button btnResolve = new Button();
            btnResolve.Name = "btnResolve";
            btnResolve.Text = "Resolution";
            btnResolve.Left = 9;
            btnResolve.Top = 66;
            btnResolve.Click += new EventHandler(Resolve);
            btnResolve.Enabled = false;
            gbMaze.Controls.Add(btnResolve);

            form.Controls.Add(gbMaze);
        }

        private void Generate(Object sender, EventArgs e)
        {
            robotXY.RemoveDrawing();
            NumericUpDown numLength = gbMaze.Controls.Find("numLength", false).First() as NumericUpDown;
            iCellPerLine = Convert.ToInt32(numLength.Value);
            iCellSize = Convert.ToInt32(MAXLENGTH / iCellPerLine);
            maze = new Maze(iCellPerLine);

            DrawMaze(maze.GetMaze());
            Button btnResolve = gbMaze.Controls.Find("btnResolve", false).First() as Button;
            btnResolve.Enabled = true;


        }

        private void Resolve(Object sender, EventArgs e)
        {
            Point[] Solution = maze.ResolveMaze();

            robotXY.Move(iCellSize / 2, 0);
            robotXY.PenDown();
            for(int compteur = Solution.Length - 1; compteur >= 0; compteur --)
            {
                Point p = Solution[compteur];
                robotXY.Move(iCellSize * p.X + (iCellSize / 2), iCellSize * p.Y + (iCellSize / 2));
            }
            robotXY.Move(iCellSize * Solution[0].X + (iCellSize / 2), iCellSize * (Solution[0].Y + 1));
            robotXY.PenUp();
            robotXY.ResetPosition();
        }

        private void DrawMaze(Cell[,] cells)
        {
            robotXY.Move(iCellSize, 0);
            robotXY.PenDown();
            robotXY.Move(MAXLENGTH, 0);
            robotXY.PenUp();
            for(int y = 0; y < iCellPerLine; y++)
            {
                robotXY.Move(0, (y + 1) * iCellSize);
                for (int x = 0; x < iCellPerLine; x++)
                {
                    bool bIsWall = cells[x, y].IsWallBottom();

                    bool bLine = true;
                    while (bLine)
                    {
                        if (x < iCellPerLine - 1)
                        {
                            if (cells[x + 1, y].IsWallBottom() == bIsWall)
                            {
                                x++;
                            }
                            else
                            {
                                bLine = false;
                            }
                        }
                        else
                        {
                            bLine = false;
                        }
                    }

                    if (cells[x, y].IsWallBottom())
                    {
                        robotXY.PenDown();
                    }
                    robotXY.Move((x + 1) * iCellSize, (y + 1) * iCellSize);
                    robotXY.PenUp();
                }
            }
            
            robotXY.Move(0, 0);
            robotXY.PenDown();
            robotXY.Move(0, MAXLENGTH);
            robotXY.PenUp();
            for (int x = 0; x < iCellPerLine; x++)
            {
                robotXY.Move((x + 1) * iCellSize, 0);
                for (int y = 0; y < iCellPerLine - 1; y++)
                {
                    bool bIsWall = cells[x, y].IsWallRight();

                    bool bLine = true;
                    while(bLine)
                    {
                        if(y < iCellPerLine - 1)
                        {
                            if(cells[x, y + 1].IsWallRight() == bIsWall)
                            {
                                y++;
                            }
                            else
                            {
                                bLine = false;
                            }
                        }
                        else
                        {
                            bLine = false;
                        }
                    }

                    /*while (cells[x, y + 1].IsWallRight() == bIsWall && y + 1 < iCellPerLine - 1)
                    {
                        y++;
                    }*/

                    if(bIsWall)
                    {
                        robotXY.PenDown();
                    }

                    robotXY.Move((x + 1) * iCellSize, (y + 1) * iCellSize);
                    robotXY.PenUp();
                }
            }

            robotXY.ResetPosition();
        }
    }
}
