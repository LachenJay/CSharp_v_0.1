using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using System.Windows.Media;
using ProjectCSharp_SchoolGradingSystem.Functions;


namespace ProjectCSharp_SchoolGradingSystem
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : UserControl
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Push.ChangeScene("StudentLogin", "Přihlášení student");
        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            name_info.Visibility = Visibility.Collapsed;
            surname_info.Visibility = Visibility.Collapsed;
            password_info.Visibility = Visibility.Collapsed;
            password_verify_info.Visibility = Visibility.Collapsed;

            List<TextBlock> info=new List<TextBlock>();
            info.Add(name_info);
            info.Add(surname_info);
            info.Add(mail_info);
            info.Add(password_info);
            info.Add(password_verify_info);

            Push.StudentRegistration(name_box,surname_box,password_box,password_box_verify,email_box, info);
        }
    }
}
