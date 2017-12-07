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

        /// <summary>
        /// Unit Test om admin update
        /// </summary>
        [TestMethod]
        public void AdminUpdateDBTest()
        {

            //Arrange
            AdminCtr adminCtr = new AdminCtr();
            Admin admin = new Admin
            {
                Id = 1,
                Username = "TheOne",
                Password = "Neo123",
                FName = "Chris",
                LName = "Tucker",
                Email = "InThe@Matrix.dk"
            };

            //Act
            bool updated = adminCtr.Update(admin);

            //Assert
            Assert.IsTrue(updated);
        }

        public void AdminDeleteDBTest()
        {
            //Arrange
            AdminCtr adminCtr = new AdminCtr();

            //Act
            adminCtr.Delete(1);
            Admin deleted = adminCtr.Delete(1);

            //Assert
            Assert.IsNull(deleted);
        }
        
    }
}
