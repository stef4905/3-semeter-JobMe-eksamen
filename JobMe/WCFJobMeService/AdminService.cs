using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BusinessLogicLayer;
using ModelLayer;

namespace WCFJobMeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AdminService" in both code and config file together.
    public class AdminService : IAdminService
    {
        AdminCtr adminCtr = new AdminCtr();

        /// <summary>
        /// Create admin
        /// </summary>
        /// <param name="admin"></param>
        public void Create(Admin admin)
        {
            adminCtr.Create(admin);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a single Admin object with the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Admin GetAdmin(int id)
        {
            return adminCtr.Get(id);
        }

        public List<Admin> GetAllAdmin()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///  Get a Admin object, from the login method with the given params
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Admin Login(string username, string password)
        {
            return adminCtr.Login(username, password);
        }

        /// <summary>
        /// Update admin
        /// </summary>
        /// <param name="admin"></param>
        public void Update(Admin admin)
        {
            adminCtr.Update(admin);
        }
    }
}
