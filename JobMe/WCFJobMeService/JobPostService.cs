using BusinessLogicLayer;
using ModelLayer;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFJobMeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "JobPostService" in both code and config file together.
    public class JobPostService : IJobPostService
    {
        private WorkHoursCtr workHoursCtr = new WorkHoursCtr();
        private JobCategoryCtr jobCategoryCtr = new JobCategoryCtr();
        private JobPostCtr jobPostCtr = new JobPostCtr();


        #region WorkHours Service

        /// <summary>
        /// Creates the given WorkHours object in the database.
        /// </summary>
        /// <param name="obj"></param>
        public void CreateWorkHours(WorkHours obj)
        {
            workHoursCtr.Create(obj);
        }

        /// <summary>
        /// Deletes a specific WorkHours object from the database by the given id.
        /// </summary>
        /// <param name="id"></param>
        public void DeleteWorkHours(int id)
        {
            workHoursCtr.Delete(id);
        }

        /// <summary>
        /// Returns a single WorkHours object from the database by the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>WorkHours</returns>
        public WorkHours GetWorkHours(int id)
        {
            return workHoursCtr.Get(id);
        }

        /// <summary>
        /// Reutns a list of all WorkHours from the database.
        /// </summary>
        /// <returns></returns>
        public List<WorkHours> GetAllWorkHours()
        {
            return workHoursCtr.GetAll();
        }

        /// <summary>
        /// Updates the given WorkHours object in the database.
        /// </summary>
        /// <param name="obj"></param>
        public void UpdateWorkHours(WorkHours obj)
        {
            workHoursCtr.Update(obj);
        }

        #endregion

        #region JobCategory Service
        /// <summary>
        /// Creates a new JobCategory object in the database
        /// </summary>
        /// <param name="obj"></param>
        public void CreateJobCategory(JobCategory obj)
        {
            jobCategoryCtr.Create(obj);
        }

        /// <summary>
        /// Deletes a JobCategory in the database by the given id
        /// </summary>
        /// <param name="id"></param>
        public void DeleteJobCategory(int id)
        {
            jobCategoryCtr.Delete(id);
        }

        /// <summary>
        /// Returns a single JobCategory by the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>JobCategory</returns>
        public JobCategory GetJobCategory(int id)
        {
            return jobCategoryCtr.Get(id);
        }

        /// <summary>
        /// Gets all objects and from the GetAll Method in the JobPostCtr Class
        /// And gets all the object from the database.
        /// </summary>
        /// <returns></returns>
        public List<JobCategory> GetAllJobCategories()
        {
            return jobCategoryCtr.GetAll();
        }

        /// <summary>
        /// Updates the given JobCategory object in the database
        /// </summary>
        /// <param name="obj"></param>
        public void UpdateJobCategory(JobCategory obj)
        {
            jobCategoryCtr.Update(obj);
        }
        #endregion

        #region JobPost Service

        /// <summary>
        /// Creates the given JobPost object in the database.
        /// </summary>
        /// <param name="obj"></param>
        public void CreateJobPost(JobPost obj)
        {
            jobPostCtr.Create(obj);
        }

        /// <summary>
        /// Deletes a specific JobPost in the database by the given id.
        /// </summary>
        /// <param name="id"></param>
        public void DeleteJobPost(int id)
        {
            jobPostCtr.Delete(id);
        }

        /// <summary>
        /// Returns a single JobPost object from the database by the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JobPost GetJobPost(int id)
        {
            return jobPostCtr.Get(id);
        }

        /// <summary>
        /// Returns a list of all JobPost in the database.
        /// </summary>
        /// <returns></returns>
        public List<JobPost> GetAllJobPost()
        {
            return jobPostCtr.GetAll();
        }

        /// <summary>
        /// Updates the given JobPost object in the database.
        /// </summary>
        /// <param name="obj"></param>
        public void UpdateJobPost(JobPost obj)
        {
            jobPostCtr.Update(obj);
        }

        public List<JobPost> GetAllJobPostToAJobApplication(int jobApplicationId)
        {
           return jobPostCtr.GetAllJobPostToAJobApplication(jobApplicationId);
        }

        /// <summary>
        /// Returns a single jobpost by the given meetingId
        /// </summary>
        /// <param name="meetingId"></param>
        /// <returns>JobPost</returns>
        public JobPost GetJobPostByMeetingId(int meetingId)
        {
            return jobPostCtr.GetJobPostByMeetingId(meetingId);
        }

        #endregion
    }
}
