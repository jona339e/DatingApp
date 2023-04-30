using DatingApp.Interfaces;
using DatingApp.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DatingApp.Services
{
    public class GetUserProfile : IGetUserProfile
    {

        string conn;

        private readonly IConfiguration configuration;
        public GetUserProfile(IConfiguration configuration)
        {
            conn = configuration.GetConnectionString("DefaultConnection");

        }
        public UserProfile GetCorrectUserProfile(int userId)
        {
            UserProfile profile = new UserProfile();
            try
            {
                using (SqlConnection con = new SqlConnection(conn))
                using (SqlCommand cmd = new SqlCommand("usp_GetUserProfile", con) { CommandType = CommandType.StoredProcedure })
                {
                    cmd.Parameters.AddWithValue("@id", userId);

                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        profile.Id = reader.GetInt32(0);
                        profile.FirstName = reader.GetString(1);
                        profile.LastName = reader.GetString(2);
                        profile.Birthdate = reader.GetDateTime(3);
                        profile.Height = reader.GetDecimal(4);
                        profile.About = reader.GetString(5);
                        profile.UserID = reader.GetInt32(6);
                        profile.CityID = reader.GetInt32(7);
                        profile.GenderID = reader.GetInt32(8);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return profile;
        }
    }
}
