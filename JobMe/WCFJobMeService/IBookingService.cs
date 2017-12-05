using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ModelLayer;

namespace WCFJobMeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBookingService" in both code and config file together.
    [ServiceContract]
    public interface IBookingService
    {
        #region Booking service
        /// <summary>
        /// Creates a new Booking by the given Booking object
        /// </summary>
        /// <param name="booking"></param>
        /// <returns>bool to see if the create method was a success or not</returns>
        [OperationContract]
        bool CreateBooking(Booking booking);

        /// <summary>
        /// Returns a single object of Booking by the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Booking</returns>
        [OperationContract]
        Booking GetBooking(int id);

        /// <summary>
        /// Retuns a list of all Bookings objects with the given MeetingId
        /// </summary>
        /// <param name="MeetingId"></param>
        /// <returns>List of Booking</returns>
        [OperationContract]
        List<Booking> GetAllBooking(int meetingId);

        /// <summary>
        /// Updates the given Booking object
        /// </summary>
        /// <param name="booking"></param>
        /// <returns>bool to see if the create method was a success or not</returns>
        [OperationContract]
        bool UpdateBooking(Booking booking);

        /// <summary>
        /// Deletes a single booking object in the database
        /// </summary>
        /// <param name="bookingId"></param>
        /// <returns></returns>
        [OperationContract]
        bool DeleteBooking(int bookingId);

        #endregion

        #region Meeting Service
        /// <summary>
        /// Creates a new meeting in the database
        /// </summary>
        /// <param name="meeting"></param>
        /// <returns>bool</returns>
        [OperationContract]
        Meeting CreateMeeting(Meeting meeting);

        /// <summary>
        /// Returns a single Meeting object with the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Metting</returns>
        [OperationContract]
        Meeting GetMeeting(int id);

        /// <summary>
        /// Deletes a single Meeting object in the database by the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        [OperationContract]
        bool DeleteMeeting(Meeting meeting);

        /// <summary>
        /// Updates the given Meeting in the database
        /// </summary>
        /// <param name="meeting"></param>
        /// <returns>bool</returns> 
        [OperationContract]
        bool UpdateMeeting(Meeting meeting);
        #endregion

        #region Session Service
        /// <summary>
        /// Creates a new session in the database
        /// </summary>
        /// <param name="session"></param>
        /// <param name="booking"></param>
        /// <returns>bool</returns>
        [OperationContract]
        bool CreateSession(Session session, Booking booking);

        /// <summary>
        /// Returns a session from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        Session GetSession(int id);

        /// <summary>
        /// Returns a list of sessions
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        List<Session> GetAllSession(int id);

        /// <summary>
        /// Deletes a single Session in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        [OperationContract]
        bool DeleteSession(Session session);

        /// <summary>
        /// Updates a session in the database
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
       [OperationContract]
        bool UpdateSession(Session session);
        #endregion


    }
}
