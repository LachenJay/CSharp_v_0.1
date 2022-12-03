using System.Linq;
using ProjectCSharp_SchoolGradingSystem.Models.DB;

namespace ProjectCSharp_SchoolGradingSystem;

internal class User
{
    private readonly string e_mail;
    private readonly string name;
    private readonly string password;
    private readonly string surname;

    public User(string name, string surname, string email, string password)
    {
        this.name = name;
        this.surname = surname;
        e_mail = email;
        this.password = password;
    }


    public string pushstudent()
    {
        //this class pushes student user to database
        using (var db = new SchoolSystem1Context())
        {
            var count = db.Student.Count();
            var newstudent = new Student();
            string temp;
            temp = "st" + (count + 1);
            newstudent.Name = name;
            newstudent.Surname = surname;
            newstudent.EMail = e_mail;
            newstudent.Password = password;
            newstudent.StudentId = temp;
            newstudent.ClassClassId = "class_A";
            db.Student.Add(newstudent);


            db.SaveChanges(true);
            return temp;
        }
    }

    public string pushteacher()
    {
        //this class pushes student user to database
        using (var db = new SchoolSystem1Context())
        {
            var count = db.Teachers.Count();
            var newteacher = new Teacher();
            string temp;
            temp = "tch" + (count + 1);
            newteacher.Name = name;
            newteacher.Surname = surname;
            newteacher.EMail = e_mail;
            newteacher.Password = password;
            newteacher.TeacherId = temp;

            db.Teachers.Add(newteacher);

            db.SaveChanges(true);
            return temp;
        }
    }
}