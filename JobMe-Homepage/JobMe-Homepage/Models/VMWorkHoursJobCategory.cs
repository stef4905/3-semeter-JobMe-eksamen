
using JobMe_Homepage.CompanyServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobMe_Homepage.Models
{
    public class VMWorkHoursJobCategory
    {
        public List<WorkHours> WorkHoursList { get; set; }
        public List<JobCategory> JobCategoryList { get; set; }

    }
}