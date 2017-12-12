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
        private static int posXi;
        private static int posYi;

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

        public void Position(int posDestX, int posDestY, Timer timer)
        {
            if (posDestX < getCurrentPos()[0])
            {
                if (posDestX != posXi)
                {
                    posXi--;
                }
            }
            else if (posDestX > getCurrentPos()[0])
            {
                if (posDestX != posXi)
                {
                    posXi++;
                }
            }


            if (posDestY < getCurrentPos()[1])
            {
                if (posDestY != posYi)
                {
                    posYi--;
                }
            }
            else if (posDestY > getCurrentPos()[1])
            {
                if (posDestY != posYi)
                {
                    posYi++;
                }
            }

            if ((posDestX == getCurrentPos()[0]) && (posDestY == getCurrentPos()[1]))
            {
                timer.Stop();
            }

            _pnlAxeY.Location = new Point(0, posYi);
            _pnlAxeX.Location = new Point(posXi, _pnlAxeY.Bottom - ((_pnlAxeX.Height / 2) + (_pnlAxeY.Height / 2)));
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
