using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models.Enums
{
    public enum EnumCompanyExpenseType
    {
        /// <summary>
        /// فواتير
        /// </summary>
        [Display(Name = "فواتير")]
        Bills = 1,
        /// <summary>
        /// مرتبات
        /// </summary>
        [Display(Name = "مرتبات")]
        Salary = 2,
        /// <summary>
        /// اصول
        /// </summary>
        [Display(Name = "اصول")]
        Assets = 3
    }
}
