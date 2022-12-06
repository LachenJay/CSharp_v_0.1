using System.Windows;
using System.Windows.Controls;
using ProjectCSharp_SchoolGradingSystem.Backend;

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
        BackboneWork.ChangeScene("AddGrade", Application.Current.MainWindow.Title);
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        BackboneWork.ChangeScene("UpdateGrade", Application.Current.MainWindow.Title);
    }

    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
        BackboneWork.ChangeScene("TeacherLogin", "Přihlášení učitel");
    }

    private void Button_Click_3(object sender, RoutedEventArgs e)
    {
        BackboneWork.ChangeScene("AddSubject", Application.Current.MainWindow.Title);
    }

    private void Button_Click_4(object sender, RoutedEventArgs e)
    {
        BackboneWork.ChangeScene("EditSubject", Application.Current.MainWindow.Title);
    }

    private void Button_Click_5(object sender, RoutedEventArgs e)
    {

        BackboneWork.ChangeScene("EditStudent", Application.Current.MainWindow.Title);
    }

    private void Button_Click_6(object sender, RoutedEventArgs e)
    {
        BackboneWork.ChangeScene("EditTeacher", Application.Current.MainWindow.Title);

    }
}