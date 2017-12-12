using JobMe_Homepage.JobPostServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace JobMe_Homepage.Models
{
    public class VMJobPostLists
    {
        public List<JobPost> jobPostList { get; set; }
        public List<JobPost> jobPostListMeeting { get; set; }
        public int countOfJobPosts { get; set; }
        public JobPost jobPost { get; set; }
    }
}