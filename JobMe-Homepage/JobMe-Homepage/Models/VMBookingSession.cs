using JobMe_Homepage.BookingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobMe_Homepage.Models
{
    public class VMBookingSession
    {
        public List<Booking> BookingList { get; set; }
        public List<Session> SessionList { get; set; }
        public JobPostServiceReference.JobPost JobPost { get; set; }

        public ApplierServiceReference.Applier Applier { get; set; }


    }
}