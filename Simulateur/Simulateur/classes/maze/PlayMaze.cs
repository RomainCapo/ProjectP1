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
        int cellLength;
        GroupBox gbMaze;
        Maze maze;

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
            gbMaze.Top = 420;
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
            gbMaze.Controls.Add(btnResolve);

            form.Controls.Add(gbMaze);
        }

        private void Generate(Object sender, EventArgs e)
        {
            NumericUpDown numLength = gbMaze.Controls.Find("numLength", false).FirstOrDefault() as NumericUpDown;
            cellLength = Convert.ToInt32(numLength.Value);
            maze = new Maze(cellLength);

            DrawMaze(maze.GetMaze());
            
        }

        private void Resolve(Object sender, EventArgs e)
        {
            Point[] Solution = maze.ResolveMaze();

            robotXY.MoveCursor(cellLength / 2, 0);
            robotXY.PenDown();
            for(int compteur = Solution.Length - 1; compteur >= 0; compteur --)
            {
                Point p = Solution[compteur];
                robotXY.MoveCursor(cellLength * p.X + (cellLength / 2), cellLength * p.Y + (cellLength / 2));
            }
            robotXY.MoveCursor(cellLength * Solution[0].X + (cellLength / 2), cellLength * (Solution[0].Y + 1));
            robotXY.PenUp();
            robotXY.ResetPosition();
        }

        private void DrawMaze(Cell[,] cells)
        {
            int cellNb = Convert.ToInt32(Math.Sqrt(cells.Length));
            cellLength = Convert.ToInt32(MAXLENGTH / cellNb);

            bool bEnd = false;

            robotXY.ResetPosition();
            for (int x = 0; x < cellNb; x++)
            {
                while(!(bEnd))
                {
                    if(x + 1 == cellNb)
                    {
                        bEnd = true;
                    }
                    else if(cells[x, 0].IsWallTop() != cells[x + 1, 0].IsWallTop())
                    {
                        bEnd = true;
                    }
                    else
                    {
                        x++;
                    }
                }

                if(cells[x, 0].IsWallTop())
                {
                    robotXY.PenDown();
                }
                else
                {
                    robotXY.PenUp();
                }

                robotXY.MoveCursor(cellLength * (x + 1), 0);
                bEnd = false;
            }
            robotXY.PenUp();

            for(int y = 0; y < cellNb; y++)
            {
                robotXY.MoveCursor(0, (y + 1) * cellLength);
                for (int x = 0; x < cellNb - 1; x++)
                {
                    while (!(bEnd))
                    {
                        if (x + 1 == cellNb)
                        {
                            bEnd = true;
                        }
                        else if (cells[x, y].IsWallBottom() != cells[x + 1, y].IsWallBottom())
                        {
                            bEnd = true;
                        }
                        else
                        {
                            x++;
                        }
                    }

                    if (cells[x, y].IsWallBottom())
                    {
                        robotXY.PenDown();
                    }
                    else
                    {
                        robotXY.PenUp();
                    }

                    robotXY.MoveCursor(cellLength * (x + 1), cellLength * (y + 1));
                    bEnd = false;
                }
                robotXY.PenUp();
            }

            robotXY.ResetPosition();
            robotXY.PenDown();
            for (int y = 0; y < cellNb; y++)
            {
                while (!(bEnd))
                {
                    if (y + 1 == cellNb)
                    {
                        bEnd = true;
                    }
                    else if (cells[0, y].IsWallLeft() != cells[0, y + 1].IsWallLeft())
                    {
                        bEnd = true;
                    }
                    else
                    {
                        y++;
                    }
                }

                if (cells[0, y].IsWallLeft())
                {
                    robotXY.PenDown();
                }
                else
                {
                    robotXY.PenUp();
                }

                robotXY.MoveCursor(0, cellLength * (y + 1));
                bEnd = false;
            }
            robotXY.PenUp();

            for (int x = 0; x < cellNb; x++)
            {
                robotXY.MoveCursor((x + 1) * cellLength, 0);
                robotXY.PenDown();
                for (int y = 0; y < cellNb; y++)
                {
                    while (!(bEnd))
                    {
                        if (y + 1 == cellNb)
                        {
                            bEnd = true;
                        }
                        else if (cells[x, y].IsWallRight() != cells[x, y + 1].IsWallRight())
                        {
                            bEnd = true;
                        }
                        else
                        {
                            y++;
                        }
                    }

                    if (cells[x, y].IsWallRight())
                    {
                        robotXY.PenDown();
                    }
                    else
                    {
                        robotXY.PenUp();
                    }

                    robotXY.MoveCursor(cellLength * (x + 1), cellLength * (y + 1));
                    bEnd = false;
                }
                robotXY.PenUp();
            }
            robotXY.ResetPosition();
        }
    }
}
