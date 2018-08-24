using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Simulateur.classes.dames
{
    class Node
    {
        Point pDestination;
        Point pTarget;
        List<Node> Children;

        public Node(Point _destination, Point _target)
        {
            Children = new List<Node>();

            pDestination = _destination;
            pTarget = _target;
        }

        public void AddChild(Point _destination, Point _target)
        {
            Children.Add(new Node(_destination, _target));
        }

        public List<Node> GetChildren()
        {
            return Children;
        }

        public List<Stack<Node>> GetBestPath()
        {
            Stack<Node> actualSeries = new Stack<Node>();
            List<Stack<Node>> bestSeries = new List<Stack<Node>>();

            actualSeries.Push(this);
            int iMaxDepth = 0;
            int iDepth = 0;

            List<Node> children = GetChildren();
            while (GetChildren().Count != 0)
            {
                while (children.Count != 0)
                {
                    children = actualSeries.Last().GetChildren();
                    actualSeries.Push(children.First());
                    iDepth++;
                }

                if (iDepth > iMaxDepth)
                {
                    bestSeries = new List<Stack<Node>>();
                }
                if (iDepth >= iMaxDepth)
                {
                    bestSeries.Add(actualSeries);
                    iMaxDepth = iDepth;
                }

                Node temp = actualSeries.Last();
                actualSeries.Pop();
                actualSeries.Last().GetChildren().Remove(temp);
                children = actualSeries.Last().GetChildren();
                iDepth--;
            }

            return bestSeries;
        }
    }
}
