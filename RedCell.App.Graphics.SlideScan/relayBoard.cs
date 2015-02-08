using System;
using FTD2XX_NET;

namespace RedCell.Devices
{
   
    /// <summary>
    /// SainSmart 5V USB Relay Board control
    /// 
    /// - Make sure FTDI D2XX drivers are installed: http://www.ftdichip.com/Drivers/D2XX.htm
    /// - Reference the .NET Wrapper FTD2XX_NET v1.0.14.0: http://www.ftdichip.com/Support/SoftwareExamples/CodeExamples/CSharp.htm
    /// 
    /// Author: Anthony Marshall, Feburary 2013
    /// 
    /// </summary>


    public static class RelayBoard
    {
        private static byte[] startup = { 0x00 };
        private static uint bytesToSend = 1;

        private static UInt32 ftdiDeviceCount = 0;
        private static FTDI.FT_STATUS ftStatus = FTDI.FT_STATUS.FT_OK;

        static FTDI myFtdiDevice = new FTDI();

        /// <summary>
        /// Find the FDTI chip, connect, set baud to 9600, set sync bit-bang mode
        /// </summary>
        /// <returns></returns>
        public static bool Initialize()
        {
            // Determine the number of FTDI devices connected to the machine
            ftStatus = myFtdiDevice.GetNumberOfDevices(ref ftdiDeviceCount);
            // Check status
            if (ftStatus == FTDI.FT_STATUS.FT_OK)
            {
                Console.WriteLine("Number of FTDI devices: " + ftdiDeviceCount);
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Failed to get number of devices (error " + ftStatus + ")");
                return false;
            }

            if (ftdiDeviceCount == 0)
            {              
                Console.WriteLine("Relay board not found, please try again");
                return false;
            }
            else
            {
                // Allocate storage for device info list
                FTDI.FT_DEVICE_INFO_NODE[] ftdiDeviceList = new FTDI.FT_DEVICE_INFO_NODE[ftdiDeviceCount];

                // Populate our device list
                ftStatus = myFtdiDevice.GetDeviceList(ftdiDeviceList);

                // Open first device in our list by serial number
                ftStatus = myFtdiDevice.OpenBySerialNumber(ftdiDeviceList[0].SerialNumber);

                if (ftStatus != FTDI.FT_STATUS.FT_OK)
                {
                    Console.WriteLine("Error connecting to relay board");
                    return false;
                }

                // Set Baud rate to 9600
                ftStatus = myFtdiDevice.SetBaudRate(9600);

                // Set FT245RL to synchronous bit-bang mode, used on sainsmart relay board
                myFtdiDevice.SetBitMode(0xFF, FTD2XX_NET.FTDI.FT_BIT_MODES.FT_BIT_MODE_SYNC_BITBANG);
                // Switch off all the relays
                myFtdiDevice.Write(startup, 1, ref bytesToSend);

                return true;
            }
        }

        /// <summary>
        /// Activate/De-activate a specific relay
        /// </summary>
        /// <param name="relay"></param>
        /// <param name="state"></param>
        public static void Set(RelayNumbers relay, Relaystate state)
        {
            uint numBytes = 1;
            uint relayAddr = (uint) relay;
            byte[] @out = { 0x00 };
            byte pins = 0x00;
            byte output = 0x00;

            // Find which relays are ON/OFF
            myFtdiDevice.GetPinStates(ref pins);

            switch (state)
            {
                case Relaystate.ON:
                    output = (byte)(pins | relayAddr);
                    break;
                case Relaystate.OFF:
                    output = (byte)(pins & ~(relayAddr));
                    break;
            }

            @out[0] = output;
            myFtdiDevice.Write(@out, 1, ref numBytes);
        }
    }
}
