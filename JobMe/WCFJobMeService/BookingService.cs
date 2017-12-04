using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ModelLayer;
using BusinessLogicLayer;

namespace WCFJobMeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BookingService" in both code and config file together.
    public class BookingService : IBookingService
    {
        //Instance varibales
        BookingCtr BookingCtr = new BookingCtr();
        MeetingCtr MeetingCtr = new MeetingCtr();
        SessionCtr SessionCtr = new SessionCtr();

        #region Booking Service

        public bool CreateBooking(Booking booking)
        {
            return BookingCtr.Create(booking);
        }

        public List<Booking> GetAllBooking(int meetingId)
        {
            return BookingCtr.GetAll(meetingId);
        }

        public Booking GetBooking(int id)
        {
            return BookingCtr.Get(id);
        }

        public bool UpdateBooking(Booking booking)
        {
            return BookingCtr.Update(booking);
        }

        #endregion

        #region Meeting Service

        public Meeting CreateMeeting(Meeting meeting)
        {
            return MeetingCtr.Create(meeting);
        }

        public bool DeleteMeeting(Meeting meeting)
        {
            return MeetingCtr.Delete(meeting);
        }

        public Meeting GetMeeting(int id)
        {
            return MeetingCtr.Get(id);
        }

        public bool UpdateMeeting(Meeting meeting)
        {
            return MeetingCtr.Update(meeting);
        }

        #endregion

        #region Session Service

        public bool CreateSession(Session session, Booking booking)
        {
            return SessionCtr.Create(session, booking);
        }

        public bool DeleteSession(Session session)
        {
            return SessionCtr.Delete(session);
        }

        public List<Session> GetAllSession(int id)
        {
            return SessionCtr.GetAll(id);
        }

        public Session GetSession(int id)
        {
            return SessionCtr.Get(id);
        }

        public bool UpdateSession(Session session)
        {
            return SessionCtr.Update(session);
        }

        #endregion
    }
}
