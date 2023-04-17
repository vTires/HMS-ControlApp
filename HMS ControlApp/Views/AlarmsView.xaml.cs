using HMS_ControlApp.Service;
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
    /// Logika interakcji dla klasy AlarmsView.xaml
    /// </summary>
    public partial class AlarmsView : UserControl
    {
        ExceptionsService exceptionsService = new ExceptionsService();
        public AlarmsView()
        {
            InitializeComponent();
            dgExceptions.DataContext = exceptionsService;
        }

        private void ClearButtonExceptions_Click(object sender, RoutedEventArgs e)
        {
            ExceptionsService.exceptionsList.Clear();

        }

        private void AddButtonExceptions_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int[] array = new int[1];
                array[1] = 1;

            }
            catch (Exception ee)
            {
                ExceptionsService.ExceptionCatcher(ee);
            }
            dgExceptions.Items.Refresh();


        }


       
    }
}
