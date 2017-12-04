using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    [DataContract]
    public class Meeting
    {
        [DataMember]
        public int Id { get; set; }
      
        [DataMember]
        public List<Booking> booking = new List<Booking>();
        [DataMember]
        public int CompanyId { get; set; }

        /// <summary>
        /// Constructor for Meeting
        /// </summary>
        /// <param name="jobPostId"></param>
        /// <param name="companyId"></param>
        public Meeting(int companyId)
        {
           
            this.CompanyId = companyId;
        }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public Meeting()
        {

        }
    }
}
