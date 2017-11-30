using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class BookingCtr
    {
        DBBooking DbBooking = new DBBooking();

        /// <summary>
        /// Creates a new booking in the database
        /// </summary>
        /// <param name="booking"></param>
        /// <returns>bool</returns>
        public bool Create(Booking booking)
        {
            return DbBooking.Create(booking);
        }

        /// <summary>
        /// Returns a booking from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Booking get(int id)
        {
            return DbBooking.get(id);
        }

        /// <summary>
        /// Returns a list of bookings
        /// </summary>
        /// <returns></returns>
        public List<Booking> GetAll(int id)
        {
            return DbBooking.GetAll(id);
        }

        /// <summary>
        /// Updates a booking in the database
        /// </summary>
        /// <param name="booking"></param>
        /// <returns></returns>
        public bool Update(Booking booking)
        {
            return DbBooking.Update(booking);
        }
    }
}
