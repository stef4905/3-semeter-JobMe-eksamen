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
        //Service referencer
        ApplierServiceClient client = new ApplierServiceClient();
        JobPostServiceClient jobClient = new JobPostServiceClient();
        JobApplicationServiceClient jobApplicationClient = new JobApplicationServiceClient();
        BookingServiceClient bookingServiceClient = new BookingServiceClient();
        JobCVServiceReference.JobCVServiceClient jobCVServiceClient = new JobCVServiceReference.JobCVServiceClient();


        #region Generel

        /// <summary>
        /// Displays a index site for the applier with the view model jobPostList which contains two jobposts lists
        /// </summary>
        /// <returns>An Index Page with the view model</returns>
        public ActionResult Index()
        {
            //gets the applier from a Session
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
                countOfJobPosts = jobClient.GetJobPostTableSize(),
                applier = Session["applier"] as ApplierServiceReference.Applier
            };
            return View(vmJobPostList);
        }

        /// <summary>
        /// Displays a partiel view _Login
        /// </summary>
        /// <returns>Return an _Login partiel</returns>
        public ActionResult _Login()
        {
            return PartialView();
        }

        /// <summary>
        /// An HTTPPost method there respone on httpPost requst, and calls the login method from the ApplierService
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns> if true it returns the index page of applier else it returns the index of the home</returns>
        [HttpPost]
        public ActionResult _Login(string email, string password)
        {
            ApplierServiceReference.Applier applier = client.Login(email, password);
            if (applier != null)
            {
                Session["applier"] = applier;
                return RedirectToAction("Index");
            }
            TempData["Fail"] = "Fail";
            return RedirectToAction("Index", "Home");

        }

        /// <summary>
        /// Displays a partiel view of the current user, with the object applier
        /// </summary>
        /// <returns>a partiel view with the object applier</returns>
        public ActionResult _CurrentUser()
        {
            ApplierServiceReference.Applier applier = new ApplierServiceReference.Applier();
            applier = Session["applier"] as ApplierServiceReference.Applier;
            return PartialView(applier);
        }
        #endregion

        #region Applier
        /// <summary>
        /// Displays a partiel view of the _CreateApplier
        /// </summary>
        /// <returns>partielsview createapplier</returns>
        public ActionResult _CreateApplier()
        {
            return PartialView();

        }
        /// <summary>
        /// Displays a applierProfile view with the param id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retruns the view with an applier object</returns>
        public ActionResult ApplierProfile(int id)
        {
            ApplierServiceReference.Applier applier = client.GetApplier(id);
            return View(applier);
        }

        /// <summary>
        /// Displays a UpdaterUserProfile view
        /// </summary>
        /// <returns>Returns a view with the view model vmApplierANDJobCategory their have the objects of an applier and a jobcategory</returns>
        public ActionResult UpdateUserProfile()
        {
            List<JobPostServiceReference.JobCategory> jobCategoryList = jobClient.GetAllJobCategories().ToList();
            ApplierServiceReference.Applier appliers = Session["applier"] as ApplierServiceReference.Applier;
            ApplierServiceReference.Applier applier = client.GetApplier(appliers.Id);
            VMApplierANDJobCategory vmApplierANDJobCategory = new VMApplierANDJobCategory();

            List<CategoryObject> CategoryList = new List<CategoryObject>();
            if (applier.JobCategoryList == null)
            {
                applier.JobCategoryList = new List<ApplierServiceReference.JobCategory>();
            }

            foreach (var item in jobCategoryList)
            {
                // a list of appliers jobcategorylist where an jobcategory id in the appliers jobcategorylist 
                // equals an id from the jobcategorylist
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


        /// <summary>
        /// An HTTPPost method there respone on httpPost requst, and calls the createApplier method from the ApplierService
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <param name="PasswordControl"></param>
        /// <returns> returns a redicret to action to the index page in applier</returns>
        [HttpPost]
        public ActionResult _CreateApplier(string Email, string Password, string PasswordControl)
        {
            ApplierServiceReference.Applier applier = new ApplierServiceReference.Applier
            {
                Password = Password,
                Email = Email
            };

            if (Password == PasswordControl)
            {
                client.Create(applier);
                applier = client.Login(Email, Password);
                Session["applier"] = applier;
                return RedirectToAction("Index");
            }
            return null;
        }

        /// <summary>
        /// An HTTPPost method there respone on httpPost requst, and calls the Updateapplier from the ApplierService
        /// with the givens params
        /// </summary>
        /// <param name="emailInput"></param>
        /// <param name="bannerInput"></param>
        /// <param name="imageInput"></param>
        /// <param name="fNameInput"></param>
        /// <param name="lNameInput"></param>
        /// <param name="birthdate"></param>
        /// <param name="PhoneInput"></param>
        /// <param name="addressInput"></param>
        /// <param name="countryInput"></param>
        /// <param name="currentJobInput"></param>
        /// <param name="homepageInput"></param>
        /// <param name="descriptionInput"></param>
        /// <param name="Categories"></param>
        /// <returns>Returns a redict to action to the updateUserProfile view</returns>
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

        /// <summary>
        /// An HTTPPost method there respone on httpPost requst, and calls the updatePassword method from the ApplierService
        /// with the params currentPassword, newPassword and RepeatNewPassword
        /// </summary>
        /// <param name="currentPassword"></param>
        /// <param name="newPassword"></param>
        /// <param name="RepeatNewPassword"></param>
        /// <returns></returns>
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

        #endregion

        #region JobPost
        /// <summary>
        /// Displays a jobPost site for the applier with a param Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a view with the ViewModel JobpostANDList with the object jobPost and a list of Jobposts</returns>
        public ActionResult JobPost(int id)
        {
            VMJobPostANDJobPostList jobPostAndList = new VMJobPostANDJobPostList
            {
                jobPost = jobClient.GetJobPost(id),
                jobPostList = jobClient.GetAllJobPost()
            };
            return View(jobPostAndList);
        }

        /// <summary>
        /// Displays a findJobPost site for the applier
        /// </summary>
        /// <returns>Returns a view with the ViewModel with a lists of JobPosts, JobCategorys and WorkHours</returns>
        public ActionResult FindJobPosts()
        {
            VMJobPostWorkHoursJobCategory VM = new VMJobPostWorkHoursJobCategory
            {
                JobPostList = jobClient.GetAllJobPost().ToList(),
                JobCategoryList = jobClient.GetAllJobCategories().ToList(),
                WorkHoursList = jobClient.GetAllWorkHours().ToList()
            };
            return View(VM);
        }

        /// <summary>
        ///  An HTTPPost method there respone on httpPost requst, and calls the FindJobPost method from the ApplierService
        /// With the params search, km, category and workHours
        /// </summary>
        /// <param name="search"></param>
        /// <param name="km"></param>
        /// <param name="category"></param>
        /// <param name="workHours"></param>
        /// <returns>Returns a view with the ViewModel with a lists of JobPosts, JobCategorys and WorkHours</returns>
        [HttpPost]
        public ActionResult FindJobPosts(string search, int km, int category, int workHours)
        {
            VMJobPostWorkHoursJobCategory VM = new VMJobPostWorkHoursJobCategory
            {
                JobPostList = jobClient.GetAllJobPost().ToList()
            };
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

        #endregion

        #region JobApplication

        /// <summary>
        /// Displays a Jobapplication view for the applier
        /// </summary>
        /// <returns>Return a view with the Viewmodel VmApllierAndApplication there cotains a object of an applier and a list of Appliers</returns>
        public ActionResult JobApplication()
        {
          
            ApplierServiceReference.Applier applier = Session["applier"] as ApplierServiceReference.Applier;
            VMApplierAndApplication vmApplierAndApplication = new VMApplierAndApplication
            {
                Applier = applier,
                JobApplicationList = jobApplicationClient.GetAllByApplierId(applier.Id).ToList()
            };
            return View(vmApplierAndApplication);
        }

        /// <summary>
        /// An HTTPPost method there respone on httpPost requst, and calls the createApplication method from the ApplierService
        /// With the params title, description and applierid
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="applierId"></param>
        /// <returns>Return a redirect to action</returns>
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
        /// <summary>
        /// An HTTPPost method there respone on httpPost requst, and calls the UpdateApplication method from the ApplierService
        /// with the params title, description and id
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="id"></param>
        /// <returns>Returns a redicrect to action to the view jobApllication</returns>
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
       
        /// <summary>
        /// A method for deleteApplication with the param Id, there deletes an application
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a redirectToAction to JobApplication view</returns>
        public ActionResult DeleteApplication(int id)
        {
            jobApplicationClient.Delete(id);
            TempData["Success"] = "Successfuld slettet!";
            return RedirectToAction("JobApplication");
        }

        /// <summary>
        ///  Display a partiel view _JobApplication
        /// </summary>
        /// <returns>Returns a partielview </returns>
        public ActionResult _JobApplication()
        {
            return PartialView();
        }
        /// <summary>
        /// Displays a SendApplication view with the param id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a view with the view model vMJobPostANDJobApplication with the objects jobPost and applier, and a list of jobapplacations</returns>
        public ActionResult SendApplication(int id)
        {
            ApplierServiceReference.Applier applier = new ApplierServiceReference.Applier();
            applier = Session["applier"] as ApplierServiceReference.Applier;
            VMJobPostANDJobApplication vMJobPostANDJobApplication = new VMJobPostANDJobApplication
            {
                JobPost = jobClient.GetJobPost(id),
                JobApplicationList = jobApplicationClient.GetAllByApplierId(applier.Id).ToList(),
                applier = applier
            };
            return View(vMJobPostANDJobApplication);
        }


        /// <summary>
        /// An HTTPPost method there respone on httpPost requst, and calls the SendAppliaction method from the ApplierService
        /// with the params jobApplicationId and jobPostId
        /// </summary>
        /// <param name="jobApplicationId"></param>
        /// <param name="jobPostId"></param>
        /// <returns>Returns a redirectToAction to the view index on the ApplierController</returns>
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
        #endregion

        #region JOBCV

        /// <summary>
        /// An HTTPPost method there respones on httpPost requst, and calls the createJobExpreicene method from the ApplierService
        /// with the params title, startdate, endDate, description and jobCVID
        /// </summary>
        /// <param name="title"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="description"></param>
        /// <param name="jobCVID"></param>
        /// <returns>Returns a RedirectToAction to the view jobappliaction</returns>
        [HttpPost]
        public ActionResult CreateJobexpericene(string title, DateTime startDate, DateTime endDate, string description, int jobCVID)
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
            TempData["Success"] = "Successfuld oprettet!";
            Session["Applier"] = client.GetApplier(applier.Id);
            return RedirectToAction("JobApplication");
        }

        /// <summary>
        /// A HTTPPost method there respones on httpPost requst, and calls the UpdateJobExpreicene method from the ApplierService
        /// with the params title, startdate, endDate, description, jobCVID and id
        /// </summary>
        /// <param name="title"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="description"></param>
        /// <param name="jobCVID"></param>
        /// /// <param name="Id"></param>
        /// <returns>Returns a RedirectToAction to the view jobappliaction</returns>
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
            TempData["Success"] = "Successfuld opdateret!";
            Session["Applier"] = client.GetApplier(applier.Id);
            return RedirectToAction("JobApplication");
        }


        /// <summary>
        /// DeleteMethod for the jobExperience with the param id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a RedirectToAction to the view jobappliaction</returns>
        public ActionResult DeleteJobExperience(int id)
        {
            ApplierServiceReference.Applier applier = Session["applier"] as ApplierServiceReference.Applier;

            TempData["Success"] = "Successfuld slettet!";
            jobCVServiceClient.DeleteJobexpericene(id);
            Session["Applier"] = client.GetApplier(applier.Id);
            return RedirectToAction("JobApplication");
        }

        /// <summary>
        /// A HTTPPost method there respones on httpPost requst, and calls the CreateEducation method from the ApplierService
        /// with the params title, startdate, endDate and institution
        /// </summary>
        /// <param name="title"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="institution"></param>
        /// <returns>Returns a RedirectToAction to the view jobappliaction</returns>
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
            TempData["Success"] = "Successfuld oprettet!";
            Session["Applier"] = client.GetApplier(applier.Id);
            return RedirectToAction("JobApplication");
        }

        /// <summary>
        /// A HTTPPost method there respones on httpPost requst, and calls the UpdateEducation method from the ApplierService
        /// with the params title, startdate, endDate, institution and id
        /// </summary>
        /// <param name="title"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="institution"></param>
        /// <param name="id"></param>
        /// <returns>Returns a RedirectToAction to the view jobappliaction</returns>
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
            TempData["Success"] = "Successfuld opdateret!";
            return RedirectToAction("JobApplication");
        }


        /// <summary>
        /// DeleteMethod for the Education with the param id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a RedirectToAction to the view jobappliaction</returns>
        public ActionResult DeleteEducation(int id)
        {
            ApplierServiceReference.Applier applier = Session["applier"] as ApplierServiceReference.Applier;

            TempData["Success"] = "Successfuld slettet!";
            jobCVServiceClient.DeleteApplierEducation(id);
            Session["Applier"] = client.GetApplier(applier.Id);
            return RedirectToAction("JobApplication");
        }

        /// <summary>
        /// Display a partial view for JobCV
        /// </summary>
        /// <returns>returns a partielview with an Applier Object</returns>
        public ActionResult _JobCV()
        {
            ApplierServiceReference.Applier applier = new ApplierServiceReference.Applier();
            applier = Session["applier"] as ApplierServiceReference.Applier;
            return PartialView(applier);

        }

        /// <summary>
        /// Displays a partial view for readJobCV
        /// </summary>
        /// <returns>Returns a partielview with the object JobCV</returns>
        public ActionResult _ReadJobCV()
        {
            ApplierServiceReference.Applier applier = new ApplierServiceReference.Applier();
            
            applier = Session["applier"] as ApplierServiceReference.Applier;
            ApplierServiceReference.JobCV jobCV = applier.JobCV;
            return PartialView(jobCV);


        }
        #endregion

        #region Booking
        /// <summary>
        /// Displays a booking view with the param Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a view with a viewmodel VMBookingSession with a applier and jobPost object</returns>
        public ActionResult Booking(int id)
        {

            JobPostServiceReference.JobPost jobPost = jobClient.GetJobPost(id);
            List<BookingService.Booking> bookingList = bookingServiceClient.GetAllBooking(jobPost.Meeting.Id).ToList();
            VMBookingSession vMBookingSession = new VMBookingSession
            {
                BookingList = bookingList,

                Applier = Session["Applier"] as ApplierServiceReference.Applier,
                JobPost = jobPost
            };
            return View(vMBookingSession);
        }

        /// <summary>
        /// BookMetting method, set an applier on a booking by updating the session with a applier id in the bookingServiceClient
        /// </summary>
        /// <param name="id"></param>
        /// <param name="JobPostId"></param>
        /// <returns>Returns a redirecToAction to booking view with the param JobPostId</returns>
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


        /// <summary>
        /// DeleteBooking method with the params id and jobPostId. Removes a applier from a session
        /// </summary>
        /// <param name="id"></param>
        /// <param name="JobPostId"></param>
        /// <returns>Returns a redirectToAction to booking with the param jobPostId</returns>
        public ActionResult DeleteBooking(int id, int JobPostId)
        {
            BookingService.Session session = bookingServiceClient.GetSession(id);
            session.ApplierId = 0;

            bookingServiceClient.RemoveApplierFromSession(session);
            TempData["Success"] = "Mødet er blevet slettet";
            return RedirectToAction("Booking/" + JobPostId);
        }

        #endregion
    }
}
