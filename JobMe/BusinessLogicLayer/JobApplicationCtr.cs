using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class JobApplicationCtr : IController<JobApplication>
    {
        //Instance variavbles
        private DbJobApplication dbJobApplication = new DbJobApplication();

        /// <summary>
        /// Creates a jobapplication by calling the method Jobapplication in DBAccesLayer.
        /// </summary>
        /// <param name="obj"></param>
        public void Create(JobApplication obj)
        {
            dbJobApplication.Create(obj);
        }

        /// <summary>
        /// Deletes a JobApplication by the given id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            dbJobApplication.Delete(id);
        }

        /// <summary>
        /// Returns a single JobApplication object from the database by the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>JobApplictaion</returns>
        public JobApplication Get(int id)
        {
            return dbJobApplication.Get(id);
        }

        /// <summary>
        /// Returns a list of all JobApplications from the database.
        /// </summary>
        /// <returns>List of all JobApplication</returns>
        public List<JobApplication> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a list of all JobApplications that has the related applierId.
        /// </summary>
        /// <param name="applierId"></param>
        /// <returns>List of JobApplication</returns>
        public List<JobApplication> GetAllByApplierId(int applierId)
        {
            return dbJobApplication.GetAllByApplierId(applierId);
        }

        /// <summary>
        /// Updates the given JobApplication in the database.
        /// </summary>
        /// <param name="obj"></param>
        public void Update(JobApplication obj)
        {
            dbJobApplication.Update(obj);
        }

        /// <summary>
        /// Takes a specific JobApplication and attaches it to a JobPost
        /// </summary>
        /// <param name="jobApplication"></param>
        /// <param name="jobPost"></param>
        public void SendApplication(JobApplication jobApplication, JobPost jobPost)
        {
            dbJobApplication.SendApplication(jobApplication, jobPost);
        }

        /// <summary>
        /// Returns all JobApplications from a specific JobPost
        /// </summary>
        /// <param name="jobPostId"></param>
        /// <returns></returns>
        public List<JobApplication> GetAllJobApplicationToAJobPost(int jobPostId)
        {
            return dbJobApplication.GetAllJobApplicationToAJobPost(jobPostId);
        }

        /// <summary>
        /// Accept er decline Job Application method, makes the Company able to accept or decline applications to their specific jobposts.
        /// </summary>
        /// <param name="jobApplication"></param>
        /// <param name="jobPost"></param>
        /// <param name="acceptApplication"></param>
        public void AcceptDeclineJobApplication(JobApplication jobApplication, JobPost jobPost, bool acceptApplication)
        {
            dbJobApplication.AcceptDeclineJobApplication(jobApplication, jobPost, acceptApplication);
        }
    }
}
