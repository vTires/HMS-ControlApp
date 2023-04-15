using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HMS_ControlApp.Service
{
    public class Rs232Service
    {
        //private static SerialPort? serialPort;

        public Rs232Service()
        {
           // serialPort = new SerialPort("COM3", 9600, Parity.Even, 7, StopBits.One);
        }

        public static void COMChoosed()
        {
            if (GlobalSettings.COMPort != null)
            {
                GlobalSettings.serialPort = new SerialPort(GlobalSettings.COMPort, 9600, Parity.Even, 7, StopBits.One);
                Rs232Service.ConnectRs();
                Rs232Service.SendCommand(Commands.PA_NEW);
            }
            else
            {
                MessageBox.Show("Error in COM Port");
            }
        }

        public static void ConnectRs()
        {
            if (GlobalSettings.serialPort != null)
            {
                GlobalSettings.serialPort.Open();
            }
            else
            {
                MessageBox.Show("There is no COM Port");
            }

            
        }
        public static void SendCommand(string command)
        {
            if (GlobalSettings.serialPort != null)
            {
                GlobalSettings.serialPort.Write(command);
            }
            else
            {
                MessageBox.Show("There is no COM Port");
            }
            
        }

        public static void ReadData(SerialPort serialPort)
        {
            string response = serialPort.ReadLine();
        }

        public static void CloseRs(SerialPort serialPort)
        {
            serialPort.Close();
        }
    }
}
