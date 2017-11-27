using BusinessLogicLayer;
using ModelLayer;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFJobMeService
{

    public class CompanyService : ICompanyService
    {
        private CompanyCtr companyCtr = new CompanyCtr();
        private WorkHoursCtr workHoursCtr = new WorkHoursCtr();
        private JobCategoryCtr jobCategoryCtr = new JobCategoryCtr();
        private JobPostCtr jobPostCtr = new JobPostCtr();

        #region Company service

        /// <summary>
        /// Creates an object and executes the Create Method in the CompanyCtr Class
        /// And puts the object into the database!
        /// </summary>
        /// <param name="company"></param>
        public void CreateCompany(Company company)
        {
            companyCtr.Create(company);
        }

        /// <summary>
        /// Deletes a specific company by the given id
        /// </summary>
        /// <param name="id"></param>
        public void DeleteCompany(int id)
        {
            companyCtr.Delete(id);
        }

        /// <summary>
        /// Returns a specific Company from the database by the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Company GetCompany(int id)
        {
            return companyCtr.Get(id);
        }

        /// <summary>
        /// Returns a list of all Company objects in the database
        /// </summary>
        /// <returns>List of Company</returns>
        public List<Company> GetAllCompany()
        {
           return companyCtr.GetAll();
        }

        /// <summary>
        /// Updates the Company in the database
        /// </summary>
        /// <param name="obj"></param>
        public void UpdateCompany(Company obj)
        {
            companyCtr.Update(obj);
        }

        /// <summary>
        /// Get a applier object, from the login method with the given params
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Company Login(string email, string password)
        {
            return companyCtr.Login(email, password);
        }

        #endregion

        #region JobPost Service
        /// <summary>
        /// Creates an object and executes the CreateJobPost Method in the CompanyCtr Class
        /// And puts the object into the database.
        /// </summary>
        /// <param name="jobPost"></param>
        public void CreateJobPost(JobPost jobPost)
        {
            jobPostCtr.Create(jobPost);
        }

        /// <summary>
        /// Deletes a specific JobPost in the database by the given id.
        /// </summary>
        /// <param name="id"></param>
        public void DeleteJobPost(int id)
        {
            jobPostCtr.Delete(id);
        }

        /// <summary>
        /// Returns a list of all JobPost in the database.
        /// </summary>
        /// <returns></returns>
        public List<JobPost> GetAllJobPost()
        {
           return jobPostCtr.GetAll();
        }

        /// <summary>
        /// Updates the given JobPost object in the database.
        /// </summary>
        /// <param name="obj"></param>
        public void UpdateJobPost(JobPost obj)
        {
            jobPostCtr.Update(obj);
        }

        /// <summary>
        /// Returns a single JobPost object from the database by the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JobPost GetJobPost(int id)
        {
           return jobPostCtr.Get(id);
        }


        #endregion

        #region JobCategory Service

        /// <summary>
        /// Creates a new JobCategory object in the database
        /// </summary>
        /// <param name="obj"></param>
        public void CreateJobCategory(JobCategory obj)
        {
            jobCategoryCtr.Create(obj);
        }

        /// <summary>
        /// Deletes a JobCategory in the database by the given id
        /// </summary>
        /// <param name="id"></param>
        public void DeleteJobCategory(int id)
        {
            jobCategoryCtr.Delete(id);
        }

        /// <summary>
        /// Returns a single JobCategory by the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>JobCategory</returns>
        public JobCategory GetJobCategory(int id)
        {
            return jobCategoryCtr.Get(id);
        }

        /// <summary>
        /// Gets all objects and from the GetAll Method in the JobPostCtr Class
        /// And gets all the object from the database.
        /// </summary>
        /// <returns></returns>
        public List<JobCategory> GetAllJobCategories()
        {
            return jobCategoryCtr.GetAll();
        }

        /// <summary>
        /// Updates the given JobCategory object in the database
        /// </summary>
        /// <param name="obj"></param>
        public void UpdateJobCategory(JobCategory obj)
        {
            jobCategoryCtr.Update(obj);
        }

        #endregion

        #region WorkHours Service
        /// <summary>
        /// Creates the given WorkHours object in the database.
        /// </summary>
        /// <param name="obj"></param>
        public void CreateWorkHours(WorkHours obj)
        {
            workHoursCtr.Create(obj);
        }

        /// <summary>
        /// Deletes a specific WorkHours object from the database by the given id.
        /// </summary>
        /// <param name="id"></param>
        public void DeleteWorkHours(int id)
        {
            workHoursCtr.Delete(id);
        }

        /// <summary>
        /// Returns a single WorkHours object from the database by the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>WorkHours</returns>
        public WorkHours GetWorkHours(int id)
        {
           return  workHoursCtr.Get(id);
        }

        /// <summary>
        /// Gets all objects and from the GetAll Method in the WorkHoursCtr Class
        /// And gets all the object from the database.
        /// </summary>
        /// <returns></returns>
        public List<WorkHours> GetlAllWorkHours()
        {
            return workHoursCtr.GetAll();
        }

        /// <summary>
        /// Updates the given WorkHours object in the database.
        /// </summary>
        /// <param name="obj"></param>
        public void UpdateWorkHours(WorkHours obj)
        {
            workHoursCtr.Update(obj);
        }

        #endregion

    }
}

