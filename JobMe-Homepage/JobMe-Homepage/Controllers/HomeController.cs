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
        JobPostServiceClient jobPostClient = new JobPostServiceClient();
        ApplierServiceReference.ApplierServiceClient applierClient = new ApplierServiceReference.ApplierServiceClient();
        public ActionResult Index()
        {

            VMJobPostAndApplierLists vmJobPostAndApplierLists = new VMJobPostAndApplierLists
            {
                jobPostList = jobPostClient.GetAllJobPost(),
                applierList = applierClient.GetAllAppliers()
            };

            return View(vmJobPostAndApplierLists);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult _Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}

