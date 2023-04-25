using DatingApp.Interfaces;
using DatingApp.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Data.SqlClient;

namespace DatingApp.Services
{
    public class CreateUser : ICreateUser
    {
        [Inject]
        IConfiguration configuration { get; set; }
        public User AddUser(User user)
        {
            string conn = configuration.GetConnectionString("DefaultConnection");

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
                    cmd.Parameters.AddWithValue("@CreateDate", user.CreateDate);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            throw new System.NotImplementedException();
        }
    }
}
