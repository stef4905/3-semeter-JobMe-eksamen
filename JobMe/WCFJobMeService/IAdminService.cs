using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ModelLayer;

namespace WCFJobMeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAdminService" in both code and config file together.
    [ServiceContract]
    public interface IAdminService
    {
        [OperationContract]
        void Create(Admin admin);

        [OperationContract]
        void Delete(int id);

        [OperationContract]
        List<Admin> GetAllAdmin();

        [OperationContract]
        Admin GetAdmin(int id);

        [OperationContract]
        void Update(Admin admin);

        [OperationContract]
        Admin Login(string email, string password);
    }
}
