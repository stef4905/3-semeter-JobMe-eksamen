using JobMe_Homepage.ApplierServiceReference;
using JobMe_Homepage.JobApplicationServiceReference;
using JobMe_Homepage.JobPostServiceReference;
using JobMe_Homepage.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobMe_Homepage.Controllers
{
    public class ApplierController : Controller
    {

        ApplierServiceClient client = new ApplierServiceClient();
        JobPostServiceClient jobClient = new JobPostServiceClient();

        JobApplicationServiceClient jobApplicationClient = new JobApplicationServiceClient();


        // GET: Applier
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult _CreateApplier()
        {
            return PartialView();

        }


        public ActionResult UpdateUserProfile()
        {
            ApplierServiceReference.Applier applier = Session["applier"] as ApplierServiceReference.Applier;

            return View(applier);
        }

        [HttpPost]
        public ActionResult _CreateApplier(string Email, string Password, string PasswordControl)
        {
            ApplierServiceReference.Applier applier = new ApplierServiceReference.Applier();
            applier.Password = Password;
            applier.Email = Email;

            //få de 2 passwords --- SKAL SIKRES!!!!
            if (Password == PasswordControl)
            {
                client.Create(applier);
                Session["applier"] = applier;
                return RedirectToAction("Index");
            }
            else
            {
                //Giv fejl omkring at password ikke stemmer overens!
            }

            return null;
        }

        public ActionResult JobCV()
        {
            return View();
            //Get the jobcv from the profile currently logged in
            //Return view with the JobCV object
            //If button "Gem oplysninger" is pressed get all information from the site
            //Assign the infomation to the JobCV object for the profile
            //Update in database

            //If button "Annuler/Gå tilbage" is pressed, dispose all changes
            //Return user to profile site
        }


        public ActionResult FindJobPosts()
        {
            VMJobPostWorkHoursJobCategory VM = new VMJobPostWorkHoursJobCategory();

            VM.JobPostList = jobClient.GetAllJobPost().ToList();
            VM.JobCategoryList = jobClient.GetAllJobCategories().ToList();
            VM.WorkHoursList = jobClient.GetAllWorkHours().ToList();

            return View(VM);
        }

        [HttpPost]
        public ActionResult FindJobPosts(string search, int km, int category, int workHours)
        {
            VMJobPostWorkHoursJobCategory VM = new VMJobPostWorkHoursJobCategory();
            VM.JobPostList = jobClient.GetAllJobPost().ToList();
            List<JobPostServiceReference.JobPost> JobPostsList = new List<JobPostServiceReference.JobPost>();

            foreach (var jobPosts in VM.JobPostList.Where(f => f.Title.ToLower().Contains(search.ToLower()) ||
            f.company.CompanyName.ToLower().Contains(search.ToLower())))
            {

                if (workHours == 0 && category == 0 && km == 0)
                {
                    JobPostsList.Add(jobPosts);

                }
                if (km != 0 || workHours != 0 || category != 0)
                {
                    if (jobPosts.workHours.Id == workHours || jobPosts.jobCategory.Id == category)
                    {
                        JobPostsList.Add(jobPosts);
                    }
                }
            }
            VM.JobPostList = JobPostsList.ToList();
            VM.JobCategoryList = jobClient.GetAllJobCategories().ToList();
            VM.WorkHoursList = jobClient.GetAllWorkHours().ToList();
            ViewBag.SearchField = "Søgeord:" + search;
            return View(VM);
        }




        #region JobApplication
        public ActionResult JobApplication()
        {
            //Hovedside til jobapplikation og cv of the applier
            ApplierServiceReference.Applier applier = Session["applier"] as ApplierServiceReference.Applier;
            //JobCV jobCV = jobCVClient.Get(applier.Id);


            VMApplierAndApplication vmApplierAndApplication = new VMApplierAndApplication
            {
                Applier = applier,
                JobApplicationList = jobApplicationClient.GetAllByApplierId(applier.Id).ToList()
               
            };




            return View(vmApplierAndApplication);
        }

        [HttpPost]
        public ActionResult _UpdateUserProfile(int applierId, string emailInput,string bannerInput, string imageInput, string fNameInput, string lNameInput, DateTime birthdate, int PhoneInput, string addressInput,
                                                string countryInput, string currentJobInput, string homepageInput, string descriptionInput, int jobCvId)
        {
            ApplierServiceReference.Applier applier = new ApplierServiceReference.Applier
            {
                Id = applierId,
                Email = emailInput,
                BannerURL = bannerInput,
                ImageURL = imageInput,
                //MISSING jobCaregory and status is not working
                FName = fNameInput,
                LName = lNameInput,
                Birthdate = birthdate,
                Phone = PhoneInput,
                Address = addressInput,
                Country = countryInput,
                CurrentJob = currentJobInput,
                HomePage = homepageInput,
                Status = true,
                Description = descriptionInput,
                JobCV = new ApplierServiceReference.JobCV
                {
                    Id = jobCvId
                }
            };

            client.Update(applier);   
            TempData["Success"] = "Successfuld updateret!";
            Session["applier"] = client.GetApplier(applierId);
            return RedirectToAction("UpdateUserProfile");
        }

        [HttpPost]
        public ActionResult CreateApplication(string title, string description, int applierId)
        {

            JobApplication jobApplication = new JobApplication
            {
                Title = title,
                Description = description,
                Applier = new JobApplicationServiceReference.Applier
                {
                    Id = applierId
                }
            };


            jobApplicationClient.Create(jobApplication);
            TempData["Success"] = "Successfuld oprettet!";
            return RedirectToAction("JobApplication");
        }

        [HttpPost]
        public ActionResult UpdateApplication(string title, string description, int id)
        {
            JobApplication jobApplication = new JobApplication
            {
                Title = title,
                Description = description,
                Id = id
            };
          

            jobApplicationClient.Update(jobApplication);
            TempData["Success"] = "Successfuld opdateret!";
            return RedirectToAction("JobApplication");
        }
        
        public ActionResult DeleteApplication(int id)
        {
            jobApplicationClient.Delete(id);
            TempData["Success"] = "Successfuld slettet!";
            return RedirectToAction("JobApplication");
        }
        public ActionResult _JobApplication()
        {
            //Job applikation siden kun ikke lavet endnu i WCF
            return PartialView();
        }

        public ActionResult _JobCV()
        {
            ApplierServiceReference.Applier applier = new ApplierServiceReference.Applier();

            //Mangler fagterm.
            applier = Session["applier"] as ApplierServiceReference.Applier;
            return PartialView(applier);
        
        }
        #endregion





        public ActionResult ApplierProfile(int id)
        {
            ApplierServiceReference.Applier applier = client.GetApplier(id);
            return View(applier);
        }

        public ActionResult _Login()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult _Login(string email, string password)
        {
            //sende password ned med Hashing!!!
            ApplierServiceReference.Applier applier = client.Login(email, password);
            Session["applier"] = applier;
            return RedirectToAction("Index");
        }

        public ActionResult _CurrentUser()
        {
            ApplierServiceReference.Applier applier = new ApplierServiceReference.Applier();

            //Mangler fagterm.
            applier = Session["applier"] as ApplierServiceReference.Applier;
            return PartialView(applier);
        }

        public ActionResult JobPost(int id)
        {
            JobPostServiceReference.JobPost jobPost = jobClient.GetJobPost(id);
            return View(jobPost);
        }


        public ActionResult SendApplication(int id)
        {
            ApplierServiceReference.Applier applier = new ApplierServiceReference.Applier();

            //Mangler fagterm.
            applier = Session["applier"] as ApplierServiceReference.Applier;


            VMJobPostANDJobApplication vMJobPostANDJobApplication = new VMJobPostANDJobApplication
            {
                JobPost = jobClient.GetJobPost(id),
                JobApplicationList = jobApplicationClient.GetAllByApplierId(applier.Id).ToList(),
                applier = applier
                
            };

            return View(vMJobPostANDJobApplication);
        }

        [HttpPost]
        public ActionResult SendApplication(int jobApplicationId, int jobPostId)
        {
            JobApplication jobApplication = new JobApplication
            {
                Id = jobApplicationId

            };
            JobApplicationServiceReference.JobPost jobPost = new JobApplicationServiceReference.JobPost
            {
                Id = jobPostId
            };


            jobApplicationClient.SendApplication(jobApplication, jobPost);
            return RedirectToAction("Index");
        }
    }
}
