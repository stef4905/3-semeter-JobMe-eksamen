using JobMe_Homepage.ApplierServiceReference;
using JobMe_Homepage.CompanyServiceReference;
using JobMe_Homepage.BookingService;
using JobMe_Homepage.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobMe_Homepage.Controllers
{
    public class CompanyController : Controller
    {
        //Service Referencer
        CompanyServiceClient client = new CompanyServiceClient();
        JobPostServiceReference.JobPostServiceClient jobClient = new JobPostServiceReference.JobPostServiceClient();
        JobApplicationServiceReference.JobApplicationServiceClient jobApplicationService = new JobApplicationServiceReference.JobApplicationServiceClient();
        ApplierServiceClient applierServiceClient = new ApplierServiceClient();
        BookingServiceClient BookingServiceClient = new BookingServiceClient();

        #region Generel

        /// <summary>
        /// Displays an Index view
        /// </summary>
        /// <returns>Returns the index with, with the viewModel vmCompany and jobPost with the object company and list of jobposts</returns>
        public ActionResult Index()
        {
            Company company = new Company();
            // Mangler fagterm på as
            company = Session["company"] as Company;
            // Returns a list of all JobPost in the database - It sorts the list so it equals the CompanyId your logged in with
            List<JobPostServiceReference.JobPost> job = jobClient.GetAllJobPost().Where(m => m.company.Id == company.Id).ToList();
            VMCompanyANDJobPost vMCompanyANDJobPost = new VMCompanyANDJobPost
            {
                Company = company,
                JobPost = job
            };

            return View(vMCompanyANDJobPost);
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
            Company company = client.Login(email, password);

            // Creates sessions for company login
            if (company != null)
            {

                Session["company"] = company;
                return RedirectToAction("Index");

            }
            TempData["FailCompany"] = "Fail";
            return RedirectToAction("Index", "Home");



        }

        #endregion

        #region Company


        /// <summary>
        /// Displays a partiel view _CreateCompany
        /// </summary>
        /// <returns>Return a _CreateCompany partiel view</returns>
        public ActionResult _CreateCompany()
        {

            return PartialView();
        }


        /// <summary>
        /// Displays a partiel view _CreateCompany
        /// </summary>
        /// <returns>Returns a _CurrentCompany partiel view with a company object</returns>
        public ActionResult _CurrentCompany()
        {
            Company company = new Company();
            company = Session["company"] as Company;
            return PartialView(company);
        }


        /// <summary>
        /// An HTTPPost method there respone on httpPost requst, and calls the createCompany method from the ApplierService
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <param name="PasswordControl"></param>
        /// <returns> returns a redicret to action to the index page in company</returns>
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
                
            }

            return null;
        }

        #endregion

        #region JobPost
        public ActionResult CreateJobPost()
        {
            VMWorkHoursJobCategory VM = new VMWorkHoursJobCategory();
            VM.WorkHoursList = jobClient.GetAllWorkHours().ToList();
            VM.JobCategoryList = jobClient.GetAllJobCategories().ToList();

            return View(VM);
        }
        /// <summary>
        /// Create Job Post method, It creates a jobPost from a constructor with the required parameters.
        /// </summary>
        /// <param name="Title"></param>
        /// <param name="Description"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="JobTitle"></param>
        /// <param name="WorkHours"></param>
        /// <param name="Address"></param>
        /// <param name="Company"></param>
        /// <param name="JobCategory"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateJobPost(string Title, string Description, DateTime StartDate, DateTime EndDate, string JobTitle, int WorkHours, string Address, Company Company, int JobCategory)
        {

            JobPostServiceReference.WorkHours workHours = new JobPostServiceReference.WorkHours { Id = WorkHours };
            JobPostServiceReference.JobCategory jobCategory = new JobPostServiceReference.JobCategory { Id = JobCategory };
            CompanyServiceReference.Company company = Session["company"] as CompanyServiceReference.Company;

            JobPostServiceReference.Company com = new JobPostServiceReference.Company
            {
                Id = company.Id
            };

            JobPostServiceReference.JobPost jobPost = new JobPostServiceReference.JobPost
            {
                Title = Title,
                Description = Description,
                StartDate = StartDate.Date,
                EndDate = EndDate.Date,
                JobTitle = JobTitle,
                workHours = workHours,
                Address = Address,
                company = com,
                jobCategory = jobCategory

            };
            try
            {

                jobClient.CreateJobPost(jobPost);
                TempData["Success"] = "Successfuld lavet!";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Displays a view JobPost with the param id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a view with a jobpost object</returns>
        public ActionResult JobPost(int id)
        {
            JobPostServiceReference.JobPost jobPost = jobClient.GetJobPost(id);
            return View(jobPost);
        }
        #endregion

        #region Appliers
        /// <summary>
        /// Returns all JobApplications from a specific JobPost
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult AppliersForJob(int id)
        {

            JobPostServiceReference.JobPost jobPost = new JobPostServiceReference.JobPost
            {
                Id = id
            };
            VMJobPostJobApplication vMJobPostJobApplication = new VMJobPostJobApplication
            {
                jobPost = jobPost,
                JobApplicationList = jobApplicationService.GetAllJobApplicationToAJobPost(id).ToList()
            };




            return View(vMJobPostJobApplication);
        }

        /// <summary>
        /// Appliers for job Method, takes the JobApplication, and JobPostId and a boolean, the boolean is a state that shows if they've been accepted to book a meeting.
        /// </summary>
        /// <param name="jobApplicationId"></param>
        /// <param name="jobPostId"></param>
        /// <param name="accepted"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AppliersForJob(int jobApplicationId, int jobPostId, int accepted)
        {
            JobApplicationServiceReference.JobApplication jobApplication = new JobApplicationServiceReference.JobApplication
            {
                Id = jobApplicationId
            };

            JobApplicationServiceReference.JobPost jobPost = new JobApplicationServiceReference.JobPost
            {
                Id = jobPostId
            };

            //Appliers for Job method takes an int for AcceptedApplication which is a bit in the database, if the int is 1 we sets the boolean to true.
            bool accept = false;
            if (accepted == 1)
            {
                accept = true;
            }

            jobApplicationService.AcceptDeclineJobApplication(jobApplication, jobPost, accept);
            return RedirectToAction("");
        }


        /// <summary>
        /// Displays a partial view _JobApplication
        /// </summary>
        /// <returns>Returns a partialview with a jobAppliaction object</returns>
        public ActionResult _JobApplication()
        {
            JobApplicationServiceReference.JobApplication jobApplication = new JobApplicationServiceReference.JobApplication();
            return PartialView(jobApplication);
        }

        /// <summary>
        /// Displays a partial view _JobCV
        /// </summary>
        /// <returns>Returns a partialview with a jobCV object</returns>
        public ActionResult _JobCV()
        {
            JobApplicationServiceReference.JobCV jobCV = new JobApplicationServiceReference.JobCV();
            return PartialView(jobCV);
        }


        //public ActionResult Accept()
        //{
        //    return RedirectToAction("ApplierForJob");
        //}

        #endregion

        #region Meeting
        

        /// <summary>
        /// Displays a meeting view, with the param id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a view with the viewModel vMMetting with a meeting Object and a list with bookings</returns>
        public ActionResult Meeting(int id)
        {
            JobPostServiceReference.JobPost JobPost = jobClient.GetJobPostByMeetingId(id);
            Company company = new Company();
            company = Session["company"] as Company;

            Meeting meeting = BookingServiceClient.GetMeeting(JobPost.Meeting.Id);
            List<BookingService.Booking> bookingList = BookingServiceClient.GetAllBooking(meeting.Id);

            VMMeeting vMMeeting = new VMMeeting
            {

                Meeting = meeting,
                BookingList = bookingList

            };
            return View(vMMeeting);
        }


        /// <summary>
        /// An HTTPPost method there respone on httpPost requst, and calls the createBooking method from the BookingService
        /// with the params meetingDate, startTime, endTime, amountOfInterview and meetingId
        /// </summary>
        /// <param name="meetingDate"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="amountOfInterview"></param>
        /// <param name="meetingId"></param>
        /// <returns>Returns a redirectToAction meeting with a meetingId</returns>
        [HttpPost]
        public ActionResult CreateBooking(string meetingDate, string startTime, string endTime, int amountOfInterview, int meetingId)
        {
            //Create a new booking object and set the needed variables
            Booking booking = new Booking();

            booking.StartDateAndTime = Convert.ToDateTime(meetingDate + " " + startTime + ":00.000");
            booking.EndDateAndTime = Convert.ToDateTime(meetingDate + " " + endTime + ":00.000");
            booking.MeetingId = meetingId;
            booking.InterviewAmount = amountOfInterview;

            //Call the client´s create method that retusrns a bool
            bool returned = BookingServiceClient.CreateBooking(booking);

            if (returned == true)
            {

                return RedirectToAction("Meeting/" + meetingId);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Deletes a boooking in bookingServiceclient with the param id and meetingId
        /// </summary>
        /// <param name="id"></param>
        /// <param name="meetingId"></param>
        /// <returns>Returns a redirectToAction Meeting with a meetingId</returns>
        public ActionResult DeleteBooking(int id, int meetingId)
        {
            bool deleted = BookingServiceClient.DeleteBooking(id);
            return RedirectToAction("Meeting/" + meetingId);
        }
        
        /// <summary>
        /// Removes a person on meeting by getting the method removeApplierfromSession in the bookingClientService
        /// </summary>
        /// <param name="id"></param>
        /// <param name="meetingId"></param>
        /// <returns>Returns a redirectToActions meeting with a meeting Id</returns>
        public ActionResult RemovePersonOnMeeting(int id, int meetingId)
        {
            Session session = BookingServiceClient.GetSession(id);
            session.ApplierId = 0;
            bool updated = BookingServiceClient.RemoveApplierFromSession(session);
            return RedirectToAction("Meeting/" + meetingId);
        }

        /// <summary>
        /// Deletes a session in bookingServiceclient with the param id and meetingId
        /// </summary>
        /// <param name="id"></param>
        /// <param name="meetingId"></param>
        /// <returns>Returns a redirectToAction Meeting with a meetingId</returns>
        public ActionResult DeleteMeeting(int id, int meetingId)
        {
            Session session = BookingServiceClient.GetSession(id);
            bool deleted = BookingServiceClient.DeleteSession(session);
            return RedirectToAction("Meeting/" + meetingId);
        }

        #endregion

    }
}