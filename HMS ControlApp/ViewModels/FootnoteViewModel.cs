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
        private string _currentTime;
        private Thread timeThread;

        public FootnoteViewModel()
        {
            StartClock();
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
