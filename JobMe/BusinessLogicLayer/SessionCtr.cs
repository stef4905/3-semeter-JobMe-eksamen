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
        ApplierCtr ApplierCtr = new ApplierCtr();

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

        /// <summary>
        /// Returns a session from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Session Get(int id)
        {
            Session session = DbSession.Get(id);
            session.Applier = ApplierCtr.Get(session.ApplierId);
            return session;
        }

        /// <summary>
        /// Returns a list of sessions
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Session> GetAll(int id)
        {
            List<Session> sessionList = DbSession.GetAll(id);
            foreach (var session in sessionList)
            {
                session.Applier = ApplierCtr.Get(session.ApplierId);
            }
            return sessionList;
        }

        /// <summary>
        /// Deletes a single Session in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public bool Delete(Session session)
        {
            return DbSession.Delete(session);
        }

        /// <summary>
        /// Updates a session in the database
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public bool Update(Session session)
        {
            return DbSession.Update(session);
        }

        /// <summary>
        /// Removes the current Applier on the given session object.
        /// </summary>
        /// <param name="session"></param>
        /// <returns>bool</returns>
        public bool RemoveApplierFromSession(Session session)
        {
            return DbSession.RemoveApplierFromSession(session);
        }
    }
}
