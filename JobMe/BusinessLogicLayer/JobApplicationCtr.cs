using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class JobApplicationCtr : IController<JobApplication>
    {
        //Instance variavbles
        private DbJobApplication dbJobApplication = new DbJobApplication();

        /// <summary>
        /// Creates a jobapplication by calling the method Jobapplication in DBAccesLayer.
        /// </summary>
        /// <param name="obj"></param>
        public void Create(JobApplication obj)
        {
            dbJobApplication.Create(obj);
        }

        /// <summary>
        /// Deletes a JobApplication by the given id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            dbJobApplication.Delete(id);
        }

        /// <summary>
        /// Returns a single JobApplication object from the database by the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>JobApplictaion</returns>
        public JobApplication Get(int id)
        {
            return dbJobApplication.Get(id);
        }

        /// <summary>
        /// Returns a list of all JobApplications from the database.
        /// </summary>
        /// <returns>List of all JobApplication</returns>
        public List<JobApplication> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a list of all JobApplications that has the related applierId.
        /// </summary>
        /// <param name="applierId"></param>
        /// <returns>List of JobApplication</returns>
        public List<JobApplication> GetAllByApplierId(int applierId)
        {
            return dbJobApplication.GetAllByApplierId(applierId);
        }

        /// <summary>
        /// Updates the given JobApplication in the database.
        /// </summary>
        /// <param name="obj"></param>
        public void Update(JobApplication obj)
        {
            dbJobApplication.Update(obj);
        }
    }
}
