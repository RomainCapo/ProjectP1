using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Simulateur.classes
{
    class Bluetooth
    {
        Form1 form;
        Label state;
        BluetoothClient localClient;

        public Bluetooth(Form1 _form)
        {
            form = _form;
            state = form.Controls.Find("lblBluetooth", true)[0] as Label;

            ConnectRobot();
        }

        public bool SendNextCoord(double X, double Y)
        {
            return SendToRobot("G1 X" + X + " Y" + Y + "\n");
        }

        public bool SendPenDown()
        {
            return SendToRobot("M1 160\n");
        }

        public bool SendPenUp()
        {
            return SendToRobot("M1 90\n");
        }

        public bool SendResetPosition()
        {
            return SendToRobot("G28\n");
        }

        private void ConnectRobot()
        {
            localClient = new BluetoothClient();
            BluetoothDeviceInfo target = new BluetoothDeviceInfo(BluetoothAddress.Parse("000B10700286")); 

            Pair(target);
            Connect(target);
        }

        private void Pair(BluetoothDeviceInfo targetDevice)
        {
            if (!(targetDevice.Authenticated))
            { 
                state.Text = "Pairage ...";
                if (!(BluetoothSecurity.PairRequest(targetDevice.DeviceAddress, "")))
                {
                    Application.Exit();
                }
            }
        }

        private void Connect(BluetoothDeviceInfo targetDevice)
        {
            state.Text = "Connexion ...";
            if (targetDevice.Authenticated && !(localClient.Connected))
            {
                localClient.Connect(targetDevice.DeviceAddress, BluetoothService.SerialPort);
                state.Text = "Connecté !";

                SendToRobot("M10\n");
                SendPenUp();
                SendResetPosition();
                SendPenUp();
            }
        }

        private bool SendToRobot(string data)
        {
            CheckBox temp = (CheckBox)form.Controls.Find("cbxUseBluetooth", true)[0];

            if (temp.Checked)
            {
                Stream stream = localClient.GetStream();

                byte[] DATA = Encoding.ASCII.GetBytes(data);

                stream.Write(DATA, 0, DATA.Length);
                stream.Flush();

                byte[] receive = new byte[1024];
                string readMessage = "";
                do
                {
                    stream.Read(receive, 0, receive.Length);
                    readMessage += Encoding.ASCII.GetString(receive);
                }
                while (!(readMessage.Contains("OK")));
            }
           
            return true;
        }
    }
}
