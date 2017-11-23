using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class JobCVCtr : IController<JobCV>
    {

        public DBJobCV dbJobCV = new DBJobCV();
        public JobExperienceCtr jobExperienceCtr = new JobExperienceCtr();
        public ApplierEducationCtr applierEducationCtr = new ApplierEducationCtr();
        public JobAppendixCtr jobAppendixCtr = new JobAppendixCtr();

        public Applier CreateAndReturnPrimaryKey(JobCV obj, Applier applier)
        {
            Applier applierReturned = dbJobCV.Create(obj, applier);
            return applierReturned;
        }

        public void Create(JobCV obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public JobCV Get(int applierId)
        {
            JobCV jobCV = dbJobCV.Get(applierId);
            return jobCV;
        }

        public List<JobCV> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(JobCV obj)
        {
            dbJobCV.Update(obj);

            foreach (var Experience in obj.JobExperienceList)
            {
                jobExperienceCtr.Update(Experience);
            }
            foreach (var Education in obj.ApplierEducationList)
            {
                applierEducationCtr.Update(Education);
            }
            foreach (var Appendix in obj.JobAppendixList)
            {
                jobAppendixCtr.Update(Appendix);
            }
        }
    }
}
