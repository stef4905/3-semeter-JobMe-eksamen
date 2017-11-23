using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ModelLayer;
using BusinessLogicLayer;

namespace WCFJobMeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "JobCVService" in both code and config file together.
    public class JobCVService : IJobCVService
    {
        JobCVCtr jobCVCtr = new JobCVCtr();

        /// <summary>
        /// Creates a new JobCV in the database returns the Primary key on the Applier.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="applier"></param>
        /// <returns>Applier</returns>
        public Applier CreateAndReturnPrimaryKey(JobCV obj, Applier applier)
        {
            return jobCVCtr.CreateAndReturnPrimaryKey(obj, applier);
        }

        /// <summary>
        /// Creates a ned jobCV with no independence on an Applier in the database. This wil not be added to any Applier.
        /// </summary>
        /// <param name="obj"></param>
        public void Create(JobCV jobCV)
        {
            jobCVCtr.Create(jobCV);
        }

        /// <summary>
        /// Deletes a single JobCV in the database by the given id.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            jobCVCtr.Delete(id);
        }

        /// <summary>
        /// Returns a single JobCV from the database by the given id.
        /// </summary>
        /// <param name="applierId"></param>
        /// <returns></returns>
        public JobCV Get(int applierId)
        {
            return jobCVCtr.Get(applierId);
        }

        /// <summary>
        /// Return a list of all JobCV from the database
        /// </summary>
        /// <returns>List of all JobCV</returns>
        public List<JobCV> GetAll()
        {
            return jobCVCtr.GetAll();
        }

        /// <summary>
        /// Updates the given JobCV object in the database
        /// </summary>
        /// <param name="obj"></param>
        public void Update(JobCV obj)
        {
            jobCVCtr.Update(obj); ;
        }
    }
}
