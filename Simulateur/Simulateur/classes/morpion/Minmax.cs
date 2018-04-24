using System;
using System.Drawing;

namespace Simulateur.classes.morpion
{
    class Minmax
    {
        int idIA, idOpponent, iDepth;

        public Minmax(int idIA, int idOpponent)
        {
            this.idIA = idIA;
            this.idOpponent = idOpponent;
            this.iDepth = 100;
        }

        public Point Play(int[,] board)
        {
            int max = -10000;
            Point pBestChoice = new Point();
            int tmp;
            int depth = iDepth;

            for(int iCompteurY = 0; iCompteurY < Math.Sqrt(board.Length); iCompteurY++)
            {
                for(int iCompteurX = 0; iCompteurX < Math.Sqrt(board.Length); iCompteurX++)
                {
                    if(board[iCompteurX, iCompteurY] == 0)
                    {
                        board[iCompteurX, iCompteurY] = idIA;

                        tmp = OpponentPlay(board, --depth);
                        if(tmp > max)
                        {
                            max = tmp;
                            pBestChoice.X = iCompteurX;
                            pBestChoice.Y = iCompteurY;
                        }

                        board[iCompteurX, iCompteurY] = 0;
                    }
                }
            }

            return pBestChoice;
        }

        private int IaPlay(int[,] board, int depth)
        {
            if (depth == 0 || WhoWin(board) != 0)
            {
                return Evaluation(board);
            }

            int max = -10000;
            int tmp;

            for (int iCompteurY = 0; iCompteurY < Math.Sqrt(board.Length); iCompteurY++)
            {
                for (int iCompteurX = 0; iCompteurX < Math.Sqrt(board.Length); iCompteurX++)
                {
                    if (board[iCompteurX, iCompteurY] == 0)
                    {
                        board[iCompteurX, iCompteurY] = idIA;

                        tmp = IaPlay(board, --depth);

                        if (tmp > max)
                        {
                            max = tmp;
                        }

                        board[iCompteurX, iCompteurY] = 0;
                    }
                }
            }

            return max;
        }

        private int OpponentPlay(int[,] board, int depth)
        {
            if(depth == 0 || WhoWin(board) != 0)
            {
                return Evaluation(board);
            }

            int min = 10000;
            int tmp;

            for(int iCompteurY = 0; iCompteurY < Math.Sqrt(board.Length); iCompteurY++)
            {
                for(int iCompteurX = 0; iCompteurX < Math.Sqrt(board.Length); iCompteurX++)
                {
                    if(board[iCompteurX, iCompteurY] == 0)
                    {
                        board[iCompteurX, iCompteurY] = idOpponent;

                        tmp = IaPlay(board, --depth);

                        if(tmp < min)
                        {
                            min = tmp;
                        }

                        board[iCompteurX, iCompteurY] = 0;
                    }
                }
            }

            return min;
        }

        private int WhoWin(int[,] board)
        {
            for (int iCompteurY = 0; iCompteurY < Math.Sqrt(board.Length); iCompteurY++)
            {
                if (board[0, iCompteurY] == board[1, iCompteurY] && board[1, iCompteurY] == board[2, iCompteurY] && board[0, iCompteurY] != 0)
                {
                    return board[0, iCompteurY];
                }
            }

            for (int iCompteurX = 0; iCompteurX < Math.Sqrt(board.Length); iCompteurX++)
            {
                if (board[iCompteurX, 0] == board[iCompteurX, 1] && board[iCompteurX, 1] == board[iCompteurX, 2] && board[iCompteurX, 0] != 0)
                {
                    return board[iCompteurX, 0];
                }
            }

            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[0, 0] != 0)
            {
                return board[0, 0];
            }

            if (board[2, 0] == board[1, 1] && board[1, 1] == board[0, 2] && board[2, 0] != 0)
            {
                return board[2, 0];
            }

            for (int iCompteurY = 0; iCompteurY < Math.Sqrt(board.Length); iCompteurY++)
            {
                for (int iCompteurX = 0; iCompteurX < Math.Sqrt(board.Length); iCompteurX++)
                {
                    if (board[iCompteurX, iCompteurY] == 0)
                    {
                        return 0;
                    }
                }
            }

            return -1;
        }

        private int Evaluation(int[,] board)
        {
            int idWinner = WhoWin(board);
            int iNbPionIA = 0, iNbPionOpponent = 0;

            for(int iCompteurY = 0; iCompteurY < Math.Sqrt(board.Length); iCompteurY++)
            {
                for (int iCompteurX = 0; iCompteurX < Math.Sqrt(board.Length); iCompteurX++)
                {
                    if(board[iCompteurX, iCompteurY] == idIA)
                    {
                        iNbPionIA++;
                    }
                    if(board[iCompteurX, iCompteurY] == idOpponent)
                    {
                        iNbPionOpponent++;
                    }
                }
            }

            if (idWinner == idIA)
            {
                return 1000 - iNbPionIA;
            }
            else if (idWinner == idOpponent)
            {
                return -1000 + iNbPionOpponent;
            }
            else
            {
                return 0;
            }
        }
    }
}
