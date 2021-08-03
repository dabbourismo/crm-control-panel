using CRM.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CRM.Repository.OrderRepositorys
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly AdlinkContext context;
        public OrderRepository(AdlinkContext _context) : base(_context)
        {
            context = _context;
        }

        public decimal GetSumPayed(int orderId)
        {
            var totalPayed = context.OrderRevenues
                .Where(t => t.OrderId == orderId)
                .Select(s => s.Amount)
                .DefaultIfEmpty(0)
                .Sum();
            return totalPayed;
        }

        public decimal GetOrderPrice(int orderId)
        {
            var price = context.Orders
                .Where(t => t.Id == orderId)
                .Select(s => s.Price).SingleOrDefault();
            return price;
        }

        public int GetNumberOfOrders(DateTime startDate, DateTime endDate)
        {
            var numberofOrders = context.Orders
                  .Where(x => x.OrderDate >= startDate && x.OrderDate <= endDate)
              .Count();
            return numberofOrders;
        }
    }
}
