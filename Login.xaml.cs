using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectCSharp_SchoolGradingSystem
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        public Login()
        { 

            InitializeComponent();
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            result_username.Visibility = Visibility.Collapsed;
            result_password.Visibility = Visibility.Collapsed;
            if (Username.Text == "login")
            {
                
                if (Password.Password == "login")
                {
                   
                    MainWindowView x = new MainWindowView(1);
                    Application.Current.MainWindow.DataContext = x;
                    Application.Current.MainWindow.Title = "Dashboard";
                }
                else
                {
                    result_password.Foreground = new SolidColorBrush(Colors.Red);
                    result_password.Text = "Heslo bylo zadáno špatně";
                    result_password.Visibility = Visibility.Visible;
                }
            }
            else
            {
                result_username.Foreground = new SolidColorBrush(Colors.Red);
                result_username.Text = "Uživatelské jméno neexistuje";
                result_username.Visibility = Visibility.Visible;
                result_password.Visibility = Visibility.Collapsed;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindowView x = new MainWindowView(2);
            Application.Current.MainWindow.DataContext = x;
            Application.Current.MainWindow.Title = "Registrace";
        }
    }
}
