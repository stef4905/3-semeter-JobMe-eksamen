using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using ModelLayer;
using DataAccessLayer;

namespace UnitTest.DataAccessLayer
{
    [TestClass]
    public class DBJobPostTest
    {
        [TestMethod]
        public void CreateJobPostDBTest()
        {
            //Arrange
            DbCompany dbCompany = new DbCompany();
            Company company = new Company("imacompany@gmai.om", "hellopassword");
            company.Id = 1;
            WorkHours workHours = new WorkHours();
            workHours.Id = 1;
            JobCategory jobCategory = new JobCategory();
            jobCategory.Id = 1;


            string iDate = "05/05/2018";
            DateTime oDate = Convert.ToDateTime(iDate);
            DateTime nowDate = oDate;
          //  JobPost jobPost = new JobPost(1, "Test job1", "Et job for dig", nowDate, oDate, "Wc Vasker", workHours, "Her", company, jobCategory);



            //Act
            //bool inserted = dbCompany.createJobPost(jobPost);

            //Assert
            // Assert.IsTrue(inserted);
        }

        [TestMethod]
        public void FindAllJobPost()
        {
            //Arrange


            //Act

            //Assert
        }
    }
}
