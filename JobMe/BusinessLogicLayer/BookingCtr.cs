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
    }
}
