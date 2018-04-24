using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinthe.Classes
{
    class Cell
    {
        private bool topWall, bottomWall, leftWall, rightWall, visited;

        public Cell()
        {
            topWall = true;
            bottomWall = true;
            leftWall = true;
            rightWall = true;
            visited = false;
        }

        public void RemoveWallTop()
        {
            topWall = false;
        }

        public bool IsWallTop()
        {
            return topWall;
        }

        public void RemoveWallBottom()
        {
            bottomWall = false;
        }

        public bool IsWallBottom()
        {
            return bottomWall;
        }

        public void RemoveWallRight()
        {
            rightWall = false;
        }

        public bool IsWallRight()
        {
            return rightWall;
        }

        public void RemoveWallLeft()
        {
            leftWall = false;
        }

        public bool IsWallLeft()
        {
            return leftWall;
        }

        public void SetVisited(bool bValue)
        {
            visited = bValue;
        }

        public bool IsVisited()
        {
            return visited;
        }
    }
}
