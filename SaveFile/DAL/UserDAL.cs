using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDAL
    {
        string ConnectionString = @"Data Source=(localdb)\ProjectsV12;Database=FileDateBase;Integrated Security=True;";

        public int GetUserId(string userName)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand("SELECT UserId FROM UserTable WHERE UserName = @UserName", connection);
                command.Parameters.AddWithValue("@UserName", userName);
                connection.Open();
                return (int)command.ExecuteScalar();
            }
        }

        public bool CheckUser(string name, string pass)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand("SELECT UserId FROM UserTable WHERE UserName = @UserName AND UserPassword = @UserPassword", connection);
                command.Parameters.AddWithValue("@UserName", name);
                command.Parameters.AddWithValue("@UserPassword", pass);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    return reader.Read();
                }
            }
        }

        public bool RegistrationUser(string name, string pass)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                try {
                    var command = new SqlCommand("INSERT INTO dbo.UserTable (UserName,UserPassword) VALUES (@UserName,@UserPassword)", connection);
                    command.Parameters.AddWithValue("@UserName", name);
                    command.Parameters.AddWithValue("@UserPassword", pass);
                    connection.Open();
                    return command.ExecuteNonQuery() == 1;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
