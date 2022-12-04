using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ProjectCSharp_SchoolGradingSystem.Models.DB;

namespace ProjectCSharp_SchoolGradingSystem.Backend;

internal class BackboneWork
{
    private List<Grade> gradelist;


    private List<Student> studentlist;
    private List<Subject> subjectlist;

    public BackboneWork()
    {


    }







    public void ChangeOnListBoxGrades(ListBox gradelistbox, ListBox studentlistbox, ListBox subjectlistbox)
    {
        gradelistbox.Items.Clear();
        if (studentlistbox.SelectedItem != null && subjectlistbox.SelectedItem!=null)
        {
            studentlist = HandOverWork.pullStudents();
            subjectlist = HandOverWork.pullSubjects();
            var s = studentlistbox.SelectedIndex;
            gradelist = GradeWork.pullGrades(studentlist[s].StudentId);
            var j = 0;
            foreach (var grade in gradelist)
            {
                if (gradelist[j].SubjectId == subjectlist[subjectlistbox.SelectedIndex].SubjectId)
                {
                    gradelistbox.Items.Add(gradelist[j].Grade1 + " " + gradelist[j].Grade_description);
                    j++;
                }
                else
                {
                    j++;
                }
            }
        }
    }



    public static void ChangeScene(string scene, string title)
    {
        switch (scene)
        {
            case "Welcome":
                Application.Current.MainWindow.DataContext = new MainWindowView(6);
                Application.Current.MainWindow.Title = title;
                break;
            case "Dashboard":
                Application.Current.MainWindow.DataContext = new MainWindowView(2);
                Application.Current.MainWindow.Title = title;
                break;

            case "Adminlg":
                Application.Current.MainWindow.DataContext = new MainWindowView(5);
                Application.Current.MainWindow.Title = title;
                break;

            case "StudentLogin":
                Application.Current.MainWindow.DataContext = new MainWindowView(1);
                Application.Current.MainWindow.Title = title;
                break;

            case "Registration":
                Application.Current.MainWindow.DataContext = new MainWindowView(3);
                Application.Current.MainWindow.Title = title;
                break;

            case "AdminDash":
                Application.Current.MainWindow.DataContext = new MainWindowView(7);
                Application.Current.MainWindow.Title = title;
                break;
            case "TeacherDash":
                Application.Current.MainWindow.DataContext = new MainWindowView(9);
                Application.Current.MainWindow.Title = title;
                break;
            case "AddGrade":
                Application.Current.MainWindow.DataContext = new MainWindowView(10);
                Application.Current.MainWindow.Title = title;
                break;
            case "UpdateGrade":
                Application.Current.MainWindow.DataContext = new MainWindowView(11);
                Application.Current.MainWindow.Title = title;
                break;
            case "TeacherRegist":
                Application.Current.MainWindow.DataContext = new MainWindowView(8);
                Application.Current.MainWindow.Title = title;
                break;
            case "TeacherLogin":
                Application.Current.MainWindow.DataContext = new MainWindowView(4);
                Application.Current.MainWindow.Title = title;
                break;
            case "AddSubject":
                Application.Current.MainWindow.DataContext = new MainWindowView(12);
                Application.Current.MainWindow.Title = title;
                break;
            case "EditSubject":
                Application.Current.MainWindow.DataContext = new MainWindowView(13);
                Application.Current.MainWindow.Title = title;
                break;
            case "EditStudent":
                Application.Current.MainWindow.DataContext = new MainWindowView(14);
                Application.Current.MainWindow.Title = title;
                break;
            case "EditAdmin":
                Application.Current.MainWindow.DataContext = new MainWindowView(15);
                Application.Current.MainWindow.Title = title;
                break;
            case "EditTeacher":
                Application.Current.MainWindow.DataContext = new MainWindowView(16);
                Application.Current.MainWindow.Title = title;
                break;
        }
    }


}