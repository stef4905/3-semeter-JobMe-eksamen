using ModelLayer;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFJobMeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IJobPostService" in both code and config file together.
    [ServiceContract]
    public interface IJobPostService
    {
     #region WorkHours Service

        [OperationContract]
        void CreateWorkHours(WorkHours obj);

        [OperationContract]
        void DeleteWorkHours(int id);

        [OperationContract]
        WorkHours GetWorkHours(int id);

        [OperationContract]
        List<WorkHours> GetAllWorkHours();

        [OperationContract]
        void UpdateWorkHours(WorkHours obj);
        #endregion

     #region JobCategory Service
        [OperationContract]
        void CreateJobCategory(JobCategory obj);

        [OperationContract]
        void DeleteJobCategory(int id);

        [OperationContract]
        JobCategory GetJobCategory(int id);

        [OperationContract]
        List<JobCategory> GetAllJobCategories();

        [OperationContract]
        void UpdateJobCategory(JobCategory obj);
        #endregion

     #region JobPost Service
        [OperationContract]
        void CreateJobPost(JobPost obj);

        [OperationContract]
        void DeleteJobPost(int id);

        [OperationContract]
        JobPost GetJobPost(int id);

        [OperationContract]
        List<JobPost> GetAllJobPost();

        [OperationContract]
        void UpdateJobPost(JobPost obj);

        [OperationContract]
        List<JobPost> GetAllJobPostToAJobApplication(int jobApplicationId);

        [OperationContract]
        JobPost GetJobPostByMeetingId(int meetingId);

        [OperationContract]
        int GetJobPostTableSize();
        #endregion

    }
}