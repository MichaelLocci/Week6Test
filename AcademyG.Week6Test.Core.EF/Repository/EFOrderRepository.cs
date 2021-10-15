using AcademyG.Week6Test.Core.Interfaces;
using AcademyG.Week6Test.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyG.Week6Test.Core.EF.Repository
{
    public class EFOrderRepository : IOrderRepository
    {
        private readonly ManagementContext ctx;

        public EFOrderRepository() : this(new ManagementContext()) { }

        public EFOrderRepository(ManagementContext ctx)
        {
            this.ctx = ctx;
        }

        public bool Add(Order item)
        {
            if (item == null)
                return false;

            try
            {
                ctx.Orders.Add(item);
                
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Order item)
        {
            if (item == null)
                return false;

            try
            {
                var order = ctx.Orders.Find(item.Id);

                if (order != null)
                    ctx.Orders.Remove(order);
                ctx.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Order> Fetch(Func<Order, bool> filter = null)
        {
            try
            {
                if (filter != null)
                    return ctx.Orders.Where(filter).ToList();

                return ctx.Orders.ToList();
            }
            catch (Exception)
            {
                return new List<Order>();
            }
        }

        public Order GetByOderCode(string orderCode)
        {
            if (string.IsNullOrEmpty(orderCode))
                return null;

            try
            {
                var order = ctx.Orders.SingleOrDefault(o => o.OderCode == orderCode);

                return order;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Order GetById(int id)
        {
            if (id <= 0)
                return null;

            return ctx.Orders.Find(id);
        }

        public bool Update(Order item)
        {
            if (item == null)
                return false;

            try
            {
                ctx.Orders.Update(item);
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
