using DatingApp.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DatingApp.Services
{
    public class GetId : IGetId
    {
        string conn;
        private readonly IConfiguration configuration;
        public GetId(IConfiguration configuration)
        {
            conn = configuration.GetConnectionString("DefaultConnection");

        }
        public int GetUserId(string username)
        {
            int id = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn))
                using (SqlCommand cmd = new SqlCommand("usp_GetId", con) { CommandType = CommandType.StoredProcedure })
                {
                    cmd.Parameters.AddWithValue("@username", username);

                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        id = reader.GetInt32(0);

                    }


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return id;
        }
    }
}
