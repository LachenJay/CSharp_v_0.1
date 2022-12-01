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
    /// Interakční logika pro TeacherLogin.xaml
    /// </summary>
    public partial class TeacherLogin : UserControl
    {
        public TeacherLogin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            result_username.Visibility = Visibility.Collapsed;
            result_password.Visibility = Visibility.Collapsed;
            string tchid = "";
            string tchpass = "";
            using (var db = new SchoolSystem1Context())
            {
                if (Username.Text != "")
                {

                    try
                    {
                        var studentload = db.Teachers.Where(s => s.TeacherId == Username.Text).ToList();


                        tchid = studentload[0].TeacherId.ToString();
                        tchpass = studentload[0].Password.ToString();

                    }
                    catch
                    {
                        result_username.Foreground = new SolidColorBrush(Colors.Red);
                        result_username.Text = "Uživatelské jméno neexistuje";
                        result_username.Visibility = Visibility.Visible;
                        result_password.Visibility = Visibility.Collapsed;
                    }
                }
            
            if (tchid != "")
            {
                if (Password.Password == tchpass)
                {

                    MainWindowView x = new MainWindowView(9);
                    Application.Current.MainWindow.DataContext = x;
                    Application.Current.MainWindow.Title = tchid ;
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
        }
    }
}
