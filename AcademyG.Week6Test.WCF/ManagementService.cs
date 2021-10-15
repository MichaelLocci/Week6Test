using AcademyG.Week6Test.Core;
using AcademyG.Week6Test.Core.BusinessLayer;
using AcademyG.Week6Test.Core.EF.Repository;
using AcademyG.Week6Test.Core.Interfaces;
using AcademyG.Week6Test.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AcademyG.Week6Test.WCF
{
    public class ManagementService : IManagementService
    {
        IManagementBL ManagementBL;

        public ManagementService()
        {
            //DI
            DependencyContainer.Register<IManagementBL, ManagementBL>();
            DependencyContainer.Register<ICustomerRepository, EFCustomerRepository>();
            DependencyContainer.Register<IOrderRepository, EFOrderRepository>();

            this.ManagementBL = DependencyContainer.Resolve<IManagementBL>();
        }

        public bool CreateCustomer(Customer newCustomer)
        {
            if (newCustomer == null)
                return false;

            return ManagementBL.CreateCustomer(newCustomer);
        }

        public bool DeleteCustomerById(int idCustomer)
        {
            if (idCustomer <= 0)
                return false;

            return ManagementBL.DeleteCustomerById(idCustomer);
        }

        public bool EditCustomer(Customer editedCustomer)
        {
            if (editedCustomer == null)
                return false;

            return ManagementBL.EditCustomer(editedCustomer);
        }

        public Customer FetchCustomerById(int idCustomer)
        {
            if (idCustomer <= 0)
                return null;

            return ManagementBL.FetchCustomerById(idCustomer);
        }

        public IEnumerable<Customer> FetchCustomers()
        {
            return ManagementBL.FetchCustomers();
        }
    }
}
