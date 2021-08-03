using CRM.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRM.MVC.ViewModels
{
    public class OrderExpensesShowDto
    {
        public int Id { get; set; }

        [Display(Name = "السبب")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Reason { get; set; }


        public int OrderId { get; set; }


        [Display(Name = "نوع المصروف")]
        [Range(1, int.MaxValue, ErrorMessage = "اختر نوع المصروف")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public EnumOrderExpenseType ExpenseType { get; set; }



        [Display(Name = "المبلغ")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Range(1, 100000.00, ErrorMessage = "يجب ان يكون المدفوع اكبر من الصفر")]
        public decimal Amount { get; set; }


        [Display(Name = "تاريخ الدفع")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "هذا الحقل مطلوب")]
        public DateTime ExpenseDate { get; set; } = DateTime.Now;
    }
}