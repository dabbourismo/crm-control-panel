using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.MVC.ViewModels
{
    public class ShowRevenuesExpenses
    {
        public int OrderId { get; set; }
        public string OrderName { get; set; }
        public bool isDone { get; set; }
    }
}