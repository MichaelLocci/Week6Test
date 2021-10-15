using AcademyG.Week6Test.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyG.Week6Test.Core.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Order GetByOderCode(string orderCode);
    }
}
