using CRM.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM.Models
{
    /// <summary>
    /// Reperesnts All Services Provided by the company
    /// </summary>
    [Obsolete]
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EnumServiceType Type { get; set; }
        public decimal Price { get; set; }
        public decimal Expense { get; set; }
        public int Days { get; set; }

        public List<Order> Orders { get; set; }
    }
}