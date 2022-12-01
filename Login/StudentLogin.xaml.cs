using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Xml.Linq;
using ProjectCSharp_SchoolGradingSystem.Models.DB;

namespace ProjectCSharp_SchoolGradingSystem
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class StudentLogin : UserControl
    {
        public StudentLogin()
        {

            InitializeComponent();

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            result_username.Visibility = Visibility.Collapsed;
            result_password.Visibility = Visibility.Collapsed;
            string studid = "";
            string studpass = "";
            using (var db = new SchoolSystem1Context())
            {
                if (Username.Text != "")
                {

                    try
                    {
                        var studentload = db.Student.Where(s => s.StudentId == Username.Text).ToList();


                        studid = studentload[0].StudentId.ToString();
                        studpass = studentload[0].Password.ToString();
                    }
                    catch
                    {
                        result_username.Foreground = new SolidColorBrush(Colors.Red);
                        result_username.Text = "Uživatelské jméno neexistuje";
                        result_username.Visibility = Visibility.Visible;
                        result_password.Visibility = Visibility.Collapsed;
                    }
                }
            }
            if(studid != "")
            {
                if (Password.Password == studpass)
                {

                    MainWindowView x = new MainWindowView(2);
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
            








        
              
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindowView x = new MainWindowView(3);
            Application.Current.MainWindow.DataContext = x;
            Application.Current.MainWindow.Title = "Registrace";

        }
    }
}
