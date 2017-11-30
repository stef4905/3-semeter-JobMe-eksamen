using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    [DataContract]
    class Meeting
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int JobPostId { get; set; }
        [DataMember]
        public List<Booking> booking = new List<Booking>();
    }
}
