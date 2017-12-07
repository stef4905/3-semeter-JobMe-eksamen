using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class AdminCtr : IController<Admin>
    {
        DbAdmin dbAdmin = new DbAdmin();

        public bool Create(Admin obj)
        {
            return dbAdmin.Create(obj);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the specific Admin.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Applier object</returns>
        public Admin Get(int id)
        {
            Admin admin = dbAdmin.Get(id);
            return admin;
        }

        public List<Admin> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Admin obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// returns an Admin with the given param from the login
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Admin Login(string username, string password)
        {
            return dbAdmin.Login(username, password);
        }
    }
}
