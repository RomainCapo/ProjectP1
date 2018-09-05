using System;
using System.Collections.Generic;
using System.Drawing;

namespace Simulateur.classes.morpion
{
    class Minmax
    {
        int idIA, idOpponent;

        public Minmax(int _idIA, int _idOpponent)
        {
            this.idIA = _idIA;
            this.idOpponent = _idOpponent;
        }

        public Point Play(int[,] _board)
        {
            int max = -10000;
            List<Point> bestChoices = new List<Point>();
            int tmp;

            for (int iCompteurY = 0; iCompteurY < Math.Sqrt(_board.Length); iCompteurY++)
            {
                for (int iCompteurX = 0; iCompteurX < Math.Sqrt(_board.Length); iCompteurX++)
                {
                    if (_board[iCompteurX, iCompteurY] == 0)
                    {
                        _board[iCompteurX, iCompteurY] = idIA;

                        tmp = OpponentPlay(_board);
                        if (tmp > max)
                        {
                            max = tmp;
                            bestChoices.Clear();
                        }
                        if (tmp == max)
                        {
                            bestChoices.Add(new Point(iCompteurX, iCompteurY));
                        }

                        _board[iCompteurX, iCompteurY] = 0;
                    }
                }
            }
            Random random = new Random((int)DateTime.Now.Ticks);
            return bestChoices[random.Next(bestChoices.Count - 1)];
        }

        private int IaPlay(int[,] _board)
        {
            if (WhoWin(_board) != -1)
            {
                return Evaluation(_board);
            }

            int max = -10000;
            int tmp;

            for (int iCompteurY = 0; iCompteurY < Math.Sqrt(_board.Length); iCompteurY++)
            {
                for (int iCompteurX = 0; iCompteurX < Math.Sqrt(_board.Length); iCompteurX++)
                {
                    if (_board[iCompteurX, iCompteurY] == 0)
                    {
                        _board[iCompteurX, iCompteurY] = idIA;

                        tmp = OpponentPlay(_board);

                        if (tmp > max)
                        {
                            max = tmp;
                        }

                        _board[iCompteurX, iCompteurY] = 0;
                    }
                }
            }

            return max;
        }

        private int OpponentPlay(int[,] _board)
        {
            if (WhoWin(_board) != -1)
            {
                return Evaluation(_board);
            }

            int min = 10000;
            int tmp;

            for (int iCompteurY = 0; iCompteurY < Math.Sqrt(_board.Length); iCompteurY++)
            {
                for (int iCompteurX = 0; iCompteurX < Math.Sqrt(_board.Length); iCompteurX++)
                {
                    if (_board[iCompteurX, iCompteurY] == 0)
                    {
                        _board[iCompteurX, iCompteurY] = idOpponent;

                        tmp = IaPlay(_board);

                        if (tmp < min)
                        {
                            min = tmp;
                        }

                        _board[iCompteurX, iCompteurY] = 0;
                    }
                }
            }

            return min;
        }

        private int WhoWin(int[,] _board)
        {
            for (int y = 0; y < 3; y++)
            {
                string hor = "";
                string vert = "";

                for (int x = 0; x < 3; x++)
                {
                    hor += _board[x, y];
                    vert += _board[y, x];
                }

                if (hor.Contains("111") || vert.Contains("111"))
                {
                    return 1;
                }
                if (hor.Contains("222") || vert.Contains("222"))
                {
                    return 2;
                }
            }

            string diag1 = "";
            string diag2 = "";
            for (int compteur = 0; compteur < 3; compteur++)
            {
                diag1 += _board[compteur, compteur];
                diag2 += _board[2 - compteur, 2 - compteur];
            }

            if (diag1.Contains("111") || diag2.Contains("111"))
            {
                return 1;
            }
            if (diag1.Contains("222") || diag2.Contains("222"))
            {
                return 2;
            }

            int nbPion = 0;
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if (_board[x, y] != 0)
                    {
                        nbPion++;
                    }
                }
            }

            if (nbPion == 9)
            {
                return 0;
            }

            return -1;
        }

        private int Evaluation(int[,] _board)
        {
            int idWinner = WhoWin(_board);
            int iNbPieces = 0;

            foreach (int value in _board)
            {
                if (value != 0)
                {
                    iNbPieces++;
                }
            }

            if (idWinner == idIA)
            {
                return 1000 - iNbPieces/* + (10 * Serie(idIA, _board))*/;
            }
            else if (idWinner == idOpponent)
            {
                return -1000 + iNbPieces/* - (10 * Serie(idOpponent, _board))*/;
            }
            else if (iNbPieces >= 9)
            {
                return 0 + Serie(idIA, _board) - Serie(idOpponent, _board);
            }

            return Serie(idIA, _board) - Serie(idOpponent, _board);
        }

        private int Serie(int id, int[,] _board)
        {
            string strID = id + "" + id;
            int suite = 0;

            for (int y = 0; y < 3; y++)
            {
                string hor = "";
                string vert = "";

                for (int x = 0; x < 3; x++)
                {
                    hor += _board[x, y];
                    vert += _board[y, x];
                }

                if (hor.Contains(strID))
                {
                    suite++;
                }
                if (vert.Contains(strID))
                {
                    suite++;
                }
            }

            string diag1 = "";
            string diag2 = "";
            for (int compteur = 0; compteur < 3; compteur++)
            {
                diag1 += _board[compteur, compteur];
                diag2 += _board[compteur, 2 - compteur];
            }

            if (diag1.Contains(strID) && diag1.Contains("0"))
            {
                suite++;
            }
            if (diag2.Contains(strID) && diag2.Contains("0"))
            {
                suite++;
            }

            return suite;
        }
    }
}
