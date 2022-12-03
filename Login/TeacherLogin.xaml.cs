using System;
using System.Windows;
using System.Windows.Controls;
using ProjectCSharp_SchoolGradingSystem.Functions;

namespace ProjectCSharp_SchoolGradingSystem
{
    /// <summary>
    /// Interakční logika pro TeacherLogin.xaml
    /// </summary>
    public partial class TeacherLogin : UserControl
    {
        private Pull pull = new Pull();
        public TeacherLogin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            result_username.Visibility = Visibility.Collapsed;
            Pull.PullTeacherLog(Username.Text, result_username, Password);
        }
        

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Push.ChangeScene("Welcome", "Výběr typu účtu");
        }
    }
}
