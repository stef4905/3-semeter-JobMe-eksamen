using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer;
using ModelLayer;
using System.Collections.Generic;

namespace UnitTestJobMe
{
    [TestClass]
    public class JobApplicationTest
    {
        [TestMethod]
        public void CreateJobApplicationInDB()
        {
            //Arrange
            DbJobApplication dbJobApplication = new DbJobApplication();
            Applier applier = new Applier
            {
                Id = 15
            };

            JobApplication jobApplication = new JobApplication(1, "Title", "Description", applier);

            //Act
            bool inserted = dbJobApplication.Create(jobApplication);

            //Assert
            Assert.IsTrue(inserted);
        }
        [TestMethod]
        public void GetJobApplicationInDB()
        {
            //Arrange
            DbJobApplication dbJobApplication = new DbJobApplication();


            //Act
           JobApplication jobApplication = dbJobApplication.Get(6);

            //Assert
            Assert.AreEqual(jobApplication.Id, 6);
        }

        [TestMethod]
        public void UpdateJobApplicationInDB()
        {
            //Arrange
            DbJobApplication dbJobApplication = new DbJobApplication();
            Applier applier = new Applier
            {
                Id = 2
            };

            JobApplication jobApplication = new JobApplication(1, "noget nyt", "En Beskrivelse", applier);
            //Act
            bool check = dbJobApplication.Update(jobApplication);

            //Assert
            Assert.IsTrue(check);
        }

        [TestMethod]
        public void DeleteJobApplicationInDB()
        {
            //Arrange
            DbJobApplication dbJobApplication = new DbJobApplication();

            
            //Act
            //If fails id not found
            dbJobApplication.Delete(1);
            JobApplication deleted =  dbJobApplication.Get(1);
            
            //Assert
            Assert.IsNull(deleted);
        }


        [TestMethod]
        public void SendJobApplicationInDB()
        {
            //Arrange
            DbJobApplication dbJobApplication = new DbJobApplication();
            Applier applier = new Applier
            {
                Id = 15
            };
            JobPost jobPost = new JobPost();
            jobPost.Id = 1;

            JobApplication jobApplication = new JobApplication(6, "eheh", "dsfs", applier);

    
            //Act
        

            bool send = dbJobApplication.SendApplication(jobApplication, jobPost);

            //Assert
            Assert.IsTrue(send);
        }


        [TestMethod]
        public void TestGetAllJobApplicationToAJobPostInDB()
        {
            //Arrange
            DbJobApplication dbJobApplication = new DbJobApplication();

            JobPost jobPost = new JobPost();
            jobPost.Id = 3;

            List<JobApplication> list = new List<JobApplication>();


            //Act
            list = dbJobApplication.GetAllJobApplicationToAJobPost(jobPost.Id);


            //Assert
            Assert.IsNotNull(list);
        }

    }
}

