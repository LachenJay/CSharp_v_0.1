﻿using ProjectCSharp_SchoolGradingSystem.Backend;
using ProjectCSharp_SchoolGradingSystem.Models.DB;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ProjectCSharp_SchoolGradingSystem;

/// <summary>
///     Interaction logic for Dashboard.xaml
/// </summary>
public partial class Dashboard : UserControl
{
    private readonly string studentid;
    private readonly List<Subject> subjectlist = new();
    private List<Student> studentlist = new();

    public Dashboard()
    {
        InitializeComponent();
        subjectlist = HandOverWork.pullSubjects();
        var j = 0;
        foreach (var subject in subjectlist)
        {
            listofsubjects.Items.Add(subjectlist[j].Name + " " + subjectlist[j].SubjectId);
            j++;
        }

        studentid = HandOverWork.PullStudentsByEmail(Application.Current.MainWindow.Title).ToList()[0].StudentId;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        BackboneWork.ChangeScene("StudentLogin", "Přihlášení student");
    }

    private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        listofgrades.Items.Clear();

        using (var db = new SchoolSystem1Context())
        {
            var i = 0;
            var grades = GradeWork.pullGrades(studentid);

            var teacher = new Teacher();
            foreach (var grade in grades)
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