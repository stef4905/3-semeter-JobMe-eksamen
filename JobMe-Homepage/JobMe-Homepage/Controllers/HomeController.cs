using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobMe_Homepage.JobPostServiceReference;
using JobMe_Homepage.Models;

namespace JobMe_Homepage.Controllers
{
    public class HomeController : Controller
    {
        //Service referencer
        JobPostServiceClient jobPostClient = new JobPostServiceClient();
        ApplierServiceReference.ApplierServiceClient applierClient = new ApplierServiceReference.ApplierServiceClient();

        /// <summary>
        ///  Displays a index view
        /// </summary>
        /// <returns>Returns view Index with a ViewModel with a count of jobposts and appliers </returns>
        public ActionResult Index()
        {
            VMJobPostAndApplierLists vmJobPostAndApplierLists = new VMJobPostAndApplierLists
            {
                countOfJobPosts = jobPostClient.GetJobPostTableSize(),
                countOfAppliers = applierClient.GetApplierTableSize()
            };
            return View(vmJobPostAndApplierLists);
        }

        /// <summary>
        /// A logout method there abandon the current session
        /// </summary>
        /// <returns>Returns to index</returns>
        public ActionResult _Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}

