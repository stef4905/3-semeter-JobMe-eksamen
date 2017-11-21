using System;
using System.Collections.Generic;
using System.Text;
using ModelLayer;
using DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.DataAccessLayer
{
    [TestClass]
    public class DBCompanyTest
    {
        [TestMethod]
        public void CompanyCreateDBTest()
        {
            //Arrange
            DbCompany dbCompany = new DbCompany();
            Company company = new Company("imacompany@gmai.om", "hellopassword");

            //Act
            bool inserted = dbCompany.Create(company);

            //Assert
            Assert.IsTrue(inserted);
        }
    }
}
