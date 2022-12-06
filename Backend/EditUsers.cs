using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Windows.Documents;
using ProjectCSharp_SchoolGradingSystem.Models.DB;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;

namespace ProjectCSharp_SchoolGradingSystem.Backend;

public class EditUsers
{
    public static void EditStudent(TextBox name_box, TextBox surname_box, TextBox email_box, PasswordBox password_box, PasswordBox password_box_verify,TextBlock info, string id)
    {
        string name = null;
        string surname = null;
        string password = null;
        string e_mail = null;
        var temp = "";
        info.Visibility = Visibility.Collapsed;
        if (name_box.Text != "")
        {
            name = name_box.Text;
        }
        

        if (surname_box.Text != "")
        {
            surname = surname_box.Text;
        }
        

        var emailcheck = new EmailAddressAttribute();
        var isvalid = emailcheck.IsValid(email_box.Text);
        if (email_box.Text != "" && isvalid)
        {
            
            e_mail = email_box.Text;
        }
        

        if (password_box.Password != "")
        {
            if (password_box.Password == password_box_verify.Password)
            {
                password = password_box.Password;
            }
            else
            {
                MessageBox.Show("Hesla se neshodují!");
                password_box.Password = "";
                password_box_verify.Password = "";
            }
            
        }
        

        if (name != "" || surname != "" || e_mail != "" || password != "" ||
            password_box.Password != password_box_verify.Password)
        {
            

            using (var db = new SchoolSystem1Context())
            {
                var studentgrab = db.Student.Where(s => s.StudentId == id).ToList()[0];
                studentgrab.Name = name;
                studentgrab.Surname = surname;
                studentgrab.EMail = e_mail;
                studentgrab.Password = password;
                db.Student.Update(studentgrab);
                db.SaveChanges(true);
                MessageBox.Show("Student upraven!");
            }
           

            
                
            
            
        }
        else
        {
            info.Visibility = Visibility.Visible;
        }
    }
    public static void EditAdmin(TextBox name_box, TextBox surname_box, TextBox email_box, PasswordBox password_box, PasswordBox password_box_verify, TextBlock info, string id)
    {
        string name = null;
        string surname = null;
        string password = null;
        string e_mail = null;
        var temp = "";
        info.Visibility = Visibility.Collapsed;
        if (name_box.Text != "")
        {
            name = name_box.Text;
        }


        if (surname_box.Text != "")
        {
            surname = surname_box.Text;
        }


        var emailcheck = new EmailAddressAttribute();
        var isvalid = emailcheck.IsValid(email_box.Text);
        if (email_box.Text != "" && isvalid)
        {

            e_mail = email_box.Text;
        }


        if (password_box.Password != "")
        {
            if (password_box.Password == password_box_verify.Password)
            {
                password = password_box.Password;
            }
            else
            {
                MessageBox.Show("Hesla se neshodují!");
                password_box.Password = "";
                password_box_verify.Password = "";
            }

        }


        if (name != "" || surname != "" || e_mail != "" || password != "" ||
            password_box.Password != password_box_verify.Password)
        {


            using (var db = new SchoolSystem1Context())
            {
                var admingrab = db.Admins.Where(s => s.AdminId == id).ToList()[0];
                admingrab.Name = name;
                admingrab.Surname = surname;
                admingrab.EMail = e_mail;
                admingrab.Password = password;
                db.Admins.Update(admingrab);
                db.SaveChanges(true);
                MessageBox.Show("Admin upraven!");
            }






        }
        else
        {
            info.Visibility = Visibility.Visible;
        }
    }

    public static void EditTeacher(TextBox name_box, TextBox surname_box, TextBox email_box, PasswordBox password_box, PasswordBox password_box_verify, TextBlock info, string id)
    {
        string name = null;
        string surname = null;
        string password = null;
        string e_mail = null;
        var temp = "";
        info.Visibility = Visibility.Collapsed;
        if (name_box.Text != "")
        {
            name = name_box.Text;
        }


        if (surname_box.Text != "")
        {
            surname = surname_box.Text;
        }


        var emailcheck = new EmailAddressAttribute();
        var isvalid = emailcheck.IsValid(email_box.Text);
        if (email_box.Text != "" && isvalid)
        {

            e_mail = email_box.Text;
        }


        if (password_box.Password != "")
        {
            if (password_box.Password == password_box_verify.Password)
            {
                password = password_box.Password;
            }
            else
            {
                MessageBox.Show("Hesla se neshodují!");
                password_box.Password = "";
                password_box_verify.Password = "";
            }

        }


        if ((name != "") && (surname != "") && (e_mail != "") && (password != "") &&
            (password_box.Password == password_box_verify.Password) && (password_box.Password !=null))
        {


            using (var db = new SchoolSystem1Context())
            {
                var teachergrab = db.Teachers.Where(s => s.TeacherId == id).ToList()[0];
                teachergrab.Name = name;
                teachergrab.Surname = surname;
                teachergrab.EMail = e_mail;
                teachergrab.Password = password;
                db.Teachers.Update(teachergrab);
                db.SaveChanges(true);

                MessageBox.Show("Učitel upraven!");
                

            }

            




        }
        else
        {
            info.Visibility = Visibility.Visible;
            
        }
    }
}