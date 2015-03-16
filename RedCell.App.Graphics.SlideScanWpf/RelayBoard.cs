using System;
using System.Threading.Tasks;

namespace RedCell.Devices
{   
    /// <summary>
    /// SainSmart 5V USB Relay Board control
    /// 
    /// - Make sure FTDI D2XX drivers are installed: http://www.ftdichip.com/Drivers/D2XX.htm
    /// Based on code by Anthony Marshall
    /// 
    /// </summary>
    public static class RelayBoard
    {
        private static byte[] startup = { 0x00, 0x00, 0x00, 0x00 };
        private static uint bytesToSend = 1;
        private static bool initialized = false;
        private static UInt32 ftdiDeviceCount = 0;
        private static FTDI.FT_STATUS ftStatus = FTDI.FT_STATUS.FT_OK;

        static FTDI myFtdiDevice = new FTDI();

        /// <summary>
        /// Find the FDTI chip, connect, set baud to 9600, set sync bit-bang mode
        /// </summary>
        /// <returns></returns>
        public static void Initialize(bool force = false)
        {
            if (initialized && !force)
                return;

            // Determine the number of FTDI devices connected to the machine
            ftStatus = myFtdiDevice.GetNumberOfDevices(ref ftdiDeviceCount);
            // Check status
            if (ftStatus == FTDI.FT_STATUS.FT_OK)
                Console.WriteLine("Number of FTDI devices: " + ftdiDeviceCount);
            else
                throw new RelayBoardException("Failed to get number of devices (error " + ftStatus + ")");

            if (ftdiDeviceCount == 0)
                throw new RelayBoardException("Relay board not found, try:\r\nchecking connections\r\nusing without a USB hub\r\nusing a powered USB hub");

            // Allocate storage for device info list
            FTDI.FT_DEVICE_INFO_NODE[] ftdiDeviceList = new FTDI.FT_DEVICE_INFO_NODE[ftdiDeviceCount];

            // Populate our device list
            ftStatus = myFtdiDevice.GetDeviceList(ftdiDeviceList);

            // Open first device in our list by serial number
            ftStatus = myFtdiDevice.OpenBySerialNumber(ftdiDeviceList[0].SerialNumber);

            if (ftStatus != FTDI.FT_STATUS.FT_OK)
                throw new RelayBoardException("The relay board is reporting an error: " + Enum.GetName(typeof(FTDI.FT_STATUS), ftStatus));

            // Set Baud rate to 9600
            ftStatus = myFtdiDevice.SetBaudRate(9600);

            // Set FT245RL to synchronous bit-bang mode, used on sainsmart relay board
            myFtdiDevice.SetBitMode(0xFF, FTDI.FT_BIT_MODES.FT_BIT_MODE_SYNC_BITBANG);
            // Switch off all the relays
            myFtdiDevice.Write(startup, bytesToSend, ref bytesToSend);
            initialized = true;
        }

        /// <summary>
        /// initialize as an asynchronous operation.
        /// </summary>
        public async static Task InitializeAsync(bool force = false)
        {
            await Task.Run(() => Initialize(force));
        }

        /// <summary>
        /// Gets or sets the pins.
        /// </summary>
        /// <value>The pins.</value>
        public static byte Pins { get; set; }

        /// <summary>
        /// Activate/De-activate a specific relay
        /// </summary>
        /// <param name="relay"></param>
        /// <param name="state"></param>
        public async static void Set(RelayNumbers relay, Relaystate state)
        {
            await Task.Run(() =>
            {
                uint numBytes = 1;
                uint relayAddr = (uint)relay;
                byte[] @out = { 0x00 };
                byte pins = 0x00;
                byte output = 0x00;

                // Get current pin state.
                myFtdiDevice.GetPinStates(ref pins);

                switch (state)
                {
                    case Relaystate.ON: output = (byte)(pins | relayAddr); break;
                    case Relaystate.OFF: output = (byte)(pins & ~(relayAddr)); break;
                }
                myFtdiDevice.GetPinStates(ref pins);
                Pins = pins;

                @out[0] = output;
                myFtdiDevice.Write(@out, 1, ref numBytes);
            });
        }
    }
}
