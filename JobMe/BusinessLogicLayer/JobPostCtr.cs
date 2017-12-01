﻿using DataAccessLayer;
using ModelLayer;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class JobPostCtr
    {

        //Instance Variables
        private DbJobPost dbJobPost = new DbJobPost();

        /// <summary>
        /// Creates the given JobPost object in the database.
        /// </summary>
        /// <param name="obj"></param>
        public void Create(JobPost obj)
        {
            dbJobPost.Create(obj);
        }

        /// <summary>
        /// Deletes a specific JobPost in the database by the given id.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a single JobPost object from the database by the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JobPost Get(int id)
        {
            return dbJobPost.Get(id);
        }

        /// <summary>
        /// Returns a list of all JobPost in the database.
        /// </summary>
        /// <returns></returns>
        public List<JobPost> GetAll()
        {
            return dbJobPost.GetAll();
        }

        /// <summary>
        /// Updates the given JobPost object in the database.
        /// </summary>
        /// <param name="obj"></param>
        public void Update(JobPost obj)
        {
            throw new NotImplementedException();
        }
    }
}
