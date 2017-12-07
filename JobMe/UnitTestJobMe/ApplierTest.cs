using System;
using System.Collections.Generic;
using System.Text;
using ModelLayer;
using DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogicLayer;

namespace UnitTest.DataAccessLayer
{
    [TestClass]
    public class DBApplierTest
    {

        /// <summary>
        /// Testing the creation of a applier in the database. by going through the controller. 
        /// The controller method reurns a bool (boolean) that will be true if the create method was succesfull.
        /// Then the bool is tested with the IsTrue, where the test will pass if the bool is returned true.
        /// </summary>
        [TestMethod]
        public void ApplierCreateDBTest()
        {
            //Arrange
            ApplierCtr ctrApplier = new ApplierCtr();
            Applier applier = new Applier("Sofie", "123", 20);
          

            //Act
           bool check = ctrApplier.Create(applier);
           
            //Assert
            Assert.IsNotNull(check);
        }


        /// <summary>
        /// Testing the update method for a Applier.
        /// We start by making the Applier controller that contains the method we need to test.
        /// Then we are  making a new Applier object and giving it the needed information.
        /// The method is tested and returns a bool (true or false) where we check if the bool is true, where the test passes.
        /// </summary>
        [TestMethod]
        public void ApplierUpdateDBTest()
        {
            //Arrange
            ApplierCtr applierCtr = new ApplierCtr();
            JobCategory jobCategory = new JobCategory
            {
                Id = 1
            };
            List<JobCategory> jobCategoryList = new List<JobCategory>();
            jobCategoryList.Add(jobCategory);

            Applier applier = new Applier
            {
                Id = 1094,
                Password = "123456",
                Email = "hej@nej.dk",
                Address = "hejvej 1",
                Country = "BonBonLand",
                ImageURL = "langIndePåNettet",
                Description = "En applier description",
                BannerURL = "LængereIndePåNettet",
                MaxRadius = 20,
                HomePage = "www.Hejvej.dk",
                FName = "Benny",
                LName = "Børge",
                Age = 41,
                Status = true,
                CurrentJob = "HejSigende",
                Birthdate = new DateTime(1989, 09, 11),
                JobCategoryList = jobCategoryList
            };

            //Act
            bool check = applierCtr.Update(applier);

            //Assert
            Assert.IsTrue(check);
        }



        /// <summary>
        /// Testing the get method on Applier. Starting new instanciating a new Applier object.
        /// then the Applier controller has been created where the get method is located. 
        /// We then call the get method that returns a Applier, where we then compare the two object's Id to see if they are the same.
        /// </summary>
        [TestMethod]
        public void ApplierGetById()
        {
            //Arrange
            ApplierCtr ctrApplier = new ApplierCtr();
            Applier applier = new Applier();

            //Act
            applier = ctrApplier.Get(2);

            //Assert
            Assert.AreEqual(applier.Id, 2);
        }

        /// <summary>
        /// Testing the delete method on Applier, thourg the ApplierCtr
        /// </summary>
        [TestMethod]
        public void DeleteApplier()
        {
            //Arrange
            ApplierCtr applierCtr = new ApplierCtr();
      

            //Act
            applierCtr.Delete(1097);
            Applier deleted = applierCtr.Get(1097);

         
            //Assert
            Assert.IsNull(deleted.Email);

     
        }


        [TestMethod]

        public void ApplierLogintest()
        {
            //Arrange
            DbApplier dbApplier = new DbApplier();
            Applier applier = new Applier();

            //Act
            applier = dbApplier.Login("stampe@gmail.com", "123456");

            //Assert
            Assert.AreEqual(applier.Email, "stampe@gmail.com");


        }
    }
}
