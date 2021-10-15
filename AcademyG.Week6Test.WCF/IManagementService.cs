using AcademyG.Week6Test.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AcademyG.Week6Test.WCF
{
    [ServiceContract]
    public interface IManagementService
    {
        [OperationContract]
        IEnumerable<Customer> FetchCustomers();

        [OperationContract]
        Customer FetchCustomerById(int idCustomer);

        [OperationContract]
        bool CreateCustomer(Customer newCustomer);

        [OperationContract]
        bool EditCustomer(Customer editedCustomer);

        [OperationContract]
        bool DeleteCustomerById(int idCustomer);
    }
}
