using System;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using Windows.Devices.Bluetooth;
using Windows.Devices.Enumeration;

namespace Simulateur.classes
{
    class Bluetooth
    {

        public Bluetooth()
        {

        }

        public bool SendNextCoord(double X, double Y)
        {
            return true;
        }

        public bool SendPenDown()
        {
            return true;
        }

        public bool SendPenUp()
        {
            return true;
        }

        public bool SendResetPosition()
        {
            return true;
        }
    }
}
