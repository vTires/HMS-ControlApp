using HMS_ControlApp.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_ControlApp.ViewModels
{
    public class HeaderViewModel : INotifyPropertyChanged
    {
        public HeaderViewModel()
        {
            GlobalSettings.PropertyChanged += GlobalSettings_PropertyChanged;
            _COMPorts = new BindingList<string>();
            FindComPorts();
        }
        private BindingList <string> _COMPorts;
        private string _SelectedCOMPort;
        private bool _IsRsConnected;

        public BindingList<string> COMPorts
        {
            get { return _COMPorts; }
            set { _COMPorts = value;
                OnPropertyChanged("COMPorts");
            }
        }
        public string SelectedCOMPort
        {
            get { return _SelectedCOMPort; }
            set
            {
                _SelectedCOMPort = value;
                GlobalSettings.COMPort = value;
                OnPropertyChanged("COMPorts");
            }
        }
        public bool IsRsConnected
        {
            get { return GlobalSettings.isRsConnected; }
            set
            {
                _IsRsConnected = value;
                OnPropertyChanged("IsRsConnected");
            }
        }

        private void FindComPorts()
        {
            string[] comPorts = System.IO.Ports.SerialPort.GetPortNames();
            foreach (string port in comPorts)
            {
                COMPorts.Add(port);
            }
        }

        #region INotify
           
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void GlobalSettings_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(GlobalSettings.isRsConnected))
                IsRsConnected = GlobalSettings.isRsConnected;
        }


        #endregion
       
    }
}
