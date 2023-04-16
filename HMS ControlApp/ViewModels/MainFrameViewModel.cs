using HMS_ControlApp.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HMS_ControlApp.ViewModels
{
    public class MainFrameViewModel : INotifyPropertyChanged
    {
        public MainFrameViewModel()
        {
            //CurrentTemperature = UpdateService.CurrentTemperature;
            //_CurrentRotation = UpdateService.CurrentRotation;
            UpdateService.PropertyChanged += UpdateService_PropertyChanged;
        }


        private float _CurrentTemperature;
        private float _CurrentRotation;

        public float CurrentTemperature
        {
            get { return UpdateService.CurrentTemperature; }
            set
            {
                if (_CurrentTemperature != value)
                {
                    _CurrentTemperature = value;
                    OnPropertyChanged("CurrentTemperature");
                }
            }
        }
       
        public float CurrentRotation
        {
            get { return UpdateService.CurrentRotation; }
            set
            {
                if (_CurrentRotation != value)
                {
                    _CurrentRotation = value;
                    OnPropertyChanged("CurrentRotation");
                }
            }
        }





        #region INotify
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void UpdateService_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(UpdateService.CurrentTemperature))
                OnPropertyChanged(nameof(CurrentTemperature));
            else if (e.PropertyName == nameof(UpdateService.CurrentRotation))
                OnPropertyChanged(nameof(CurrentRotation));
        }

        #endregion
    }




}
