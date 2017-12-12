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

        [TestMethod]
        public void CompanyCreateTest()
        {
            //Arrange
            CompanyCtr companyCtr = new CompanyCtr();
            Company company = new Company("mathias@mat.dk", "123");

            //Act
            bool check = companyCtr.Create(company);

            //Assert
            Assert.IsNotNull(check);
        }

        [TestMethod]
        public void CompanyUpdateTest()
        {
            //Arrange
            CompanyCtr companyCtr = new CompanyCtr();
            BusinessType businessType = new BusinessType
            {
                Id = 1
            };
            Company company = new Company
            {
                Id = 1017,
                Email = "Jeger@opdateret.dk",
                Password = "nyt",
                Phone = 12345678,
                Address = "Viljevej 67A",
                Country = "Deutchland",
                ImageURL = "",
                Description = "Hvor der er vilje er viljevej",
                BannerURL = "asdasdasd",
                MaxRadius = 20,
                Homepage = "Deter.dk",
                CompanyName = "Steffens firma",
                CVR = 123123123,
                businessType = businessType
            };

            //Act
            bool check = companyCtr.Update(company);

            //Assert
            Assert.IsTrue(check);
        }

        [TestMethod]
        public void CompanyDeleteTest()
        {
            //Assert
            CompanyCtr companyCtr = new CompanyCtr();

            //Act
            companyCtr.Delete(1018);
            Company company = companyCtr.Get(1018);

            //Assert
            Assert.IsNull(company.Email);
        }

        [TestMethod]
        public void CompanyGetByIdTest()
        {
            //Arrange
            CompanyCtr companyCtr = new CompanyCtr();
            Company company = new Company();

            //Act
            company = companyCtr.Get(1016);

            //Assert
            Assert.AreEqual(company.Id, 1016);
        }

    }
}
