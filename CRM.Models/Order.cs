using CRM.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM.Models
{
    /// <summary>
    /// Represents Main Orders By Clients
    /// </summary>
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EnumServiceType ServiceType { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; } = null;

        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal Required { get; set; }
        public decimal MaxExpense { get; set; }

        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }

        public List<OrderRevenue> Revenues { get; set; } = new List<OrderRevenue>();
        public List<OrderExpense> Expenses { get; set; } = new List<OrderExpense>();

        /// <summary>
        /// True if Sum Payed == Required
        /// </summary>
        public bool isDone { get; set; } = false;
    }
}