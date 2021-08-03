using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRM.MVC.ViewModels
{
    public class DashboardDto
    {
        [Display(Name = "من")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "هذا الحقل مطلوب")]
        public DateTime FromDate { get; set; } = DateTime.Now;

        [Display(Name = "الى")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "هذا الحقل مطلوب")]
        public DateTime ToDate { get; set; } = DateTime.Now;

        //عامة
        public int NumberOfClients { get; set; }
        public decimal TotalCompanyExpenses { get; set; }
        public int NumberOfOrders { get; set; }

        //اوردرات عامه
        public decimal TotalOrderIncome { get; set; }
        public decimal TotalOrderOutcome { get; set; }
        public decimal TotalOrderRevenue { get; set; }

        //الشركه عامه
        public decimal TotalCompanyRevenue { get; set; }//ctor

        //social
        public decimal SocialMediaIncome { get; set; }
        public decimal SocialMediaFinanceOutcome { get; set; }
        public decimal SocialMediaOrderExpenseOutcome { get; set; }
        public decimal SocialMediaComissionOutcome { get; set; }
        public decimal SocialMediaTotalOutcome { get; set; }//ctor
        public decimal SocialMediaRevenue { get; set; }//ctor



        //programing
        public decimal ProgramingIncome { get; set; }
        public decimal ProgramingFinanceOutcome { get; set; }
        public decimal ProgramingExpenseOutcome { get; set; }
        public decimal ProgramingComissionOutcome { get; set; }
        public decimal ProgramingTotalOutcome { get; set; }//ctor
        public decimal ProgramingRevenue { get; set; }//ctor

        public DashboardDto()
        {


            SocialMediaRevenue = SocialMediaIncome - SocialMediaTotalOutcome;


            ProgramingTotalOutcome = ProgramingFinanceOutcome +
                                     ProgramingExpenseOutcome +
                                      ProgramingComissionOutcome;

            ProgramingRevenue = ProgramingIncome - ProgramingTotalOutcome;

        }
    }
}