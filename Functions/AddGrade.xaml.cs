using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ProjectCSharp_SchoolGradingSystem.Functions;
using ProjectCSharp_SchoolGradingSystem.Models.DB;

namespace ProjectCSharp_SchoolGradingSystem;

/// <summary>
///     Interakční logika pro AddGrade.xaml
/// </summary>
public partial class AddGrade : UserControl
{
    private readonly Push acc = new();
    private readonly List<Student> studentlist = new();
    private readonly List<Subject> subjectlist = new();
    private Pull req = new();

    public AddGrade()
    {
        InitializeComponent();

        studentlist = Pull.pullStudents();
        var i = 0;
        foreach (var student in studentlist)
        {
            listofstudents.Items.Add(
                studentlist[i].Name + " " + studentlist[i].Surname + " " + studentlist[i].StudentId);
            i++;
        }


        subjectlist = Pull.pullSubjects();
        var j = 0;
        foreach (var subject in subjectlist)
        {
            if (subjectlist[j].TeacherTeacherId == Application.Current.MainWindow.Title)
                listofsubjects.Items.Add(subjectlist[j].Name + " " + subjectlist[j].SubjectId);

            j++;
        }
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        using (var db = new SchoolSystem1Context())
        {
            var student = studentlist[listofstudents.SelectedIndex].StudentId;
            var subject = subjectlist[listofsubjects.SelectedIndex].SubjectId;
            var grade_description = descr.Text;
            var teacher = Application.Current.MainWindow.Title;


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

            acc.AddGradeExt(student, subject, teacher, grade, grade_description);
        }
    }

    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
        Push.ChangeScene("TeacherDash", Application.Current.MainWindow.Title);
    }
}