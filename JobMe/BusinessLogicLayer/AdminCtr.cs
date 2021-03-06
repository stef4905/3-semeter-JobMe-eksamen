﻿using System;
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

        /// <summary>
        /// Create a admin login
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Create(Admin obj)
        {
            return dbAdmin.Create(obj);
        }

        /// <summary>
        /// Deletes a specific Admin by id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            dbAdmin.Delete(id);
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

        /// <summary>
        /// Returns All Admins
        /// </summary>
        /// <returns></returns>
        public List<Admin> GetAll()
        {
            return dbAdmin.GetAll();
        }

        /// <summary>
        /// Update an admin in DB
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Update(Admin obj)
        {
            return dbAdmin.Update(obj);
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
