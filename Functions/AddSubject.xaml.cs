using ProjectCSharp_SchoolGradingSystem.Backend;
using ProjectCSharp_SchoolGradingSystem.Models.DB;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ProjectCSharp_SchoolGradingSystem
{
    /// <summary>
    /// Interakční logika pro AddSubject.xaml
    /// </summary>
    public partial class AddSubject : UserControl
    {
        private List<Teacher> teacherlist = new List<Teacher>();
        public AddSubject()
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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Warning.Visibility = Visibility.Collapsed;
            if (SubjectNameBox.Text != "" && SubjectNameBox.Text != null && TeacherBox.SelectedIndex >= 0)
            {
                string teacherid = teacherlist[TeacherBox.SelectedIndex].TeacherId;
                SubjectWork.AddSubjectExt(SubjectNameBox.Text, teacherid);
            }
            else
            {
                Warning.Visibility = Visibility.Visible;
            }
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
