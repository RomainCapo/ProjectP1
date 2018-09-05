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
        Forest forest;
        //Minmax minmax;

        bool bCanStillEat;
        Point pDeadPieceLocation;
        int iWhitePiecesLeft, iBlackPiecesLeft;
        const int CELLPERLINE = 10;
        Point pRemoved = new Point(-1, -1);
        bool bWhiteTurn;

        Tree currentTree;

        //----------------------------------------------------------------
        //Constructeur de la classe
        //----------------------------------------------------------------
        public Dames()
        {

            //Création du plateau
            board = new Pion[10, 10];
            forest = new Forest();
            //minmax = new Minmax();

            bCanStillEat = true;
            bWhiteTurn = true;

            //Ajout des pions dans le plateau
            for (int y = 0; y < 4; y++)
            {
                for (int x = y % 2; x < CELLPERLINE; x += 2)
                {
                    //Création du pion blanc
                    board[x, y] = new Pion(true);
                    iWhitePiecesLeft++;

                    //Création du pion noir
                    board[x, y + 6] = new Pion(false);
                    iBlackPiecesLeft++;
                }
            }

            forest.GenerateForest(board, true);
        }

        //----------------------------------------------------------------
        //Verifie et déplace un pion du joueur
        //----------------------------------------------------------------
        public bool MovePlayer(Point position, Point destination)
        {
            if (currentTree == null)
            {
                currentTree = forest.GetTree(position);
            }


            if (currentTree.GetChildren().Count != 0)
            {
                foreach (Node child in currentTree.GetChildren())
                {
                    if (child.GetPosition() == destination)
                    {
                        Move(position, child, true);

                        if (forest.CanEat())
                        {
                            pDeadPieceLocation = child.GetTarget();
                            board[pDeadPieceLocation.X, pDeadPieceLocation.Y] = null;
                        }

                        currentTree.SetChildren(child.GetChildren());
                        currentTree.SetLocation(child.GetPosition());

                        if (currentTree.GetChildren().Count == 0)
                        {
                            bCanStillEat = false;

                            bWhiteTurn = false;
                            currentTree = null;
                        }

                        return true;
                    }
                }
            }
            return false;
        }

        //----------------------------------------------------------------
        //Revoie si le joueur actuel peux encore manger
        //----------------------------------------------------------------
        public bool CanStillEat()
        {
            if (bCanStillEat)
            {
                return true;
            }
            else
            {
                forest.GenerateForest(board, bWhiteTurn);
                bWhiteTurn = !(bWhiteTurn);
                bCanStillEat = true;
                return false;
            }
        }

        //----------------------------------------------------------------
        //Déplace le pion en paramêtre
        //----------------------------------------------------------------
        private void Move(Point _location, Node node, bool _color)
        {
            if (forest.CanEat())
            {
                pDeadPieceLocation = node.GetTarget();
                board[pDeadPieceLocation.X, pDeadPieceLocation.Y] = null;

                if (_color)
                {
                    iBlackPiecesLeft--;
                }
                else
                {
                    iWhitePiecesLeft--;
                }
            }

            board[node.GetPosition().X, node.GetPosition().Y] = board[_location.X, _location.Y];
            board[_location.X, _location.Y] = null;
        }

        //----------------------------------------------------------------
        //Déplace le pion de l'IA
        //----------------------------------------------------------------
        public Point[] MoveIA()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);

            /*if(currentMoves.Count == 0)
            {
                Tree piecePossibility = minmax.GetMove(board, 1);
                currentMoves = piecePossibility.GetChildren();
                pLocation = piecePossibility.GetLocation();
            }*/

            if (currentTree == null)
            {
                currentTree = forest.GetRandomTree();
            }

            Node child = currentTree.GetChildren()[rand.Next(currentTree.GetChildren().Count - 1)];
            Point pLocation = currentTree.GetLocation();
            Point pDestination = child.GetPosition();

            Move(pLocation, child, false);

            if (forest.CanEat())
            {
                pDeadPieceLocation = child.GetTarget();
                board[pDeadPieceLocation.X, pDeadPieceLocation.Y] = null;
            }

            currentTree.SetChildren(child.GetChildren());
            currentTree.SetLocation(child.GetPosition());

            if (currentTree.GetChildren().Count == 0)
            {
                bCanStillEat = false;
                currentTree = null;
            }

            return new Point[2] { pLocation, pDestination };
        }

        //----------------------------------------------------------------
        //Verifie l'etat de la partie
        //----------------------------------------------------------------
        public int Check()
        {
            if (iWhitePiecesLeft <= 0)
            {
                return 1;
            }
            if (iBlackPiecesLeft <= 0)
            {
                return 2;
            }
            return 0;
        }

        //----------------------------------------------------------------
        //Verifie si un des pions peux devenir une dame
        //----------------------------------------------------------------
        public Point CheckTransformation(bool _color)
        {
            int x = 0;
            int y = 0;
            if (_color)
            {
                x = 1;
                y = 9;
            }
            for (int compteur = x; compteur < 10; compteur += 2)
            {
                if (board[compteur, y] != null)
                {
                    if (board[compteur, y].GetColor() == _color && board[compteur, y].GetState() == false)
                    {
                        board[compteur, y].Upgrade();
                        return new Point(compteur, y);
                    }
                }
            }

            return Point.Empty;
        }

        //----------------------------------------------------------------
        //Retourne le plateau de jeu
        //----------------------------------------------------------------
        public Pion[,] GetBoard()
        {
            return board;
        }

        //----------------------------------------------------------------
        //Retourne l'emplacement de la piece mangée
        //----------------------------------------------------------------
        public Point GetDeadPieceLocation()
        {
            return pDeadPieceLocation;
        }

        //----------------------------------------------------------------
        //Retourne si le joueur actuel peux manger
        //----------------------------------------------------------------
        public bool CanEat()
        {
            return forest.CanEat();
        }


        //----------------------------------------------------------------
        //Retourne les pieces déplacable par le joueur actuel
        //----------------------------------------------------------------
        public List<Point> GetMovablePieces()
        {
            return forest.GetMovablePieces();
        }

        //----------------------------------------------------------------
        //Retourne l'arbre de possibilité de la piece en parametre
        //----------------------------------------------------------------
        public Tree GetTree(Point _location)
        {
            return forest.GetTree(_location);
        }
    }
}