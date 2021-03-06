﻿using InTheHand.Net;
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
        CheckBox temp;
        bool bEnableBluetooth;

        public Bluetooth(Form1 _form)
        {
            form = _form;
            state = _form.Controls.Find("lblBluetooth", true)[0] as Label;
            temp = _form.Controls.Find("cbxUseBluetooth", true)[0] as CheckBox;
            bEnableBluetooth = true;

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
            SendPenUp();
            return SendNextCoord(0, 0);
            //return SendToRobot("G28\n");
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
                        state.Text = "Connecté !";
                        bIsConnected = true;
                    }
                    catch
                    {
                        if (MessageBox.Show("Impossible de se connecter au robot... Voulez-vous ressayer ?", "Erreur connexion", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No)
                        {
                            bIsConnected = true;
                            CheckBox temp = form.Controls.Find("cbxUseBluetooth", true)[0] as CheckBox;
                            state.Text = "Non-connecté !";
                            temp.Enabled = false;
                            temp.Checked = false;
                        }
                    }
                }
                while (!(bIsConnected));

                SendToRobot("G28\n");
                SendToRobot("M10\n");
            }
        }

        private bool SendToRobot(string data)
        {
            if (temp.Checked && bEnableBluetooth)
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

        public bool EnableBluetooth(bool state)
        {
            return bEnableBluetooth = state;
        }
    }
}
