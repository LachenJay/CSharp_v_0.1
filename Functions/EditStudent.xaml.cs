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
using ProjectCSharp_SchoolGradingSystem.Backend;
using ProjectCSharp_SchoolGradingSystem.Models.DB;

namespace ProjectCSharp_SchoolGradingSystem
{
    /// <summary>
    /// Interakční logika pro EditStudent.xaml
    /// </summary>
    public partial class EditStudent : UserControl
    {
        private List<Student> studentlist = HandOverWork.pullStudents();
        private Student student = new Student();
        public EditStudent()
        {
            InitializeComponent();
            studentlist = HandOverWork.pullStudents();
            var i = 0;
            foreach (var student in studentlist)
            {
                ListboxStudents.Items.Add(
                    studentlist[i].Name + " " + studentlist[i].Surname + " " + studentlist[i].StudentId);
                i++;
            }
        }

        private void ListboxStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                student = studentlist[ListboxStudents.SelectedIndex];
                student = studentlist[ListboxStudents.SelectedIndex];
                NameBox.Text = student.Name;
                SurnameBox.Text = student.Surname;
                EmailBox.Text = student.EMail;
            }
            catch{}
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EditUsers.EditStudent(NameBox, SurnameBox, EmailBox, PasswordBox, PasswordVerifyBox, infoblock, student.StudentId);
            ListboxStudents.Items.Clear();
            
            studentlist = HandOverWork.pullStudents();
            var i = 0;
            foreach (var student in studentlist)
            {
                ListboxStudents.Items.Add(
                    studentlist[i].Name + " " + studentlist[i].Surname + " " + studentlist[i].StudentId);
                i++;
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
