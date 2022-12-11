using ProjectCSharp_SchoolGradingSystem.Backend;
using ProjectCSharp_SchoolGradingSystem.Models.DB;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ProjectCSharp_SchoolGradingSystem
{
    /// <summary>
    /// Interakční logika pro EditAdmin.xaml
    /// </summary>
    public partial class EditAdmin : UserControl
    {
        private List<Admin> adminlist = HandOverWork.pullAdmins();
        private Admin admin = new Admin();
        public EditAdmin()
        {
            InitializeComponent();
            adminlist = HandOverWork.pullAdmins();
            var i = 0;


            adminlist = HandOverWork.pullAdminByEmail(Application.Current.MainWindow.Title);



            admin = adminlist[0];
            NameBox.Text = admin.Name;
            SurnameBox.Text = admin.Surname;
            EmailBox.Text = admin.EMail;

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EditUsers.EditAdmin(NameBox, SurnameBox, EmailBox, PasswordBox, PasswordVerifyBox, infoblock, admin.AdminId);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            BackboneWork.ChangeScene("AdminDash", Application.Current.MainWindow.Title);

        }
    }
}
