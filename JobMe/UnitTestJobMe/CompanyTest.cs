using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayer;
using DataAccessLayer;
using BusinessLogicLayer;

namespace UnitTestJobMe
{
    [TestClass]
    public class CompanyTest
    {
        [TestMethod]
        public void CompanygetAllTest()
        {
            //Arrange
            CompanyCtr companyCtr = new CompanyCtr();
            List<Company> companyList = new List<Company>();

            //Act
            companyList = companyCtr.GetAll();

            //Assert
            Assert.IsNotNull(companyList);
        }
    }
}
