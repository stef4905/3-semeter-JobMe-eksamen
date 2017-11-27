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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "JobApplicationService" in both code and config file together.
    public class JobApplicationService : IJobApplicationService
    {
        JobApplicationCtr jobAppCtr = new JobApplicationCtr();

        /// <summary>
        /// Accept er decline Job Application method, makes the Company able to accept or decline applications to their specific jobposts.
        /// </summary>
        /// <param name="jobApplication"></param>
        /// <param name="jobPost"></param>
        /// <param name="acceptApplication"></param>
        public void AcceptDeclineJobApplication(JobApplication jobApplication, JobPost jobPost, bool acceptApplication)
        {
            jobAppCtr.AcceptDeclineJobApplication(jobApplication, jobPost, acceptApplication);
        }

        /// <summary>
        /// Create a JobApplication
        /// </summary>
        /// <param name="jobApplication"></param>
        public void Create(JobApplication jobApplication)
        {
            jobAppCtr.Create(jobApplication);
        }

        /// <summary>
        /// Deletes a JobApplication by the given id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            jobAppCtr.Delete(id);
        }

        /// <summary>
        /// Return a Job application by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JobApplication Get(int id)
        {
            return jobAppCtr.Get(id);
        }

        /// <summary>
        /// Gets an object and executes the "GetAllByApplierId" in the JobApplicationCtr Class
        /// 
        /// </summary>
        /// <param name="applierId"></param>
        /// <returns></returns>
        public List<JobApplication> GetAllByApplierId(int applierId)
        {
            return jobAppCtr.GetAllByApplierId(applierId);
        }

        /// <summary>
        /// Returns all JobApplications from a specific JobPost
        /// </summary>
        /// <param name="jobPostId"></param>
        /// <returns></returns>
        public List<JobApplication> GetAllJobApplicationToAJobPost(int jobPostId)
        {
            return jobAppCtr.GetAllJobApplicationToAJobPost(jobPostId);
        }

        /// <summary>
        /// Takes a JobApplication and "attaches" it to a specific JobPost
        /// </summary>
        /// <param name="jobApplication"></param>
        /// <param name="jobPost"></param>
        public void SendApplication(JobApplication jobApplication, JobPost jobPost)
        {
            jobAppCtr.SendApplication(jobApplication, jobPost);
        }

        /// <summary>
        /// Updates the given JobApplication in the database.
        /// </summary>
        /// <param name="obj"></param>
        public void Update(JobApplication obj)
        {
            jobAppCtr.Update(obj);
        }
    }
}
