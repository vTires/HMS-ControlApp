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
        private float _CurrentTemperature;
        private float _CurrentRotation;
        private float _SPTemperature;
        private float _SPRotation;

        public bool IsFrameShouldBeEnabled
        {
            get { return GlobalSettings.isRsConnected; }
            set
            {
                _IsFrameShouldBeEnabled = value;
                OnPropertyChanged(nameof(IsFrameShouldBeEnabled));
            }
        }
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
        public float SPTemperature
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
        public float SPRotation
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
            GlobalSettings.serialPort.ReadLine();          

        }
        public void SetTemperature()
        {
            string CurrentSetPoint = Commands.SetSpeed.Replace("Y", SPTemperature.ToString());
            Rs232Service.SendCommand(CurrentSetPoint);
            GlobalSettings.serialPort.ReadLine();
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
