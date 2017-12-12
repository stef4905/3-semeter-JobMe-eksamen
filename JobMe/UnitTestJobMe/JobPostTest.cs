using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer;
using ModelLayer;
using System.Collections.Generic;
using BusinessLogicLayer;

namespace UnitTestJobMe
{
    [TestClass]
    public class JobPostTest
    {
        [TestMethod]
        public void CreateJobPostDBTest()
        {
            //Arrange
            DbJobPost dbJobPost = new DbJobPost();
            Company company = new Company("imacompany@gmai.om", "hellopassword");
            company.Id = 1;
            WorkHours workHours = new WorkHours();
            workHours.Id = 1;
            JobCategory jobCategory = new JobCategory();
            jobCategory.Id = 1;


            string iDate = "05/05/2018";
            DateTime oDate = Convert.ToDateTime(iDate);
            DateTime nowDate = oDate;
            Meeting meeting = new Meeting
            {
                CompanyId = 1,
                Id = 6

            };

            JobPost jobPost = new JobPost(1, "Test job1", "Et job for dig", nowDate, oDate, "Wc Vasker", workHours, "Her", company, jobCategory);
            jobPost.Meeting = meeting;

            // Act
            bool inserted = dbJobPost.Create(jobPost);

            // Assert
            Assert.IsTrue(inserted);
        }

        [TestMethod]
        public void JobPostGetById()
        {
            //Arrange
            DbJobPost dbJob = new DbJobPost();
            JobPost jobPost = new JobPost();

            //Act
            jobPost = dbJob.Get(1037);

            //Assert
            Assert.AreEqual(jobPost.Id, 1037);
        }

        [TestMethod]
        public void TestGetAllJobPostToAJobApplicationInDB()
        {
            //Arrange
            DbJobPost dbJobPost = new DbJobPost();

            JobApplication jobApplication = new JobApplication();
            jobApplication.Id = 6;

            List<JobPost> list = new List<JobPost>();


            //Act
            list = dbJobPost.GetAllJobPostToAJobApplication(jobApplication.Id);


            //Assert
            Assert.IsNotNull(list);
        }

        [TestMethod]
        public void TestJobPostTableSize()
        {
            //Arrange
            int count;
            DbJobPost dbJobPost = new DbJobPost();

            //Act
            count = dbJobPost.GetJobPostTableSize();

            //Assert
            Assert.AreEqual(14, count);

        }

        [TestMethod]
        public void JobPostUpdateTest()
        {
            //Arrange
            DbJobPost dbJobPost = new DbJobPost();
            JobPostCtr jobPostCtr = new JobPostCtr();

            Company testcompany = new Company();
            testcompany.Id = 1;
            WorkHours testworkHours = new WorkHours();
            testworkHours.Id = 1;
            JobCategory testjobCategory = new JobCategory();
            testjobCategory.Id = 1;
            Meeting testmeeting = new Meeting
            {
                CompanyId = 1,
                Id = 54

            };

            JobPost jobPostUpdate = new JobPost
            {
                Id = 1051,
                Title = "UnitTestedAgain",
                Description = "Simple Unit Tested once more",
                StartDate = new DateTime(2017, 12, 12),
                EndDate = new DateTime(2019, 05, 05),
                JobTitle = "Unit Test Job Titleee",
                workHours = testworkHours,
                Address = "UnitTestVej 321123",
                company = testcompany,
                jobCategory = testjobCategory,
                Meeting = testmeeting
            };
            JobPost JobPostReturnedToTest = null;

            //Act
            jobPostCtr.Update(jobPostUpdate);
            JobPostReturnedToTest = jobPostCtr.Get(jobPostUpdate.Id);

            //Assert
            Assert.AreEqual(JobPostReturnedToTest.Id, jobPostUpdate.Id);
            Assert.AreEqual(JobPostReturnedToTest.Title, jobPostUpdate.Title);
            Assert.AreEqual(JobPostReturnedToTest.Description, jobPostUpdate.Description);
            Assert.AreEqual(JobPostReturnedToTest.StartDate, jobPostUpdate.StartDate);
            Assert.AreEqual(JobPostReturnedToTest.EndDate, jobPostUpdate.EndDate);
            Assert.AreEqual(JobPostReturnedToTest.JobTitle, jobPostUpdate.JobTitle);
            Assert.AreEqual(JobPostReturnedToTest.workHours.Id, jobPostUpdate.workHours.Id);
            Assert.AreEqual(JobPostReturnedToTest.Address, jobPostUpdate.Address);
            Assert.AreEqual(JobPostReturnedToTest.company.Id, jobPostUpdate.company.Id);
            Assert.AreEqual(JobPostReturnedToTest.jobCategory.Id, jobPostUpdate.jobCategory.Id);
            Assert.AreEqual(JobPostReturnedToTest.Meeting.Id, jobPostUpdate.Meeting.Id);
        }

        [TestMethod]
        public void DeleteJobPost()
        {
            //Arrange
            JobPostCtr jobPostCtr = new JobPostCtr();

            //Act
            jobPostCtr.Delete(1052);
            JobPost deletedJobPost = jobPostCtr.Get(1052);


            //Assert
            Assert.IsNull(deletedJobPost.JobTitle);
        }
    }
}
