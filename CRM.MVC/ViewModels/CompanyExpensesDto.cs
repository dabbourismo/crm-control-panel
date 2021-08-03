using CRM.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.MVC.ViewModels
{
    public class CompanyExpensesDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "اسم المصروف")]
        public string Name { get; set; }

        [Display(Name = "السبب (اختياري)")]
        public string Reason { get; set; }


        [Display(Name = "نوع المصروف")]
        [Range(1, int.MaxValue, ErrorMessage = "اختر نوع المصروف")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public EnumCompanyExpenseType ExpenseType { get; set; }

        [Display(Name = "المبلغ")]
        [Range(1, int.MaxValue, ErrorMessage = "اختر المبلغ")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public decimal Amount { get; set; }

        [Display(Name = "التاريخ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ExpenseDate { get; set; } = DateTime.Now;
    }
}