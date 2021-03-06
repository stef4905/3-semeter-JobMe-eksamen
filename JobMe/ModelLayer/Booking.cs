﻿using System;
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
        public int Id { get; set; }
        [DataMember]
        public DateTime StartDateAndTime { get; set; }
        [DataMember]
        public DateTime EndDateAndTime { get; set; }
        [DataMember]
        public int InterviewAmount { get; set; }
        [DataMember]
        public List<Session> sessionList = new List<Session>();
        [DataMember]
        public int MeetingId { get; set; }


        /// <summary>
        /// Constructor for Booking
        /// </summary>
        /// <param name="meetingId"></param>
        /// <param name="startDateAndTime"></param>
        /// <param name="endDateAndTime"></param>
        /// <param name="interviewAmount"></param>
        public Booking(DateTime startDateAndTime, DateTime endDateAndTime, int interviewAmount, int meetingId)
        {
            this.StartDateAndTime = startDateAndTime;
            this.EndDateAndTime = endDateAndTime;
            this.InterviewAmount = interviewAmount;
            this.MeetingId = meetingId;
        }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public Booking()
        { }
    }
}
