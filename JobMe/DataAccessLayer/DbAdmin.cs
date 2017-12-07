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
    public class DbAdmin : IDataAccess<Admin>
    {

        private string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        /// <summary>
        /// Create an admin login
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Create(Admin obj)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Admin (Username, Password, FName, LName, Email) VALUES (@Username, @Password, @FName, @LName, @Email)";
                    cmd.Parameters.AddWithValue("Username", obj.Username);
                    cmd.Parameters.AddWithValue("Password", obj.Password);
                    cmd.Parameters.AddWithValue("FName", obj.FName);
                    cmd.Parameters.AddWithValue("LName", obj.LName);
                    cmd.Parameters.AddWithValue("Email", obj.Email);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch(SqlException e)
                    {
                        throw e;
                    }
                }
            }
        }

        /// <summary>
        /// Is a method that deletes a Admin from the database by the id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Admin WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("Id", id);
                    cmd.ExecuteNonQuery();

                }
            }
        }

        /// <summary>
        /// Is the method to Get the admin from the Database.
        /// This includes all variables on admin.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Admin Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                Admin admin = new Admin();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Admin WHERE Id = @id";
                    cmd.Parameters.AddWithValue("id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            admin.Id = (int)reader["Id"];
                            admin.Username = (string)reader["Username"];
                            admin.Password = (string)reader["Password"];
                        }
                    }
                    return admin;
                }
            }
        }

        public List<Admin> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update a admin in DB
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Update(Admin obj)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Admin SET Username = @Username, Password = @Password, FName = @FName, LName = @LName, Email = @Email WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("Username", obj.Username);
                    cmd.Parameters.AddWithValue("Password", obj.Password);
                    cmd.Parameters.AddWithValue("FName", obj.FName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("LName", obj.LName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("Email", obj.Email ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("Id", obj.Id);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch(SqlException e)
                    {
                        throw e;
                    }
                    
                }
            }
        }


        /// <summary>
        /// Finds an admin in the database with the given param, and return the admin
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Admin Login(string username, string password)
        {

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                Admin admin = new Admin();
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Admin WHERE Username = @username AND Password = @password";
                    cmd.Parameters.AddWithValue("username", username);
                    cmd.Parameters.AddWithValue("password", password);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        admin.Id = (int)reader["Id"];
                        admin.Username = (string)reader["username"];
                        admin.Password = (string)reader["password"];
                        reader.Close();
                        if(admin.Username == username && admin.Password == password)
                        {
                            Admin login = Get(admin.Id);
                            return login;
                        }
                        
                    }
                    return null;
                }
            }

        }
    }
}
