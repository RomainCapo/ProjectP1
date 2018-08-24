using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Simulateur.classes.dames
{
    class Forest
    {
        List<Tree> forest;
        public Forest()
        {
            forest = new List<Tree>();
        }

        public void GenerateForest(Pion[,] _board, bool _color)
        {
            int iTopLength = 0;

            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //A optimiser !!!
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            for (int y = 0; y < 10;  y++)
            {
                for(int x = 0; y < 10; x++)
                {
                    if (_board[x, y] != null)
                    {
                        if (_board[x, y].GetColor() == _color)
                        {
                            Tree tree = new Tree(new Point(x, y));
                            int iLength = tree.GenerateTree(_board, _color);

                            if(iLength > iTopLength)
                            {
                                iTopLength = iLength;
                                forest.Clear();
                            }
                            if(iLength >= iTopLength)
                            {
                                forest.Add(tree);
                            }
                        }
                    }
                }
            }
        }

        public Tree GetTree(Point _position)
        {
            foreach(Tree tree in forest)
            {
                if(tree.GetLocation() == _position)
                {
                    return tree;
                }
            }
            return null;
        }
    }
}
