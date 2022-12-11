using ProjectCSharp_SchoolGradingSystem.Backend;
using System.Windows;
using System.Windows.Controls;

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
        var nav = HandOverWork.pullAdminByEmail(Application.Current.MainWindow.Title);
        if (nav.Count != 0)
        {
            BackboneWork.ChangeScene("AdminDash", Application.Current.MainWindow.Title);
        }
        else
        {

            BackboneWork.ChangeScene("StudentLogin", "Přihlášení žáka");
        }

    }


    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        name_info.Visibility = Visibility.Collapsed;

        var info = name_info;

        RegistrationWork.StudentRegistration(name_box, surname_box, password_box, password_box_verify, email_box, info);
    }


}