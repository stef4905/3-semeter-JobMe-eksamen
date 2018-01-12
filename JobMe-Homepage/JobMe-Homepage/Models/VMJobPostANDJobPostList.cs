using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobMe_Homepage.JobPostServiceReference;

namespace JobMe_Homepage.Models
{
    public class VMJobPostANDJobPostList
    {
        public JobPost jobPost { get; set; }
        public List<JobPost> jobPostList = new List<JobPost>();
    }
}