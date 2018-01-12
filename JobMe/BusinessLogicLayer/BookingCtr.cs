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
                //LastEndTime is first set to the bookings start date and time.
                //This will later be changed to the last inserted sessions end time.
                DateTime LastEndTime = booking.StartDateAndTime;
                //Returnes the booking that was just inserted into the database (Only returns if the Create method works)
                Booking bookingReturned = DbBooking.Create(booking);
                //Finding the time difference between the start en endtime.
                //This is used to calculate the total time available to use for interviews.
                TimeSpan diff = booking.EndDateAndTime - bookingReturned.StartDateAndTime;
                //availableTime is the time each applier (interview) has available to use.
                //This is calculated by deviding the time difference from before with the total amount of interviews needed.
                TimeSpan availableTime = new TimeSpan(diff.Ticks / bookingReturned.InterviewAmount);


                //Calculating the first endtime by using the number of Appliers (interviews) where the total time is calculated.
                //The endTime is then calculated by getting the original EndDateTime on the booking, where it is subtracted bu the totalEndTime, adding the availableTime.
                Double ii = Convert.ToDouble(bookingReturned.InterviewAmount);
                TimeSpan totalEndTime = new TimeSpan(0, Convert.ToInt16(availableTime.Minutes * ii), 0);
                DateTime endTime = bookingReturned.EndDateAndTime - totalEndTime + availableTime;

                //For each applier (interview) we now create a new session and insert it into the database.
                //We also add the lastEndTime and EndTime here to specify the startTime and Endtime for the specific session.
                for (int i = 1; i <= bookingReturned.InterviewAmount; i++)
                {

                    Session session = new Session();
                    session.StartTime = LastEndTime;
                    session.EndTime = endTime;
                    SessionCtr.Create(session, bookingReturned);


                    //Changine the LastEndTime to the current endtime. This will allow the next session to have a startTime, starting at de same time as the previous ended.
                    LastEndTime = endTime;
                    //The new endTime will be the current endTime, adding the time available for each applier (interview).
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
        /// Deletes a single booking object in the database
        /// </summary>
        /// <param name="bookingId"></param>
        /// <returns>bool</returns>
        public bool Delete(int bookingId)
        {
            Booking booking = DbBooking.Get(bookingId);
            //Delete all session on the booking
            foreach (var session in booking.sessionList)
            {
                bool deleted = SessionCtr.Delete(session);
            }
            //Delete the booking
            return DbBooking.Delete(bookingId);
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
            List<Booking> bookingList = DbBooking.GetAll(id);
            foreach (var booking in bookingList)
            {
                booking.sessionList =  SessionCtr.GetAll(booking.Id);
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
