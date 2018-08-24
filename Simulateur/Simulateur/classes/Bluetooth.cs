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
            return SendToRobot("G1 X" + X + ".00 Y" + Y + ".00 A0 F0 \n");
        }

        public bool SendPenDown()
        {
            System.Threading.Thread.Sleep(100);
            if (SendToRobot("M1 160\n"))
            {
                System.Threading.Thread.Sleep(100);
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool SendPenUp()
        {
            System.Threading.Thread.Sleep(100);
            if (SendToRobot("M1 90\n"))
            {
                System.Threading.Thread.Sleep(100);
                return true;
            }
            else
            {
                return false;
            }
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
                bool bIsConnected = false;
                do
                {
                    try
                    {
                        localClient.Connect(targetDevice.DeviceAddress, BluetoothService.SerialPort);
                        bIsConnected = true;
                    }
                    catch
                    {
                        if (MessageBox.Show("Impossible de se connecter au robot... Voulez-vous ressayer ?", "Erreur connexion", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No)
                        {
                            bIsConnected = true;
                            CheckBox temp = form.Controls.Find("cbxUseBluetooth", true)[0] as CheckBox;
                            temp.Enabled = false;
                            temp.Checked = false;
                        }
                    }
                }
                while (!(bIsConnected));

                state.Text = "Connecté !";

                //SendToRobot("M4 0\n");
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
