using DatingApp.Interfaces;
using DatingApp.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Data.SqlClient;

namespace DatingApp.Services
{
    public class CreateUser : ICreateUser
    {
        string conn;

        private readonly IConfiguration configuration;
        public CreateUser(IConfiguration configuration)
        {
            conn = configuration.GetConnectionString("DefaultConnection");

        }
        public void AddUser(User user)
        {
            

            try
            {
                using (SqlConnection con = new SqlConnection(conn))
                {
                    SqlCommand cmd = new SqlCommand("usp_InsertUser", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@salt", user.Salt);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@CreatedDate", user.CreateDate);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            // maybe fire event here to notify user was created
        }
    }
}
