using JobMe_Homepage.ApplierServiceReference;
using JobMe_Homepage.CompanyServiceReference;
using JobMe_Homepage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobMe_Homepage.Controllers
{
    public class CompanyController : Controller
    {
        CompanyServiceClient client = new CompanyServiceClient();
        JobPostServiceReference.JobPostServiceClient jobClient = new JobPostServiceReference.JobPostServiceClient();
        JobApplicationServiceReference.JobApplicationServiceClient jobApplicationService = new JobApplicationServiceReference.JobApplicationServiceClient();
        ApplierServiceClient applierServiceClient = new ApplierServiceClient();
        // GET: Company
        public ActionResult Index()
        {
            Company company = new Company();
            // Mangler fagterm på as
            company = Session["company"] as Company;
            return View(company);
        }

        public ActionResult _CreateCompany()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult _CreateCompany(string Email, string Password, string PasswordControl)
        {
            Company company = new Company();
            company.Email = Email;
            company.Password = Password;

            if (Password == PasswordControl)
            {
                client.CreateCompany(company);
                // Creates session on creation of user
                Session["company"] = company;
                return RedirectToAction("Index");
            }
            else
            {
                //Giv fejl omkring at password ikke stemmer overens
            }

            return null;
        }

        public ActionResult CreateJobPost()
        {
            VMWorkHoursJobCategory VM = new VMWorkHoursJobCategory();
            VM.WorkHoursList = client.GetlAllWorkHours().ToList();
            VM.JobCategoryList = client.GetAllJobCategories().ToList();
            return View(VM);
        }

        [HttpPost]
        public ActionResult CreateJobPost(string Title, string Description, DateTime StartDate, DateTime EndDate, string JobTitle, int WorkHours, string Address, Company Company, int JobCategory)
        {
            WorkHours workHours = new WorkHours { Id = WorkHours };

            CompanyServiceReference.JobCategory jobCategory = new CompanyServiceReference.JobCategory { Id = JobCategory };
            


            Company company =  Session["company"] as Company;

            JobPost jobPost = new JobPost
            {
                Title = Title,
                Description = Description,
                StartDate = StartDate.Date,
                EndDate = EndDate.Date,
                JobTitle = JobTitle,
                workHours = workHours,
                Address = Address,
                company = company,
                jobCategory = jobCategory


            };
            try
            {
                client.CreateJobPost(jobPost);
                return RedirectToAction("Index");
            }




            catch (Exception)
            {

                throw;
            }

        }


        public ActionResult JobPost(int id)
        {
            JobPostServiceReference.JobPost jobPost = jobClient.GetJobPost(id);
            return View(jobPost);
        }

        [HttpPost]
        public ActionResult _Login(string email, string password)
        {
            Company company = client.Login(email, password);

            // Creates sessions for company login
            Session["company"] = company;

            return RedirectToAction("Index");
        }

        public ActionResult _CurrentCompany()
        {
            Company company = new Company();
            // Mangler fagterm på as
            company = Session["company"] as Company;
            return PartialView(company);
        }

        public ActionResult AppliersForJob(int id)
        {
            VMJobPostJobApplication vMJobPostJobApplication = new VMJobPostJobApplication
            {
               
                JobApplicationList = jobApplicationService.GetAllJobApplicationToAJobPost(id).ToList(),
              
                
                

            };




            return View(vMJobPostJobApplication);
        }

        public ActionResult _JobApplication()
        {
            JobApplicationServiceReference.JobApplication jobApplication = new JobApplicationServiceReference.JobApplication();
            return PartialView(jobApplication);
        }

        public ActionResult _JobCV()
        {
            JobCV jobCV = new JobCV();
            return PartialView(jobCV);
        }
        
    }
}