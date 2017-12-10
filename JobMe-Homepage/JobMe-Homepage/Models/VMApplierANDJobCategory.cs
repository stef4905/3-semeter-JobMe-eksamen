using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobMe_Homepage.Models
{
    public class VMApplierANDJobCategory
    {
        public ApplierServiceReference.Applier Applier { get; set; }
        public List<CategoryObject> JobCategoryList { get; set; }
    }

    //Object for the makeing the Applier.Jobcategory and Jobcategory list to compare if the applier has or not have the Category
    public class CategoryObject
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public bool IsChecked { get; set; }
    }
}