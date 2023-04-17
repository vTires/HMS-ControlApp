using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_ControlApp.Models
{
    public class ExceptionsServiceModel : INotifyPropertyChanged
    {
        private int _exceptionNo;
        private string _exceptionTime;
        private string _exception;
        private string _exceptionStackTrace;

        public int exceptionNo
        {
            get { return _exceptionNo; }
            set
            {
                _exceptionNo = value;
                OnPropertyChanged("exceptionNo");
            }
        }
        public string exceptionTime
        {
            get { return _exceptionTime; }
            set
            {
                _exceptionTime = value;
                OnPropertyChanged("exceptionTime");
            }
        }
        public string exception
        {
            get { return _exception; }
            set
            {
                _exception = value;
                OnPropertyChanged("exception");
            }
        }
        public string exceptionStackTrace
        {
            get { return _exceptionStackTrace; }
            set
            {
                _exceptionStackTrace = value;
                OnPropertyChanged("exceptionStackTrace");
            }
        }

        #region INotify
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    
}
}
