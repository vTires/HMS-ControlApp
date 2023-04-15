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

        private void StartRotation(object sender, RoutedEventArgs e)
        {
            Rs232Service.SendCommand(Commands.StartRotation);
        }

        private void StartHeating(object sender, RoutedEventArgs e)
        {
            Rs232Service.SendCommand(Commands.StartHeating);
        }
      
    }
}
