using ProjectCSharp_SchoolGradingSystem.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Windows;
using System.Windows.Controls;

namespace ProjectCSharp_SchoolGradingSystem.Functions
{
    
    internal class Pull
    {
        

        public Pull()
        {

            
        }

        public static List<Student> pullStudents()
        {
            List<Student> listofst = new List<Student>();
            using (var db = new SchoolSystem1Context())
            {
                var students = db.Student.ToList();
                listofst = students;
                return listofst;
               
            }

        }
        public static List<Subject> pullSubjects()
        {
            List<Subject> listofsj = new List<Subject>();
            using (var db = new SchoolSystem1Context())
            {
                var subject = db.Subjects.ToList();
                listofsj = subject;
                return listofsj;
            }

        }
        public static List<Grade> pullGrades(string username)
        {
            List<Grade> listofgr = new List<Grade>();
            using (var db = new SchoolSystem1Context())
            {
                if (db.Grades.Count() > 0)
                {
                    
                        listofgr = db.Grades.Where(s => s.StudentStudentId == username).ToList();

                        return listofgr;
                    

                }
                else
                {
                    return listofgr;
                }
                
            }

        }

        

        public static void PullAdminLog(string username, TextBlock resultusername, PasswordBox password)
        {
            string[] admin = new string[2];

            if (username != "")
            {

                try
                {
                    using (var db = new SchoolSystem1Context())
                    {
                        var adminload = db.Admins.Where(s => s.AdminId == username).ToList();
                        
                        admin[0] = adminload[0].AdminId.ToString();
                        admin[1] = adminload[0].Password.ToString();
                        
                    }
                }
                catch
                {
                    resultusername.Visibility = Visibility.Visible;
                }
            }

            if (admin[0] != "" && admin[0] != null)
            {
                if (password.Password == admin[1])
                {
                    
                    Push.ChangeScene("AdminDash", admin[0]);
                }
                else
                {
                    resultusername.Visibility = Visibility.Visible;
                }
            }



            
        }

        public static void PullStudentLog(string username, TextBlock resultusername, PasswordBox Password)
        {
            string[] student = new string[2];

            if (username != "")
            {

                try
                {
                    using (var db = new SchoolSystem1Context())
                    {
                        var studentload = db.Student.Where(s => s.StudentId == username).ToList();
                        
                        student[0] = studentload[0].StudentId.ToString();
                        student[1] = studentload[0].Password.ToString();
                        
                    }
                }
                catch
                {
                    resultusername.Visibility = Visibility.Visible;
                }
            }

            if (student[0] != "" && student[0] != null)
            {
                if (Password.Password == student[1])
                {

                    Push.ChangeScene("Dashboard", student[0]);
                }
                else
                {
                    resultusername.Visibility = Visibility.Visible;
                }
            }
            
        }
        public static void PullTeacherLog(string username, TextBlock result_username, PasswordBox Password)
        {
            string[] teacher = new string[2];

            if (username != "")
            {

                try
                {
                    using (var db = new SchoolSystem1Context())
                    {
                        var teacherload = db.Teachers.Where(s => s.TeacherId == username).ToList();
                        
                        teacher[0] = teacherload[0].TeacherId.ToString();
                        teacher[1] = teacherload[0].Password.ToString();
                        
                    }
                }
                catch
                {
                    result_username.Visibility = Visibility.Visible;
                }
            }

            if (teacher[0] != "" && teacher[0] != null)
            {
                if (Password.Password == teacher[1])
                {

                    Push.ChangeScene("TeacherDash", teacher[0]);
                }
                else
                {
                    result_username.Visibility = Visibility.Visible;
                }


            }

           
        }
    }
}
