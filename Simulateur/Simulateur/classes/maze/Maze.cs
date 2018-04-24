using System;
using System.Collections.Generic;
using System.Drawing;

namespace Labyrinthe.Classes
{

    class Maze
    {
        Cell[,] tblMaze;
        Random random = new Random();
        public Maze(int sideLength)
        {
            tblMaze = new Cell[sideLength, sideLength];
            for(int iCompteurY = 0; iCompteurY < sideLength; iCompteurY++)
            {
                for (int iCompteurX = 0; iCompteurX < sideLength; iCompteurX++)
                {
                    tblMaze[iCompteurX, iCompteurY] = new Cell();
                }
            }
            GenerateMaze(sideLength);
            tblMaze[0, 0].RemoveWallTop();
            tblMaze[sideLength - 1, sideLength - 1].RemoveWallBottom();
        }

        private void GenerateMaze(int sideLength)
        {
            int iVisitedCounter = 1;
            Point pCurrentCell = new Point(0, 0);
            Stack<Point> tblStack = new Stack<Point>();

            tblStack.Push(pCurrentCell);
            tblMaze[pCurrentCell.X, pCurrentCell.Y].SetVisited(true);

            while(iVisitedCounter != tblMaze.Length)
            {
                Point pNeighborLocation = GetRandomNeighbor(pCurrentCell);
                while (pNeighborLocation == new Point(-1, -1))
                {
                    pCurrentCell = tblStack.Pop();
                    pNeighborLocation = GetRandomNeighbor(pCurrentCell);
                }

                Point pNeighborRelativeLocaltion = new Point(pCurrentCell.X - pNeighborLocation.X, pCurrentCell.Y - pNeighborLocation.Y);
                if(pNeighborRelativeLocaltion.X == 0 && pNeighborRelativeLocaltion.Y == 1)
                {
                    tblMaze[pCurrentCell.X, pCurrentCell.Y].RemoveWallTop();
                    pCurrentCell = pNeighborLocation;
                    tblMaze[pCurrentCell.X, pCurrentCell.Y].RemoveWallBottom();
                }
                if (pNeighborRelativeLocaltion.X == 0 && pNeighborRelativeLocaltion.Y == -1)
                {
                    tblMaze[pCurrentCell.X, pCurrentCell.Y].RemoveWallBottom();
                    pCurrentCell = pNeighborLocation;
                    tblMaze[pCurrentCell.X, pCurrentCell.Y].RemoveWallTop();
                }
                if (pNeighborRelativeLocaltion.X == 1 && pNeighborRelativeLocaltion.Y == 0)
                {
                    tblMaze[pCurrentCell.X, pCurrentCell.Y].RemoveWallLeft();
                    pCurrentCell = pNeighborLocation;
                    tblMaze[pCurrentCell.X, pCurrentCell.Y].RemoveWallRight();
                }
                if (pNeighborRelativeLocaltion.X == -1 && pNeighborRelativeLocaltion.Y == 0)
                {
                    tblMaze[pCurrentCell.X, pCurrentCell.Y].RemoveWallRight();
                    pCurrentCell = pNeighborLocation;
                    tblMaze[pCurrentCell.X, pCurrentCell.Y].RemoveWallLeft();
                }
                tblMaze[pCurrentCell.X, pCurrentCell.Y].SetVisited(true);
                tblStack.Push(pCurrentCell);
                iVisitedCounter++;
            }
        }

        public Point[] ResolveMaze()
        {
            Stack<Point> Path = new Stack<Point>();
            Point pCurrentCell = new Point(0, 0);
            Point pFinalCell = new Point(Convert.ToInt32(Math.Sqrt(tblMaze.Length)) - 1, Convert.ToInt32(Math.Sqrt(tblMaze.Length)) - 1);

            ResetVisits();
            Path.Push(pCurrentCell);
            tblMaze[pCurrentCell.X, pCurrentCell.Y].SetVisited(true);

            while (pCurrentCell != pFinalCell)
            {
                pCurrentCell = GetRandomPath(pCurrentCell);
                while (pCurrentCell == new Point(-1, -1))
                {
                    pCurrentCell = Path.Peek();
                    pCurrentCell = GetRandomPath(pCurrentCell);
                    if(pCurrentCell == new Point(-1, -1))
                    {
                        Path.Pop();
                    }
                }

                tblMaze[pCurrentCell.X, pCurrentCell.Y].SetVisited(true);
                Path.Push(pCurrentCell);
            }

            return Path.ToArray();
        }

        private Point GetRandomNeighbor(Point pMazeCell)
        {
            List<Point> tblNeighbors = new List<Point>();
            Point[] tblNeighborsLocation = new Point[4] { new Point(0, 1), new Point(1, 0), new Point(0, -1), new Point(-1, 0)};

            foreach(Point pNeighbor in tblNeighborsLocation)
            {
                if(pMazeCell.X + pNeighbor.X >= 0 && pMazeCell.X + pNeighbor.X < Math.Sqrt(tblMaze.Length) && pMazeCell.Y + pNeighbor.Y >= 0 && pMazeCell.Y + pNeighbor.Y < Math.Sqrt(tblMaze.Length))
                {
                    if(tblMaze[pMazeCell.X + pNeighbor.X, pMazeCell.Y + pNeighbor.Y].IsVisited() == false)
                    {
                        tblNeighbors.Add(new Point(pMazeCell.X + pNeighbor.X, pMazeCell.Y + pNeighbor.Y));
                    }
                }
            }
            if (tblNeighbors.Count == 0)
            {
                return new Point(-1, -1);
            }
            else
            {
                int iRandomNeighbor = random.Next(0, tblNeighbors.Count);
                return tblNeighbors[iRandomNeighbor];
            }
        }

        private Point GetRandomPath(Point pMazeCell)
        {
            List<Point> tblNeighbors = new List<Point>();
            List<Point> tblNeighborsLocation = new List<Point>();

            if(tblMaze[pMazeCell.X, pMazeCell.Y].IsWallTop() == false)
            {
                tblNeighborsLocation.Add(new Point(0, -1));
            }
            if (tblMaze[pMazeCell.X, pMazeCell.Y].IsWallBottom() == false)
            {
                tblNeighborsLocation.Add(new Point(0, 1));
            }
            if (tblMaze[pMazeCell.X, pMazeCell.Y].IsWallRight() == false)
            {
                tblNeighborsLocation.Add(new Point(1, 0));
            }
            if (tblMaze[pMazeCell.X, pMazeCell.Y].IsWallLeft() == false)
            {
                tblNeighborsLocation.Add(new Point(-1, 0));
            }

            foreach (Point pNeighbor in tblNeighborsLocation)
            {
                if (pMazeCell.X + pNeighbor.X >= 0 && pMazeCell.X + pNeighbor.X < Math.Sqrt(tblMaze.Length) && pMazeCell.Y + pNeighbor.Y >= 0 && pMazeCell.Y + pNeighbor.Y < Math.Sqrt(tblMaze.Length))
                {
                    if (tblMaze[pMazeCell.X + pNeighbor.X, pMazeCell.Y + pNeighbor.Y].IsVisited() == false)
                    {
                        tblNeighbors.Add(new Point(pMazeCell.X + pNeighbor.X, pMazeCell.Y + pNeighbor.Y));
                    }
                }
            }
            if (tblNeighbors.Count == 0)
            {
                return new Point(-1, -1);
            }
            else
            {
                int iRandomNeighbor = random.Next(0, tblNeighbors.Count);
                return tblNeighbors[iRandomNeighbor];
            }
        }

        private void ResetVisits()
        {
            foreach(Cell cell in tblMaze)
            {
                cell.SetVisited(false);
            }
        }

        public Cell[,] GetMaze()
        {
            return tblMaze;
        }
    }
}
