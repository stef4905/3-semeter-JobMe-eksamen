using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class MeetingCtr
    {
        DBMeeting DbMeeting = new DBMeeting();
        BookingCtr bookingCtr = new BookingCtr();

        /// <summary>
        /// Creates a new meeting in the database
        /// </summary>
        /// <param name="meeting"></param>
        /// <returns>bool</returns>
        public Meeting Create(Meeting meeting)
        {
            return DbMeeting.Create(meeting);
        }

        /// <summary>
        /// Returns a single Meeting object with the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Metting</returns>
        public Meeting Get(int id)
        {
            Meeting meeting = DbMeeting.Get(id);
            meeting.booking = bookingCtr.GetAll(meeting.Id);
            return meeting;
        }

        /// <summary>
        /// Deletes a single Meeting object in the database by the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public bool Delete(Meeting meeting)
        {
            return DbMeeting.Delete(meeting);
        }

        /// <summary>
        /// Updates the given Meeting in the database
        /// </summary>
        /// <param name="meeting"></param>
        /// <returns>bool</returns> 
        public bool Update(Meeting meeting)
        {
            return DbMeeting.Update(meeting);
        }
    }
}
