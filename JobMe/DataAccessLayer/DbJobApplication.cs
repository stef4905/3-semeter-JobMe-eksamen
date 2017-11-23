using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using System.Data.SqlClient;
using System.Configuration;

namespace DataAccessLayer
{
    public class DbJobApplication : IDataAccess<JobApplication>
    {

        //Instance variables
        private string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;


        /// <summary>
        /// Creates the given JobApplication in the database
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Create(JobApplication obj)

        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = "INSERT INTO JobApplication (Title, Description, ApplierId) VALUES (@Title, @Description, @ApplierId)";
                        cmd.Parameters.AddWithValue("Title", obj.Title);
                        cmd.Parameters.AddWithValue("Description", obj.Description);
                        cmd.Parameters.AddWithValue("ApplierId", obj.ApplierId);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (SqlException)
                    {
                        return false;
                    }
                }
            }

        }
        /// <summary>
        /// Deletes a JobApplication in the database from a specific Id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
           using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM JobApplication WHERE Id = @id";
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Returns a specific JobApplication by the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>JobApplication</returns>
        public JobApplication Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM JobApplication WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("Id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        JobApplication jobApplication = new JobApplication((int)reader["Id"], (string)reader["Title"], (string)reader["Description"], (int)reader["ApplierId"]);
                        return jobApplication;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        /// <summary>
        /// Returns a list of all JobApplciations in the database
        /// </summary>
        /// <returns>List of all JobApplication</returns>
        public List<JobApplication> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a list of JobApplication from the database, that has the corosponding ApplierId from the Applier
        /// </summary>
        /// <param name="ApplierId"></param>
        /// <returns></returns>
        public List<JobApplication> GetAllByApplierId(int ApplierId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM JobApplication WHERE ApplierId = @ApplierId";
                    cmd.Parameters.AddWithValue("ApplierId", ApplierId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<JobApplication> jobApplicationList = new List<JobApplication>();
                    while (reader.Read())
                    {
                        JobApplication jobApplication = new JobApplication((int)reader["Id"], (string)reader["Title"], (string)reader["Description"], (int)reader["ApplierId"]);
                        jobApplicationList.Add(jobApplication);
                    }
                    return jobApplicationList;
                }
            }
        }

        /// <summary>
        /// Updates the given JobApplication object in the database
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Update(JobApplication obj)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "UPDATE JobApplication SET Title = @Title, Description = @Description WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("Title", obj.Title);
                    cmd.Parameters.AddWithValue("Description", obj.Description);
                    cmd.Parameters.AddWithValue("Id", obj.Id);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (SqlException)
                    {
                        return false;
                    }
                }
            }
        }

        public bool SendApplication(JobApplication jobApplication, JobPost jobPost)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = "INSERT INTO JobApplicationJobPost (JobApplicationId, JobPostId) VALUES (@JobApplicationId, @JobPostId)";
                        cmd.Parameters.AddWithValue("JobApplicationId", jobApplication.Id);
                        cmd.Parameters.AddWithValue("JobPostId", jobPost.Id);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (SqlException)
                    {
                        return false;
                    }
                }
            }
        }
    }
}