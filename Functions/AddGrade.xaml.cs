using ProjectCSharp_SchoolGradingSystem.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectCSharp_SchoolGradingSystem
{
    /// <summary>
    /// Interakční logika pro AddGrade.xaml
    /// </summary>
    public partial class AddGrade : UserControl
    {
        List<Student> studentlist = new List<Student>();
        List<Subject> subjectlist = new List<Subject>();

        public AddGrade()
        {
            
            InitializeComponent();
            using (var db = new SchoolSystem1Context())
            {
                var students = db.Student.ToList();
                studentlist = students;
                int i = 0;
                foreach (Student student in studentlist)
                {
                    listofstudents.Items.Add(studentlist[i].Name + " " + studentlist[i].Surname + " " + studentlist[i].StudentId);
                    i++;
                }


                var subjects = db.Subjects.ToList();
                subjectlist = subjects;
                int j = 0;
                foreach (Subject subject in subjectlist)
                {
                    listofsubjects.Items.Add(subjectlist[j].Name + " " + subjectlist[j].SubjectId);
                    j++;
                }


            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            using (var db = new SchoolSystem1Context())
            {
                
                int x = listofstudents.SelectedIndex;
                int y = listofsubjects.SelectedIndex;
                string student = studentlist[x].StudentId;
                string subject = subjectlist[y].SubjectId;
                string teacher = Application.Current.MainWindow.Title;
                var count = db.Grades.Count();
                int grade = 0;
                if (one.IsChecked == true) { grade = 1; }
                if (two.IsChecked == true) { grade = 2; } 
                if(three.IsChecked==true) { grade= 3;}
                if(four.IsChecked==true) { grade = 4; }
                if(five.IsChecked==true) { grade = 5; }

                
                
                Grade addinggrade = new Grade();
                addinggrade.StudentStudentId = student;
                addinggrade.SubjectId = subject;
                addinggrade.TeacherTeacherId= teacher;
                addinggrade.GradeId = count+1;
                addinggrade.Grade1 = grade;
                db.Grades.Add(addinggrade);
                db.SaveChanges(true);

                MessageBox.Show("Známka uložena!");
            }
        }
    }
}
