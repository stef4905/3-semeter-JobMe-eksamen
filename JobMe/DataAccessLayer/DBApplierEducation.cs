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
    public class DBApplierEducation : IDataAccess<ApplierEducation>
    {
        //Connection string for instanciating sql connection 
        private string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        /// <summary>
        /// Creates a new ApplierEducation in the database, by the given ApplierEducation object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Create(ApplierEducation obj)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = "INSERT INTO ApplierEducation (EducationName, Institution, StartDate, EndDate, JobCVId) VALUES (@EducationName, @Institution, @StartDate, @EndDate, @JobCVId)";
                        cmd.Parameters.AddWithValue("EducationName", obj.EducationName);
                        cmd.Parameters.AddWithValue("Institution", obj.Institution);
                        cmd.Parameters.AddWithValue("StartDate", obj.StartDate);
                        cmd.Parameters.AddWithValue("EndDate", obj.EndDate);
                        cmd.Parameters.AddWithValue("JobCVId", obj.JobCVId);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (SqlException) {
                        return false;
                    }

                }
            }
        }

        /// <summary>
        /// Deletes a single ApplierEdiucation in the database, by the given id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM ApplierEducation WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Returns a single object of ApplierEducation by the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ApplierEducation Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM ApplierEducation WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("Id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        ApplierEducation applierEducation = new ApplierEducation();
                        applierEducation.id = (int)reader["id"];
                        applierEducation.EducationName = (string)reader["EducationName"];
                        applierEducation.Institution = (string)reader["Institution"];
                        applierEducation.StartDate = (DateTime)reader["StartDate"];
                        applierEducation.EndDate = (DateTime)reader["EndDate"];
                        applierEducation.JobCVId = (int)reader["JobCVId"];
                        return applierEducation;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        /// <summary>
        /// Returns a list of all ApplierEducations in the database.
        /// </summary>
        /// <returns></returns>
        public List<ApplierEducation> GetAll()
        {
            return null;
        }

        /// <summary>
        /// Returns a list of all ApplierEducations with the corosponding JobCVID from the Applier
        /// </summary>
        /// <param name="jobCVId"></param>
        /// <returns></returns>
        public List<ApplierEducation> GetAllByJobCVId(int jobCVId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM ApplierEducation WHERE JobCVId = @JobCVId";
                    cmd.Parameters.AddWithValue("JobCVId", jobCVId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<ApplierEducation> EducationList = new List<ApplierEducation>();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ApplierEducation applierEducation = new ApplierEducation();
                            applierEducation.id = (int)reader["id"];
                            applierEducation.EducationName = (string)reader["EducationName"];
                            applierEducation.Institution = (string)reader["Institution"];
                            applierEducation.StartDate = (DateTime)reader["StartDate"];
                            applierEducation.EndDate = (DateTime)reader["EndDate"];
                            applierEducation.JobCVId = (int)reader["JobCVId"];
                            EducationList.Add(applierEducation);
                        }
                    }
                    return EducationList;
                }
            }
        }

        /// <summary>
        /// Updates the given ApplierEducations in the database
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Update(ApplierEducation obj)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = "UPDATE ApplierEducation SET EducationName = @EducationName, Institution = @Institution, StartDate = @StartDate, EndDate = @EndDate, JobCVId = @JobCVId WHERE Id = @Id ";
                        cmd.Parameters.AddWithValue("EducationName", obj.EducationName);
                        cmd.Parameters.AddWithValue("Institution", obj.Institution);
                        cmd.Parameters.AddWithValue("StartDate", obj.StartDate);
                        cmd.Parameters.AddWithValue("EndDate", obj.EndDate);
                        cmd.Parameters.AddWithValue("JobCVId", obj.JobCVId);
                        cmd.Parameters.AddWithValue("Id", obj.id);
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
