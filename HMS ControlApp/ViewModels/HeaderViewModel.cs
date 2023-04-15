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

        private BindingList <string> _COMPorts;
        private string _SelectedCOMPort;

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


        public HeaderViewModel()
        {
            _COMPorts = new BindingList<string>();
            FindComPorts();
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
        #endregion
    }
}
