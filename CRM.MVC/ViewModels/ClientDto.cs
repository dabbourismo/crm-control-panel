using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRM.MVC.ViewModels
{
    public class ClientDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "اسم العميل")]
        public string Name { get; set; }

        [Display(Name = "التخصص")]
        public string Speciality { get; set; }

        [Display(Name = "الشركة")]
        public string Company { get; set; }

        [Display(Name = "تليفون 1")]
        [StringLength(11, ErrorMessage = "رقم الهاتف يجب ان يكون 11 رقم ")]
        public string Phone1 { get; set; }

        [Display(Name = "تليفون 2")]
        [StringLength(11, ErrorMessage = "رقم الهاتف يجب ان يكون 11 رقم ")]
        public string Phone2 { get; set; }

        [Display(Name = "المدينة")]
        public string City { get; set; }

        [Display(Name = "العنوان")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }


        [Display(Name = "تقييم")]
        [Range(0, 5, ErrorMessage = "يجب ان يكون بين 0 الى 5")]
        public int Rating { get; set; } = 0;


    }
}