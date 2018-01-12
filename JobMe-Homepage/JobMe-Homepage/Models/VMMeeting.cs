
using JobMe_Homepage.BookingService;
using JobMe_Homepage.JobApplicationServiceReference;
using JobMe_Homepage.ApplierServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobMe_Homepage.Models
{
    public class VMMeeting
    {
        public BookingService.Meeting Meeting { get; set; }
        public JobPost JobPost { get; set; }

        public List<BookingService.Booking> BookingList { get; set; }


        public VMMeeting()
        {

        }

    }
}