using DataAccessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class CompanyCtr : IController<Company>
    {

        //Instance variables
        private DbCompany dbCompany = new DbCompany();

        /// <summary>
        /// Sends an object through the DataAccessLayer, and executes Create Method
        /// </summary>
        /// <param name="obj"></param>
        public bool Create(Company obj)
        {
            return dbCompany.Create(obj);
        }

        /// <summary>
        /// Deletes the Comapny object in the database
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a single Company
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Company Get(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a list of all Company objects in the database
        /// </summary>
        /// <returns>List of Company</returns>
        public List<Company> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the Company in the database
        /// </summary>
        /// <param name="obj"></param>
        public void Update(Company obj)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// return a object through the DataAccessLayer, and find a company with the given param
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Company Login(string email, string password)
        {
            return dbCompany.Login(email, password);
        }
    }
}
