using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur.classes.dames
{
    class Dames
    {
        Pion[,] board;
        bool bTurnWhite = true;
        int iWhitePiecesLeft, iBlackPiecesLeft;
        const int CELLPERLINE = 10;
        Point pRemoved = new Point(-1, -1);

        public Dames()
        {
            iWhitePiecesLeft = 10;
            iBlackPiecesLeft = 10;

            //Création du plateau
            board = new Pion[10, 10];

            //Ajout des pions dans le plateau
            for (int y = 0; y < 4; y++)
            {
                for (int x = y % 2; x < CELLPERLINE; x += 2)
                {
                    //Création du pion blanc
                    board[x, y] = new Pion(true);

                    //Création du pion noir
                    board[x, y + 6] = new Pion(false);
                }
            }
        }

        /*public List<Stack<Node>>[,] GetWays(bool isWhite)
        {

        }*/

        public void MovePiece(int _fromX, int _fromY, int _toX, int _toY)
        {

        }

        public Pion[,] GetBoard()
        {
            return board;
        }
    }
}