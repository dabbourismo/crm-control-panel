using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRM.MVC.ViewModels
{
    public class OrderRevenuesAddDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }

 

        [Display(Name = "ملاحظة(اختياري)")]
        public string OptionalNote { get; set; }

        [Display(Name = "السعر الاصلي للاوردر")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public decimal Price { get; set; }

        [Display(Name = "الخصم")]
        public decimal Discount { get; set; }

        [Display(Name = "المدفوع مسبقا")]
        public decimal OldPayed { get; set; }

        [Display(Name = "باقي حساب الاوردر")]
        public decimal OldRemaining { get; set; }

        /// <summary>
        /// The only field that is not read only
        /// </summary>
        [Display(Name = "المدفوع الان")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Range(1, 100000.00, ErrorMessage = "يجب ان يكون المدفوع اكبر من الصفر")]
        public decimal Amount { get; set; }

        [Display(Name = "المتبقي")]
        public decimal Remaining { get; set; }

        [Display(Name = "تاريخ الدفع")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "هذا الحقل مطلوب")]
        public DateTime RevenueDate { get; set; } = DateTime.Now;


        public bool isDone { get; set; }
    }
}