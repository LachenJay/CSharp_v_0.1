using System.Windows;
using System.Windows.Controls;
using ProjectCSharp_SchoolGradingSystem.Backend;

namespace ProjectCSharp_SchoolGradingSystem;

/// <summary>
///     Interakční logika pro AdminDash.xaml
/// </summary>
public partial class AdminDash : UserControl
{
    public AdminDash()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        BackboneWork.ChangeScene("TeacherRegist", Application.Current.MainWindow.Title);
    }

    private void Button_Click1(object sender, RoutedEventArgs e)
    {
        BackboneWork.ChangeScene("Registration", Application.Current.MainWindow.Title);
    }

    private void Button_Click2(object sender, RoutedEventArgs e)
    {
        BackboneWork.ChangeScene("AddSubject", Application.Current.MainWindow.Title);
    }

    private void Button_Click3(object sender, RoutedEventArgs e)
    {
        BackboneWork.ChangeScene("EditSubject", Application.Current.MainWindow.Title);
    }

    private void Button_teacher(object sender, RoutedEventArgs e)
    {
        BackboneWork.ChangeScene("EditTeacher", Application.Current.MainWindow.Title);
    }

    private void Button_student(object sender, RoutedEventArgs e)
    {
        BackboneWork.ChangeScene("EditStudent", Application.Current.MainWindow.Title);
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        BackboneWork.ChangeScene("EditAdmin", Application.Current.MainWindow.Title);
    }

    private void Button_back(object sender, RoutedEventArgs e)
    {
        BackboneWork.ChangeScene("Adminlg", Application.Current.MainWindow.Title);
    }
}