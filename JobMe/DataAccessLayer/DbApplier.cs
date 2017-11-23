using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using ModelLayer;
using System.Data.SqlClient;
using System.Configuration;

namespace DataAccessLayer
{
    public class DbApplier : IDataAccess<Applier>
    {
        //Connection string for instanciating sql connection 
        private string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;




        /// <summary>
        /// Is a method that creates a Applier in the database with the variables Email & Password.
        /// </summary>
        /// <param name="obj">Is a Applier object</param>
        public bool Create(Applier obj)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                        cmd.CommandText = "INSERT INTO Applier (Email, Password, MaxRadius, JobCVId) VALUES (@Email, @Password, @MaxRadius, @JobCVId)";
                        cmd.Parameters.AddWithValue("Email", obj.Email);
                        cmd.Parameters.AddWithValue("Password", obj.Password);
                        cmd.Parameters.AddWithValue("MaxRadius", 50);
                        cmd.Parameters.AddWithValue("JobCVId", obj.JobCV.Id);
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
        /// Is a method that creates a Applier in the database and returns the Applier with the primary key set in the database.
        /// </summary>
        /// <param name="obj">Is a Applier object</param>
        public Applier CreateAndReturnApplier(Applier obj)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Applier (Email, Password, MaxRadius, JobCVId) output INSERTED.Id VALUES (@Email, @Password, @MaxRadius, @JobCVId)";
                    cmd.Parameters.AddWithValue("Email", obj.Email);
                    cmd.Parameters.AddWithValue("Password", obj.Password);
                    cmd.Parameters.AddWithValue("MaxRadius", 50);
                    cmd.Parameters.AddWithValue("JobCVId", obj.JobCV.Id);
                    try
                    {
                        obj.Id = (int)cmd.ExecuteScalar();
                        return obj;
                    }
                    catch (SqlException)
                    {
                        return null;
                    }
                }
            }
        }

        /// <summary>
        /// Is a method that Deletes a Applier from the database by the id.
        /// </summary>
        /// <param name="id">Is the Id of the Applier</param>
        public void Delete(int id)
        {
            //using (SqlConnection connection = conn.OpenConnection())
            //{
            //    using (SqlCommand cmd = connection.CreateCommand())
            //    {
            //        cmd.CommandText = "DELETE FROM Applier WHERE Id = @id";
            //        cmd.Parameters.AddWithValue("id", id);
            //        cmd.ExecuteNonQuery();
            //    }
            //}
        }

        /// <summary>
        /// Is the method to Get the applier from the Database.
        /// This includes all variables on Applier - except password.
        /// This also includes jobcategory for the specific Applier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Applier Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                Applier applier = new Applier();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Applier WHERE Id = @id";
                    cmd.Parameters.AddWithValue("id", id);


                    DBJobCV dbJobCV = new DBJobCV();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            applier.Id = (int)reader["Id"];
                            applier.Email = (string)reader["Email"];
                            applier.Country = (string)reader["Country"];
                            applier.Description = (string)reader["Description"];
                            applier.BannerURL = (string)reader["BannerURL"];
                            applier.ImageURL = (string)reader["ImageURL"];
                            applier.MaxRadius = (int)reader["MaxRadius"];
                            applier.HomePage = (string)reader["HomePage"];
                            applier.FName = (string)reader["FName"];
                            applier.LName = (string)reader["LName"];
                            applier.Age = (int)reader["Age"];
                            applier.Status = (bool)reader["Status"];
                            applier.CurrentJob = (string)reader["CurrentJob"];
                            applier.Birthdate = (DateTime)reader["Birthdate"];
                            applier.JobCV = dbJobCV.Get((int)reader["JobCVId"]);
                        }
                    }

                    //Executes the JobCategory command for Applier.
                    cmd.CommandText = "SELECT * FROM ApplierJobCategory WHERE ApplierId = @ApplierId";
                    cmd.Parameters.AddWithValue("ApplierId", applier.Id);

                    List<JobCategory> jobcategoryList = new List<JobCategory>();
                    DbJobCategory dbJobCategory = new DbJobCategory();
                    try
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    JobCategory jobCategory = dbJobCategory.Get((int)reader["JobcategoryId"]);
                                    jobcategoryList.Add(jobCategory);
                                }
                            }
                        }
                        //Sets the JobCategoryList equal to Applier JobCategoryList.
                        applier.JobCategoryList = jobcategoryList;
                    }
                    catch (SqlException e)
                    {
                        throw e;
                        }
                        return applier;
                    }
                }
            }

        /// <summary>
        /// Returns a list of all the Appliers
        /// </summary>
        /// <returns></returns>
        public List<Applier> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the Applier object in the database
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Update(Applier obj)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Applier SET Email = @Email, Phone = @Phone, Country = @Country, Description = @Description, BannerURL = @BannerURL," +
                        " ImageURL = @ImageURL,  MaxRadius = @MaxRadius, HomePage = @HomePage, FName = @FName, LName = @LName, Age = @Age, Status = @Status," +
                        " CurrentJob = @CurrentJob, Birthdate = @Birthdate, JobCVId = @JobCVId" +
                        "WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("Email", obj.Email);
                    cmd.Parameters.AddWithValue("Phone", obj.Phone);
                    cmd.Parameters.AddWithValue("Country", obj.Country);
                    cmd.Parameters.AddWithValue("Description", obj.Description);
                    cmd.Parameters.AddWithValue("BannerURL", obj.BannerURL);
                    cmd.Parameters.AddWithValue("ImageURL", obj.ImageURL);
                    cmd.Parameters.AddWithValue("MaxRadius", obj.MaxRadius);
                    cmd.Parameters.AddWithValue("HomePage", obj.HomePage);
                    cmd.Parameters.AddWithValue("FName", obj.FName);
                    cmd.Parameters.AddWithValue("LName", obj.LName);
                    cmd.Parameters.AddWithValue("Age", obj.Age);
                    cmd.Parameters.AddWithValue("Status", obj.Status);
                    cmd.Parameters.AddWithValue("CurrentJob", obj.CurrentJob);
                    cmd.Parameters.AddWithValue("Birthdate", obj.Birthdate);
                    cmd.Parameters.AddWithValue("JobCVId", obj.JobCV.Id);
                    cmd.Parameters.AddWithValue("Id", obj.Id);

                    try
                    {
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
        /// Finds an applier in the database with the given param, and return the applier
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Applier Login(string email, string password)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                Applier applier = new Applier();

                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Applier WHERE Email = @email AND Password = @password";
                    cmd.Parameters.AddWithValue("email", email);
                    cmd.Parameters.AddWithValue("password", password);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        applier.Id = (int)reader["Id"];
                        applier.Email = (string)reader["Email"];
                        applier.Password = (string)reader["Password"];
                        if (reader.IsDBNull(reader.GetOrdinal("Description")))
                        { // Kan evt ændres til status når den bliver sat værk.
                            applier.Description = null;
                        }
                        else
                        {
                            applier.Description = (string)reader["Description"];
                        }

                    }
                    reader.Close();
                    if (applier.Email == email && applier.Password == password && applier.Description != null)
                    {
                        Applier Login = Get(applier.Id);
                        return Login;
                    }
                    else
                    {
                        if (applier.Email == email && applier.Password == password)
                        {
                            return applier;
                        }
                    }
                    return null;
                }
            }
        }

    }
}

