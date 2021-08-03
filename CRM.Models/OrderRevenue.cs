using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM.Models
{
    /// <summary>
    /// Any revenues that are related to orders
    /// </summary>
    public class OrderRevenue
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public string OptionalNote { get; set; }

        public decimal Amount { get; set; }
        public DateTime RevenueDate { get; set; }
    }
}