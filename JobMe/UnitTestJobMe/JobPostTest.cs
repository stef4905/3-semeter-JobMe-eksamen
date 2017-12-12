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
        public void JobPostUpdateDBTest()
        {
            //Arrange
            DbJobPost dbJobPost = new DbJobPost();
            JobPostCtr jobPostCtr = new JobPostCtr();

            Company testcompany = new Company("unittest@gmail.com", "hellopassword");
            testcompany.Id = 1;
            WorkHours testworkHours = new WorkHours();
            testworkHours.Id = 1;
            JobCategory testjobCategory = new JobCategory();
            testjobCategory.Id = 1;
            Meeting testmeeting = new Meeting
            {
                CompanyId = 1,
                Id = 6

            };
            JobPost jobPost = new JobPost
            {
                Id = 5001,
                Title = "UnitTestsss",
                Description = "Simple Unit Testssss",
                StartDate = new DateTime(2017, 05, 05),
                EndDate = new DateTime(2018, 05, 05),
                JobTitle = "Unit Test Job Titleeeeeeee",
                workHours = testworkHours,
                Address = "UnitTestVejURedigeret 123",
                company = testcompany,
                jobCategory = testjobCategory,
                Meeting = testmeeting


            };


            JobPost jobPostUpdate = new JobPost
            {
                Id = 5001,
                Title = "UnitTested",
                Description = "Simple Unit Tested",
                StartDate = new DateTime(2017, 05, 05),
                EndDate = new DateTime(2018, 05, 05),
                JobTitle = "Unit Test Job Title",
                workHours = testworkHours,
                Address = "UnitTestVej 321",
                company = testcompany,
                jobCategory = testjobCategory,
                Meeting = testmeeting


            };
            //Act
            jobPostCtr.Create(jobPost);
            jobPostCtr.Update(jobPostUpdate);

            //Assert
            Assert.AreNotEqual(jobPost, jobPostUpdate);



        }
        [TestMethod]
        public void DeleteJobPost()
        {
            //Arrange
            JobPostCtr jobPostCtr = new JobPostCtr();

            //Act
            jobPostCtr.Delete(1050);
            JobPost deletedJobPost = jobPostCtr.Get(1050);


            //Assert
            Assert.IsNull(deletedJobPost.Id);
        }
    }
}
