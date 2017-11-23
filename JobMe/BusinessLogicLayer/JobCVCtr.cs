using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class JobCVCtr : IController<JobCV>
    {
        //Insatance variables
        public DBJobCV dbJobCV = new DBJobCV();
        public JobExperienceCtr jobExperienceCtr = new JobExperienceCtr();
        public ApplierEducationCtr applierEducationCtr = new ApplierEducationCtr();
        public JobAppendixCtr jobAppendixCtr = new JobAppendixCtr();

        /// <summary>
        /// Creates a new JobCV in the database returns the Primary key on the Applier.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="applier"></param>
        /// <returns>Applier</returns>
        public Applier CreateAndReturnPrimaryKey(JobCV obj, Applier applier)
        {
            Applier applierReturned = dbJobCV.Create(obj, applier);
            return applierReturned;
        }

        /// <summary>
        /// Creates a ned jobCV with no independence on an Applier in the database. This wil not be added to any Applier.
        /// </summary>
        /// <param name="obj"></param>
        public void Create(JobCV obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a single JobCV in the database by the given id.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Returns a single JobCV from the database by the given id.
        /// </summary>
        /// <param name="applierId"></param>
        /// <returns></returns>
        public JobCV Get(int applierId)
        {
            JobCV jobCV = dbJobCV.Get(applierId);
            return jobCV;
        }

        /// <summary>
        /// Return a list of all JobCV from the database
        /// </summary>
        /// <returns>List of all JobCV</returns>
        public List<JobCV> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the given JobCV object in the database
        /// </summary>
        /// <param name="obj"></param>
        public void Update(JobCV obj)
        {
            dbJobCV.Update(obj);

            foreach (var Experience in obj.JobExperienceList)
            {
                jobExperienceCtr.Update(Experience);
            }
            foreach (var Education in obj.ApplierEducationList)
            {
                applierEducationCtr.Update(Education);
            }
            foreach (var Appendix in obj.JobAppendixList)
            {
                jobAppendixCtr.Update(Appendix);
            }
        }
    }
}
