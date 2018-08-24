using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Simulateur.classes.dames
{
    class Node
    {
        Point pPosition;
        List<Node> Children;

        public Node(Point _position)
        {
            Children = new List<Node>();

            pPosition = _position;
        }

        public void AddChild(Node Child)
        {
            Children.Add(Child);
        }

        public List<Node> GetChildren()
        {
            return Children;
        }

        public Point GetPosition()
        {
            return pPosition;
        }
    }
}
