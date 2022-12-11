using ProjectCSharp_SchoolGradingSystem.Backend;
using System.Windows;
using System.Windows.Controls;


namespace ProjectCSharp_SchoolGradingSystem;

/// <summary>
///     Interaction logic for Login.xaml
/// </summary>
public partial class StudentLogin : UserControl
{


    public StudentLogin()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        result_username.Visibility = Visibility.Collapsed;

        LoginWork.PullStudentLog(Username.Text, result_username, Password);
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        BackboneWork.ChangeScene("Registration", "Registrace studenta");
    }

    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
        BackboneWork.ChangeScene("Welcome", "Výběr typu účtu");
    }
}