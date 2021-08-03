using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models.Enums
{
    public enum EnumServiceType
    {
        [Display(Name = "برمجة")]
        Programing = 1,
        [Display(Name = "سوشيال")]
        SocialMedia = 2
    }
}
