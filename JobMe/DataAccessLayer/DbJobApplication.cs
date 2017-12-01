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
                        cmd.Parameters.AddWithValue("ApplierId", obj.Applier.Id);
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

                    try
                    {
                        cmd.ExecuteNonQuery();
                    } catch (SqlException e)
                    {
                        throw e;
                    }
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
                    DbApplier dbApplier = new DbApplier();

                    if (reader.Read())
                    {
                        JobApplication jobApplication = new JobApplication((int)reader["Id"], (string)reader["Title"], (string)reader["Description"], dbApplier.Get((int)reader["ApplierId"]));
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
                    DbApplier dbApplier = new DbApplier();
                    List<JobApplication> jobApplicationList = new List<JobApplication>();
                    while (reader.Read())
                    {
                        JobApplication jobApplication = new JobApplication((int)reader["Id"], (string)reader["Title"], (string)reader["Description"], dbApplier.Get((int)reader["ApplierId"]));
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

        /// <summary>
        /// Takes a JobApplication and "attaches" it to a specific JobPost
        /// JobApplicationJobPost is a collection of JobApplications.
        /// </summary>
        /// <param name="jobApplication"></param>
        /// <param name="jobPost"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Updates the accceptApplication boolean in the jobapplicationJobPostDB
        /// </summary>
        /// <param name="jobApplication"></param>
        /// <param name="jobPost"></param>
        /// <param name="acceptApplication"></param>
        /// <returns></returns>
        public bool AcceptDeclineJobApplication(JobApplication jobApplication, JobPost jobPost, bool acceptApplication)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "UPDATE JobApplicationJobPost SET AcceptApplication = @AcceptApplication WHERE JobApplicationId = @JobApplicationId AND JobPostId = @JobPostId";
                    cmd.Parameters.AddWithValue("AcceptApplication", acceptApplication);
                    cmd.Parameters.AddWithValue("JobApplicationId", jobApplication.Id);
                    cmd.Parameters.AddWithValue("JobPostId", jobPost.Id);

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
        /// <summary>
        /// Returns all JobApplications from a specific JobPost
        /// </summary>
        /// <param name="jobPostId"></param>
        /// <returns></returns>
        public List<JobApplication> GetAllJobApplicationToAJobPost(int jobPostId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM JobApplicationJobPost WHERE JobPostId = @JobPostId AND (AcceptApplication = @AcceptApplication OR AcceptApplication IS NULL)";
                    cmd.Parameters.AddWithValue("JobPostId", jobPostId);
                    cmd.Parameters.AddWithValue("AcceptApplication", 1);
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<JobApplication> jobApplicationList = new List<JobApplication>();

                    while (reader.Read())
                    {
                        JobApplication jobApplication = new JobApplication
                        {
                             Id = (int)reader["JobApplicationId"]
                        };
                        jobApplication = Get(jobApplication.Id);
                        jobApplicationList.Add(jobApplication);
                    }
                    return jobApplicationList;
                }
            }

        }
    }
}