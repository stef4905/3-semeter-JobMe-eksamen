using JobMe_Homepage.ApplierServiceReference;
using JobMe_Homepage.JobApplicationServiceReference;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobMe_Homepage.Models
{
    public class VMApplierAndApplication
    {
        public ApplierServiceReference.Applier Applier { get; set; }

        public List<JobApplication> JobApplicationList { get; set; }
    }
}