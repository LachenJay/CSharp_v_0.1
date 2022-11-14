using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Threading.Tasks.Dataflow;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ProjectCSharp_SchoolGradingSystem
{
    internal class User
    {
        private string name;
        private string surname;
        private string e_mail;
        private string password;

        public User(string name, string surname, string email, string password)
        {
            this.name = name;
            this.surname = surname;
            this.e_mail = email;
            this.password = password;
        }
        
        
        public string push()
        {

            //this class pushes student user to database

            using (SqlConnection sn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SchoolSystem1;Integrated Security=True"))
            {
                
                string lastid = "SELECT TOP(1) student_id FROM [dbo].[student] ORDER BY 1 DESC"; // set  
                SqlCommand lastidcmd = new SqlCommand(lastid, sn);
                lastidcmd.CommandType = CommandType.Text;
                lastidcmd.Connection.Open();
                SqlDataReader reader = lastidcmd.ExecuteReader();
                reader.Read();

                string data = reader["student_id"].ToString();

                char[] lastidchar = data.ToCharArray();
                data = "";

                for (int ix = 2; ix < lastidchar.Length; ix++)
                {
                    data += lastidchar[ix];
                }
                int id = Convert.ToInt32(data);
                id = id + 1;
                data = "st" + id;

                lastidcmd.Connection.Close();




                string querry = "INSERT INTO [dbo].[student] ([student_id], [name], [surname], [e_mail], [password], [class_class_id]) VALUES (@student_id, @name, @surname, @e_mail, @password, 'class_A')"; // set  
                SqlCommand cmd = new SqlCommand(querry, sn);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@student_id", data);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@surname", surname);
                cmd.Parameters.AddWithValue("@e_mail", e_mail);
                cmd.Parameters.AddWithValue("@password", password);
                
                sn.Open();


                int i = cmd.ExecuteNonQuery();
                sn.Close();
                return data;
            }
            
        }
    }
}
