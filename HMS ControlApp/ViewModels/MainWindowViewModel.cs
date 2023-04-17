using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HMS_ControlApp.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            
        }
  
        

        #region INotify
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void SetPressedStyle(Button button)
        {
            button.Style = Application.Current.FindResource("MenuButtonPressedStyle") as Style;
        }
        public void SetStyle(Button button)
        {
            button.Style = Application.Current.FindResource("MenuButtonStyle") as Style;
        }

        #endregion


    }
}
