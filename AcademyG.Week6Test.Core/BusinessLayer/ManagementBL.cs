using AcademyG.Week6Test.Core.Interfaces;
using AcademyG.Week6Test.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyG.Week6Test.Core.BusinessLayer
{
    public class ManagementBL : IManagementBL
    {
        private readonly ICustomerRepository customerRepo;
        private readonly IOrderRepository orderRepo;

        public ManagementBL() //WCF
        {
            this.customerRepo = DependencyContainer.Resolve<ICustomerRepository>();
            this.orderRepo = DependencyContainer.Resolve<IOrderRepository>();
        }

        public ManagementBL(IOrderRepository orderRepository, ICustomerRepository customerRepository)
        {
            this.orderRepo = orderRepository;
            this.customerRepo = customerRepository;
        }

        #region CUSTOMER

        public bool CreateCustomer(Customer newCustomer)
        {
            if (newCustomer == null)
                return false;

            return customerRepo.Add(newCustomer);
        }
        public bool DeleteCustomerById(int idCustomer)
        {
            if (idCustomer <= 0)
                return false;

            Customer customerDelete = customerRepo.GetById(idCustomer);

            if (customerDelete == null)
                return false;

            return customerRepo.Delete(customerDelete);
        }
        public bool EditCustomer(Customer editedCustomer)
        {
            if (editedCustomer == null)
                return false;

            return customerRepo.Update(editedCustomer);
        }
        public Customer FetchCustomerByCustomerCode(string customerCode)
        {
            if (String.IsNullOrEmpty(customerCode))
                return null;

            return customerRepo.GetByCustomerCode(customerCode);

        }
        public Customer FetchCustomerById(int id)
        {
            if (id <= 0)
                return null;

            return customerRepo.GetById(id);
        }
        public IEnumerable<Customer> FetchCustomers(Func<Customer, bool> filter = null)
        {
            if (filter != null)
                return customerRepo.Fetch().Where(filter);

            return customerRepo.Fetch();
        }

        #endregion

        #region ORDER
        public bool CreateOrder(Order newOrder)
        {
            if (newOrder == null)
                return false;

            return orderRepo.Add(newOrder);
        }
        public bool DeleteOrderById(int idOrder)
        {
            if (idOrder <= 0)
                return false;

            Order orderDelete = orderRepo.GetById(idOrder);

            if (orderDelete == null)
                return false;

            return orderRepo.Delete(orderDelete);
        }
        public bool EditOrder(Order editeOrder)
        {
            if (editeOrder == null)
                return false;

            return orderRepo.Update(editeOrder);
        }
        public Order FetchOrderById(int id)
        {
            if (id <= 0)
                return null;

            return orderRepo.GetById(id);
        }
        public Order FetchOrderByOrderCode(string orderCode)
        {
            if (String.IsNullOrEmpty(orderCode))
                return null;

            return orderRepo.GetByOderCode(orderCode);
        }
        public IEnumerable<Order> FetchOrders(Func<Order, bool> filter = null)
        {
            if (filter != null)
                return orderRepo.Fetch().Where(filter);

            return orderRepo.Fetch();
        }
        #endregion
    }
}
