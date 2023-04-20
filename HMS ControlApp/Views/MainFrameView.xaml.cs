using HMS_ControlApp.Service;
using HMS_ControlApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HMS_ControlApp.Views
{
    /// <summary>
    /// Logika interakcji dla klasy MainFrameView.xaml
    /// </summary>
    public partial class MainFrameView : UserControl
    {
        MainFrameViewModel mainFrameViewModel = new MainFrameViewModel();

        public MainFrameView()
        {
            InitializeComponent();
            DataContext = mainFrameViewModel;
            
        }

        private void StartStopRotation(object sender, RoutedEventArgs e)
        {
            if (btnStartStopRotation.Content == Application.Current.FindResource("StringMainFrame_StartRotation") as string)
            {
                Rs232Service.SendCommand(Commands.StartRotation);
                btnStartStopRotation.Content = Application.Current.FindResource("StringMainFrame_StopRotation") as string;
            }
            else
            {
                Rs232Service.SendCommand(Commands.StopRotation);
                btnStartStopRotation.Content = Application.Current.FindResource("StringMainFrame_StartRotation") as string;
            }
            
        }

        private void StartStopHeating(object sender, RoutedEventArgs e)
        {
            if (btnStartStopHeating.Content == Application.Current.FindResource("StringMainFrame_StartHeating") as string)
            {
                Rs232Service.SendCommand(Commands.StartHeating);
                btnStartStopHeating.Content = Application.Current.FindResource("StringMainFrame_StopHeating") as string;
            }
            else
            {
                Rs232Service.SendCommand(Commands.StopHeating);
                btnStartStopHeating.Content = Application.Current.FindResource("StringMainFrame_StartHeating") as string;
            }
        }

        private void StartStopTime(object sender, RoutedEventArgs e)
        {
            if (btnStartStopTime.Content == Application.Current.FindResource("StringMainFrame_StartTime") as string)
            {
                //Rs232Service.SendCommand(Commands.StartTime);
                btnStartStopTime.Content = Application.Current.FindResource("StringMainFrame_StopTime") as string;
            }
            else
            {
                //Rs232Service.SendCommand(Commands.StopTime);
                btnStartStopTime.Content = Application.Current.FindResource("StringMainFrame_StartTime") as string;
            }
        }

        private void tbRotationSP_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbRotationSP != null && GlobalSettings.serialPort != null) mainFrameViewModel.SetSpeed();
        }

        private void tbTempSP_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbTempSP != null && GlobalSettings.serialPort != null) mainFrameViewModel.SetTemperature();
        }

        private void tbTime_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbTempSP != null && GlobalSettings.serialPort != null) mainFrameViewModel.SetTemperature();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mainFrameViewModel.ChangeTemperatureControl((byte)e.NewValue);
        }
    }
}
