using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_ControlApp
{
    public class GlobalSettings
    {
        public static SerialPort? serialPort;

        public GlobalSettings()
        {
            serialPort = new SerialPort("COM3", 9600, Parity.Even, 7, StopBits.One);
        }
    }
}
