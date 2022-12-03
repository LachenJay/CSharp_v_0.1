using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ProjectCSharp_SchoolGradingSystem.Models.DB;

namespace ProjectCSharp_SchoolGradingSystem.Functions;

internal class Pull
{
    public static List<Student> pullStudents()
    {
        var listofst = new List<Student>();
        using (var db = new SchoolSystem1Context())
        {
            var students = db.Student.ToList();
            listofst = students;
            return listofst;
        }
    }

    public static List<Subject> pullSubjects()
    {
        var listofsj = new List<Subject>();
        using (var db = new SchoolSystem1Context())
        {
            var subject = db.Subjects.ToList();
            listofsj = subject;
            return listofsj;
        }
    }

    public static List<Grade> pullGrades(string username)
    {
        var listofgr = new List<Grade>();
        using (var db = new SchoolSystem1Context())
        {
            if (db.Grades.Count() > 0)
            {
                listofgr = db.Grades.Where(s => s.StudentStudentId == username).ToList();

                return listofgr;
            }

            return listofgr;
        }
    }


    public static void PullAdminLog(string username, TextBlock resultusername, PasswordBox password)
    {
        var admin = new string[2];

        if (username != "")
            try
            {
                using (var db = new SchoolSystem1Context())
                {
                    var adminload = db.Admins.Where(s => s.EMail == username).ToList();

                    admin[0] = adminload[0].EMail;
                    admin[1] = adminload[0].Password;
                }
            }
            catch
            {
                resultusername.Visibility = Visibility.Visible;
            }

        if (admin[0] != "" && admin[0] != null)
        {
            if (password.Password == admin[1])
                Push.ChangeScene("AdminDash", admin[0]);
            else
                resultusername.Visibility = Visibility.Visible;
        }
    }

    public static void PullStudentLog(string username, TextBlock resultusername, PasswordBox Password)
    {
        var student = new string[2];

        if (username != "")
            try
            {
                using (var db = new SchoolSystem1Context())
                {
                    var studentload = db.Student.Where(s => s.EMail == username).ToList();

                    student[0] = studentload[0].EMail;
                    student[1] = studentload[0].Password;
                }
            }
            catch
            {
                resultusername.Visibility = Visibility.Visible;
            }

        if (student[0] != "" && student[0] != null)
        {
            if (Password.Password == student[1])
                Push.ChangeScene("Dashboard", student[0]);
            else
                resultusername.Visibility = Visibility.Visible;
        }
    }

    public static void PullTeacherLog(string username, TextBlock result_username, PasswordBox Password)
    {
        var teacher = new string[2];

        if (username != "")
            try
            {
                using (var db = new SchoolSystem1Context())
                {
                    var teacherload = db.Teachers.Where(s => s.EMail == username).ToList();

                    teacher[0] = teacherload[0].EMail;
                    teacher[1] = teacherload[0].Password;
                }
            }

            catch
            {
                result_username.Visibility = Visibility.Visible;
            }

        if (teacher[0] != "" && teacher[0] != null)
        {
            if (Password.Password == teacher[1])
                Push.ChangeScene("TeacherDash", teacher[0]);
            else
                result_username.Visibility = Visibility.Visible;
        }
    }
}