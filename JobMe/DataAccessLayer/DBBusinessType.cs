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
    class DBBusinessType : IDataAccess<BusinessType>
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Is a method that deletes the BusinessType from the database by its ID
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            throw new NotImplementedException();
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

        public List<BusinessType> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(BusinessType obj)
        {
            throw new NotImplementedException();
        }
    }
}
