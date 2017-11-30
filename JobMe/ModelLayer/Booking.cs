using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    [DataContract]
    class Booking
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
    }
}
