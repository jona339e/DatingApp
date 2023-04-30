using DatingApp.Interfaces;
using DatingApp.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DatingApp.Services
{
    public class UserExist : IUserExist
    {
        string conn;
        private readonly IConfiguration configuration;
        public UserExist(IConfiguration configuration)
        {
            conn = configuration.GetConnectionString("DefaultConnection");
            
        }
        public int UserExists(string username)
        {
            int count = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(conn))
                using (SqlCommand cmd = new SqlCommand("usp_UserExist", con) { CommandType = CommandType.StoredProcedure})
                {                   
                    cmd.Parameters.AddWithValue("@Username", username);

                    con.Open();

                    count = (int)cmd.ExecuteScalar(); // the count will always only have 1 row therefore i can use ExecuteScalar
                    // waow
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


           return count;
        }

    
    }
}
