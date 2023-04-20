using HMS_ControlApp.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HMS_ControlApp.Service
{
    public class Rs232Service
    {

        
        public Rs232Service()
        {
            
        }

        public static void COMChoosed()
        {
            HeaderView headerView = new HeaderView();
            if (GlobalSettings.COMPort != null)
            {
                GlobalSettings.serialPort = new SerialPort(GlobalSettings.COMPort, 9600, Parity.Even, 7, StopBits.One);
                
                try
                {
                    GlobalSettings.serialPort.ReadTimeout = 1000;
                    Rs232Service.ConnectRs();
                    Rs232Service.SendCommand(Commands.PA_NEW);
                    var response = GlobalSettings.serialPort.ReadLine();
                    if (response == "PA_NEW\r")
                    {
                        GlobalSettings.isRsConnected = true;
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
                catch (TimeoutException ex)
                {
                    GlobalSettings.serialPort.Close();
                    ExceptionsService.ExceptionCatcher(ex);
                    MessageBox.Show("Timeout while waiting for response from the device. Please check the connection and try again.");
                    GlobalSettings.COMPort = null;
                    headerView.ZeroComboBox();
                }
                catch (IOException ex)
                {
                    GlobalSettings.serialPort.Close();
                    ExceptionsService.ExceptionCatcher(ex);
                    MessageBox.Show("An I/O error occurred while communicating with the device: " + ex.Message);
                    GlobalSettings.COMPort = null;
                    headerView.ZeroComboBox();
                }
                catch (Exception ex)
                {
                    GlobalSettings.serialPort.Close();
                    ExceptionsService.ExceptionCatcher(ex);
                    MessageBox.Show("An error occurred while communicating with the device: " + ex.Message);
                    GlobalSettings.COMPort = null;
                    headerView.ZeroComboBox();
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
                    //GlobalSettings.isRsConnected = true;
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
            try
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
            catch (Exception e)
            {
                ExceptionsService.ExceptionCatcher(e);
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
