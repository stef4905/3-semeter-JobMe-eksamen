using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using ModelLayer;
using DataAccessLayer;

namespace UnitTest.DataAccessLayer
{
    [TestClass]
    public class DBJobApplicationTest
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
    }
}
