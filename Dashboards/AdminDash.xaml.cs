using System;
using System.Windows;
using System.Windows.Controls;


namespace ProjectCSharp_SchoolGradingSystem
{
    /// <summary>
    /// Interakční logika pro AdminDash.xaml
    /// </summary>
    public partial class AdminDash : UserControl
    {
        public AdminDash()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindowView x = new MainWindowView(8);
            Application.Current.MainWindow.DataContext = x;
            Application.Current.MainWindow.Title = "Registrace učitele";
        }
    }
}
