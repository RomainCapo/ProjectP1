using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur.classes.dames
{
    class Tree
    {
        Point pLocation;
        bool bPeuxManger;
        List<Node> children;
        int iLength;

        public Tree(Point _location)
        {
            children = new List<Node>();
            pLocation = _location;
            iLength = 0;
        }

        public int GenerateTree(Pion[,] _board, bool _color)
        {
            bPeuxManger = false;

            children = GetMoves(_board, _color);

            return iLength;
        }

        private List<Node> GetMoves(Pion[,] _board, bool _color)
        {
            if (_board[pLocation.X, pLocation.Y].GetState())
            {
                children = GetKingMove(_board, _color);
            }
            else
            {
                children = GetMenMove(_board, _color);
            }

            return children;
        }

        private List<Node> GetMenMove(Pion[,] _board, bool _color)
        {
            List<Node> possibleMoves = MenTargets(_board, pLocation, _color);
            if (possibleMoves.Count != 0 && !(bPeuxManger))
            {
                children.Clear();
                bPeuxManger = true;
            }
            if (bPeuxManger)
            {
                foreach (Node target in possibleMoves)
                {
                    children.Add(MenRafle(_board, target, new Stack<Point>(), _color));
                }
            }
            else
            {
                possibleMoves = MenMoves(_board, pLocation);
                foreach (Node target in possibleMoves)
                {
                    children.Add(target);
                }
            }

            return possibleMoves;
        }

        private List<Node> MenMoves(Pion[,] _board, Point _location)
        {
            List<Node> possibleMoves = new List<Node>();
            int iY;

            if (_board[_location.X, _location.Y].GetColor())
            {
                iY = 1;
            }
            else
            {
                iY = -1;
            }

            for (int x = -1; x <= 1; x += 2)
            {
                if (x + _location.X >= 0 && x + _location.X < 10 && iY + _location.Y >= 0 && iY + _location.Y < 10)
                {
                    if (_board[x + _location.X, iY + _location.Y] == null)
                    {
                        possibleMoves.Add(new Node(new Point(x + _location.X, iY + _location.Y)));
                    }
                }
            }

            return possibleMoves;
        }

        private List<Node> MenTargets(Pion[,] _board, Point _location, bool _color)
        {
            List<Node> children = new List<Node>();

            Point[] corners = new Point[4] { new Point(1, 1), new Point(1, -1), new Point(-1, -1), new Point(-1, 1) };

            foreach (Point corner in corners)
            {
                Point target = new Point(_location.X + corner.X, _location.Y + corner.Y);
                Point destination = new Point(_location.X + 2 * corner.X, _location.Y + 2 * corner.Y);

                if (destination.X >= 0 && destination.X < 10 && destination.Y >= 0 && destination.Y < 10)
                {
                    if (_board[target.X, target.Y] != null && _board[destination.X, destination.Y] == null)
                    {
                        if (_board[target.X, target.Y].GetColor() != _color)
                        {
                            children.Add(new Node(destination, target));
                        }
                    }
                }
            }
            return children;
        }

        /*private Node MenRafle(Pion[,] _board, Node _baseNode, bool _color)
        {
            List<Queue<Node>> nodesToCheck = new List<Queue<Node>>();
            Queue<Node> temp = new Queue<Node>();
            Stack<Point> eatenCells = new Stack<Point>();
            temp.Enqueue(_baseNode);
            nodesToCheck.Add(temp);

            do
            {
                Node currentNode = nodesToCheck[nodesToCheck.Count - 1].Dequeue();
                List<Node> possibleMove = KingTargets(_board, currentNode.GetPosition(), _color);
                eatenCells.Push(currentNode.GetTarget());

                while (possibleMove.Count != 0)
                {
                    Queue<Node> children = new Queue<Node>();
                    foreach (Node child in possibleMove)
                    {
                        if(!(eatenCells.Contains(child.GetTarget())))
                        {
                            currentNode.AddChild(child);
                            children.Enqueue(child);
                        }
                    }
                    currentNode = children.Dequeue();
                    eatenCells.Push(currentNode.GetTarget());
                    nodesToCheck.Add(children);

                    possibleMove = KingTargets(_board, currentNode.GetPosition(), _color);
                }

                if(nodesToCheck[nodesToCheck.Count - 1].Count == 0)
                {
                    nodesToCheck.RemoveAt(nodesToCheck.Count - 1);
                    eatenCells.Pop();
                }
            }
            while(nodesToCheck.Count != 0);

            return _baseNode;
        }*/

        private Node MenRafle(Pion[,] _board, Node _currentNode, Stack<Point> _path, bool _color)
        {
            foreach (Node child in MenTargets(_board, _currentNode.GetPosition(), _color))
            {
                if (!(_path.Contains(child.GetTarget())))
                {
                    _path.Push(child.GetTarget());
                    _currentNode.AddChild(MenRafle(_board, child, _path, _color));
                    _path.Pop();
                }
            }
            return _currentNode;
        }

        private List<Node> GetKingMove(Pion[,] _board, bool _color)
        {
            List<Node> kingMoves = KingTargets(_board, pLocation, _color);
            if (kingMoves.Count != 0 && !(bPeuxManger))
            {
                children.Clear();
                bPeuxManger = true;
            }
            if (bPeuxManger)
            {
                foreach (Node target in kingMoves)
                {
                    children.Add(KingRafle(_board, target, new Stack<Point>(), _color));
                }
            }
            else
            {
                kingMoves = KingMoves(_board, pLocation);
                foreach (Node target in kingMoves)
                {
                    children.Add(target);
                }
            }

            return kingMoves;
        }

        private List<Node> KingMoves(Pion[,] _board, Point _location)
        {
            List<Node> possibleMoves = new List<Node>();
            Point[] directions = new Point[4] { new Point(-1, -1), new Point(-1, 1), new Point(1, -1), new Point(1, 1) };

            foreach (Point direction in directions)
            {
                Point pCurrentLocation = _location;
                bool bBlocked = false;
                pCurrentLocation.X += direction.X;
                pCurrentLocation.Y += direction.Y;

                while (pCurrentLocation.X >= 0 && pCurrentLocation.X < 10 && pCurrentLocation.Y >= 0 && pCurrentLocation.Y < 10 && bBlocked == false)
                {
                    if (_board[pCurrentLocation.X, pCurrentLocation.Y] == null)
                    {
                        possibleMoves.Add(new Node(pCurrentLocation));

                        pCurrentLocation.X += direction.X;
                        pCurrentLocation.Y += direction.Y;
                    }
                    else
                    {
                        bBlocked = true;
                    }
                }
            }

            return possibleMoves;
        }

        private List<Node> KingTargets(Pion[,] _board, Point _location, bool _color)
        {
            List<Node> possibleMoves = new List<Node>();

            Point[] directions = new Point[4] { new Point(-1, -1), new Point(-1, 1), new Point(1, -1), new Point(1, 1) };

            foreach (Point direction in directions)
            {
                bool bAsFinished = false;
                Point pCurrentLocation = _location;
                Point pPossibleTarget = Point.Empty;

                do
                {
                    pCurrentLocation.X += direction.X;
                    pCurrentLocation.Y += direction.Y;

                    if (pCurrentLocation.X >= 0 && pCurrentLocation.X < 10 && pCurrentLocation.Y >= 0 && pCurrentLocation.Y < 10)
                    {
                        if (_board[pCurrentLocation.X, pCurrentLocation.Y] == null)
                        {
                            if (pPossibleTarget != Point.Empty)
                            {
                                possibleMoves.Add(new Node(pCurrentLocation, pPossibleTarget));
                            }
                        }
                        else
                        {
                            if (_board[pCurrentLocation.X, pCurrentLocation.Y].GetColor() != _color)
                            {
                                if (pPossibleTarget == Point.Empty)
                                {
                                    pPossibleTarget = pCurrentLocation;
                                }
                                else
                                {
                                    bAsFinished = true;
                                }
                            }
                            else
                            {
                                bAsFinished = true;
                            }
                        }
                    }
                    else
                    {
                        bAsFinished = true;
                    }
                }
                while (bAsFinished == false);
            }
            return possibleMoves;
        }

        /*private Node KingRafle(Pion[,] _board, Node _baseNode, bool _color)
        {
            Stack<Point> EatenPieces = new Stack<Point>();
            Queue<Node> nodesToCheck = new Queue<Node>();
            Node CurrentNode = _baseNode;
            int iLength = 0;

            do
            {
                foreach (Node possibleChild in KingTargets(_board, CurrentNode.GetPosition(), _color))
                {
                    if(!(EatenPieces.Contains(possibleChild.GetTarget())))
                    {
                        if (iLength == 0)
                        {
                            _baseNode.AddChild(possibleChild);
                        }
                        else
                        {
                            CurrentNode.AddChild(possibleChild);
                        }

                        nodesToCheck.Enqueue(possibleChild);
                    }
                }
                iLength++;

                CurrentNode = nodesToCheck.Dequeue();
            }
            while (nodesToCheck.Count != 0);

            return _baseNode;
        }*/

        private Node KingRafle(Pion[,] _board, Node _currentNode, Stack<Point> _path, bool _color)
        {
            foreach (Node child in KingTargets(_board, _currentNode.GetPosition(), _color))
            {
                if (_path.Contains(child.GetTarget()))
                {
                    _path.Push(child.GetTarget());
                    _currentNode.AddChild(KingRafle(_board, child, _path, _color));
                    _path.Pop();
                }
            }
            return _currentNode;
        }

        public void SetChildren(List<Node> _children)
        {
            children = _children;
        }

        public void SetLocation(Point _location)
        {
            pLocation = _location;
        }

        public List<Node> GetChildren()
        {
            return children;
        }

        public Point GetLocation()
        {
            return pLocation;
        }

        public bool CanEat()
        {
            return bPeuxManger;
        }

        public void RemoveChild(int _index)
        {
            children.RemoveAt(_index);
        }
    }
}
