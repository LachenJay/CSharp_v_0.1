using ProjectCSharp_SchoolGradingSystem.Backend;
using System.Windows;
using System.Windows.Controls;



namespace ProjectCSharp_SchoolGradingSystem;

/// <summary>
///     Interakční logika pro Admin.xaml
/// </summary>
public partial class Adminlg : UserControl
{
    private readonly HandOverWork pull = new();
    private readonly BackboneWork push = new();

    public Adminlg()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        result_username.Visibility = Visibility.Collapsed;


        LoginWork.PullAdminLog(Username.Text, result_username, Password);
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        BackboneWork.ChangeScene("Welcome", "Výběr typu účtu");
    }
}