﻿using ProjectCSharp_SchoolGradingSystem.Backend;
using ProjectCSharp_SchoolGradingSystem.Models.DB;
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

namespace ProjectCSharp_SchoolGradingSystem
{
    /// <summary>
    /// Interakční logika pro EditTeacher.xaml
    /// </summary>
    public partial class EditTeacher : UserControl
    {
        private List<Teacher> teacherlist = HandOverWork.pullTeachers();
        private Teacher teacher = new Teacher();
        private static string mail;
        public EditTeacher()
        {
            InitializeComponent();
            teacherlist = HandOverWork.pullTeachers();
            teacher = HandOverWork.pullTeacherByMail(Application.Current.MainWindow.Title)[0];
            var i = 0;
            foreach (var student in teacherlist)
            {
                ListBoxTeachers.Items.Add(
                    teacherlist[i].Name + " " + teacherlist[i].Surname + " " + teacherlist[i].TeacherId);
                i++;
            }

            
            var temp = HandOverWork.pullTeacherByMail(Application.Current.MainWindow.Title);

            if (temp.Count != 0)
            {
                ListBoxTeachers.IsEnabled = false;
                ListBoxTeachers.Visibility = Visibility.Collapsed;
                mail = temp[0].EMail;
                NameBox.Text = teacher.Name;
                SurnameBox.Text = teacher.Surname;
                EmailBox.Text = teacher.EMail;
            }

        }

        private void ListboxStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                teacher = teacherlist[ListBoxTeachers.SelectedIndex];
                NameBox.Text = teacher.Name;
                SurnameBox.Text = teacher.Surname;
                EmailBox.Text = teacher.EMail;
            }
            catch{}

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            var temp = HandOverWork.pullTeacherByMail(mail);
            
            if (temp.Count != 0)
            {
                mail = EmailBox.Text;
                temp = HandOverWork.pullTeacherByMail(mail);
                
            }
            else
            {
                temp = null;
            }
            EditUsers.EditTeacher(NameBox, SurnameBox, EmailBox, PasswordBox, PasswordVerifyBox, infoblock, teacher.TeacherId);

            
            if (temp.Count != 0)
            {
                    mail = EmailBox.Text;
                    
                        Application.Current.MainWindow.Title = mail;
                    
            }

            ListBoxTeachers.Items.Clear();
            teacherlist = HandOverWork.pullTeachers();

            var i = 0;
            foreach (var student in teacherlist)
            {
                ListBoxTeachers.Items.Add(
                    teacherlist[i].Name + " " + teacherlist[i].Surname + " " + teacherlist[i].TeacherId);
                i++;
            }
            

            PasswordBox.Password = "";
            PasswordVerifyBox.Password = "";

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var nav = HandOverWork.pullTeacherByMail(Application.Current.MainWindow.Title);
            if (nav.Count != 0)
            {
                BackboneWork.ChangeScene("TeacherLogin", Application.Current.MainWindow.Title);
            }
            else
            {
                BackboneWork.ChangeScene("AdminDash", Application.Current.MainWindow.Title);
            }
        }
    }
}
