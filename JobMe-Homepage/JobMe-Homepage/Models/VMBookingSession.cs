using JobMe_Homepage.BookingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobMe_Homepage.Models
{
    public class VMBookingSession
    {
        public List<Booking> bookingList { get; set; }
        public List<Session> sessionList { get; set; }


    }
}