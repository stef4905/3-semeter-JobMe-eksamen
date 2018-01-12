using DataAccessLayer;
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
            DBMeeting dBMeeting = new DBMeeting();
            Meeting meeting = new Meeting
            {
                CompanyId = obj.company.Id

            };
            dBMeeting.Create(meeting);

            obj.Meeting = meeting;

            dbJobPost.Create(obj);
        }

        /// <summary>
        /// Deletes a specific JobPost in the database by the given id.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            dbJobPost.Delete(id);
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
            dbJobPost.Update(obj);
        }

        /// <summary>
        /// Gets a list of jobspost by the jobappliactionId
        /// </summary>
        /// <param name="jobApplicationId"></param>
        /// <returns></returns>
        public List<JobPost> GetAllJobPostToAJobApplication(int jobApplicationId)
        {
            return dbJobPost.GetAllJobPostToAJobApplication(jobApplicationId);
        }

        /// <summary>
        /// Returns a single jobpost object from the database by the give meetingId
        /// </summary>
        /// <param name="meetingId"></param>
        /// <returns></returns>
        public JobPost GetJobPostByMeetingId(int meetingId)
        {
            return dbJobPost.GetJogPostByMeetingId(meetingId);
        }

        /// <summary>
        /// Return the number of rows in the jobPost table in the database
        /// </summary>
        /// <returns></returns>
        public int GetJobPostTableSize()
        {
            return dbJobPost.GetJobPostTableSize();
        }
    }
}
