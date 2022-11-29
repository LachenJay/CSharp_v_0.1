using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {

            this.Title = "Login";
            Console.WriteLine("2");
            InitializeComponent();
            


        }
        public int SwitchView
        {
            get;
            set;
        }
        public void MainWindowViewx()
        {
            SwitchView = 0;
        }
        
        








    }
}
