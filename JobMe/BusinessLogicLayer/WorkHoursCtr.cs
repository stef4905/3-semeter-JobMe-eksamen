using DataAccessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class WorkHoursCtr : IController<WorkHours>
    {
        //Instance variables
        DbWorkHour dbWorkHour = new DbWorkHour();

        /// <summary>
        /// Creates the given WorkHours object in the database.
        /// </summary>
        /// <param name="obj"></param>
        public void Create(WorkHours obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a specific WorkHours object from the database by the given id.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a single WorkHours object from the database by the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>WorkHours</returns>
        public WorkHours Get(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reutns a list of all WorkHours from the database.
        /// </summary>
        /// <returns></returns>
        public List<WorkHours> GetAll()
        {
           return dbWorkHour.GetAll();
        }

        /// <summary>
        /// Updates the given WorkHours object in the database.
        /// </summary>
        /// <param name="obj"></param>
        public void Update(WorkHours obj)
        {
            throw new NotImplementedException();
        }
    }
}
