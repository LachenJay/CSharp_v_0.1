using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Threading.Tasks.Dataflow;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using ProjectCSharp_SchoolGradingSystem.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace ProjectCSharp_SchoolGradingSystem
{
    internal class User
    {
        private string name;
        private string surname;
        private string e_mail;
        private string password;

        public User(string name, string surname, string email, string password)
        {
            this.name = name;
            this.surname = surname;
            this.e_mail = email;
            this.password = password;
        }
        
        
        public string pushstudent()
        {

            //this class pushes student user to database
            using (var db = new SchoolSystem1Context())
            {
                var count = db.Student.Count();
                Student newstudent = new Student();
                string temp;
                temp= "st" + (count + 1);
                newstudent.Name = this.name;
                newstudent.Surname = this.surname;
                newstudent.EMail = this.e_mail;
                newstudent.Password = this.password;
                newstudent.StudentId = temp;
                newstudent.ClassClassId = "class_A";
                db.Student.Add(newstudent);
                
                db.SaveChanges(true);
                return temp;
            }

            





        }
        public void Login(string userName, string password)
        {
            
        }
    }
}
