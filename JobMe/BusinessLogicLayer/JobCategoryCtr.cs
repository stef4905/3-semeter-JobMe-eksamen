using DataAccessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class JobCategoryCtr : IController<JobCategory>
    {
        //Instance variables
        DbJobCategory dbJobCategory = new DbJobCategory();

        /// <summary>
        /// Creates a new JobCategory object in the database
        /// </summary>
        /// <param name="obj"></param>
        public bool Create(JobCategory obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a JobCategory in the database by the given id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a single JobCategory by the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>JobCategory</returns>
        public JobCategory Get(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Is a method that calls the GetAll method from the DbAccesLayer
        /// </summary>
        /// <returns></returns>
        public List<JobCategory> GetAll()
        {
            return dbJobCategory.GetAll();
        }

        /// <summary>
        /// Updates the given JobCategory object in the database
        /// </summary>
        /// <param name="obj"></param>
        public bool Update(JobCategory obj)
        {
            throw new NotImplementedException();
        }
    }
}
