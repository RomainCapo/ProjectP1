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

        public Tree(Point _location)
        {
            children = new List<Node>();
            pLocation = _location;
        }

        public bool Next(Point _destination)
        {
            foreach(Node child in children)
            {
                if(child.GetPosition() == _destination)
                {
                    pLocation = child.GetPosition();
                    children = child.GetChildren();
                    return true;
                }
            }
            return false;
        }

        public int GenerateTree(Pion[,] _board, bool _color)
        {
            bPeuxManger = false;
            int iMaxLength = 0;

            children = GetMovements(_board, iMaxLength);

            return iMaxLength;
        }

        private List<Node> GetMovements(Pion[,] _board, int _length)
        {
            if(_board[pLocation.X, pLocation.Y].GetState())
            {

            }
            else
            {
                List<Node> targets = BasicAsTarget(_board, pLocation); 
                if(targets.Count != 0 && !(bPeuxManger))
                {
                    bPeuxManger = true;
                }
                if(bPeuxManger)
                {
                    foreach(Node child in children)
                    {
                        children.Add(BasicRafle(child, new Stack<Point>(), _length));
                    }
                }
                else
                {

                }
                
            }

            return children;
        }

        private List<Node> BasicAsTarget(Pion[,] _board, Point _position)
        {
            List<Node> children = new List<Node>();
            for(int y = -1; y <= 1; y +=2)
            {
                for(int x = -1; x <= 1; x +=2)
                {
                    bool bExist = true;
                    for(int compteur = 1; compteur <= 2; compteur++)
                    {
                        if (_position.X + (x * compteur) < 0 && _position.X + (x * compteur) >= 10 && _position.Y + (y * compteur) < 0 && _position.Y + (y * compteur) >= 10)
                        {
                            bExist = false;
                        }
                    }
                    if(bExist)
                    {
                        children.Add(new Node(new Point(_position.X + (x * 2), _position.Y + (y * 2))));
                    }
                    
                }
            }
            return children;

        }

        private Node BasicRafle(Node _currentNode, Stack<Point> _path, int _length)
        {
            return _currentNode;
        }
        
        public List<Node> GetChildren()
        {
            return children;
        }

        public Point GetLocation()
        {
            return pLocation;
        }
    }
}
