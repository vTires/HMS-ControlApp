using HMS_ControlApp.Service;
using HMS_ControlApp.Views;
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
using static HMS_ControlApp.Service.LanguageService;

namespace HMS_ControlApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FootnoteView footnoteView = new FootnoteView();
        MainFrameView mainFrameView = new MainFrameView();
        HeaderView headerView = new HeaderView();

        public MainWindow()
        {
            
            InitializeComponent();
            LanguageService.ChangeLanguage(Languages.English);
            GlobalSettings globalsettings = new GlobalSettings();


        }
    }
}
