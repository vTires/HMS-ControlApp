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
    /// Logika interakcji dla klasy SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        LanguageService languageService;

        public SettingsView()
        {
            InitializeComponent();
            languageService = new LanguageService();
            DataContext = languageService;
            cbLanguage.ItemsSource = Enum.GetValues(typeof(LanguageService.Languages));
        }

        private void cbLanguageValueChange(object sender, SelectionChangedEventArgs e)
        {
            if (cbLanguage.SelectedIndex == (int)LanguageService.Languages.Polski)
            {
                LanguageService.ChangeLanguage(LanguageService.Languages.Polski);
            }
            else
            {
                LanguageService.ChangeLanguage(LanguageService.Languages.English);
            }
        }
    }
}
