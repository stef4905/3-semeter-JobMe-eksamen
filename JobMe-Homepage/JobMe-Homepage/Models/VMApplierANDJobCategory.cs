using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobMe_Homepage.Models
{
    public class VMApplierANDJobCategory
    {
        public ApplierServiceReference.Applier Applier { get; set; }
        public List<JobPostServiceReference.JobCategory> JobCategoryList { get; set; }
    }
}