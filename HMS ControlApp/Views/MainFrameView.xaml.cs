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
            if (btnStartStopRotation.Content == "Start rotation")
            {
                Rs232Service.SendCommand(Commands.StartRotation);
                GlobalSettings.serialPort.ReadLine();
                btnStartStopRotation.Content = "Stop rotation";
            }
            else
            {
                Rs232Service.SendCommand(Commands.StopRotation);
                GlobalSettings.serialPort.ReadLine();
                btnStartStopRotation.Content = "Start rotation";
            }
            
        }

        private void StartStopHeating(object sender, RoutedEventArgs e)
        {
            if (btnStartStopHeating.Content == "Start heating")
            {
                Rs232Service.SendCommand(Commands.StartHeating);
                GlobalSettings.serialPort.ReadLine();
                btnStartStopHeating.Content = "Stop heating";
            }
            else
            {
                Rs232Service.SendCommand(Commands.StopHeating);
                GlobalSettings.serialPort.ReadLine();
                btnStartStopHeating.Content = "Start heating";
            }
        }
      
        private void tbRotationSP_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbRotationSP != null) mainFrameViewModel.SetSpeed();
        }

        private void tbTempSP_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbTempSP != null) mainFrameViewModel.SetTemperature();
        }
    }
}
