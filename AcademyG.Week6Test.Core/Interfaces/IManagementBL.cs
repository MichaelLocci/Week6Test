using AcademyG.Week6Test.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyG.Week6Test.Core.Interfaces
{
    public interface IManagementBL
    {

        #region Customer

        IEnumerable<Customer> FetchCustomers(Func<Customer, bool> filter = null);
        Customer FetchCustomerById(int id);
        Customer FetchCustomerByCustomerCode(string customerCode);
        bool CreateCustomer(Customer newCustomer);
        bool EditCustomer(Customer editedCustomer);
        bool DeleteCustomerById(int idCustomer);

        #endregion

        #region Loan

        IEnumerable<Order> FetchOrders(Func<Order, bool> filter = null);
        Order FetchOrderById(int id);
        Order FetchOrderByOrderCode(string orderCode);
        bool CreateOrder(Order newOrder);
        bool EditOrder(Order editeOrder);
        bool DeleteOrderById(int idOrder);

        #endregion
    }
}
