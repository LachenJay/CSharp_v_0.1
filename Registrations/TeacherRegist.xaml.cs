using System;

using System.Windows;
using System.Windows.Controls;

using System.Windows.Media;


namespace ProjectCSharp_SchoolGradingSystem
{
    /// <summary>
    /// Interakční logika pro TeacherRegist.xaml
    /// </summary>
    public partial class TeacherRegist : UserControl
    {
        public TeacherRegist()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            name_info.Visibility = Visibility.Collapsed;
            surname_info.Visibility = Visibility.Collapsed;
            password_info.Visibility = Visibility.Collapsed;
            password_verify_info.Visibility = Visibility.Collapsed;
            string name = null;
            string surname = null;
            string password = null;
            string e_mail = null;
            string temp = "";
            if (name_box.Text != "")
            {
                name = name_box.Text;
            }
            else
            {
                name_info.Foreground = new SolidColorBrush(Colors.Red);
                name_info.Visibility = Visibility.Visible;
            }
            if (surname_box.Text != "")
            {
                surname = surname_box.Text;
            }
            else
            {
                surname_info.Foreground = new SolidColorBrush(Colors.Red);
                surname_info.Visibility = Visibility.Visible;
            }
            if (email_box.Text != "")
            {

                mail_info.Visibility = Visibility.Hidden;
                e_mail = name_box.Text;
            }
            else
            {
                mail_info.Foreground = new SolidColorBrush(Colors.Red);
                mail_info.Visibility = Visibility.Visible;
            }
            if (password_box.Password != "")
            {
                if (password_box.Password == password_box_verify.Password)
                {
                    password = password_box.Password;
                }
                else
                {
                    password_verify_info.Text = "Hesla se neshodují";
                    password_verify_info.Foreground = new SolidColorBrush(Colors.Red);
                    password_verify_info.Visibility = Visibility.Visible;
                }
            }
            else
            {
                password_info.Foreground = new SolidColorBrush(Colors.Red);
                password_info.Visibility = Visibility.Visible;
            }

            if (name != "" || surname != "" || e_mail != "" || password != "" || password_box.Password != password_box_verify.Password)
            {
                User addnew = new User(name, surname, e_mail, password);

                try
                {
                    temp = addnew.pushteacher();
                    MessageBox.Show("Vaše přihlašovací jméno je: " + temp);
                    MainWindowView x = new MainWindowView(0);
                    Application.Current.MainWindow.DataContext = x;
                    Application.Current.MainWindow.Title = "Login";
                }
                catch
                {
                    MessageBox.Show("db error");
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindowView x = new MainWindowView(7);
            Application.Current.MainWindow.DataContext = x;
            Application.Current.MainWindow.Title = "Admin Dashboard";
        }
    }
    }

