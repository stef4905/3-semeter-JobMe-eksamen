using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class ApplierEducationCtr : IController<ApplierEducation>
    {
        //Instance variables
        DBApplierEducation dbApplierEducation = new DBApplierEducation();

        /// <summary>
        /// Creates a new ApplierEducation object in the database.
        /// </summary>
        /// <param name="obj"></param>
        public bool Create(ApplierEducation obj)
        {
            return dbApplierEducation.Create(obj);
        }

        /// <summary>
        /// Deletes a ApplierEducation in the database using the given id.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            dbApplierEducation.Delete(id);
        }

        /// <summary>
        /// Returns a single ApplierEducation from the database using the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ApplierEducation</returns>
        public ApplierEducation Get(int id)
        {
            return dbApplierEducation.Get(id);
        }

        /// <summary>
        /// Returns a list of all ApplierEducation obejcts that are corospoding with a single JobCVId. This is located on the specific Applier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List of ApplierEducation</returns>
        public List<ApplierEducation> GetAllByJobCVId(int id)
        {
            return dbApplierEducation.GetAllByJobCVId(id);
        }

        /// <summary>
        /// Returns a list of all ApplierEducations in the database.
        /// </summary>
        /// <returns>List of ApplierEducation</returns>
        public List<ApplierEducation> GetAll()
        {
            return dbApplierEducation.GetAll();
        }

        /// <summary>
        /// Updates the ApplierEducation object in the database.
        /// </summary>
        /// <param name="obj"></param>
        public bool Update(ApplierEducation obj)
        {
            return dbApplierEducation.Update(obj);
        }
    }
}
