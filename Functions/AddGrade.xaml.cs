using ProjectCSharp_SchoolGradingSystem.Functions;
using ProjectCSharp_SchoolGradingSystem.Models.DB;
using System;
using System.Collections.Generic;

using System.Windows;
using System.Windows.Controls;


namespace ProjectCSharp_SchoolGradingSystem
{
    /// <summary>
    /// Interakční logika pro AddGrade.xaml
    /// </summary>
    public partial class AddGrade : UserControl
    {
        List<Student> studentlist = new List<Student>();
        List<Subject> subjectlist = new List<Subject>();
        Pull req = new Pull();
        Push acc = new Push();

        public AddGrade()
        {
            
            InitializeComponent();
            
                studentlist = Pull.pullStudents();
                int i = 0;
                foreach (Student student in studentlist)
                {
                    listofstudents.Items.Add(studentlist[i].Name + " " + studentlist[i].Surname + " " + studentlist[i].StudentId);
                    i++;
                }


                subjectlist = Pull.pullSubjects();
                int j = 0;
                foreach (Subject subject in subjectlist)
                {
                    listofsubjects.Items.Add(subjectlist[j].Name + " " + subjectlist[j].SubjectId);
                    j++;
                }


            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            using (var db = new SchoolSystem1Context())
            {
                
                string student = studentlist[listofstudents.SelectedIndex].StudentId;
                string subject = subjectlist[listofsubjects.SelectedIndex].SubjectId;
                string grade_description = descr.Text;
                string teacher = Application.Current.MainWindow.Title;
                

                
                int grade = 0;
                if (one.IsChecked == true) { grade = 1; }
                else if (two.IsChecked == true) { grade = 2; } 
                else if(three.IsChecked==true) { grade= 3;}
                else if(four.IsChecked==true) { grade = 4; }
                else if(five.IsChecked==true) { grade = 5; }

                acc.AddGradeExt(student, subject, teacher, grade, grade_description);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Push.ChangeScene("TeacherDash", Application.Current.MainWindow.Title);
        }
    }
}
