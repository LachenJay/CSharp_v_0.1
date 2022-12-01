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
    /// Interakční logika pro Welcome.xaml
    /// </summary>
    public partial class Welcome : UserControl
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindowView x = new MainWindowView(1);
            Application.Current.MainWindow.DataContext = x;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindowView x = new MainWindowView(4);
            Application.Current.MainWindow.DataContext = x;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindowView x = new MainWindowView(5);
            Application.Current.MainWindow.DataContext = x;
        }
    }
}
