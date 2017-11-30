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

        public bool Create(Meeting meeting)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Meeting (JobPostId, CompanyId) VALUES (@JobPostId, @CompanyId)";
                    cmd.Parameters.AddWithValue("JobPostId", meeting.Id);
                    cmd.Parameters.AddWithValue("CompanyId", meeting.CompanyId);
                    try
                    {

                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (SqlException e)
                    {
                        return false;
                        throw e;
                    }
                }
            }
        }

    }
}
