using AcademyG.Week6Test.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyG.Week6Test.Core.Interfaces
{
    public interface ICustomerRepository :IRepository<Customer>
    {
        Customer GetByCustomerCode(string customerCode);
    }
}
