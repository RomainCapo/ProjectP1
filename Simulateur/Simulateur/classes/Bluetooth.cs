using System.Diagnostics;
using System.Windows.Forms;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Devices.Enumeration;

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

        private void Scan()
        {
            string[] requestedProperties = { "System.Devices.Aep.DeviceAddress", "System.Devices.Aep.IsConnected" };

            DeviceWatcher deviceWatcher =
                        DeviceInformation.CreateWatcher(
                                BluetoothLEDevice.GetDeviceSelectorFromPairingState(false),
                                requestedProperties,
                                DeviceInformationKind.AssociationEndpoint);

            // Register event handlers before starting the watcher.
            // Added, Updated and Removed are required to get all nearby devices
            deviceWatcher.Added += DeviceWatcher_Added;
            deviceWatcher.Updated += DeviceWatcher_Updated;
            deviceWatcher.Removed += DeviceWatcher_Removed;

            // Start the watcher.
            deviceWatcher.Start();
        }

        private async void ConnectDevice(DeviceInformation device)
        {

        }

        private void DeviceWatcher_Added(DeviceWatcher x, DeviceInformation y)
        {
            if(y.Name == "Makeblock_LE")
            {
                ConnectDevice(y);
            }
        }

        private void DeviceWatcher_Updated(DeviceWatcher x, DeviceInformationUpdate y)
        {

        }

        private void DeviceWatcher_Removed(DeviceWatcher x, DeviceInformationUpdate y)
        {

        }

        private bool SendToRobot(string data)
        { 
            //System.Threading.Thread.Sleep(100);
            return true;
        }
    }
}
