using CRM.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM.Models
{
    public class CompanyExpense
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Reason { get; set; }

        public EnumCompanyExpenseType ExpenseType { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
    }
}