﻿using System;
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
        [TestMethod]
        public void ApplierCreateDBTest()
        {
            //Arrange
            ApplierCtr ctrApplier = new ApplierCtr();
            Applier applier = new Applier("Sofie", "123", 20);
          

            //Act
            ctrApplier.Create(applier);
            Applier returned = ctrApplier.Get(applier.Id);
            //Assert
            Assert.IsNotNull(returned);
        }

        [TestMethod]
        public void ApplierUpdateDBTest()
        {
            //Arrange
            DbApplier dbApplier = new DbApplier();

            JobCV jobCV = new JobCV
            {
                Id = 1
            };

            Applier applier = new Applier
            {
                Id = 6,
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
                JobCV = jobCV,   
            };

            //Act
            bool check = dbApplier.Update(applier);

            //Assert
            Assert.IsTrue(check);
        }

        [TestMethod]
        public void ApplierGetById()
        {
            //Arrange
            DbApplier dbApplier = new DbApplier();
            Applier applier = new Applier();

            //Act
            applier = dbApplier.Get(2);

            //Assert
            Assert.AreEqual(applier.Id, 2);
        }


        [TestMethod]
        public void DeleteApplier()
        {
            //Arrange
            DbApplier dbApplier = new DbApplier();
            Applier applier = new Applier();

            //Act
            dbApplier.Delete(2);
            Applier deleted = dbApplier.Get(2);

            //Assert
            Assert.IsNull(deleted);

     
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
