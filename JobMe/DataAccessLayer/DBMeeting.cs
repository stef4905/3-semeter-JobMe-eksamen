using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using System.Configuration;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DBMeeting
    {

        //Connection string for instanciating sql connection 
        private string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public Meeting Create(Meeting meeting)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Meeting (JobPostId, CompanyId) output INSERTED.Id VALUES (@JobPostId, @CompanyId)";
                    cmd.Parameters.AddWithValue("JobPostId", meeting.JobPostId);
                    cmd.Parameters.AddWithValue("CompanyId", meeting.CompanyId);
                    try
                    {

                        cmd.ExecuteNonQuery();
                        meeting.Id = (int)cmd.ExecuteScalar();
                        return meeting;
                    }
                    catch (SqlException e)
                    {
                        throw e;
                    }
                }
            }
        }

    }
}
