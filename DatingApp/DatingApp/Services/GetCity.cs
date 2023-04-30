using DatingApp.Interfaces;
using DatingApp.Models;
using DatingApp.Pages;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DatingApp.Services
{
    public class GetCity : IGetCity
    {
        string conn;

        private readonly IConfiguration configuration;
        public GetCity(IConfiguration configuration)
        {
            conn = configuration.GetConnectionString("DefaultConnection");

        }
        public string GetCityByZip(int zip)
        {
            string city = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn))
                using (SqlCommand cmd = new SqlCommand("usp_GetCity", con) { CommandType = CommandType.StoredProcedure })
                {
                    cmd.Parameters.AddWithValue("@zip", zip);

                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        city = reader.GetString(0);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return city;
        }
    }
}
