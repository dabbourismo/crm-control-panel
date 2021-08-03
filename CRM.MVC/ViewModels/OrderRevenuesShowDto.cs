using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.MVC.ViewModels
{
    public class OrderRevenuesShowDto
    {
        public int Id { get; set; }

        public int OrderId { get; set; }        
        public string OptionalNote { get; set; }

        public decimal Amount { get; set; }
        public DateTime RevenueDate { get; set; }
    }
}