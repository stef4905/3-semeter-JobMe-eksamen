using DataAccessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class ApplierCtr : IController<Applier>
    {
        //Instance Variables
        public DbApplier dbApplier = new DbApplier();
        public JobCVCtr jobCVCtr = new JobCVCtr();

        /// <summary>
        /// Inserts the Applier in the database.
        /// </summary>
        /// <param name="obj"></param>
        public void Create(Applier obj)
        {
                Applier applier = dbApplier.CreateAndReturnApplier(obj);
                applier.Birthdate = DateTime.Now;
                applier.JobCV = new JobCV(0, "Ikke endnu redigeret", 0, "Bio tekst");
                Applier applierReturned = jobCVCtr.CreateAndReturnPrimaryKey(applier.JobCV, applier);
                Update(applierReturned);      
         }


        /// <summary>
        /// Deletes a Applier in the database using the given id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the whole applier and Jobcategory list for the specific applier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Applier object</returns>
        public Applier Get(int id)
        {
            Applier applier = dbApplier.Get(id);
            if(applier.JobCV != null) { 
            applier.JobCV = jobCVCtr.Get(applier.JobCV.Id);
            }
            return applier;
        }

        /// <summary>
        /// Returns a List of all Appliers in the database.
        /// </summary>
        /// <returns>List of Appliers</returns>
        public List<Applier> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates Applier in the database.
        /// </summary>
        /// <param name="obj"></param>
        public void Update(Applier obj)
        {
            dbApplier.Update(obj);
        }


        /// <summary>
        /// returns an Appiler with the given param from the login
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Applier Login(string email, string password)
        {
            return dbApplier.Login(email, password);
        }
    }
}
