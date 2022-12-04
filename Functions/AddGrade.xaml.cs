using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ProjectCSharp_SchoolGradingSystem.Backend;
using ProjectCSharp_SchoolGradingSystem.Models.DB;

namespace ProjectCSharp_SchoolGradingSystem;

/// <summary>
///     Interakční logika pro AddGrade.xaml
/// </summary>
public partial class AddGrade : UserControl
{
    private readonly BackboneWork acc = new();
    private readonly List<Student> studentlist = new();
    private readonly List<Subject> subjectlist = new();
    private readonly List<Teacher> teacherlist = HandOverWork.pullTeachers();
    
    private HandOverWork req = new();

    public AddGrade()
    {
        InitializeComponent();

        studentlist = HandOverWork.pullStudents();
        var i = 0;
        foreach (var student in studentlist)
        {
            listofstudents.Items.Add(
                studentlist[i].Name + " " + studentlist[i].Surname + " " + studentlist[i].StudentId);
            i++;
        }

        using (var db = new SchoolSystem1Context())
        {
            var tech = HandOverWork.pullTeacherByMail(Application.Current.MainWindow.Title)[0];
            subjectlist = HandOverWork.pullSubjects();
            var j = 0;
            foreach (var subject in subjectlist)
            {
               
                if (subjectlist[j].TeacherTeacherId == tech.TeacherId)
                    listofsubjects.Items.Add(subjectlist[j].Name + " " + subjectlist[j].SubjectId);

                j++;
            }
        }
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        using (var db = new SchoolSystem1Context())
        {
            var student = studentlist[listofstudents.SelectedIndex].StudentId;
            var subject = subjectlist[listofsubjects.SelectedIndex].SubjectId;
            var grade_description = descr.Text;
            var tech = HandOverWork.pullTeacherByMail(Application.Current.MainWindow.Title)[0];

            var grade = 0;
            if (one.IsChecked == true)
                grade = 1;
            else if (two.IsChecked == true)
                grade = 2;
            else if (three.IsChecked == true)
                grade = 3;
            else if (four.IsChecked == true)
                grade = 4;
            else if (five.IsChecked == true) grade = 5;

            GradeWork.AddGradeExt(student, subject, tech.TeacherId, grade, grade_description);
        }
    }

    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
        BackboneWork.ChangeScene("TeacherDash", Application.Current.MainWindow.Title);
    }
}