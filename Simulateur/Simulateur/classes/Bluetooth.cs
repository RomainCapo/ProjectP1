using System;
using System.Windows.Forms;
using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;

namespace Simulateur.classes
{
    class Bluetooth
    {
        bool inProgress = false, isConnected = false;
        BluetoothClient client;

        public Bluetooth()
        {
            ConnectDevice();
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

        private bool SendToRobot(string data)
        { 
            //System.Threading.Thread.Sleep(100);
            return true;
        }

        private void ConnectDevice()
        {
            const string TARGETADDRESS = "Geronimo-Samsung";
            const string TARGETPIN = "";

            BluetoothDeviceInfo robot = Scan(TARGETADDRESS);
            if(robot != null)
            {
                bool result = Connect(robot, TARGETPIN);

                if (result)
                {
                    MessageBox.Show("Connexion au robot réussie !", "Connecté", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isConnected = true;
                }
                else
                {
                    if (MessageBox.Show("Impossible de se connecter au robot !\nVoulez-vous recommencer ?", "Erreur", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                    {
                        ConnectDevice();
                    }
                }
            }
            else
            {
                if(MessageBox.Show("Impossible de trouver le robot !\nVoulez-vous recommencer ?", "Erreur", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    ConnectDevice();
                }
            }
        }

        private BluetoothDeviceInfo Scan(string TARGETADDRESS)
        {
            client = new BluetoothClient();
            BluetoothDeviceInfo[] devices = client.DiscoverDevices(10, true, true, true, false);
            foreach (BluetoothDeviceInfo device in devices)
            {
                if (device.DeviceName == TARGETADDRESS)
                {
                    return device;
                }
            }
            return null;
        }

        private bool Connect(BluetoothDeviceInfo target, string PIN)
        {
            if(!client.Connected)
            {
                client = new BluetoothClient();
            }

            if (!BluetoothSecurity.PairRequest(target.DeviceAddress, PIN))
            {
                return false;
            }

            inProgress = true;
            client.BeginConnect(target.DeviceAddress, target.InstalledServices[0], ConnectionResult, client);
            while (inProgress) { }
            return client.Connected;
        }

        private void ConnectionResult(IAsyncResult result)
        {
            inProgress = false;
        }
    }
}
