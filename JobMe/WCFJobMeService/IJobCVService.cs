using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ModelLayer;

namespace WCFJobMeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IJobCVService" in both code and config file together.
    [ServiceContract]
    public interface IJobCVService
    {
        [OperationContract]
        Applier CreateAndReturnPrimaryKey(JobCV obj, Applier applier);

        [OperationContract]
        void Create(JobCV jobCV);

        [OperationContract]
        void Delete(int id);

        [OperationContract]
        JobCV Get(int applierId);

        [OperationContract]
        List<JobCV> GetAll();

        [OperationContract]
        void Update(JobCV obj);


        #region JobExperienceService
        [OperationContract]
        void CreateJobexpericene(JobExperience jobExperience);

        [OperationContract]
        void UpdateJobexpericene(JobExperience jobExperience);
        [OperationContract]
        void DeleteJobexpericene(int id);

        #endregion

        #region EducationService
        [OperationContract]
        void CreateApplierEducation(ApplierEducation applierEducation);

        [OperationContract]
        void UpdateApplierEducation(ApplierEducation applierEducation);
        [OperationContract]
        void DeleteApplierEducation(int id);

        #endregion

    }
}
