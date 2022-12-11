using ProjectCSharp_SchoolGradingSystem.Backend;
using System.Windows;
using System.Windows.Controls;

namespace ProjectCSharp_SchoolGradingSystem;

/// <summary>
///     Interakční logika pro TeacherLogin.xaml
/// </summary>
public partial class TeacherLogin : UserControl
{
    private HandOverWork pull = new();

    public TeacherLogin()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        result_username.Visibility = Visibility.Collapsed;
        LoginWork.PullTeacherLog(Username.Text, result_username, Password);
    }


    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
        BackboneWork.ChangeScene("Welcome", "Výběr typu účtu");
    }
}