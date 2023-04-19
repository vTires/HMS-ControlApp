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

        public Rs232Service()
        {

        }

        public static void COMChoosed()
        {
            if (GlobalSettings.COMPort != null)
            {
                GlobalSettings.serialPort = new SerialPort(GlobalSettings.COMPort, 9600, Parity.Even, 7, StopBits.One);
                Rs232Service.ConnectRs();
                Rs232Service.SendCommand(Commands.PA_NEW);
                var response = GlobalSettings.serialPort.ReadLine();
                if (response == "PA_NEW\r")
                {
                    Rs232Service.SendCommand(Commands.StopHeating);
                    Rs232Service.SendCommand(Commands.StopRotation);
                    UpdateService.GetProcessValue_Dispatcher.Start();
                }
                else
                {
                    GlobalSettings.serialPort.Close();
                    MessageBox.Show("COM Port is not correct");
                }

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
                if (GlobalSettings.serialPort.IsOpen == true)
                {
                    GlobalSettings.isRsConnected = true;
                }
                else GlobalSettings.isRsConnected = false;
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
                if (command != "PA_NEW\r\n" && command != "IN_PV_3\r\n" && command != "IN_PV_5\r\n")
                {
                    var response = GlobalSettings.serialPort.ReadLine();
                }

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
