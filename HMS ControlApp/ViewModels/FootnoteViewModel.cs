using HMS_ControlApp.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace HMS_ControlApp.ViewModels
{
    public class FootnoteViewModel : INotifyPropertyChanged
    {
        public event EventHandler TimeChanged;
        private string _currentTime;
        private Thread timeThread;
        private ChartService chartService;

        public FootnoteViewModel()
        {
            StartClock();
            chartService = new ChartService();
        }

        public string CurrentTime
        {
            get { return _currentTime; }
            set
            {
                if (_currentTime != value)
                {
                    _currentTime = value;
                    OnPropertyChanged("CurrentTime");
                }
            }
        }

        private void StartClock()
        {
            timeThread = new Thread(new ThreadStart(UpdateClock));
            timeThread.IsBackground = true;
            timeThread.Start();
        }

        private void UpdateClock()
        {

            while (true)
            {
                DateTime currentTime = DateTime.Now;
                string formattedTime = currentTime.ToString("HH:mm:ss");


                Application.Current.Dispatcher.Invoke(() =>
                    {
                        CurrentTime = formattedTime;
                        if (chartService != null) chartService.SetCurrentTime(currentTime);
                        
                    });
                

                Thread.Sleep(1000);
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
