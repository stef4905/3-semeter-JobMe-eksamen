using System;

using DataAccessLayer;
using ModelLayer;
using BusinessLogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.DataAccessLayer
{
    [TestClass]
    public class DBJobCVTest
    {
        //[TestMethod]
        //public void CreateJobCVInDB()
        //{
        //    //Arrange
        //    JobCV jobCV = new JobCV(1, "Jensens bøfhus", 15, "Bio");
        //    DBJobCV dbJobCV = new DBJobCV();

        //    //Act
        //    bool inserted = dbJobCV.Create(jobCV);

        //    //Assert
        //    Assert.IsTrue(inserted);
        //}

        [TestMethod]
        public void GetTest()
        {
            //Arrange
            DBJobCV dbJobCV = new DBJobCV();

            //Act
            JobCV jobCv = dbJobCV.Get(1);

            //Assert
            Assert.IsNotNull(jobCv);

        }
    }
}
