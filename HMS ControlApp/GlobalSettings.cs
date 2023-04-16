using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_ControlApp
{
    public class GlobalSettings
    {
        public static SerialPort? serialPort;
        public static string COMPort;
        private static bool _isRsConnected = false;

        public GlobalSettings()
        {
            
        }

        

        public static bool isRsConnected
        {
            get { return _isRsConnected; }
            set
            {
                _isRsConnected = value;
                OnPropertyChanged(nameof(isRsConnected));
            }
        }




        #region INotify
        public static event PropertyChangedEventHandler PropertyChanged;
        private static void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
