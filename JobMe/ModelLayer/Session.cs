using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    [DataContract]
    public class Session
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ApplierId { get; set; }
        [DataMember]
        public DateTime StartTime { get; set; }
        [DataMember]
        public DateTime EndTime { get; set; }
        [DataMember]
        public int BookingId { get; set; }
        [DataMember]
        public Applier Applier { get; set; }
    
        /// <summary>
        /// Constructor for Session
        /// </summary>
        /// <param name="applierId"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        public Session(int applierId, DateTime startTime, DateTime endTime)
        {
            this.ApplierId = applierId;
            this.StartTime = startTime;
            this.EndTime = endTime;
        }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public Session()
        { }

        

    }
}
