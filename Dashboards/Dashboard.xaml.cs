using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ProjectCSharp_SchoolGradingSystem.Functions;
using ProjectCSharp_SchoolGradingSystem.Models.DB;


namespace ProjectCSharp_SchoolGradingSystem
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : UserControl
    {
        private List<Student> studentlist = new List<Student>();
        private List<Subject> subjectlist = new List<Subject>();
        private string studentid;
        public Dashboard()
        {
            InitializeComponent();
            subjectlist = Pull.pullSubjects();
            int j = 0;
            foreach (Subject subject in subjectlist)
            {
                listofsubjects.Items.Add(subjectlist[j].Name + " " + subjectlist[j].SubjectId);
                j++;
            }

            studentid = Application.Current.MainWindow.Title;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Push.ChangeScene("StudentLogin", "Přihlášení student");
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listofgrades.Items.Clear();
            
            using (var db = new SchoolSystem1Context())
            {
                int i = 0;
                List<Grade> grades = Pull.pullGrades(studentid);
                
                Teacher teacher = new Teacher();
                foreach (Grade grade in grades)
                {
                    if (grades[i].SubjectId == subjectlist[listofsubjects.SelectedIndex].SubjectId)
                    {
                        teacher = db.Teachers.Find(grades[i].TeacherTeacherId);
                        listofgrades.Items.Add(grades[i].Grade1 + " | " + grades[i].TeacherTeacherId + " | " +
                                               teacher.Name + " " + teacher.Surname + " | " +
                                               grades[i].Grade_description);
                    }

                    i++;
                }
            }

        }
    }
}
