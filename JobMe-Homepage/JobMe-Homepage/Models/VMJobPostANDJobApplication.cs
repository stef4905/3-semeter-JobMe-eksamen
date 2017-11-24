using JobMe_Homepage.ApplierServiceReference;
using JobMe_Homepage.JobApplicationServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobMe_Homepage.Models
{
    public class VMJobPostANDJobApplication
    {
        public JobPostServiceReference.JobPost JobPost { get; set; }
        public List<JobApplication> JobApplicationList { get; set; }
        public ApplierServiceReference.Applier applier { get; set; }
    }
}