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

        #region BusinessType Service
        [OperationContract]
        bool CreateBusinessType(BusinessType obj);

        [OperationContract]
        BusinessType GetBusinessType(int id);

        [OperationContract]
        List<BusinessType> GetAllBusinessType();

        [OperationContract]
        bool UpdateBusinessType(BusinessType obj);

        [OperationContract]
        void DeleteBusinessType(int id);
        #endregion
    }

}