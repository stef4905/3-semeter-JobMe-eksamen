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
        private BusinessTypeCtr BusinessTypeCtr = new BusinessTypeCtr();

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

        /// <summary>
        /// Returns a int (count) for the numbers of rows of companies in the database
        /// </summary>
        /// <returns></returns>
        public int GetCompanyTableSize()
        {
            return companyCtr.GetCompanyTableSize();
        }
        #endregion

        #region BusinessType Service
        /// <summary>
        /// Creates a new BusinessType in the database by the given object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>bool</returns>
        public bool CreateBusinessType(BusinessType obj)
        {
            return BusinessTypeCtr.Create(obj);
        }

        /// <summary>
        /// Returns a specific BusinessType from the database by the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>BusinessType</returns>
        public BusinessType GetBusinessType(int id)
        {
            return BusinessTypeCtr.Get(id);
        }

        /// <summary>
        /// Returns a list of all BusinessType in the database
        /// </summary>
        /// <returns>List<BusinessType></returns>
        public List<BusinessType> GetAllBusinessType()
        {
            return BusinessTypeCtr.GetAll();
        }

        /// <summary>
        /// Updates the given BusinessType object in the database
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>bool</returns>
        public bool UpdateBusinessType(BusinessType obj)
        {
            return BusinessTypeCtr.Update(obj);
        }

        /// <summary>
        /// Deletes a specific BusinessType from the database by the given id
        /// </summary>
        /// <param name="id"></param>
        public void DeleteBusinessType(int id)
        {
            BusinessTypeCtr.Delete(id);
        }
        #endregion


    }
}

