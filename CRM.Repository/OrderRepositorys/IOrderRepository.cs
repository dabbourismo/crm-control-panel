using CRM.Models;
using System;
using System.Collections.Generic;

namespace CRM.Repository.OrderRepositorys
{
    public interface IOrderRepository : IRepository<Order>
    {
        decimal GetSumPayed(int orderId);
        decimal GetOrderPrice(int orderId);

        int GetNumberOfOrders(DateTime startDate, DateTime endDate);
       
    }
}
