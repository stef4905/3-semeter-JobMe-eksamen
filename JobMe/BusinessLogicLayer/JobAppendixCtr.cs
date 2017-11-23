using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class JobAppendixCtr : IController<JobAppendix>
    {

        //Instance variables
        DBJobAppendix dbJobAppendix = new DBJobAppendix();

        /// <summary>
        /// Creates a JobAppendix in the database.
        /// </summary>
        /// <param name="obj"></param>
        public void Create(JobAppendix obj)
        {
            dbJobAppendix.Create(obj);
        }

        /// <summary>
        /// Deletes a specific JobAppendix in the database by the given id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Returns a single JobAppendix from the database by the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JobAppendix Get(int id)
        {
            return dbJobAppendix.Get(id);
        }

        /// <summary>
        /// Returns a list of aa JobAppendix on a single JobCVId that are located on the Applier
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List of JobAppendix</returns>
        public List<JobAppendix> GetAllByJobCVId(int id)
        {
            return dbJobAppendix.GetAllByJobCVId(id); 
        }

        /// <summary>
        /// Returns a list of all JobAppendix from the database
        /// </summary>
        /// <returns>List of all JobAppendix</returns>
        public List<JobAppendix> GetAll()
        {
            return dbJobAppendix.GetAll();
        }

        /// <summary>
        /// Updates the given JobAppendix in the database
        /// </summary>
        /// <param name="obj"></param>
        public void Update(JobAppendix obj)
        {
            dbJobAppendix.Update(obj);
        }
    }
}
