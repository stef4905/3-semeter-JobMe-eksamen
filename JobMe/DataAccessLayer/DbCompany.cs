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
        /// Creates a new Company in the database by the given Company obejct
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
        /// Deletes a single Company in the database by the given id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Company WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("Id", id);
                    cmd.ExecuteNonQuery();

                }
            }
        }
    

        /// <summary>
        /// Returns a Company Object from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Company Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                DBBusinessType dbBusinessType = new DBBusinessType();
                Company company = new Company();

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
                        if (reader["Phone"] == DBNull.Value)
                        {
                            company.Phone = 0;
                        }
                        else
                        {
                            company.Phone = (int)reader["Phone"];
                        }

                        if (reader["Address"] == DBNull.Value)
                        {
                            company.Address = "";
                        }
                        else
                        {
                            company.Address = (string)reader["Address"];
                        }

                        if (reader["Country"] == DBNull.Value)
                        {
                            company.Country = "";
                        }
                        else
                        {
                            company.Country = (string)reader["Country"];
                        }
                        if (reader["ImageURL"] == DBNull.Value)
                        {
                            company.ImageURL = "";
                        }
                        else
                        {
                            company.ImageURL = (string)reader["ImageURL"];
                        }
                        if (reader["Description"] == DBNull.Value)
                        {
                            company.Description = "";
                        }
                        else
                        {
                            company.Description = (string)reader["Description"];
                        }
                        if (reader["BannerURL"] == DBNull.Value)
                        {
                            company.BannerURL = "";
                        }
                        else
                        {
                            company.BannerURL = (string)reader["BannerURL"];
                        }
                        if (reader["MaxRadius"] == DBNull.Value)
                        {
                            company.MaxRadius = 0;
                        }
                        else
                        {
                            company.MaxRadius = (int)reader["MaxRadius"];
                        }

                        if (reader["HomePage"] == DBNull.Value)
                        {
                            company.Homepage = "";
                        }
                        else
                        {
                            company.Homepage = (string)reader["HomePage"];
                        }

                        if (reader["CompanyName"] == DBNull.Value)
                        {
                            company.CompanyName = "";
                        }
                        else
                        {
                            company.CompanyName = (string)reader["CompanyName"];
                        }
                        if (reader["CVR"] == DBNull.Value)
                        {
                            company.CVR = 0;
                        }
                        else
                        {
                            company.CVR = (int)reader["CVR"];
                        }
                        if (reader["BusinessTypeId"] == DBNull.Value)
                        {
                            company.businessType = new BusinessType();
                            company.businessType.Id = 0;
                            company.businessType.Type = "Ikke Angivet";
                        }
                        else
                        {
                            company.businessType = dbBusinessType.Get((int)reader["BusinessTypeId"]);
                            company.businessType.Id = (int)reader["BusinessTypeId"];
                        }
                    }
                }
                return company;
            }
        }

        /// <summary>
        /// Returns a list of all Companies from the database
        /// </summary>
        /// <returns>List of all Company</returns>
        public List<Company> GetAll()
        {
            List<Company> companyList = new List<Company>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Company";
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Company company = new Company();
                        DBBusinessType dBBusinessType = new DBBusinessType();
                        company.Id = (int)reader["Id"];
                        company.Email = (string)reader["Email"];
                        company.Password = (string)reader["Password"];
                        if (reader["Phone"] == DBNull.Value)
                        {
                            company.Phone = 0;
                        }
                        else
                        {
                            company.Phone = (int)reader["Phone"];
                        }

                        if (reader["Address"] == DBNull.Value)
                        {
                            company.Address = "";
                        }
                        else
                        {
                            company.Address = (string)reader["Address"];
                        }

                        if (reader["Country"] == DBNull.Value)
                        {
                            company.Country = "";
                        }
                        else
                        {
                            company.Country = (string)reader["Country"];
                        }
                        if (reader["ImageURL"] == DBNull.Value)
                        {
                            company.ImageURL = "";
                        }
                        else
                        {
                            company.ImageURL = (string)reader["ImageURL"];
                        }
                        if (reader["Description"] == DBNull.Value)
                        {
                            company.Description = "";
                        }
                        else
                        {
                            company.Description = (string)reader["Description"];
                        }
                        if (reader["BannerURL"] == DBNull.Value)
                        {
                            company.BannerURL = "";
                        }
                        else
                        {
                            company.BannerURL = (string)reader["BannerURL"];
                        }
                        if (reader["MaxRadius"] == DBNull.Value)
                        {
                            company.MaxRadius = 0;
                        }
                        else
                        {
                            company.MaxRadius = (int)reader["MaxRadius"];
                        }

                        if (reader["HomePage"] == DBNull.Value)
                        {
                            company.Homepage = "";
                        }
                        else
                        {
                            company.Homepage = (string)reader["HomePage"];
                        }

                        if (reader["CompanyName"] == DBNull.Value)
                        {
                            company.CompanyName = "";
                        }
                        else
                        {
                            company.CompanyName = (string)reader["CompanyName"];
                        }
                        if (reader["CVR"] == DBNull.Value)
                        {
                            company.CVR = 0;
                        }
                        else
                        {
                            company.CVR = (int)reader["CVR"];
                        }
                        if (reader["BusinessTypeId"] == DBNull.Value)
                        {
                            company.businessType = new BusinessType();
                            company.businessType.Id = 0;
                            company.businessType.Type = "Ikke Angivet";
                        }
                        else
                        {
                            company.businessType = dBBusinessType.Get((int)reader["BusinessTypeId"]);
                            company.businessType.Id = (int)reader["BusinessTypeId"];
                        }
                        companyList.Add(company);
                    }
                }
            }
            return companyList;
        }

        /// <summary>
        /// Updates the given Company object in the database
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>A Bool to ensure the update</returns>
        public bool Update(Company obj)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Company SET Email = @Email, Password = @Password, Phone = @Phone, Address = @Address, Country = @Country, ImageURL = @ImageURL, Description = @Description, BannerURl = @BannerURl, MaxRadius = @MaxRadius, HomePage = @HomePage, CompanyName = @CompanyName, CVR = @CVR, BusinessTypeId = @BusinessTypeId WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("Email", obj.Email);
                    cmd.Parameters.AddWithValue("Password", obj.Password);
                    cmd.Parameters.AddWithValue("Phone", obj.Phone);
                    cmd.Parameters.AddWithValue("Address", obj.Address ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("Country", obj.Country ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("ImageURL", obj.ImageURL ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("Description", obj.Description ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("BannerURl", obj.BannerURL ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("MaxRadius", obj.MaxRadius);
                    cmd.Parameters.AddWithValue("HomePage", obj.Homepage ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("CompanyName", obj.CompanyName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("CVR", obj.CVR);
                    cmd.Parameters.AddWithValue("BusinessTypeId", obj.businessType.Id); 
                    cmd.Parameters.AddWithValue("Id", obj.Id);
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
