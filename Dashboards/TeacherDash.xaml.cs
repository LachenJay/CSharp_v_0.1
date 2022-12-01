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
    /// Interakční logika pro TeacherDash.xaml
    /// </summary>
    public partial class TeacherDash : UserControl
    {
        public TeacherDash()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindowView x = new MainWindowView(10);
            Application.Current.MainWindow.DataContext = x;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
