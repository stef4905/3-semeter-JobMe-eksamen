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
    public class DBJobCV
    {
        //Is an instance of DBConnection
        private string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;


        /// <summary>
        /// Add the specifik jobcv into the database
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Applier Create(JobCV obj, Applier applier)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = "INSERT INTO JobCV (Title, Bio) output INSERTED.Id VALUES (@Title, @Bio)";
                        cmd.Parameters.AddWithValue("Title", obj.Title);
                        cmd.Parameters.AddWithValue("Bio", obj.Bio);
                        applier.JobCV.Id = (int)cmd.ExecuteScalar();
                        return applier;
                    }
                    catch (SqlException)
                    {
                        return null;
                    }
                }
            }

        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return a single JobCV Object by the given Applier
        /// </summary>
        /// <param name="apllier"></param>
        /// <returns></returns>
        public JobCV Get(int JobCVId)
        {
           
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM JobCV WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", JobCVId);
                    
                    DBApplierEducation dbApplierEducation = new DBApplierEducation();
                    DBJobAppendix dbJobAppendix = new DBJobAppendix();
                    DBJobExperience dbJobExperience = new DBJobExperience();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            JobCV jobCV = new JobCV()
                            {
                                Id = (int)reader["Id"],
                                Title = (string)reader["Title"],
                                Bio = (string)reader["Bio"],
                                ApplierEducationList = dbApplierEducation.GetAllByJobCVId((int)reader["Id"]),
                                JobAppendixList = dbJobAppendix.GetAllByJobCVId((int)reader["Id"]),
                                JobExperienceList = dbJobExperience.GetAllByJobCVId((int)reader["Id"])
                            };
                            return jobCV;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }  
            }
        }

        public List<JobCV> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the given object JobCV in the database
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Update(JobCV obj)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = "UPDATE JobCV SET Title = @Title, ApplierId = @ApplierId WHERE Id = @Id ";
                        cmd.Parameters.AddWithValue("Titlte", obj.Title);
                        cmd.Parameters.AddWithValue("StartDate", obj.ApplierId);
                        cmd.Parameters.AddWithValue("Id", obj.Id);
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
