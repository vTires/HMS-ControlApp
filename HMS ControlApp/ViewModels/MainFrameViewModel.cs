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
            UpdateService.PropertyChanged += UpdateService_PropertyChanged;
            GlobalSettings.PropertyChanged += GlobalSettings_PropertyChanged;
        }

        private bool _IsFrameShouldBeEnabled = false;
        private double _CurrentTemperature;
        private double _CurrentRotation;
        private double _SPTemperature;
        private double _SPRotation;

        public bool IsFrameShouldBeEnabled
        {
            get { return GlobalSettings.isRsConnected; }
            set
            {
                _IsFrameShouldBeEnabled = value;
                OnPropertyChanged(nameof(IsFrameShouldBeEnabled));
            }
        }
        public double CurrentTemperature
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
        public double CurrentRotation
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
        public double SPTemperature
        {
            get { return _SPTemperature; }
            set
            {
                if (_SPTemperature != value)
                {
                    _SPTemperature = value;
                    OnPropertyChanged("SPTemperature");
                }
            }
        }
        public double SPRotation
        {
            get { return _SPRotation; }
            set
            {
                if (_SPRotation != value)
                {
                    _SPRotation = value;
                    OnPropertyChanged("SPRotation");
                }
            }
        }


        public void SetSpeed()
        {
            string CurrentSetPoint = Commands.SetSpeed.Replace("Y", SPRotation.ToString());
            Rs232Service.SendCommand(CurrentSetPoint);

        }
        public void SetTemperature()
        {
            string CurrentSetPoint = Commands.SetTemperature.Replace("Y", SPTemperature.ToString());
            Rs232Service.SendCommand(CurrentSetPoint);
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
        private void GlobalSettings_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(GlobalSettings.isRsConnected))
                OnPropertyChanged(nameof(IsFrameShouldBeEnabled));
        }

        #endregion
    }




}
