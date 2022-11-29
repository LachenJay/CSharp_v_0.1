using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;


namespace ProjectCSharp_SchoolGradingSystem
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        public Login()
        { 

            InitializeComponent();
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            result_username.Visibility = Visibility.Collapsed;
            result_password.Visibility = Visibility.Collapsed;
            
            SqlConnection sn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SchoolSystem1;Integrated Security=True");


            int sst = 0;
            string temp = "";
                try
                {


                    string querry = "SELECT student_id FROM [dbo].[student] where student_id=@student_id"; // set  
                    SqlCommand cmd = new SqlCommand(querry, sn);
                    cmd.Parameters.AddWithValue("@student_id", Username.Text);
                    cmd.CommandType = CommandType.Text;

                    //Entity framework a linq
                    
                    sn.Open();


                    int i = cmd.ExecuteNonQuery();
                    sst = i;
                    sn.Close();
                
                    
                    string passwordquery = "SELECT password FROM [dbo].[student] where student_id=@student_id"; // set  
                    SqlCommand cmdpass = new SqlCommand(passwordquery, sn);
                    cmdpass.Parameters.AddWithValue("@student_id", Username.Text);
                    cmdpass.CommandType = CommandType.Text;
                    sn.Open();


                    temp = cmdpass.ExecuteScalar().ToString();
                    
                    sn.Close();
                }
                catch
                {
                    sst = 4;
                }
                
            
            
            if (sst == -1)
            {
                
                if (Password.Password == temp)
                {
                   
                    MainWindowView x = new MainWindowView(1);
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
            else
            {
                result_username.Foreground = new SolidColorBrush(Colors.Red);
                result_username.Text = "Uživatelské jméno neexistuje";
                result_username.Visibility = Visibility.Visible;
                result_password.Visibility = Visibility.Collapsed;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindowView x = new MainWindowView(2);
            Application.Current.MainWindow.DataContext = x;
            Application.Current.MainWindow.Title = "Registrace";
        }
    }
}
