using CRM.Models;
using CRM.Repository.OrderRepositorys;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace CRM.Repository.OrderRevenueRepositorys
{
    public class OrderRevenueRepository : GenericRepository<OrderRevenue>, IOrderRevenueRepository
    {
        private readonly AdlinkContext context;
        public OrderRevenueRepository(AdlinkContext _context) : base(_context)
        {
            context = _context;
        }

        public List<OrderRevenue> GetOrderRevenues(int orderId)
        {
            var orderRevenues = context.OrderRevenues
                .Where(t => t.OrderId == orderId)
                .ToList();
            return orderRevenues;
        }

        public decimal GetAllOrdersIncome(DateTime startDate, DateTime endDate)
        {
            var totalRev = context.OrderRevenues
                .Where(x => x.RevenueDate >= startDate && x.RevenueDate <= endDate)
                .Select(x => x.Amount)
                .DefaultIfEmpty(0)
                .Sum();
            return totalRev;
        }

        public decimal GetAllSocialMediaIncome(DateTime startDate, DateTime endDate)
        {
            var totalRev = context.OrderRevenues
                .Where(x => x.RevenueDate >= startDate && x.RevenueDate <= endDate
                       && x.Order.ServiceType == Models.Enums.EnumServiceType.SocialMedia)

                .Select(x => x.Amount)
                .DefaultIfEmpty(0)
                .Sum();
            return totalRev;
        }


        public decimal GetAllProgramingIncome(DateTime startDate, DateTime endDate)
        {
            var totalRev = context.OrderRevenues
                .Where(x => x.RevenueDate >= startDate && x.RevenueDate <= endDate
                       && x.Order.ServiceType == Models.Enums.EnumServiceType.Programing)

                .Select(x => x.Amount)
                .DefaultIfEmpty(0)
                .Sum();
            return totalRev;
        }


    }
}
