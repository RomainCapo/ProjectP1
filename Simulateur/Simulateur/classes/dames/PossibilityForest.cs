using System.Collections.Generic;
using System.Linq;

namespace Simulateur.classes.dames
{
    class PossibilityForest
    {
        Node[,] forest;

        public PossibilityForest()
        {
            forest = new Node[10, 10];
        }

        public void AddNewPieceMovement(Node _tree, int _x, int _y)
        {
            forest[_x, _y] = _tree;
        }

        public List<Stack<Node>>[,] GetPossibleMovement()
        {
            List<Stack<Node>>[,] possibleMovements = new List<Stack<Node>>[10, 10];
            int iLongestDepth = 0;

            for(int y = 0; y < 10; y++)
            {
                for(int x = 0; x < 10; x++)
                {
                    if (forest[x, y] != null)
                    {
                        List<Stack<Node>> bestNodeWays = forest[x, y].GetBestPath();

                        int iActualDepth = bestNodeWays.First().Count;

                        if (iActualDepth > iLongestDepth)
                        {
                            possibleMovements = new List<Stack<Node>>[10, 10];
                        }
                        if(iActualDepth >= iLongestDepth)
                        {
                            possibleMovements[x, y] = bestNodeWays;
                        }
                    }
                }
            }
            return possibleMovements;
        }

        public void Clear()
        {
            forest = new Node[10, 10];
        }
    }
}
