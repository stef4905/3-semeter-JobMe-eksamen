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
        SessionCtr SessionCtr = new SessionCtr();

        /// <summary>
        /// Creates a new booking in the database
        /// </summary>
        /// <param name="booking"></param>
        /// <returns>bool</returns>
        public bool Create(Booking booking)
        {
            try
            {
                DateTime LastEndTime = booking.StartDateAndTime;
                Booking bookingReturned = DbBooking.Create(booking);
                TimeSpan diff = booking.EndDateAndTime - bookingReturned.StartDateAndTime;
                TimeSpan availableTime = new TimeSpan(diff.Ticks / bookingReturned.InterviewAmount);


                //Calculating the endtime
                Double ii = Convert.ToDouble(bookingReturned.InterviewAmount);
                TimeSpan totalEndTime = new TimeSpan(0, Convert.ToInt16(availableTime.Minutes * ii), 0);
                DateTime endTime = bookingReturned.EndDateAndTime - totalEndTime + availableTime;

                for (int i = 1; i <= bookingReturned.InterviewAmount; i++)
                {

                    Session session = new Session();
                    session.StartTime = LastEndTime;
                    session.EndTime = endTime;
                    SessionCtr.Create(session, bookingReturned);


                    //Set the starttime on the original booking to ensure new time is sat for next session
                    //bookingReturned.StartDateAndTime = session.StartTime.Add(availableTime);
                    LastEndTime = endTime;
                    endTime = endTime + availableTime;
                    
                }
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Returns a booking from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Booking Get(int id)
        {
            Booking booking = DbBooking.Get(id);
            booking.sessionList = SessionCtr.GetAll(booking.Id);
            return booking;
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
        /// <summary>
        /// Gets a booking in the database by meetigId
        /// </summary>
        /// <param name="meetingid"></param>
        /// <returns></returns>
        public Booking GetBookingByMeetingId(int meetingid)
        {
            return DbBooking.GetBookingByMeetingId(meetingid);
        }

    }
}
