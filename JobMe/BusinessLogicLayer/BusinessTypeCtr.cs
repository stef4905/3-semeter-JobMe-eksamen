using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class BusinessTypeCtr : IController<BusinessType>
    {
        private DBBusinessType DBBusinessType = new DBBusinessType();

        public bool Create(BusinessType obj)
        {
            return DBBusinessType.Create(obj);
        }

        public void Delete(int id)
        {
            DBBusinessType.Delete(id);
        }

        public BusinessType Get(int id)
        {
            return DBBusinessType.Get(id);
        }

        public List<BusinessType> GetAll()
        {
            return DBBusinessType.GetAll();
        }

        public bool Update(BusinessType obj)
        {
            return DBBusinessType.Update(obj);
        }
    }
}
