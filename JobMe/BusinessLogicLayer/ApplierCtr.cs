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
        //Connection to database
        public static DbConnection DbConnection = new DbConnection();

        public DbApplier dbApplier = new DbApplier(DbConnection);
        public JobCVCtr jobCVCtr = new JobCVCtr();

        public void Create(Applier obj)
        {
            try {
                Applier applier = dbApplier.CreateAndReturnApplier(obj);
                Applier applierReturned = jobCVCtr.CreateAndReturnPrimaryKey(new JobCV(), applier);
                Update(applierReturned);
            } catch (Exception exeption)
            {
                throw exeption;
            }



         }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the whole applier and Jobcategory list for the specific applier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Applier Get(int id)
        {
            Applier applier = dbApplier.Get(id);
           applier.JobCV = jobCVCtr.Get(applier.Id);
            return applier;
        }

        public List<Applier> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Applier obj)
        {
            dbApplier.Update(obj);
        }


        /// <summary>
        /// returns an Appiler with the given param
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
