using DatingApp.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DatingApp.Services
{
    public class GetGender : IGetGender
    {
        string conn;

        private readonly IConfiguration configuration;
        public GetGender(IConfiguration configuration)
        {
            conn = configuration.GetConnectionString("DefaultConnection");

        }
        public string GetGenderName(int id)
        {
            string gender = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn))
                using (SqlCommand cmd = new SqlCommand("usp_GetGender", con) { CommandType = CommandType.StoredProcedure })
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        gender = reader.GetString(0);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return gender;
        }
    }
}
