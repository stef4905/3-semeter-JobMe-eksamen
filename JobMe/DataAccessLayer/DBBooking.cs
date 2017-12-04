using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using System.Data.SqlClient;

namespace DataAccessLayer
{

    public class DBBooking
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        /// <summary>
        /// Inserts the booking object into the database
        /// </summary>
        /// <param name="booking"></param>
        /// <returns></returns>
        public bool Create(Booking booking)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = "INSERT INTO Booking(StartDateAndTime, EndDateAndTime, InterviewAmount, MeetingId) VALUES (@StartDateAndTime, @EndDateAndTime, @InterviewAmount, @MeetingId)";
                        cmd.Parameters.AddWithValue("StartDateAndTime", booking.StartDateAndTime);
                        cmd.Parameters.AddWithValue("EndDateAndTime", booking.EndDateAndTime);
                        cmd.Parameters.AddWithValue("InterviewAmount", booking.InterviewAmount);
                        cmd.Parameters.AddWithValue("MeetingId", booking.MeetingId);
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
        /// Delete a Booking !NOT DONE!
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a booking from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Booking Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Booking WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("Id", id);
                    
                    try
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        Booking booking = new Booking();
                        if (reader.Read())
                        {
                            
                            booking.Id = (int)reader["Id"];
                            booking.StartDateAndTime = (DateTime)reader["StartDateAndTime"];
                            booking.EndDateAndTime = (DateTime)reader["EndDateAndTime"];
                            booking.InterviewAmount = (int)reader["InterviewAmount"];
                            booking.MeetingId = (int)reader["MeetingId"];
                        }
                        return booking;
                    }
                    catch(SqlException e)
                    {
                        throw e;
                    }
                }
            }
        }

        /// <summary>
        /// Returns a list of bookings
        /// </summary>
        /// <returns></returns>
        public List<Booking> GetAll(int id)
        {
            List<Booking> bookingList = new List<Booking>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Booking WHERE MeetingId = @MeetingId";
                    cmd.Parameters.AddWithValue("MeetingId", id);
                    try
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            Booking booking = new Booking();
                            booking.Id = (int)reader["Id"];
                            booking.StartDateAndTime = (DateTime)reader["StartDateAndTime"];
                            booking.EndDateAndTime = (DateTime)reader["EndDateAndTime"];
                            booking.InterviewAmount = (int)reader["InterviewAmount"];
                            booking.MeetingId = (int)reader["MeetingId"];
                            bookingList.Add(booking);

                        }
                    }
                    catch(SqlException e)
                    {
                        throw e;
                    }
                }
            }
            return bookingList;
        }

        /// <summary>
        /// Updates a booking in the database
        /// </summary>
        /// <param name="booking"></param>
        /// <returns></returns>
        public bool Update(Booking booking)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Booking SET StartDateAndTime = @StartDateAndTime, EndDateAndTime = @EndDateAndTime, MeetingId = @MeetingId WHERE Id = @Id";
                    try
                    {
                        cmd.Parameters.AddWithValue("StartDateAndTime", booking.StartDateAndTime);
                        cmd.Parameters.AddWithValue("EndDateAndTime", booking.EndDateAndTime);
                        cmd.Parameters.AddWithValue("MeetingId", booking.MeetingId);
                        cmd.Parameters.AddWithValue("Id", booking.Id);
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
        /// Returns a booking from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Booking GetBookingByMeetingId(int meetingid)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Booking WHERE MeetingId = @MeetingId";
                    cmd.Parameters.AddWithValue("MeetingId", meetingid);

                    try
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        Booking booking = new Booking();
                        if (reader.Read())
                        {

                            booking.Id = (int)reader["Id"];
                            booking.StartDateAndTime = (DateTime)reader["StartDateAndTime"];
                            booking.EndDateAndTime = (DateTime)reader["EndDateAndTime"];
                            booking.InterviewAmount = (int)reader["InterviewAmount"];
                            booking.MeetingId = (int)reader["MeetingId"];
                        }
                        return booking;
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
