using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class SessionCtr
    {
        DBSession DbSession = new DBSession();

        /// <summary>
        /// Creates a new session in the database
        /// </summary>
        /// <param name="session"></param>
        /// <param name="booking"></param>
        /// <returns>bool</returns>
        public bool Create(Session session, Booking booking)
        {
            return DbSession.Create(session, booking);
        }

        public Booking Get(int id)
        {
            return DbSession.Get(id);
        }

        public List<Session> GetAll(int id)
        {
            return DbSession.GetAll(id);
        }

        public bool Delete(int id)
        {
            return DbSession.Delete(id);
        }

        public bool Update(Booking booking)
        {
            return DbSession.Update(booking);
        }
    }
}
