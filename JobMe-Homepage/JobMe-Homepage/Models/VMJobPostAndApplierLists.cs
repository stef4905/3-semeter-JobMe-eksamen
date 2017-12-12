using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobMe_Homepage.JobPostServiceReference;


namespace JobMe_Homepage.Models
{
    public class VMJobPostAndApplierLists
    {
        public List<JobPost> jobPostList { get; set; }
        public List<ApplierServiceReference.Applier> applierList { get; set; }
        public int countOfJobPosts { get; set; }
        public int countOfAppliers { get; set; }
        public JobPost jobPost { get; set; }
    }
}