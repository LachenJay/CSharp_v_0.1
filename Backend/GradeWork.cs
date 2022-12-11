using ProjectCSharp_SchoolGradingSystem.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ProjectCSharp_SchoolGradingSystem.Backend;

public class GradeWork
{
    private List<Grade> gradelist = new List<Grade>();


    private List<Student> studentlist = HandOverWork.pullStudents();
    private List<Subject> subjectlist = HandOverWork.pullSubjects();


    public static void AddGradeExt(string student, string subject, string teacher, int grade, string descr)
    {
        using (var db = new SchoolSystem1Context())
        {
            var count = db.Grades.Count();
            Random x = new Random();
            int n = x.Next(0, 99999999);

            var addinggrade = new Grade();
            addinggrade.StudentStudentId = student;
            addinggrade.SubjectId = subject;
            addinggrade.TeacherTeacherId = teacher;
            addinggrade.GradeId = "grd" + teacher + (n);
            addinggrade.Grade1 = Convert.ToString(grade);
            addinggrade.Grade_description = "Popis známky: " + descr;
            db.Grades.Add(addinggrade);
            db.SaveChanges(true);
            MessageBox.Show("Známka uložena!");
        }
    }
    public static void DeleteGradeExt(Grade grade)
    {
        using (var db = new SchoolSystem1Context())
        {
            db.Grades.Remove(grade);
            db.SaveChanges(true);
            MessageBox.Show("Známka smazána!");
        }
    }
    public static void UpdateGradeExt(string grade, int gradevalue, string grade_description)
    {
        using (var db = new SchoolSystem1Context())
        {
            var temp = db.Grades.Where(s => s.GradeId == grade).ToList();
            temp[0].Grade1 = Convert.ToString(gradevalue);
            temp[0].Grade_description = grade_description;
            db.Grades.Update(temp[0]);
            db.SaveChanges(true);
            MessageBox.Show("Známka upravena!");
        }
    }
    public static void EditGrade(ListBox studentlistbox, ListBox gradelistbox, ListBox subjectListBox, CheckBox removecheckbox, TextBox descr,
        List<RadioButton> rad)
    {
        var s = studentlistbox.SelectedIndex;
        List<Student> studentlist = HandOverWork.pullStudents();

        using (var db = new SchoolSystem1Context())
        {
            var grads = pullGrades(studentlist[s].StudentId);
            List<Subject> subj = new List<Subject>();
            subj = HandOverWork.pullSubjects();
            var grdd = new List<Grade>();
            var i = 0;
            foreach (var gr in grads)
            {
                if (grads[i].SubjectId == subj[subjectListBox.SelectedIndex].SubjectId)
                {
                    grdd.Add(grads[i]);
                }

                i++;
            }

            if (removecheckbox.IsChecked == false)
            {
                var grade_description = descr.Text;


                var grade = 0;
                var name = "";
                int j = 0;
                foreach (var radi in rad)
                {
                    if (rad[j].IsChecked == true) { name = rad[j].Name; }
                    j++;
                }

                switch (name)
                {
                    case "one":
                        grade = 1;
                        break;
                    case "two":
                        grade = 2;
                        break;
                    case "three":
                        grade = 3;
                        break;
                    case "four":
                        grade = 4;
                        break;
                    case "five":
                        grade = 5;
                        break;
                }

                UpdateGradeExt(grdd[gradelistbox.SelectedIndex].GradeId, grade, grade_description);

            }
            else
            {
                var messageBoxResult = MessageBox.Show("Opravdu chcete smazat tuto známku?", "Potvrzení smazání",
                    MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes) DeleteGradeExt(grdd[gradelistbox.SelectedIndex]);
            }
        }
    }

    public static List<Grade> pullGrades(string username)
    {
        var listofgr = new List<Grade>();
        using (var db = new SchoolSystem1Context())
        {
            if (db.Grades.Count() > 0)
            {
                listofgr = db.Grades.Where(s => s.StudentStudentId == username).ToList();

                return listofgr;
            }

            return listofgr;
        }
    }
    public static List<Grade> pullGradesBySubjectID(string subjectId)
    {
        var listofgr = new List<Grade>();
        using (var db = new SchoolSystem1Context())
        {
            if (db.Grades.Count() > 0)
            {
                listofgr = db.Grades.Where(s => s.SubjectId == subjectId).ToList();

                return listofgr;
            }

            return listofgr;
        }
    }
}