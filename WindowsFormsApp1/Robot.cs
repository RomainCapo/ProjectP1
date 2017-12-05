using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp1
{
    class Robot
    {
        private Panel _pnlSurface;
        private Panel _pnlAxeX;
        private Panel _pnlAxeY;

        public Robot(Panel pnlSurface, Panel pnlAxeX, Panel pnlAxeY)
        {
            _pnlSurface = pnlSurface;
            _pnlAxeX = pnlAxeX;
            _pnlAxeY = pnlAxeY;
        }

        public void RetourPositionDepart()
        {
            _pnlAxeX.Location = new Point(0, 0);
            _pnlAxeY.Location = new Point(0, 0);
        }

        public void Position(int x, int y)
        {
            _pnlAxeY.Location = new Point(0, y);
            _pnlAxeX.Location = new Point(x, _pnlAxeY.Bottom - ((_pnlAxeX.Height / 2) + (_pnlAxeY.Height /2)));     
        }

        public int[] getCurrentPos()
        {
            int[] currentPos = new int[2];

            currentPos[0] = _pnlAxeX.Left - (_pnlAxeX.Width / 2);
            currentPos[1] = _pnlAxeY.Bottom - (_pnlAxeY.Height / 2);

            return currentPos;
        }
    }
}
