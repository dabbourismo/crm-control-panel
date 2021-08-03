using CRM.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.MVC.ViewModels
{
    public class OrdersShowDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public EnumServiceType ServiceType { get; set; }

        public int ClientId { get; set; }

        public string ClientName { get; set; }

        public decimal Required { get; set; }

        public decimal MaxExpense { get; set; }

        public decimal Price { get; set; }

        public decimal Discount { get; set; }

        /// <summary>
        /// Remainig = sum from revenue table
        /// </summary>
        public decimal Payed { get; set; }

        /// <summary>
        /// Remainig = Required-Payed(sum from revenue table)
        /// </summary>
        public decimal Remaining { get; set; }

        /// <summary>
        /// Expenses = sum expenses from order table where orderid = {}
        /// </summary>
        public decimal Expenses { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// True if Sum Payed == Required
        /// </summary>
        public bool isDone { get; set; } = false;
    }
}