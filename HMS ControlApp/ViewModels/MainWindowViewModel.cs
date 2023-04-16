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
            GlobalSettings.PropertyChanged += GlobalSettings_PropertyChanged;
        }
  
        private bool _IsFrameShouldBeEnabled = false;
        public bool IsFrameShouldBeEnabled
        {
            get { return  GlobalSettings.isRsConnected; }
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
        private void GlobalSettings_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(GlobalSettings.isRsConnected))
                OnPropertyChanged(nameof(IsFrameShouldBeEnabled));
        }

        #endregion


    }
}
