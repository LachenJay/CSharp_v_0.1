using System;

using System.Windows;
using System.Windows.Controls;

using ProjectCSharp_SchoolGradingSystem.Functions;

namespace ProjectCSharp_SchoolGradingSystem
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class StudentLogin : UserControl
    {
        private Pull pull = new Pull();
        private Push push= new Push();
        public StudentLogin()
        {

            InitializeComponent();

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            result_username.Visibility = Visibility.Collapsed;

            Pull.PullStudentLog(Username.Text, result_username, Password);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Push.ChangeScene("Registration", "Registrace studenta");

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Push.ChangeScene("Welcome", "Výběr typu účtu");
        }
    }
}
