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
        public DateTime StartDateAndTime { get; set; }
        public DateTime EndDateAndTime { get; set; }

    }
}
