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
    public class DBBusinessType : IDataAccess<BusinessType>
    {

        //Connection string for instanciating sql connection 
        private string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        /// <summary>
        /// Is a method that creates a BusinessType in the database 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Create(BusinessType obj)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = "INSERT INTO BusinessType (Type) VALUES (@Type)";
                        cmd.Parameters.AddWithValue("Type", obj.Type);
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
        /// Is a method that deletes the BusinessType from the database by its ID
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = "DELETE FROM BusinessType WHERE Id = @Id";
                        cmd.Parameters.AddWithValue("Id", id);
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        throw e;
                    }
                }
            }
        }

        /// <summary>
        /// Is a method that returns the BusinessType object by its ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BusinessType Get(int id)
        {
            BusinessType businessType = new BusinessType();
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using(SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM BusinessType WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("Id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        businessType.Id = (int)reader["Id"];
                        businessType.Type = (string)reader["Type"];
                    }
                }
            }
            return businessType;
        }

        /// <summary>
        /// Returns all current available business types from the database
        /// </summary>
        /// <returns>List<BusinessType></returns>
        public List<BusinessType> GetAll()
        {
            List<BusinessType> businessTypeList = new List<BusinessType>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Select * from BusinessType";
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        BusinessType businessType = new BusinessType((int)reader["Id"], (string)reader["Type"]);
                        businessTypeList.Add(businessType);
                    }
                }
            }
            return businessTypeList;
        }

        /// <summary>
        /// Updates the given businesstype in the database
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>bool</returns>
        public bool Update(BusinessType obj)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = "UPDATE BusinessType SET Type = @Type WHERE Id = @Id";
                        cmd.Parameters.AddWithValue("Type", obj.Type);
                        cmd.Parameters.AddWithValue("Id", obj.Id);
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
    }
}
