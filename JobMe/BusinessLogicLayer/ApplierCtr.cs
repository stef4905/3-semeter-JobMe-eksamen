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
        public bool Create(Applier obj)
        {
            try
            {
                Applier applier = dbApplier.CreateAndReturnApplier(obj);
                applier.Birthdate = DateTime.Now;
                applier.JobCV = new JobCV(0, "Ikke endnu redigeret", "Bio tekst");

                Applier applierReturned = jobCVCtr.CreateAndReturnPrimaryKey(applier.JobCV, applier);
                Update(applierReturned);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }



        }


        /// <summary>
        /// Deletes a Applier in the database using the given id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            dbApplier.Delete(id);
        }

        /// <summary>
        /// Returns the whole applier and Jobcategory list for the specific applier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Applier object</returns>
        public Applier Get(int id)
        {
            Applier applier = dbApplier.Get(id);
            if (applier.JobCV != null)
            {
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
            return dbApplier.GetAll();
        }

        /// <summary>
        /// Updates Applier in the database.
        /// </summary>
        /// <param name="obj"></param>
        public bool Update(Applier obj)
        {

            bool updated = dbApplier.Update(obj);
            if (updated == true)
            {
                if (obj.JobCategoryList != null)
                {
                    UpdateApplierJobCategories(obj);
                }
                return true;
            }

            else
            {
                return false;
            }

        }

        public void UpdateApplierJobCategories(Applier obj)
        {

            dbApplier.DeleteApplierJobCategories(obj.Id);



            foreach (var item in obj.JobCategoryList)
            {
                dbApplier.CreateApplierJobCategories(item.Id, obj.Id);
            }


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

        /// <summary>
        /// Return the number of rows in the Applier table in the database
        /// </summary>
        /// <returns></returns>
        public int GetApplierTableSize()
        {
            return dbApplier.GetApplierTableSize();
        }


        /// <summary>
        /// Updates the given Appleir objects password
        /// </summary>
        /// <param name="applier"></param>
        public void UpdatePassword(Applier applier)
        {
            dbApplier.UpdatePassword(applier);
        }
    }
}
