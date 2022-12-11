using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.Windows.Controls;

namespace ProjectCSharp_SchoolGradingSystem.Backend;

public class RegistrationWork
{
    public static void StudentRegistration(TextBox name_box, TextBox surname_box, PasswordBox password_box,
        PasswordBox password_box_verify, TextBox email_box, TextBlock info)
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

            info.Visibility = Visibility.Visible;
        }

        if (surname_box.Text != "")
        {
            surname = surname_box.Text;
        }
        else
        {

            info.Visibility = Visibility.Visible;
        }

        var emailcheck = new EmailAddressAttribute();
        var isvalid = emailcheck.IsValid(email_box.Text);
        if (email_box.Text != "" && isvalid)
        {
            info.Visibility = Visibility.Hidden;
            e_mail = email_box.Text;
        }
        else
        {


            info.Visibility = Visibility.Visible;
        }

        if (password_box.Password != "")
        {
            if (password_box.Password == password_box_verify.Password)
            {
                password = password_box.Password;
            }
            else
            {


                info.Visibility = Visibility.Visible;
            }
        }
        else
        {

            info.Visibility = Visibility.Visible;
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
        PasswordBox password_box_verify, TextBox email_box, TextBlock info)
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

            info.Visibility = Visibility.Visible;
        }

        if (surname_box.Text != "")
        {
            surname = surname_box.Text;
        }
        else
        {

            info.Visibility = Visibility.Visible;
        }

        var emailcheck = new EmailAddressAttribute();
        var isvalid = emailcheck.IsValid(email_box.Text);
        if (email_box.Text != "" && isvalid)
        {
            info.Visibility = Visibility.Hidden;
            e_mail = name_box.Text;
        }
        else
        {

            info.Visibility = Visibility.Visible;
        }

        if (password_box.Password != "")
        {
            if (password_box.Password == password_box_verify.Password)
            {
                password = password_box.Password;
            }
            else
            {

                info.Visibility = Visibility.Visible;
            }
        }
        else
        {

            info.Visibility = Visibility.Visible;
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