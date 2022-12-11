using ProjectCSharp_SchoolGradingSystem.Models.DB;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ProjectCSharp_SchoolGradingSystem.Backend;

internal class HandOverWork
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
    public static List<Student> PullStudentsByEmail(string email)
    {

        using (var db = new SchoolSystem1Context())
        {
            List<Student> tech = db.Student.Where(s => s.EMail == Application.Current.MainWindow.Title).ToList();




            return tech;
        }



    }
    public static List<Student> pullStudentsById(string id)
    {
        var listofsj = new List<Student>();
        using (var db = new SchoolSystem1Context())
        {
            var student = db.Student.Where(s => s.StudentId == id).ToList(); ;
            listofsj = student;
            return listofsj;
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
    public static List<Teacher> pullTeachers()
    {
        var listofsj = new List<Teacher>();
        using (var db = new SchoolSystem1Context())
        {
            var subject = db.Teachers.ToList();
            listofsj = subject;
            return listofsj;
        }
    }

    public static List<Teacher> pullTeacherByMail(string email)
    {

        using (var db = new SchoolSystem1Context())
        {
            var tech = db.Teachers.Where(s => s.EMail == Application.Current.MainWindow.Title).ToList();
            return tech;
        }


    }
    public static List<Teacher> pullTeachersById(string id)
    {
        var listofsj = new List<Teacher>();
        using (var db = new SchoolSystem1Context())
        {
            var subject = db.Teachers.Where(s => s.TeacherId == id).ToList(); ;
            listofsj = subject;
            return listofsj;
        }
    }

    public static List<Admin> pullAdmins()
    {
        var listofst = new List<Admin>();
        using (var db = new SchoolSystem1Context())
        {
            var admins = db.Admins.ToList();
            listofst = admins;
            return listofst;
        }
    }
    public static List<Admin> pullAdminByEmail(string email)
    {

        using (var db = new SchoolSystem1Context())
        {
            var tech = db.Admins.Where(s => s.EMail == Application.Current.MainWindow.Title).ToList();
            return tech;
        }


    }




}