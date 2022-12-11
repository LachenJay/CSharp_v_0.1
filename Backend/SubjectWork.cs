using ProjectCSharp_SchoolGradingSystem.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ProjectCSharp_SchoolGradingSystem.Backend;

public class SubjectWork
{
    public static void AddSubjectExt(string name, string teacherid)
    {
        using (var db = new SchoolSystem1Context())
        {
            var count = db.Subjects.Count();


            var addingsubj = new Subject();
            addingsubj.Name = name;
            addingsubj.TeacherTeacherId = teacherid;

            Random x = new Random();
            int n = x.Next(9999);
            addingsubj.SubjectId = "subj" + (n);

            db.Subjects.Add(addingsubj);
            db.SaveChanges(true);
            MessageBox.Show("Předmět uložen!");
        }

    }
    public static void DeleteSubjectExt(Subject subject)
    {
        using (var db = new SchoolSystem1Context())
        {
            db.Subjects.Remove(subject);
            db.SaveChanges(true);
            MessageBox.Show("Předmět smazán!");
        }
    }
    public static void UpdateSubjectExt(string name, string teacherid, string subjectid)
    {
        using (var db = new SchoolSystem1Context())
        {
            var temp = db.Subjects.Where(s => s.SubjectId == subjectid).ToList();
            temp[0].Name = name;
            temp[0].TeacherTeacherId = teacherid;
            db.Subjects.Update(temp[0]);
            db.SaveChanges(true);
            MessageBox.Show("Úpravy předmětu uloženy!");
        }
    }

    public static void CompleteDeletion(ListBox SubjectBox, ListBox TeacherBox, TextBox NameBox, CheckBox Deletecheck, TextBlock Warning)
    {
        List<Teacher> teacherlist = HandOverWork.pullTeachers();
        List<Subject> subjectlist = HandOverWork.pullSubjects();
        if (Deletecheck.IsChecked == false)
        {
            if (SubjectBox.SelectedIndex >= 0 && TeacherBox.SelectedIndex >= 0 && NameBox.Text != "" && NameBox.Text != null)
            {
                SubjectWork.UpdateSubjectExt(NameBox.Text, teacherlist[TeacherBox.SelectedIndex].TeacherId, subjectlist[SubjectBox.SelectedIndex].SubjectId);
            }
            else
            {
                Warning.Visibility = Visibility.Visible;
            }
        }
        else
        {
            var messageBoxResult = MessageBox.Show("Opravdu chcete smazat tneto předmět i se všemi známkami?", "Potvrzení smazání",
                MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                using (var db = new SchoolSystem1Context())
                {
                    int i = 0;
                    List<Grade> gradetodelete =
                        GradeWork.pullGradesBySubjectID(subjectlist[SubjectBox.SelectedIndex].SubjectId);
                    foreach (var grade in gradetodelete)
                    {
                        GradeWork.DeleteGradeExt(gradetodelete[i]);
                        i++;

                    }

                    SubjectWork.DeleteSubjectExt(subjectlist[SubjectBox.SelectedIndex]);
                }
            }
        }
    }



}