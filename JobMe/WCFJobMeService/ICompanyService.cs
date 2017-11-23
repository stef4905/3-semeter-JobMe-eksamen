using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFJobMeService
{
    [ServiceContract]
    public interface ICompanyService
    {
        #region Company Service
                [OperationContract]
                void CreateCompany(Company company);

                [OperationContract]
                void DeleteCompany(int id);

                [OperationContract]
                Company GetCompany(int id);

                [OperationContract]
                List<Company> GetAllCompany();

                [OperationContract]
                void UpdateCompany(Company obj);

                [OperationContract]
                Company Login(string email, string password);

                #endregion

        #region JobPost Service
        [OperationContract]
        void CreateJobPost(JobPost jobPost);

        [OperationContract]
        void DeleteJobPost(int id);

        [OperationContract]
        List<JobPost> GetAllJobPost();

        [OperationContract]
        void UpdateJobPost(JobPost obj);

        [OperationContract]
        JobPost GetJobPost(int id);
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

        #region WorkHours Service

        [OperationContract]
        void CreateWorkHours(WorkHours obj);

        [OperationContract]
        void DeleteWorkHours(int id);


        [OperationContract]
        WorkHours GetWorkHours(int id);


        [OperationContract]
        List<WorkHours> GetlAllWorkHours();

        [OperationContract]
        void UpdateWorkHours(WorkHours obj);

#endregion
    }

}