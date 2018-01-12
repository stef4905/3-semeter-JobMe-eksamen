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
                    catch (SqlException e)
                    {
                        return false;
                        throw e;
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
                    cmd.Parameters.AddWithValue("JobCVId", 1);

                    obj.Id = (int)cmd.ExecuteScalar();
                    return obj;
                }
            }
        }


        /// <summary>
        /// Is a method that Deletes a Applier from the database by the id.
        /// </summary>
        /// <param name="id">Is the Id of the Applier</param>
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Applier WHERE Id = @id";
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                }
            }
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
                            applier.Password = (string)reader["Password"];
                            if (reader["Phone"] == DBNull.Value)
                            {
                                applier.Phone = 0;
                            }
                            else
                            {
                                applier.Phone = (int)reader["Phone"];
                            }
                            if (reader["Address"] == DBNull.Value)
                            {
                                applier.Address = null;
                            }
                            else
                            {
                                applier.Address = (string)reader["Address"];
                            }

                            if (reader["Country"] == DBNull.Value)
                            {
                                applier.Country = null;
                            }
                            else
                            {
                                applier.Country = (string)reader["Country"];
                            }

                            if (reader["Description"] == DBNull.Value)
                            {
                                applier.Description = null;
                            }
                            else
                            {
                                applier.Description = (string)reader["Description"];
                            }
                            if (reader["BannerURL"] == DBNull.Value)
                            {
                                applier.BannerURL = null;
                            }
                            else
                            {
                                applier.BannerURL = (string)reader["BannerURL"];
                            }

                            if (reader["ImageURL"] != DBNull.Value)
                            {
                                applier.ImageURL = (string)reader["ImageURL"];
                            }



                            if (reader["MaxRadius"] != DBNull.Value)
                            {
                                applier.MaxRadius = (int)reader["MaxRadius"];
                            }


                            if (reader["HomePage"] != DBNull.Value)
                            {
                                applier.HomePage = (string)reader["HomePage"];
                            }


                            if (reader["FName"] != DBNull.Value)
                            {
                                applier.FName = (string)reader["FName"];
                            }


                            if (reader["LName"] != DBNull.Value)
                            {
                                applier.LName = (string)reader["LName"];
                            }


                            if (reader["Age"] != DBNull.Value)
                            {
                                applier.Age = (int)reader["Age"];
                            }


                            if (reader["Status"] != DBNull.Value)
                            {
                                applier.Status = (bool)reader["Status"];
                            }

                            if (reader["CurrentJob"] != DBNull.Value)
                            {
                                applier.CurrentJob = (string)reader["CurrentJob"];
                            }

                            if (reader["Birthdate"] == DBNull.Value)
                            {
                                applier.Birthdate = new DateTime();
                            }
                            else
                            {
                                applier.Birthdate = (DateTime)reader["Birthdate"];
                            }

                            if (reader["JobCVId"] != DBNull.Value)
                            {
                                applier.JobCV = dbJobCV.Get((int)reader["JobCVId"]);
                            }


                        }
                    }

                    Applier applierToReturn = GetJobCategoryOnApplier(applier);

                    return applierToReturn;
                }
            }
        }

        /// <summary>
        /// Returns the Applier's JobCategory list. This metod should only be called inside the Get(id) method. Unless other ussage is needed.
        /// </summary>
        /// <param name="applier"></param>
        /// <returns></returns>
        public Applier GetJobCategoryOnApplier(Applier applier)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
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
            List<Applier> applierList = new List<Applier>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Applier";
                    SqlDataReader reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {
                        DBJobCV dBJobCV = new DBJobCV();
                        Applier applier = new Applier();
                        applier.Id = (int)reader["Id"];
                        applier.Email = (string)reader["Email"];
                        applier.Password = (string)reader["Password"];
                        if (reader["Phone"] == DBNull.Value)
                        {
                            applier.Phone = 0;
                        }
                        else
                        {
                            applier.Phone = (int)reader["Phone"];
                        }
                        if (reader["Address"] == DBNull.Value)
                        {
                            applier.Address = null;
                        }
                        else
                        {
                            applier.Address = (string)reader["Address"];
                        }

                        if (reader["Country"] == DBNull.Value)
                        {
                            applier.Country = null;
                        }
                        else
                        {
                            applier.Country = (string)reader["Country"];
                        }

                        if (reader["Description"] == DBNull.Value)
                        {
                            applier.Description = null;
                        }
                        else
                        {
                            applier.Description = (string)reader["Description"];
                        }
                        if (reader["BannerURL"] == DBNull.Value)
                        {
                            applier.BannerURL = null;
                        }
                        else
                        {
                            applier.BannerURL = (string)reader["BannerURL"];
                        }

                        if (reader["ImageURL"] != DBNull.Value)
                        {
                            applier.ImageURL = (string)reader["ImageURL"];
                        }



                        if (reader["MaxRadius"] != DBNull.Value)
                        {
                            applier.MaxRadius = (int)reader["MaxRadius"];
                        }


                        if (reader["HomePage"] != DBNull.Value)
                        {
                            applier.HomePage = (string)reader["HomePage"];
                        }


                        if (reader["FName"] != DBNull.Value)
                        {
                            applier.FName = (string)reader["FName"];
                        }


                        if (reader["LName"] != DBNull.Value)
                        {
                            applier.LName = (string)reader["LName"];
                        }


                        if (reader["Age"] != DBNull.Value)
                        {
                            applier.Age = (int)reader["Age"];
                        }


                        if (reader["Status"] != DBNull.Value)
                        {
                            applier.Status = (bool)reader["Status"];
                        }

                        if (reader["CurrentJob"] != DBNull.Value)
                        {
                            applier.CurrentJob = (string)reader["CurrentJob"];
                        }

                        if (reader["Birthdate"] == DBNull.Value)
                        {
                            applier.Birthdate = new DateTime();
                        }
                        else
                        {
                            applier.Birthdate = (DateTime)reader["Birthdate"];
                        }

                        if (reader["JobCVId"] != DBNull.Value)
                        {
                            applier.JobCV = dBJobCV.Get((int)reader["JobCVId"]);
                        }
                        applier = GetJobCategoryOnApplier(applier);
                        applierList.Add(applier);

                    }
                }
            }
            return applierList;
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
                    cmd.CommandText = "UPDATE Applier SET Email = @Email, Phone = @Phone, Address = @Address, Country = @Country, Description = @Description, BannerURL = @BannerURL," +
                        " ImageURL = @ImageURL,  MaxRadius = @MaxRadius, HomePage = @HomePage, FName = @FName, LName = @LName, Age = @Age, Status = @Status," +
                        " CurrentJob = @CurrentJob, Birthdate = @Birthdate, Password = @Password, JobCVId = @JobCVId " +
                        "WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("Email", obj.Email);
                    cmd.Parameters.AddWithValue("Phone", obj.Phone);
                    cmd.Parameters.AddWithValue("Address", obj.Address ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("Country", obj.Country ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("Description", obj.Description ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("BannerURL", obj.BannerURL ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("ImageURL", obj.ImageURL ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("MaxRadius", obj.MaxRadius);
                    cmd.Parameters.AddWithValue("HomePage", obj.HomePage ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("FName", obj.FName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("LName", obj.LName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("Age", obj.Age);
                    cmd.Parameters.AddWithValue("Status", obj.Status);
                    cmd.Parameters.AddWithValue("CurrentJob", obj.CurrentJob ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("Birthdate", obj.Birthdate);
                    cmd.Parameters.AddWithValue("Password", obj.Password);
                    cmd.Parameters.AddWithValue("JobCVId", obj.JobCV.Id);
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

                        DBJobCV dbJobCV = new DBJobCV();
                        applier.Id = (int)reader["Id"];
                        applier.Email = (string)reader["Email"];
                        applier.Password = (string)reader["Password"];


                        if (reader["JobCVId"] != DBNull.Value)
                        {
                            applier.JobCV = dbJobCV.Get((int)reader["JobCVId"]);
                        }
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


        /// <summary>
        /// Inserter a ApplierJobCategory into the database with the params JobCategory and ApplierId
        /// </summary>
        /// <param name="jobCategoryId"></param>
        /// <param name="applierId"></param>
        public void CreateApplierJobCategories(int jobCategoryId, int applierId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO ApplierJobCategory (JobCategoryId, ApplierId) VALUES (@JobCategoryId, @ApplierId)";
                    cmd.Parameters.AddWithValue("JobCategoryId", jobCategoryId);
                    cmd.Parameters.AddWithValue("ApplierId", applierId);

                    try
                    {
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
        /// Deletes the connection between Applier and JobCategory in the database by the ApplierId
        /// </summary>
        /// <param name="applierId"></param>
        public void DeleteApplierJobCategories(int applierId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM ApplierJobCategory WHERE ApplierId = @ApplierId";
                    cmd.Parameters.AddWithValue("ApplierId", applierId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Return the number of rows in the Applier table in the database
        /// </summary>
        /// <returns></returns>
        public int GetApplierTableSize()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {

                    cmd.CommandText = "SELECT COUNT(*) FROM Applier";
                    int count = (int)cmd.ExecuteScalar();
                    return count;
                }
            }
        }

        /// <summary>
        /// Updates the given Appleir objects password in the database
        /// </summary>
        /// <param name="applier"></param>
        public void UpdatePassword(Applier applier)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = "UPDATE Applier set Password = @Password WHERE Id = @Id";
                        cmd.Parameters.AddWithValue("Password", applier.Password);
                        cmd.Parameters.AddWithValue("Id", applier.Id);
                        cmd.ExecuteNonQuery();
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

