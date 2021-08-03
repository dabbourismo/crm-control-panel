using CRM.Models;
using CRM.Models.Enums;
using CRM.MVC.Validators;
using Foolproof;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRM.MVC.ViewModels
{
    public class OrdersAddDto
    {
        public int Id { get; set; }

        [Display(Name = "اسم الاوردر")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Name { get; set; }

        [Display(Name = "النوع")]
        [Range(1, int.MaxValue, ErrorMessage = "اختر نوع الخدمة")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public EnumServiceType ServiceType { get; set; }

        public int ClientId { get; set; }

        [Display(Name = "سعر الاوردر")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "هذا الحقل مطلوب")]
        [Range(0, 100000, ErrorMessage = "يجب ان يكون السعر بصفر او اكثر")]
        public decimal Price { get; set; } = 0;

        //foolproof lib
        [Display(Name = "الخصم")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "هذا الحقل مطلوب")]
        public decimal Discount { get; set; } = 0;

        [Display(Name = "المطلوب")]
        public decimal Required
        {
            get
            {
                return Price - Discount;
            }
        }

        /// <summary>
        /// Only for show field
        /// </summary>
        [Display(Name = "المتبقي")]
        public decimal Remaining { get; set; }

        [Display(Name = "اقصى مصروف مقترح")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "هذا الحقل مطلوب")]       
        public decimal MaxExpense { get; set; } = 0;

        /// <summary>
        /// Goes into Revenue table
        /// </summary>
        [Display(Name = "تم دفع")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Range(0, 100000, ErrorMessage = "يجب ان يكون المدفوع بصفر او اكثر")]
        public decimal Payed { get; set; }

        [Display(Name = "تاريخ الطلب")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "هذا الحقل مطلوب")]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Display(Name = "تاريخ التسليم")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DeliveryDate { get; set; } = DateTime.Now;

        public bool isDone { get; set; }

        public List<OrderRevenue> OrderRevenues { get; set; }

    }
}