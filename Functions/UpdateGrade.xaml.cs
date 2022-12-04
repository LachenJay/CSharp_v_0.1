using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ProjectCSharp_SchoolGradingSystem.Backend;
using ProjectCSharp_SchoolGradingSystem.Models.DB;

namespace ProjectCSharp_SchoolGradingSystem;

/// <summary>
///     Interakční logika pro RemoveGrade.xaml
/// </summary>
public partial class UpdateGrade : UserControl
{
    private readonly BackboneWork push = new();
    private List<Teacher> tech;

    public UpdateGrade()
    {
        InitializeComponent();
        var i = 0;
        var studentlist = HandOverWork.pullStudents();
        var subjectlist = HandOverWork.pullSubjects();
        foreach (var student in studentlist)
        {
            studentlistbox.Items.Add(
                studentlist[i].Name + " " + studentlist[i].Surname + " " + studentlist[i].StudentId);
            i++;
        }

        using (var db = new SchoolSystem1Context())
        {
            tech = db.Teachers.Where(s => s.EMail == Application.Current.MainWindow.Title).ToList();
        }

        var j = 0;
        foreach (var subject in subjectlist)
        {
            
            if (subjectlist[j].TeacherTeacherId == tech[0].TeacherId)
                subjectlistbox.Items.Add(subjectlist[j].Name + " " + subjectlist[j].SubjectId);

            j++;
        }
    }

    private void Studentlistbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        push.ChangeOnListBoxGrades(gradelistbox, studentlistbox, subjectlistbox);
    }

    private void Subjectlistbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        push.ChangeOnListBoxGrades(gradelistbox, studentlistbox, subjectlistbox);
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        List<RadioButton> rad = new();
        rad.Add(one);
        rad.Add(two);
        rad.Add(three);
        rad.Add(four);
        rad.Add(five);
        if (gradelistbox.SelectedItem != null)
        {
            GradeWork.EditGrade(studentlistbox, gradelistbox, subjectlistbox,removecheckbox, descr, rad);
        }

        
    }

    private void removecheckbox_Checked(object sender, RoutedEventArgs e)
    {
        descr.IsEnabled = false;
        one.IsEnabled = false;
        two.IsEnabled = false;
        three.IsEnabled = false;
        four.IsEnabled = false;
        five.IsEnabled = false;
    }

    private void removecheckbox_Unchecked(object sender, RoutedEventArgs e)
    {
        descr.IsEnabled = true;
        one.IsEnabled = true;
        two.IsEnabled = true;
        three.IsEnabled = true;
        four.IsEnabled = true;
        five.IsEnabled = true;
    }

    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
        BackboneWork.ChangeScene("TeacherDash", Application.Current.MainWindow.Title);
    }
}