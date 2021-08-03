
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models.Enums
{
    public enum EnumOrderExpenseType
    {
        /// <summary>
        /// تمويل
        /// </summary>
        [Display(Name = "تمويل")]
        Finance = 1,
        /// <summary>
        /// مصروف خدمة
        /// </summary>
        [Display(Name = "مصروف خدمة")]
        OrderExpense = 2,
        /// <summary>
        /// عمولة
        /// </summary>
        [Display(Name = "عمولة")]
        Commission = 3        
    }
}
