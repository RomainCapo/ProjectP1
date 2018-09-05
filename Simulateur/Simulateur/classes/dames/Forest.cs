using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Simulateur.classes.dames
{
    class Forest
    {
        List<Tree> forest;
        bool bCanEat;
        public Forest()
        {
            forest = new List<Tree>();
        }

        public void GenerateForest(Pion[,] _board, bool _color)
        {
            forest.Clear();
            int iTopLength = 0;
            bCanEat = false;

            for (int y = 0; y < 10; y++)
            {
                for (int x = y % 2; x < 10; x++)
                {
                    Pion currentPiece = _board[x, y];
                    if (currentPiece != null)
                    {
                        if (currentPiece.GetColor() == _color)
                        {
                            Tree tree = new Tree(new Point(x, y));
                            int iLength = tree.GenerateTree(_board, _color);

                            if (tree.CanEat() == true && bCanEat == false)
                            {
                                bCanEat = true;
                                forest.Clear();
                                iTopLength = 0;
                            }

                            if (tree.GetChildren().Count != 0 && tree.CanEat() == bCanEat)
                            {
                                if (iLength > iTopLength)
                                {
                                    iTopLength = iLength;
                                    forest.Clear();
                                }
                                if (iLength >= iTopLength)
                                {
                                    forest.Add(tree);
                                }
                            }
                        }
                    }
                }
            }
        }

        public Tree GetTree(Point _position)
        {
            foreach (Tree tree in forest)
            {
                if (tree.GetLocation() == _position)
                {
                    return tree;
                }
            }
            return null;
        }

        public List<Point> GetMovablePieces()
        {
            List<Point> movablePieces = new List<Point>();
            foreach (Tree piece in forest)
            {
                movablePieces.Add(piece.GetLocation());
            }

            return movablePieces;
        }

        public Tree GetRandomTree()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            if(forest.Count == 0)
            {
                return null;
            }
            else
            {
                return forest[rand.Next(forest.Count - 1)];
            }
        }

        public bool CanEat()
        {
            return bCanEat;
        }

        public List<Tree> GetForest()
        {
            return forest;
        }
    }
}
