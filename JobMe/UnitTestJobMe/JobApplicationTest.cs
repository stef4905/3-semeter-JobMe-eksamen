using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer;
using ModelLayer;

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
            JobApplication jobApplication = new JobApplication(1, "Title", "Description", 15);

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
           JobApplication jobApplication = dbJobApplication.Get(1);

            //Assert
            Assert.AreEqual(jobApplication.Id, 1);
        }

        [TestMethod]
        public void UpdateJobApplicationInDB()
        {
            //Arrange
            DbJobApplication dbJobApplication = new DbJobApplication();

            JobApplication jobApplication = new JobApplication(1, "noget nyt", "En Beskrivelse", 2);
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





    }
}

