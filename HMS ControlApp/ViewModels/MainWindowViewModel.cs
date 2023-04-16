using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_ControlApp.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            IsFrameShouldBeEnabled = GlobalSettings.isRsConnected;
        }

        private bool _IsFrameShouldBeEnabled = false;
        public bool IsFrameShouldBeEnabled
        {
            get { return _IsFrameShouldBeEnabled; }
            set
            {
                _IsFrameShouldBeEnabled = value;
                OnPropertyChanged(nameof(IsFrameShouldBeEnabled));
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
