using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayer;
using DataAccessLayer;
using BusinessLogicLayer;

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

        /// <summary>
        /// Test on create admin
        /// </summary>
        [TestMethod]
        public void AdminCreateDBTest()
        {
            //Arrange
            AdminCtr adminCtr = new AdminCtr();
            Admin admin = new Admin("Boss", "123", "Finn", "Larsen", "FinnLarsen@email.dk");

            //Act
            bool inserted = adminCtr.Create(admin);

            //Assert
            Assert.IsTrue(inserted);
        }

        [TestMethod]
        public void AdminUpdateDBTest()
        {

            //Arrange
            AdminCtr adminCtr = new AdminCtr();
            Admin admin = new Admin("TheOne", "Neo123", "Chris", "Tucker", "InThe@Matrix.dk");

            //Act
            

            //Assert

        }
        
    }
}
