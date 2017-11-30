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
    public class DBSession
    {

        //Connection string for instanciating sql connection 
        private string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;


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
    }
}
