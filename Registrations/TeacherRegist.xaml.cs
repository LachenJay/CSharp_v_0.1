using ProjectCSharp_SchoolGradingSystem.Backend;
using System.Windows;
using System.Windows.Controls;

namespace ProjectCSharp_SchoolGradingSystem;

/// <summary>
///     Interakční logika pro TeacherRegist.xaml
/// </summary>
public partial class TeacherRegist : UserControl
{
    public TeacherRegist()
    {
        InitializeComponent();
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        name_info.Visibility = Visibility.Collapsed;


        var info = name_info;


        RegistrationWork.TeacherRegistration(name_box, surname_box, password_box, password_box_verify, email_box, info);
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        BackboneWork.ChangeScene("AdminDash", Application.Current.MainWindow.Title);
    }
}