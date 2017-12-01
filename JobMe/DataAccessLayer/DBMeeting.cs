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


        /// <summary>
        /// Creates the given Meeting in the database
        /// </summary>
        /// <param name="meeting"></param>
        /// <returns>Updates Meeting with the primary id, usde for Booking creation</returns>
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

        /// <summary>
        /// Returns a single Meeting object with the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Metting</returns>
        public Meeting Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Meeting WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("Id", id);
                    try
                    {
                        Meeting meeting = new Meeting();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            meeting.Id = (int)reader["Id"];
                            meeting.JobPostId = (int)reader["JobPostId"];
                            //List of all booking are getted through the controller
                            meeting.CompanyId = (int)reader["CompanyId"];                              
                        }
                        return meeting;
                    }
                    catch (SqlException e)
                    {
                        throw e;
                    }
                }
            }
        }

        /// <summary>
        /// Deletes a single Meeting object in the database by the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public bool Delete(Meeting meeting)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE * FROM Meeting WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("Id", meeting.Id);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (SqlException e)
                    {
                        throw e;
                    }
                }
            }
        }

        /// <summary>
        /// Updates the given Meeting in the database
        /// </summary>
        /// <param name="meeting"></param>
        /// <returns>bool</returns>
        public bool Update(Meeting meeting)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Meeting SET JobPostId = @JobPostId, CompanyId = @CompanyId WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("JobPostId", meeting.JobPostId);
                    cmd.Parameters.AddWithValue("CompanyId", meeting.CompanyId);
                    //Checking that the id has been set and isen´t equal to zero. If it is, 
                    //then it would be changed to NULL, wich the SQL understands
                    if (meeting.Id != 0)
                    {
                        cmd.Parameters.AddWithValue("Id", meeting.Id);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("Id", null);
                    }

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (SqlException e)
                    {
                        throw e;
                        return false;
                    }
                }
            }
        }


    }
}
