using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    [DataContract]
    public class Booking
    {
        [DataMember]
        public int MeetingId { get; set; }
        [DataMember]
        public DateTime StartDateAndTime { get; set; }
        [DataMember]
        public DateTime EndDateAndTime { get; set; }
        [DataMember]
        public int InterviewAmount { get; set; }
        [DataMember]
        public Session session { get; set; }
        [DataMember]
        public List<Session> sessionList = new List<Session>();


        /// <summary>
        /// Constructor for Booking
        /// </summary>
        /// <param name="meetingId"></param>
        /// <param name="startDateAndTime"></param>
        /// <param name="endDateAndTime"></param>
        /// <param name="interviewAmount"></param>
        public Booking(int meetingId, DateTime startDateAndTime, DateTime endDateAndTime, int interviewAmount)
        {
            this.MeetingId = meetingId;
            this.StartDateAndTime = startDateAndTime;
            this.EndDateAndTime = endDateAndTime;
            this.InterviewAmount = interviewAmount;
        }
    }
}
