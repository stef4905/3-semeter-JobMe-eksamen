using JobMe_Homepage.ApplierServiceReference;
using JobMe_Homepage.JobApplicationServiceReference;
using JobMe_Homepage.JobPostServiceReference;
using JobMe_Homepage.BookingService;
using JobMe_Homepage.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobMe_Homepage.JobCVServiceReference;
namespace JobMe_Homepage.Controllers
{
    public class ApplierController : Controller
    {

        ApplierServiceClient client = new ApplierServiceClient();
        JobPostServiceClient jobClient = new JobPostServiceClient();

        JobApplicationServiceClient jobApplicationClient = new JobApplicationServiceClient();
        BookingServiceClient bookingServiceClient = new BookingServiceClient();
        JobCVServiceReference.JobCVServiceClient jobCVServiceClient = new JobCVServiceReference.JobCVServiceClient();

        // GET: Applier
        public ActionResult Index()
        {
            ApplierServiceReference.Applier applier = Session["applier"] as ApplierServiceReference.Applier;
            List<JobPostServiceReference.JobPost> jobPostList = new List<JobPostServiceReference.JobPost>();
            List<JobApplication> jobApplicationList = jobApplicationClient.GetAllByApplierId(applier.Id).ToList();

            foreach (var jobapplication in jobApplicationList)
            {
                List<JobPostServiceReference.JobPost> jobPostList2 = jobClient.GetAllJobPostToAJobApplication(jobapplication.Id).ToList();
                jobPostList.AddRange(jobPostList2);
            }
            VMJobPostLists vmJobPostList = new VMJobPostLists
            {
                jobPostListMeeting = jobPostList,
                jobPostList = jobClient.GetAllJobPost(),
                countOfJobPosts = jobClient.GetJobPostTableSize()

            };
            return View(vmJobPostList);
        }

        public ActionResult _CreateApplier()
        {
            return PartialView();

        }


        public ActionResult UpdateUserProfile()
        {

            List<JobPostServiceReference.JobCategory> jobCategoryList = jobClient.GetAllJobCategories().ToList();
            ApplierServiceReference.Applier applier = Session["applier"] as ApplierServiceReference.Applier;

            VMApplierANDJobCategory vmApplierANDJobCategory = new VMApplierANDJobCategory();



            List<CategoryObject> CategoryList = new List<CategoryObject>();
            if (applier.JobCategoryList == null)
            {
                applier.JobCategoryList = new List<ApplierServiceReference.JobCategory>();
            }

            foreach (var item in jobCategoryList)
            {



                var test = applier.JobCategoryList.Where(m => m.Id == item.Id).FirstOrDefault();

                if (test != null)
                {
                    CategoryObject categoryObject = new CategoryObject
                    {
                        Id = item.Id,



                        IsChecked = true,

                        Name = item.Title

                    };

                    CategoryList.Add(categoryObject);

                }

                else
                {
                    CategoryObject categoryObject = new CategoryObject
                    {
                        Id = item.Id,



                        IsChecked = false,

                        Name = item.Title

                    };

                    CategoryList.Add(categoryObject);

                }


            }


            vmApplierANDJobCategory.Applier = applier;

            vmApplierANDJobCategory.JobCategoryList = CategoryList;

            return View(vmApplierANDJobCategory);
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
        #region JOBCV
        [HttpPost]
        public ActionResult createJobexpericene(string title, DateTime startDate, DateTime endDate, string description, int jobCVID)
        {
            ApplierServiceReference.Applier applier = Session["applier"] as ApplierServiceReference.Applier;
            JobCVServiceReference.JobExperience jobExperience = new JobCVServiceReference.JobExperience
            {
                Title = title,
                StartDate = startDate,
                EndDate = endDate,
                Description = description,
                JobCVId = jobCVID

            };
            jobCVServiceClient.CreateJobexpericene(jobExperience);
            Session["Applier"] = client.GetApplier(applier.Id);
            return RedirectToAction("JobApplication");
        }
        [HttpPost]
        public ActionResult UpdateJobexpericene(string title, DateTime startDate, DateTime endDate, string description, int id)
        {
            ApplierServiceReference.Applier applier = Session["applier"] as ApplierServiceReference.Applier;
            JobCVServiceReference.JobExperience jobExperience = new JobCVServiceReference.JobExperience
            {
                Title = title,
                StartDate = startDate,
                EndDate = endDate,
                Description = description,
                JobCVId = applier.JobCV.Id,
                Id = id

            };
            jobCVServiceClient.UpdateJobexpericene(jobExperience);
            Session["Applier"] = client.GetApplier(applier.Id);
            return RedirectToAction("JobApplication");
        }

        public ActionResult DeleteJobExperience(int id)
        {
            ApplierServiceReference.Applier applier = Session["applier"] as ApplierServiceReference.Applier;

            TempData["Success"] = "Successfuld slettet!";
            jobCVServiceClient.DeleteJobexpericene(id);
            Session["Applier"] = client.GetApplier(applier.Id);
            return RedirectToAction("JobApplication");
        }

        [HttpPost]
        public ActionResult CreateEducation(string title, DateTime startDate, DateTime endDate, string institution)
        {
            ApplierServiceReference.Applier applier = Session["applier"] as ApplierServiceReference.Applier;
            JobCVServiceReference.ApplierEducation applierEducation = new JobCVServiceReference.ApplierEducation
            {
                EducationName = title,
                StartDate = startDate,
                EndDate = endDate,
                Institution = institution,
                JobCVId = applier.JobCV.Id

            };
            jobCVServiceClient.CreateApplierEducation(applierEducation);
            Session["Applier"] = client.GetApplier(applier.Id);
            return RedirectToAction("JobApplication");
        }

        [HttpPost]
        public ActionResult UpdateEducation(string title, DateTime startDate, DateTime endDate, string institution, int id)
        {
            ApplierServiceReference.Applier applier = Session["applier"] as ApplierServiceReference.Applier;
            JobCVServiceReference.ApplierEducation applierEducation = new JobCVServiceReference.ApplierEducation
            {
                EducationName = title,
                StartDate = startDate,
                EndDate = endDate,
                Institution = institution,
                JobCVId = applier.JobCV.Id,
                id = id

            };
            jobCVServiceClient.UpdateApplierEducation(applierEducation);
            Session["Applier"] = client.GetApplier(applier.Id);
            return RedirectToAction("JobApplication");
        }

        public ActionResult DeleteEducation(int id)
        {
            ApplierServiceReference.Applier applier = Session["applier"] as ApplierServiceReference.Applier;

            TempData["Success"] = "Successfuld slettet!";
            jobCVServiceClient.DeleteApplierEducation(id);
            Session["Applier"] = client.GetApplier(applier.Id);
            return RedirectToAction("JobApplication");
        }

        #endregion

        [HttpPost]
        public ActionResult _UpdateUserProfile(string emailInput, string bannerInput, string imageInput, string fNameInput, string lNameInput, DateTime birthdate, int PhoneInput, string addressInput,
                                                string countryInput, string currentJobInput, string homepageInput, string descriptionInput, List<int> Categories)
        {
            ApplierServiceReference.Applier applierS = Session["applier"] as ApplierServiceReference.Applier;

            ApplierServiceReference.Applier applier = new ApplierServiceReference.Applier
            {
                Id = applierS.Id,
                Email = emailInput,
                BannerURL = bannerInput,
                ImageURL = imageInput,
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
                JobCV = applierS.JobCV,
                Password = applierS.Password

            };

            List<ApplierServiceReference.JobCategory> jobCategoryList = new List<ApplierServiceReference.JobCategory>();

            if (Categories != null)
            {

                foreach (var item in Categories)
                {
                    ApplierServiceReference.JobCategory jobCategory = new ApplierServiceReference.JobCategory
                    {
                        Id = item,
                        Title = "Noget"

                    };

                    jobCategoryList.Add(jobCategory);
                }
            }

            applier.JobCategoryList = jobCategoryList;



            client.Update(applier);
            TempData["Success"] = "Successfuld opdateret!";
            Session["applier"] = client.GetApplier(applier.Id);
            return RedirectToAction("UpdateUserProfile");
        }


        [HttpPost]
        public ActionResult UpdatePassword(string currentPassword, string newPassword, string RepeatNewPassword)
        {
            ApplierServiceReference.Applier applier = Session["applier"] as ApplierServiceReference.Applier;

            if (applier.Password != currentPassword)
            {
                TempData["Fail"] = "Forkert kodeord";


                return RedirectToAction("UpdateUserProfile");

            }
            else if (newPassword != RepeatNewPassword)
            {
                TempData["Fail"] = "Kodeordene stemmer ikke overens!";


                return RedirectToAction("UpdateUserProfile");
            }
            else
            {
                applier.Password = newPassword;

                client.Update(applier);
                TempData["Success"] = "Kodeordet er ændret!";
                Session["applier"] = client.GetApplier(applier.Id);
                return RedirectToAction("UpdateUserProfile");

            }

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

            if (applier != null)
            {

                Session["applier"] = applier;
                return RedirectToAction("Index");
            }
            TempData["Fail"] = "Fail";
            return RedirectToAction("Index", "Home");

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
            TempData["Success"] = "Din ansøgning er blevet sendt";
            return RedirectToAction("Index");
        }




        public ActionResult Booking(int id)
        {

            JobPostServiceReference.JobPost jobPost = jobClient.GetJobPost(id);
            List<BookingService.Booking> bookingList = bookingServiceClient.GetAllBooking(jobPost.Meeting.Id).ToList();
            //List<BookingService.Session> sessionList = new List<BookingService.Session>();
            //foreach (var session in bookingList)
            //{
            //    sessionList.AddRange(session.sessionList);

            //}

            VMBookingSession vMBookingSession = new VMBookingSession
            {
                BookingList = bookingList,

                Applier = Session["Applier"] as ApplierServiceReference.Applier,
                JobPost = jobPost


            };



            return View(vMBookingSession);
        }

        public ActionResult BookMeeting(int id, int JobPostId)
        {


            ApplierServiceReference.Applier applier = Session["Applier"] as ApplierServiceReference.Applier;
            BookingService.Session session = bookingServiceClient.GetSession(id);
            session.ApplierId = applier.Id;


            bool returnedStatus = bookingServiceClient.UpdateSession(session);
            if (returnedStatus == true)
            {
                TempData["Success"] = "Mødet Booket d." + session.StartTime + "" + session.EndTime.ToShortTimeString();
            }
            else
            {
                TempData["Failed"] = "Tiden d. " + session.StartTime + "" + session.EndTime.ToShortTimeString() + " er desværre allerede optaget, vælg venlist en anden tid";
            }
            return RedirectToAction("Booking/" + JobPostId);
        }


        public ActionResult DeleteBooking(int id, int JobPostId)
        {
            BookingService.Session session = bookingServiceClient.GetSession(id);
            session.ApplierId = 0;

            bookingServiceClient.RemoveApplierFromSession(session);
            TempData["Success"] = "Mødet er blevet slettet";
            return RedirectToAction("Booking/" + JobPostId);
        }
    }
}
