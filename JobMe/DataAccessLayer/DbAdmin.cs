﻿using System;
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

        public void Delete(int id)
        {
            throw new NotImplementedException();
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

        public bool Update(Admin obj)
        {
            throw new NotImplementedException();
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
