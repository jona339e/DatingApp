using DatingApp.Interfaces;
using DatingApp.Models;
using DatingApp.Pages;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DatingApp.Services
{
    public class UpdateProfile : IUpdateProfile
    {
        string conn;
        private readonly IConfiguration configuration;
        public UpdateProfile(IConfiguration configuration)
        {
            conn = configuration.GetConnectionString("DefaultConnection");

        }
        public bool UpdateUserProfile(Models.UserProfile userprofile)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conn))
                using (SqlCommand cmd = new SqlCommand("usp_UpdateProfile", con) { CommandType = CommandType.StoredProcedure })
                {
                    cmd.Parameters.AddWithValue("@Id", userprofile.Id);
                    cmd.Parameters.AddWithValue("@FirstName", userprofile.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", userprofile.LastName);
                    cmd.Parameters.AddWithValue("@Birthdate", userprofile.Birthdate);
                    cmd.Parameters.AddWithValue("@Height", userprofile.Height);
                    cmd.Parameters.AddWithValue("@About", userprofile.About);
                    cmd.Parameters.AddWithValue("@CityID", userprofile.CityID);
                    cmd.Parameters.AddWithValue("@GenderID", userprofile.GenderID);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            
            return true;
        


        }
    }
}
