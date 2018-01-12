using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class JobExperienceCtr : IController<JobExperience>
    {
        //Instance variables
        DBJobExperience dbJobExperience = new DBJobExperience();

        /// <summary>
        /// Creates a new JobExperience in the database.
        /// </summary>
        /// <param name="obj"></param>
        public bool Create(JobExperience obj)
        {
            return dbJobExperience.Create(obj);
        }

        /// <summary>
        /// Deletes a specific JobExperience in the database by the given id.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            dbJobExperience.Delete(id);
        }

        /// <summary>
        /// Returns a single JobExperience object from the database by the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>JobExperience</returns>
        public JobExperience Get(int id)
        {
            return dbJobExperience.Get(id);
        }

        /// <summary>
        /// Returns a list of all JobExperience that has a relation to the JobCVId from a specific Applier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List of JobExperience</returns>
        public List<JobExperience> GetAllByJobCVId(int id)
        {
            return dbJobExperience.GetAllByJobCVId(id);
        }

        /// <summary>
        /// Returns a list of all JobExperience in the database.
        /// </summary>
        /// <returns>List of all JobExperience</returns>
        public List<JobExperience> GetAll()
        {
            return dbJobExperience.GetAll();
        }

        /// <summary>
        /// Updates the given JobExperience object in the database.
        /// </summary>
        /// <param name="obj"></param>
        public bool Update(JobExperience obj)
        {
            return dbJobExperience.Update(obj);
        }
    }
}
