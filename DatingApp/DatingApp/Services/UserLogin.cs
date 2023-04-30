using DatingApp.Interfaces;
using DatingApp.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DatingApp.Services
{
    public class UserLogin : IUserLogin
    {
        string conn;

        private readonly IConfiguration configuration;
        public UserLogin(IConfiguration configuration)
        {
            conn = configuration.GetConnectionString("DefaultConnection");

        }

        public string GetPassword(int id)
        {
            string password = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(conn))
                using (SqlCommand cmd = new SqlCommand("usp_GetPassword", con) { CommandType = CommandType.StoredProcedure })
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        password = reader.GetString(0);

                    }


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return password;
        }

        public string GetSalt(int id)
        {
            string salt = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(conn))
                using (SqlCommand cmd = new SqlCommand("usp_GetSalt", con) { CommandType = CommandType.StoredProcedure })
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        salt = reader.GetString(0);

                    }


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return salt;
        }

    }
}
