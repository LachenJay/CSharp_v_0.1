﻿using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ProjectCSharp_SchoolGradingSystem.Functions;

namespace ProjectCSharp_SchoolGradingSystem;

/// <summary>
///     Interakční logika pro RemoveGrade.xaml
/// </summary>
public partial class UpdateGrade : UserControl
{
    private readonly Push push = new();

    public UpdateGrade()
    {
        InitializeComponent();
        var i = 0;
        var studentlist = Pull.pullStudents();
        var subjectlist = Pull.pullSubjects();
        foreach (var student in studentlist)
        {
            studentlistbox.Items.Add(
                studentlist[i].Name + " " + studentlist[i].Surname + " " + studentlist[i].StudentId);
            i++;
        }


        var j = 0;
        foreach (var subject in subjectlist)
        {
            if (subjectlist[j].TeacherTeacherId == Application.Current.MainWindow.Title)
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
        push.EditGrade(studentlistbox, gradelistbox, removecheckbox, descr, rad);
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
        Push.ChangeScene("TeacherDash", Application.Current.MainWindow.Title);
    }
}