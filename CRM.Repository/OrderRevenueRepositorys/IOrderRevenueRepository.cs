using CRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Repository.OrderRevenueRepositorys
{
    public interface IOrderRevenueRepository : IRepository<OrderRevenue>
    {
        List<OrderRevenue> GetOrderRevenues(int orderId);
        decimal GetAllOrdersIncome(DateTime startDate, DateTime endDate);
        decimal GetAllSocialMediaIncome(DateTime startDate, DateTime endDate);
        decimal GetAllProgramingIncome(DateTime startDate, DateTime endDate);


    }
}
