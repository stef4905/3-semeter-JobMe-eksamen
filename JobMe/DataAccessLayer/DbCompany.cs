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
    public class DbCompany : IDataAccess<Company>
    {
        //Connection string for instanciating sql connection 
        private string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        /// <summary>
        /// its method that create a Company in the database with  the varibles Email & passeword
        /// </summary>
        /// <param name="obj"></param>
        public bool Create(Company obj)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "INSERT INTO Company (Email, Password) VALUES (@Email, @Password)";
                        cmd.Parameters.AddWithValue("Email", obj.Email);
                        cmd.Parameters.AddWithValue("Password", obj.Password);
                        cmd.ExecuteNonQuery();
                        return true;
                    }


                }
                catch (SqlException)
                {
                    return false;

                }
            }
        }

        /// <summary>
        /// Is a method that deletes a company from the database by the Id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a Company Object from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Company Get(int id)
        {

            Company company = new Company();
            DBBusinessType dbBusinessType = new DBBusinessType();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Company WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("Id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        company.Id = (int)reader["Id"];
                        company.Email = (string)reader["Email"];
                        company.Password = (string)reader["Password"];
                        company.Phone = (int)reader["Phone"];
                        company.Address = (string)reader["Address"];
                        company.Country = (string)reader["Country"];
                        company.Description = (string)reader["Description"];
                        company.BannerURL = (string)reader["BannerURL"];
                        company.MaxRadius = (int)reader["MaxRadius"];
                        company.Homepage = (string)reader["HomePage"];
                        company.CompanyName = (string)reader["CompanyName"];
                        company.CVR = (int)reader["CVR"];
                        company.businessType = dbBusinessType.Get((int)reader["BusinessTypeId"]);
                        // Allows ImageURL to be null, if not null, reads the current company ImageURL.
                        if (reader.IsDBNull(reader.GetOrdinal("ImageURL")))
                            company.ImageURL = null;
                        else
                            company.ImageURL = (string)reader["ImageURL"];
                    }
                }
            }
            return company;
        }

        public List<Company> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(Company obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///  Finds a company in the database with the given param, and return the company
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Company Login(string email, string password)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                Company company = new Company();
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Company WHERE Email = @email AND Password = @password";
                    cmd.Parameters.AddWithValue("email", email);
                    cmd.Parameters.AddWithValue("password", password);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        company.Id = (int)reader["Id"];
                        company.Email = (string)reader["Email"];
                        company.Password = (string)reader["Password"];
                        if (reader.IsDBNull(reader.GetOrdinal("Description"))) // Kan evt ændres til status når den bliver sat værk.
                            company.Description = null;
                        else
                            company.Description = (string)reader["Description"];


                    }
                    reader.Close();


                    if (company.Email == email && company.Password == password && company.Description != null)
                    {
                        Company FullCompany = Get(company.Id);
                        return FullCompany;
                    }

                    else
                    {
                        if (company.Email == email && company.Password == password)
                        {
                            return company;
                        }
                    }

                    return null;

                }
            }
        }
    }
}
