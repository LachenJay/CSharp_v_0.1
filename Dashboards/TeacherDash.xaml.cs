using System.Windows;
using System.Windows.Controls;
using ProjectCSharp_SchoolGradingSystem.Functions;

namespace ProjectCSharp_SchoolGradingSystem;

/// <summary>
///     Interakční logika pro TeacherDash.xaml
/// </summary>
public partial class TeacherDash : UserControl
{
    public TeacherDash()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Push.ChangeScene("AddGrade", Application.Current.MainWindow.Title);
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        Push.ChangeScene("UpdateGrade", Application.Current.MainWindow.Title);
    }

    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
        Push.ChangeScene("TeacherLogin", "Přihlášení učitel");
    }
}