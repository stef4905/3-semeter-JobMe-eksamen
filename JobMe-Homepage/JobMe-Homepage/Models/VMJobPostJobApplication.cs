using JobMe_Homepage.JobApplicationServiceReference;
using JobMe_Homepage.JobPostServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobMe_Homepage.Models
{
    public class VMJobPostJobApplication
    {
        
        public List<JobApplication> JobApplicationList { get; set; }
        public CompanyServiceReference.JobPost jobPost { get; set; }

    }
}