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
    public class DBSession
    {

        //Connection string for instanciating sql connection 
        private string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        /// <summary>
        /// Inserts the session object into the database
        /// </summary>
        /// <param name="session"></param>
        /// <param name="booking"></param>
        /// <returns></returns>
        public bool Create(Session session, Booking booking)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Session (StartTime, EndTime, BookingId) VALUES(@StartTime, @EndTime, @BookingId)";
                    cmd.Parameters.AddWithValue("StartTime", session.StartTime);
                    cmd.Parameters.AddWithValue("EndTime", session.EndTime);
                    cmd.Parameters.AddWithValue("BookingId", booking.Id);

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
        /// Deletes a single Session in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public bool Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE * FROM Session WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("Id", id);

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
        /// Returns a session from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Session Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Session WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("Id", id);

                    try
                    {
                        Session session = new Session();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            session.Id = (int)reader["Id"];
                            session.StartTime = (DateTime)reader["StartTime"];
                            session.EndTime = (DateTime)reader["EndTime"];
                            session.ApplierId = (int)reader["ApplierId"];
                            session.BookingId = (int)reader["BookingId"];
                        }
                        return session;
                    }
                    catch(SqlException e)
                    {
                        throw e;
                    }
                }
            }
        }

        /// <summary>
        /// Returns a list of sessions
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Session> GetAll(int id)
        {
            List<Session> sessionList = new List<Session>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Session WHERE BookingId = @BookingId";
                    cmd.Parameters.AddWithValue("BookingId", id);
                    try
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            Session session = new Session();
                            session.Id = (int)reader["Id"];
                            session.StartTime = (DateTime)reader["StartTime"];
                            session.EndTime = (DateTime)reader["EndTime"];
                            session.ApplierId = (int)reader["ApplierId"];
                            session.BookingId = (int)reader["BookingId"];
                            sessionList.Add(session);
                        }
                        return sessionList;
                    }
                    catch(SqlException e)
                    {
                        throw e;
                    }
                }
            }
        }

        /// <summary>
        /// Updates a session in the database
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public bool Update(Session session)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Session SET StartTime = @StartTime, EndTime = @EndTime, ApplierId = @ApplierId, BookingId = @BookingId WHERE Id = @Id";
                    try
                    {
                        cmd.Parameters.AddWithValue("StartTime", session.StartTime);
                        cmd.Parameters.AddWithValue("EndTime", session.EndTime);
                        cmd.Parameters.AddWithValue("ApplierId", session.ApplierId);
                        cmd.Parameters.AddWithValue("BookingId", session.BookingId);
                        cmd.Parameters.AddWithValue("Id", session.Id);
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
    }
}
