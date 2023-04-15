using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HMS_ControlApp.Service
{
    public class LanguageService
    {
        public static void ChangeLanguage(Languages language)
        {
            var dictionary = new ResourceDictionary();

            if (language == Languages.Polski)
            {
                dictionary.Source = new Uri("..\\Resources\\StringResources.pl.xaml", UriKind.Relative);
            }
            else
            {
                dictionary.Source = new Uri("..\\Resources\\StringResources.en.xaml", UriKind.Relative);
            }

            Application.Current.Resources.MergedDictionaries.Add(dictionary);
        }

        public static string? GetStringByKey(string key)
        {
            return Application.Current.Resources[key] as string;
        }

        public enum Languages
        {
            English, Polski
        }
    }
}
