using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ProjectCSharp_SchoolGradingSystem.Models.DB;

namespace ProjectCSharp_SchoolGradingSystem.Functions;

internal class Push
{
    private List<Grade> gradelist;


    private List<Student> studentlist;
    private List<Subject> subjectlist;

    public Push()
    {
        studentlist = Pull.pullStudents();
        subjectlist = Pull.pullSubjects();
        gradelist = new List<Grade>();
    }

    public void AddGradeExt(string student, string subject, string teacher, int grade, string descr)
    {
        using (var db = new SchoolSystem1Context())
        {
            var count = db.Grades.Count();


            var addinggrade = new Grade();
            addinggrade.StudentStudentId = student;
            addinggrade.SubjectId = subject;
            addinggrade.TeacherTeacherId = teacher;
            addinggrade.GradeId = "grd" + (count + 1);
            addinggrade.Grade1 = Convert.ToString(grade);
            addinggrade.Grade_description = "Popis známky: " + descr;
            db.Grades.Add(addinggrade);
            db.SaveChanges(true);
            MessageBox.Show("Známka uložena!");
        }
    }

    public void DeleteGradeExt(Grade grade)
    {
        using (var db = new SchoolSystem1Context())
        {
            db.Grades.Remove(grade);
            db.SaveChanges(true);
            MessageBox.Show("Známka smazána!");
        }
    }

    public void UpdateGradeExt(string grade, int gradevalue, string grade_description)
    {
        using (var db = new SchoolSystem1Context())
        {
            var temp = db.Grades.Where(s => s.GradeId == grade).ToList();
            temp[0].Grade1 = Convert.ToString(gradevalue);
            temp[0].Grade_description = grade_description;
            db.Grades.Update(temp[0]);
            db.SaveChanges(true);
            MessageBox.Show("Známka upravena!");
        }
    }

    public void ChangeOnListBoxGrades(ListBox gradelistbox, ListBox studentlistbox, ListBox subjectlistbox)
    {
        gradelistbox.Items.Clear();
        if (studentlistbox.SelectedItem != null)
        {
            studentlist = Pull.pullStudents();
            subjectlist = Pull.pullSubjects();
            var s = studentlistbox.SelectedIndex;
            gradelist = Pull.pullGrades(studentlist[s].StudentId);
            var j = 0;
            foreach (var grade in gradelist)
                if (gradelist[j].SubjectId == subjectlist[subjectlistbox.SelectedIndex].SubjectId)
                {
                    gradelistbox.Items.Add(gradelist[j].Grade1 + " " + gradelist[j].Grade_description);
                    j++;
                }
                else
                {
                    j++;
                }
        }
    }

    public void EditGrade(ListBox studentlistbox, ListBox gradelistbox, CheckBox removecheckbox, TextBox descr,
        List<RadioButton> rad)
    {
        var s = studentlistbox.SelectedIndex;


        using (var db = new SchoolSystem1Context())
        {
            var grads = Pull.pullGrades(studentlist[s].StudentId);
            var grdd = new List<Grade>();
            var i = 0;
            foreach (var gr in grads)
            {
                grdd.Add(grads[i]);
                i++;
            }

            if (removecheckbox.IsChecked == false)
            {
                var grade_description = descr.Text;


                var grade = 0;
                var name = "";
                foreach (var radi in rad)
                {
                    if (rad[i].IsChecked == true) name = rad[i].Name;
                    grade++;
                }

                switch (name)
                {
                    case "one":
                        grade = 1;
                        break;
                    case "two":
                        grade = 2;
                        break;
                    case "three":
                        grade = 3;
                        break;
                    case "four":
                        grade = 4;
                        break;
                    case "five":
                        grade = 5;
                        break;
                }

                UpdateGradeExt(grdd[gradelistbox.SelectedIndex].GradeId, grade, grade_description);
            }
            else
            {
                var messageBoxResult = MessageBox.Show("Opravdu chcete smazat tuto známku?", "Potvrzení smazání",
                    MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes) DeleteGradeExt(grdd[gradelistbox.SelectedIndex]);
            }
        }
    }

    public static void ChangeScene(string scene, string title)
    {
        switch (scene)
        {
            case "Welcome":
                Application.Current.MainWindow.DataContext = new MainWindowView(6);
                Application.Current.MainWindow.Title = title;
                break;
            case "Dashboard":
                Application.Current.MainWindow.DataContext = new MainWindowView(2);
                Application.Current.MainWindow.Title = title;
                break;

            case "Adminlg":
                Application.Current.MainWindow.DataContext = new MainWindowView(5);
                Application.Current.MainWindow.Title = title;
                break;

            case "StudentLogin":
                Application.Current.MainWindow.DataContext = new MainWindowView(1);
                Application.Current.MainWindow.Title = title;
                break;

            case "Registration":
                Application.Current.MainWindow.DataContext = new MainWindowView(3);
                Application.Current.MainWindow.Title = title;
                break;

            case "AdminDash":
                Application.Current.MainWindow.DataContext = new MainWindowView(7);
                Application.Current.MainWindow.Title = title;
                break;
            case "TeacherDash":
                Application.Current.MainWindow.DataContext = new MainWindowView(9);
                Application.Current.MainWindow.Title = title;
                break;
            case "AddGrade":
                Application.Current.MainWindow.DataContext = new MainWindowView(10);
                Application.Current.MainWindow.Title = title;
                break;
            case "UpdateGrade":
                Application.Current.MainWindow.DataContext = new MainWindowView(11);
                Application.Current.MainWindow.Title = title;
                break;
            case "TeacherRegist":
                Application.Current.MainWindow.DataContext = new MainWindowView(8);
                Application.Current.MainWindow.Title = title;
                break;
            case "TeacherLogin":
                Application.Current.MainWindow.DataContext = new MainWindowView(4);
                Application.Current.MainWindow.Title = title;
                break;
        }
    }

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
            var addnew = new User(name, surname, e_mail, password);

            try
            {
                temp = addnew.pushstudent();
                MessageBox.Show("Vaše přihlašovací jméno je: " + temp);
                ChangeScene("StudentLogin", "Přihlášení student");
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
            var addnew = new User(name, surname, e_mail, password);

            try
            {
                temp = addnew.pushteacher();
                MessageBox.Show("Vaše přihlašovací jméno je: " + temp);
                ChangeScene("StudentLogin", "Přihlášení student");
            }
            catch
            {
                MessageBox.Show("Někde se stala chyba");
            }
        }
    }
}