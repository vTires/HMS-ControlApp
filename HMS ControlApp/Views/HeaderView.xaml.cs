using HMS_ControlApp.Service;
using HMS_ControlApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO.Ports;
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
    /// Logika interakcji dla klasy HeaderView.xaml
    /// </summary>
    public partial class HeaderView : UserControl
    {
        HeaderViewModel headerViewModel = new HeaderViewModel();
        public HeaderView()
        {
            InitializeComponent();
            DataContext = headerViewModel;
        }

        private void cbComPortSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Rs232Service.COMChoosed();
        }
    }
}
