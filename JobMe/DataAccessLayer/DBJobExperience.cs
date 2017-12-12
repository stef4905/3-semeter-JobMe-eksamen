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
    public class DBJobExperience: IDataAccess<JobExperience>
    {

        //Instance variables
        private string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        /// <summary>
        /// Inserts the JobExperince obejct into the database
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Create(JobExperience obj)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = "INSERT INTO JobExperience (Title, StartDate, EndDate, Description, JobCvId) VALUES (@Title, @StartDate, @EndDate, @Description, @JobCVId)";
                        cmd.Parameters.AddWithValue("Title", obj.Title);
                        cmd.Parameters.AddWithValue("StartDate", obj.StartDate);
                        cmd.Parameters.AddWithValue("EndDate", obj.EndDate);
                        cmd.Parameters.AddWithValue("Description", obj.Description);
                        cmd.Parameters.AddWithValue("JobCVId", obj.JobCVId);
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
        /// Deletes the specific JobExperience in the database with the given id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM JobExperience WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Returns a single object of JobExperience by the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JobExperience Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM JobExperience WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("Id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        JobExperience jobExperience = new JobExperience();
                        jobExperience.Id = (int)reader["Id"];
                        jobExperience.Title = (string)reader["Title"];
                        jobExperience.StartDate = (DateTime)reader["StartDate"];
                        jobExperience.EndDate = (DateTime)reader["EndDate"];
                        jobExperience.Description = (string)reader["Description"];
                        jobExperience.JobCVId = (int)reader["JobCVId"];
                        return jobExperience;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        /// <summary>
        /// Returns a list of all JobExperience from the database
        /// </summary>
        /// <returns>List of all JobExperiences</returns>
        public List<JobExperience> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a list of all JobExperience with the corosponding JobCVId
        /// </summary>
        /// <param name="jobCVId"></param>
        /// <returns></returns>
        public List<JobExperience> GetAllByJobCVId(int jobCVId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM JobExperience WHERE JobCVId = @JobCVId";
                    cmd.Parameters.AddWithValue("JobCVId", jobCVId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<JobExperience> ExperienceList = new List<JobExperience>();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            JobExperience jobExperience = new JobExperience();
                            jobExperience.Id = (int)reader["Id"];
                            jobExperience.Title = (string)reader["Title"];
                            jobExperience.StartDate = (DateTime)reader["StartDate"];
                            jobExperience.EndDate = (DateTime)reader["EndDate"];
                            jobExperience.Description = (string)reader["Description"];
                            jobExperience.JobCVId = (int)reader["JobCVId"];
                            ExperienceList.Add(jobExperience);
                        }
                    }
                    return ExperienceList;
                }
            }
        }

        /// <summary>
        /// Updates the JobExperience object in the database
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Update(JobExperience obj)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = "UPDATE JobExperience SET Title = @Title, StartDate = @StartDate, EndDate = @EndDate, Description = @Description, JobCVId = @JobCVId WHERE Id = @Id ";
                        cmd.Parameters.AddWithValue("Title", obj.Title);
                        cmd.Parameters.AddWithValue("StartDate", obj.StartDate);
                        cmd.Parameters.AddWithValue("EndDate", obj.EndDate);
                        cmd.Parameters.AddWithValue("Description", obj.Description);
                        cmd.Parameters.AddWithValue("JobCVId", obj.JobCVId);
                        cmd.Parameters.AddWithValue("Id", obj.Id);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (SqlException e)
                    {
                        
                        return false;
                    }
                }
            }
        }
    }
}
