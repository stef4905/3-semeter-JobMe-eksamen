using ModelLayer;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DbJobPost : IDataAccess<JobPost>
    {
        //Instance variables
        private string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        /// <summary>
        /// Create an JobPost Object and executes it into the databases through the database connection
        /// Its protected against SQL Injections with Parameters.
        /// </summary>
        /// <param name="obj">Is a JobPost object</param>
        /// <returns></returns>
        public bool Create(JobPost obj)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                try
                {
                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "INSERT INTO JobPost (Title, Description, StartDate, EndDate, JobTitle, WorkHoursId, Address, CompanyId, JobCategoryId, MeetingId) VALUES (@Title, @Description, @StartDate, @EndDate, @JobTitle, @WorkHoursId, @Address, @CompanyId, @JobCategoryId, @MeetingId)";
                        cmd.Parameters.AddWithValue("Title", obj.Title);
                        cmd.Parameters.AddWithValue("Description", obj.Description);
                        cmd.Parameters.AddWithValue("StartDate", obj.StartDate);
                        cmd.Parameters.AddWithValue("EndDate", obj.EndDate);
                        cmd.Parameters.AddWithValue("JobTitle", obj.JobTitle);
                        cmd.Parameters.AddWithValue("WorkHoursId", obj.workHours.Id);
                        cmd.Parameters.AddWithValue("Address", obj.Address);
                        cmd.Parameters.AddWithValue("CompanyId", obj.company.Id);
                        cmd.Parameters.AddWithValue("JobCategoryId", obj.jobCategory.Id);
                        cmd.Parameters.AddWithValue("MeetingId", obj.Meeting.Id);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Returns a single jobpost object from the database by the given meetingId
        /// </summary>
        /// <param name="meetingId"></param>
        /// <returns></returns>
        public JobPost GetJogPostByMeetingId(int meetingId)
        {
            DbWorkHour dbWorkHour = new DbWorkHour();
            DbCompany dbCompany = new DbCompany();
            DbJobCategory dbJobCategory = new DbJobCategory();
            JobPost jobPost = new JobPost();
            DBMeeting dBMeeting = new DBMeeting();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM JobPost WHERE MeetingId = @MeetingId";
                    cmd.Parameters.AddWithValue("MeetingId", meetingId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        jobPost.Id = (int)reader["Id"];
                        jobPost.Title = (string)reader["Title"];
                        jobPost.Description = (string)reader["Description"];
                        jobPost.StartDate = (DateTime)reader["StartDate"];
                        jobPost.EndDate = (DateTime)reader["EndDate"];
                        jobPost.JobTitle = (string)reader["JobTitle"];
                        jobPost.workHours = dbWorkHour.Get((int)reader["WorkHoursId"]);
                        jobPost.Address = (string)reader["Address"];
                        jobPost.company = dbCompany.Get((int)reader["CompanyId"]);
                        jobPost.jobCategory = dbJobCategory.Get((int)reader["JobCategoryId"]);
                        jobPost.Meeting = dBMeeting.Get((int)reader["MeetingId"]);
                    };
                    return jobPost;
                }
            }
        }

        /// <summary>
        /// Deletes a specific JobPost by the given id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a JobPost Object from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>jobPost</returns>
        public JobPost Get(int id)
        {
            DbWorkHour dbWorkHour = new DbWorkHour();
            DbCompany dbCompany = new DbCompany();
            DbJobCategory dbJobCategory = new DbJobCategory();
            JobPost jobPost = new JobPost();
            DBMeeting dBMeeting = new DBMeeting();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM JobPost WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("Id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        //Gets the company on the jobPost
                        Company companyReturned = dbCompany.Get((int)reader["CompanyId"]);

                        jobPost.Id = (int)reader["Id"];
                        jobPost.Title = (string)reader["Title"];
                        jobPost.Description = (string)reader["Description"];
                        jobPost.StartDate = (DateTime)reader["StartDate"];
                        jobPost.EndDate = (DateTime)reader["EndDate"];
                        jobPost.JobTitle = (string)reader["JobTitle"];
                        jobPost.workHours = dbWorkHour.Get((int)reader["WorkHoursId"]);
                        jobPost.Address = (string)reader["Address"];
                        jobPost.company = companyReturned;
                        jobPost.CompanyName = companyReturned.CompanyName;
                        jobPost.jobCategory = dbJobCategory.Get((int)reader["JobCategoryId"]);
                        jobPost.Meeting = dBMeeting.Get((int)reader["MeetingId"]);
                    };
                    return jobPost;
                }
            }
        }

        /// <summary>
        /// Returns a list of all JobPost from the database
        /// </summary>
        /// <returns>a jobPostList</returns>
        public List<JobPost> GetAll()
        {
            List<JobPost> jobPostList = new List<JobPost>();
            DBMeeting dbMeeting = new DBMeeting();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM JobPost";
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        DbWorkHour dbWorkHour = new DbWorkHour();
                        DbCompany dbCompany = new DbCompany();
                        DbJobCategory dbJobCategory = new DbJobCategory();

                        //Gets the company on the jobPost
                        Company companyReturned = dbCompany.Get((int)reader["CompanyId"]);

                        JobPost jobPost = new JobPost
                        {
                            Id = (int)reader["Id"],
                            Title = (string)reader["Title"],
                            Description = (string)reader["Description"],
                            StartDate = (DateTime)reader["StartDate"],
                            EndDate = (DateTime)reader["EndDate"],
                            JobTitle = (string)reader["JobTitle"],
                            workHours = dbWorkHour.Get((int)reader["WorkHoursId"]),
                            Address = (string)reader["Address"],
                            company = companyReturned,
                            CompanyName = companyReturned.CompanyName,
                            jobCategory = dbJobCategory.Get((int)reader["JobCategoryId"]),
                            Meeting = dbMeeting.Get((int)reader["MeetingId"])
                        };
                        jobPostList.Add(jobPost);
                    }
                }
            }
            return jobPostList;
        }


        /// <summary>
        /// Updates the given JobPost object in the database
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Bool to ensure update was succesfull</returns>
        public bool Update(JobPost obj)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Returns all jobpost from a specific jobapplication
        /// </summary>
        /// <param name="JobApplicationId"></param>
        /// <returns></returns>
        public List<JobPost> GetAllJobPostToAJobApplication(int jobApplicationId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM JobApplicationJobPost WHERE JobApplicationId = @jobApplicationId AND AcceptApplication = @AcceptApplication";
                    cmd.Parameters.AddWithValue("jobApplicationId", jobApplicationId);
                    cmd.Parameters.AddWithValue("AcceptApplication", 1);
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<JobPost> jobPostList = new List<JobPost>();

                    while (reader.Read())
                    {
                        JobPost jobPost = new JobPost
                        {
                            Id = (int)reader["JobPostId"]
                        };
                        jobPost = Get(jobPost.Id);
                        jobPostList.Add(jobPost);
                    }
                    return jobPostList;
                }
            }

        }
    }
}

