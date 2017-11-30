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

    class DBBooking
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;


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
                    catch (SqlException)
                    {
                        return false;
                    }
                }
            }
        }
    }
}
