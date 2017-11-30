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

        /// <summary>
        /// Creates a new meeting in the database
        /// </summary>
        /// <param name="meeting"></param>
        /// <returns>bool</returns>
        public Meeting Create(Meeting meeting)
        {
            return DbMeeting.Create(meeting);
        }
    }
}
