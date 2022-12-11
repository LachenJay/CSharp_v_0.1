using ProjectCSharp_SchoolGradingSystem.Backend;
using ProjectCSharp_SchoolGradingSystem.Models.DB;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ProjectCSharp_SchoolGradingSystem
{
    /// <summary>
    /// Interakční logika pro EditSubject.xaml
    /// </summary>
    public partial class EditSubject : UserControl
    {
        private List<Teacher> teacherlist = new List<Teacher>();
        private List<Subject> subjectlist = new List<Subject>();
        private readonly BackboneWork push = new();
        public EditSubject()
        {
            InitializeComponent();
            teacherlist = new List<Teacher>();
            teacherlist = HandOverWork.pullTeachers();
            var i = 0;
            foreach (var teacher in teacherlist)
            {
                TeacherBox.Items.Add(
                    teacherlist[i].Name + " " + teacherlist[i].Surname + " " + teacherlist[i].TeacherId);
                i++;
            }

            subjectlist = new List<Subject>();
            subjectlist = HandOverWork.pullSubjects();
            var j = 0;
            foreach (var subject in subjectlist)
            {
                SubjectBox.Items.Add(
                    subjectlist[j].Name + " " + subjectlist[j].TeacherTeacherId);
                j++;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Warning.Visibility = Visibility.Collapsed;
            SubjectWork.CompleteDeletion(SubjectBox, TeacherBox, NameBox, Deletecheck, Warning);
            push.ChangeOnListBoxSubject(SubjectBox);

        }

        private void Deletecheck_Checked(object sender, RoutedEventArgs e)
        {
            TeacherBox.IsEnabled = false;
            NameBox.IsEnabled = false;

        }

        private void Deletecheck_OnUnchecked(object sender, RoutedEventArgs e)
        {
            TeacherBox.IsEnabled = true;
            NameBox.IsEnabled = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {


            var nav = HandOverWork.pullTeacherByMail(Application.Current.MainWindow.Title);
            if (nav.Count != 0)
            {
                BackboneWork.ChangeScene("TeacherDash", Application.Current.MainWindow.Title);
            }
            else
            {
                BackboneWork.ChangeScene("AdminDash", Application.Current.MainWindow.Title);
            }
        }
    }
}
