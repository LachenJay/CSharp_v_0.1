using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ProjectCSharp_SchoolGradingSystem.Functions;

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
        surname_info.Visibility = Visibility.Collapsed;
        password_info.Visibility = Visibility.Collapsed;
        password_verify_info.Visibility = Visibility.Collapsed;


        var info = new List<TextBlock>();
        info.Add(name_info);
        info.Add(surname_info);
        info.Add(mail_info);
        info.Add(password_info);
        info.Add(password_verify_info);
        Push.TeacherRegistration(name_box, surname_box, password_box, password_box_verify, email_box, info);
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var x = new MainWindowView(7);
        Application.Current.MainWindow.DataContext = x;
        Application.Current.MainWindow.Title = "Admin Dashboard";
    }
}