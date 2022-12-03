using ProjectCSharp_SchoolGradingSystem.Functions;
using ProjectCSharp_SchoolGradingSystem.Models.DB;
using System;

using System.Windows;
using System.Windows.Controls;


namespace ProjectCSharp_SchoolGradingSystem
{
    /// <summary>
    /// Interakční logika pro Admin.xaml
    /// </summary>
    public partial class Adminlg : UserControl
    {
        private readonly Pull pull=new();
        private readonly Push push = new();
        public Adminlg()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            result_username.Visibility = Visibility.Collapsed;
            
             
            Pull.PullAdminLog(Username.Text, result_username, Password);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Push.ChangeScene("Welcome", "Výběr typu účtu");
        }
    }
}
