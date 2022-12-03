using ProjectCSharp_SchoolGradingSystem.Functions;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ProjectCSharp_SchoolGradingSystem
{
    /// <summary>
    /// Interakční logika pro Welcome.xaml
    /// </summary>
    public partial class Welcome : UserControl
    {
        
        public Welcome()
        {
            Application.Current.MainWindow.Title = "Výběr typu účtu";
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Push.ChangeScene("StudentLogin", "Přihlášení žáka");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Push.ChangeScene("TeacherLogin", "Přihlášení učitele");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Push.ChangeScene("Adminlg", "Přihlášení admin");
        }
    }
}
