using ProjectCSharp_SchoolGradingSystem.Models.DB;
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

namespace ProjectCSharp_SchoolGradingSystem
{
    /// <summary>
    /// Interakční logika pro Admin.xaml
    /// </summary>
    public partial class Adminlg : UserControl
    {
        public Adminlg()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            result_username.Visibility = Visibility.Collapsed;
            result_password.Visibility = Visibility.Collapsed;
            string admid = "";
            string admpass = "";
            using (var db = new SchoolSystem1Context())
            {
                if (Username.Text != "")
                {
                    try
                    {
                        var studentload = db.Admins.Where(s => s.AdminId == Username.Text).ToList();


                        admid = studentload[0].AdminId.ToString();
                        admpass = studentload[0].Password.ToString();
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
            if (admid != "" && admid != null)
            {
                if (Password.Password == admpass)
                {

                    MainWindowView x = new MainWindowView(7);
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
            else if(admid!="")
            {
                result_username.Foreground = new SolidColorBrush(Colors.Red);
                result_username.Text = "Uživatelské jméno neexistuje";
                result_username.Visibility = Visibility.Visible;
                result_password.Visibility = Visibility.Collapsed;
            }










        }
    }
}
