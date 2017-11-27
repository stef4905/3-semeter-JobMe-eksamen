
using JobMe_Homepage.JobPostServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobMe_Homepage.Models
{
    public class VMCompanyANDJobPost
    {
        public CompanyServiceReference.Company Company { get; set; }
        public List<JobPost> JobPost { get; set; }
    }
}