using AcademyG.Week6Test.Core.Interfaces;
using AcademyG.Week6Test.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyG.Week6Test.Core.EF.Repository
{
    public class EFCustomerRepository : ICustomerRepository
    {

        private readonly ManagementContext ctx;

        public EFCustomerRepository() : this(new ManagementContext()) { }

        public EFCustomerRepository(ManagementContext ctx)
        {
            this.ctx = ctx;
        }

        public bool Add(Customer item)
        {
            if (item == null)
                return false;

            try
            {
                ctx.Customers.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Customer item)
        {
            if (item == null)
                return false;

            try
            {
                var customer = ctx.Customers.Find(item.Id);

                if (customer != null)
                    ctx.Customers.Remove(customer);
                ctx.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Customer> Fetch(Func<Customer, bool> filter = null)
        {
            try
            {
                if (filter != null)
                    return ctx.Customers.Where(filter).ToList();

                return ctx.Customers.ToList();
            }
            catch (Exception)
            {
                return new List<Customer>();
            }
        }

        public Customer GetByCustomerCode(string customerCode)
        {
            if (string.IsNullOrEmpty(customerCode))
                return null;

            try
            {
                var customer = ctx.Customers.SingleOrDefault(c => c.CustomerCode == customerCode);

                return customer;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Customer GetById(int id)
        {
            if (id <= 0)
                return null;

            return ctx.Customers.Find(id); ;
        }

        public bool Update(Customer item)
        {
            if (item == null)
                return false;

            try
            {
                ctx.Customers.Update(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
