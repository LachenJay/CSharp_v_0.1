using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace ProjectCSharp_SchoolGradingSystem.Backend;

public class RegistrationWork
{
    public static void StudentRegistration(TextBox name_box, TextBox surname_box, PasswordBox password_box,
        PasswordBox password_box_verify, TextBox email_box, List<TextBlock> info)
    {
        string name = null;
        string surname = null;
        string password = null;
        string e_mail = null;
        var temp = "";
        if (name_box.Text != "")
        {
            name = name_box.Text;
        }
        else
        {
            info[0].Foreground = new SolidColorBrush(Colors.Red);
            info[0].Visibility = Visibility.Visible;
        }

        if (surname_box.Text != "")
        {
            surname = surname_box.Text;
        }
        else
        {
            info[1].Foreground = new SolidColorBrush(Colors.Red);
            info[2].Visibility = Visibility.Visible;
        }

        var emailcheck = new EmailAddressAttribute();
        var isvalid = emailcheck.IsValid(email_box.Text);
        if (email_box.Text != "" && isvalid)
        {
            info[2].Visibility = Visibility.Hidden;
            e_mail = email_box.Text;
        }
        else
        {
            info[2].Foreground = new SolidColorBrush(Colors.Red);
            info[2].Text = "Email nebyl zadán správně!";
            info[2].Visibility = Visibility.Visible;
        }

        if (password_box.Password != "")
        {
            if (password_box.Password == password_box_verify.Password)
            {
                password = password_box.Password;
            }
            else
            {
                info[4].Text = "Hesla se neshodují";
                info[4].Foreground = new SolidColorBrush(Colors.Red);
                info[4].Visibility = Visibility.Visible;
            }
        }
        else
        {
            info[3].Foreground = new SolidColorBrush(Colors.Red);
            info[3].Visibility = Visibility.Visible;
        }

        if (name != "" || surname != "" || e_mail != "" || password != "" ||
            password_box.Password != password_box_verify.Password)
        {
            var addnew = new RegistPushToDat(name, surname, e_mail, password);

            try
            {

                temp = addnew.pushstudent();
                MessageBox.Show("Vaše přihlašovací jméno je váš email");
            }
            catch
            {
                MessageBox.Show("Někde se stala chyba");
            }
        }
    }

    public static void TeacherRegistration(TextBox name_box, TextBox surname_box, PasswordBox password_box,
        PasswordBox password_box_verify, TextBox email_box, List<TextBlock> info)
    {
        string name = null;
        string surname = null;
        string password = null;
        string e_mail = null;
        var temp = "";
        if (name_box.Text != "")
        {
            name = name_box.Text;
        }
        else
        {
            info[0].Foreground = new SolidColorBrush(Colors.Red);
            info[0].Visibility = Visibility.Visible;
        }

        if (surname_box.Text != "")
        {
            surname = surname_box.Text;
        }
        else
        {
            info[1].Foreground = new SolidColorBrush(Colors.Red);
            info[2].Visibility = Visibility.Visible;
        }

        var emailcheck = new EmailAddressAttribute();
        var isvalid = emailcheck.IsValid(email_box.Text);
        if (email_box.Text != "" && isvalid)
        {
            info[2].Visibility = Visibility.Hidden;
            e_mail = name_box.Text;
        }
        else
        {
            info[2].Foreground = new SolidColorBrush(Colors.Red);
            info[2].Text = "Email nebyl zadán správně!";
            info[2].Visibility = Visibility.Visible;
        }

        if (password_box.Password != "")
        {
            if (password_box.Password == password_box_verify.Password)
            {
                password = password_box.Password;
            }
            else
            {
                info[4].Text = "Hesla se neshodují";
                info[4].Foreground = new SolidColorBrush(Colors.Red);
                info[4].Visibility = Visibility.Visible;
            }
        }
        else
        {
            info[3].Foreground = new SolidColorBrush(Colors.Red);
            info[3].Visibility = Visibility.Visible;
        }

        if (name != "" || surname != "" || e_mail != "" || password != "" ||
            password_box.Password != password_box_verify.Password)
        {
            var addnew = new RegistPushToDat(name, surname, e_mail, password);

            try
            {
                temp = addnew.pushteacher();
                MessageBox.Show("Vaše přihlašovací jméno je váš email");
            }
            catch
            {
                MessageBox.Show("Někde se stala chyba");
            }
        }
    }
}