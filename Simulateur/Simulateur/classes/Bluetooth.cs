using System.Windows.Forms;
using Windows

namespace Simulateur.classes
{
    class Bluetooth
    {
        public Bluetooth()
        {
            ConnectRobot();
            SendToRobot("M10<0x0A>");
        }

        public bool SendNextCoord(double X, double Y)
        {
            return SendToRobot("G1 X" + X + " Y" + Y + "<0x0A>");
        }

        public bool SendPenDown()
        {
            return SendToRobot("M1 90<0x0A>");
        }

        public bool SendPenUp()
        {
            return SendToRobot("M1 160<0x0A>");
        }

        public bool SendResetPosition()
        {
            return SendToRobot("G28<0x0A>");
        }

        private void ConnectRobot()
        {
            
        }

        private bool SendToRobot(string data)
        { 
            //System.Threading.Thread.Sleep(100);
            return true;
        }
    }
}
