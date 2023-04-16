using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_ControlApp.Service
{
    public class UpdateService /*: INotifyPropertyChanged*/
    {
        public static System.Windows.Threading.DispatcherTimer GetProcessValue_Dispatcher;

        private static float _CurrentTemperature;
        private static float _CurrentRotation;

        public static float CurrentTemperature
        {
            get { return _CurrentTemperature; }
            set { _CurrentTemperature = value;
                OnPropertyChanged(nameof(CurrentTemperature));
            }
        }
        public static float CurrentRotation
        {
            get { return _CurrentRotation; }
            set { _CurrentRotation = value;
                OnPropertyChanged(nameof(CurrentRotation));
            }
        }


        public UpdateService()
        {
            GetProcessValue_Dispatcher = new System.Windows.Threading.DispatcherTimer();
            GetProcessValue_Dispatcher.Tick += GetProcessValue_Tick;
            GetProcessValue_Dispatcher.Interval = new TimeSpan(0, 0, 0, 1, 0);
        }

        public void GetProcessValue_Tick(object sender, EventArgs e)
        {
            Rs232Service.SendCommand(Commands.GetTempHotplate);
            var CurrentTemp = GlobalSettings.serialPort.ReadLine();
            UpdateService.CurrentTemperature = ConvertReadToFloat(CurrentTemp);
            Rs232Service.SendCommand(Commands.GetRotation);
            var CurrentRot = GlobalSettings.serialPort.ReadLine();
            UpdateService.CurrentRotation = ConvertReadToFloat(CurrentRot);
        }

        public float ConvertReadToFloat(string Readline)
        {
            string[] substrings = Readline.Split(' ');
            string temp_str = substrings[1];
            temp_str = temp_str.Trim('\r');
            temp_str = temp_str.Replace(".", ",");
            return float.Parse(temp_str);

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
