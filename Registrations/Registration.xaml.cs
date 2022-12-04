using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ProjectCSharp_SchoolGradingSystem.Backend;
using ProjectCSharp_SchoolGradingSystem.Models.DB;

namespace ProjectCSharp_SchoolGradingSystem;

/// <summary>
///     Interaction logic for Registration.xaml
/// </summary>
public partial class Registration : UserControl
{
    public Registration()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var nav = HandOverWork.PullStudentsByEmail(Application.Current.MainWindow.Title);
        if (nav.Count != 0)
        {
            BackboneWork.ChangeScene("StudentLogin", Application.Current.MainWindow.Title);
        }
        else
        {
            BackboneWork.ChangeScene("AdminDash", Application.Current.MainWindow.Title);
        }
        
    }


    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        name_info.Visibility = Visibility.Collapsed;
        surname_info.Visibility = Visibility.Collapsed;
        password_info.Visibility = Visibility.Collapsed;
        password_verify_info.Visibility = Visibility.Collapsed;

        var info = new List<TextBlock>();
        info.Add(name_info);
        info.Add(surname_info);
        info.Add(mail_info);
        info.Add(password_info);
        info.Add(password_verify_info);

        RegistrationWork.StudentRegistration(name_box, surname_box, password_box, password_box_verify, email_box, info);
    }
}