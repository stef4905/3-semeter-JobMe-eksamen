﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayer;
using DataAccessLayer;

namespace UnitTestJobMe
{
    /// <summary>
    /// Summary description for AdminTest
    /// </summary>
    [TestClass]
    public class AdminTest
    {

        [TestMethod]
        public void AdminGetById()
        {
            //Arrange
            DbAdmin dbAdmin = new DbAdmin();
            Admin admin = new Admin();

            //Act
            admin = dbAdmin.Get(1);

            //Assert
            Assert.AreEqual(admin.Id, 1);
        }

        [TestMethod]

        public void AdminLogintest()
        {
            //Arrange
            DbAdmin dbAdmin = new DbAdmin();
            Admin admin = new Admin();

            //Act
            admin = dbAdmin.Login("Admin", "123");

            //Assert
            Assert.AreEqual(admin.Username, "Admin");


        }
    }
}