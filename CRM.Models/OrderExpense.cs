using CRM.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM.Models
{
    /// <summary>
    /// Any expenses that are related to orders
    /// </summary>
    public class OrderExpense
    {       
        public int Id { get; set; }

        public string Reason { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; } = null;


        public EnumOrderExpenseType ExpenseType { get; set; }

        public decimal Amount { get; set; }

        public DateTime ExpenseDate { get; set; }
    }
}