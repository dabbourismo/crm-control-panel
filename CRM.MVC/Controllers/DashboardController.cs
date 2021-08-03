using CRM.MVC.ViewModels;
using CRM.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.MVC.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public DashboardController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        [HttpGet]
        public ActionResult DashboardIndex()
        {
            int numberOfOrders = unitOfWork.OrdersRepository.GetNumberOfOrders(DateTime.MinValue, DateTime.Now);
            int numberOfClients = unitOfWork.ClientsRepository.GetClientsCount();
            //company
            decimal totalOrderIncome = unitOfWork.OrderRevenueRepository.GetAllOrdersIncome(DateTime.MinValue, DateTime.Now);
            decimal totalOrderOutcome = unitOfWork.OrderExpenseRepository.GetAllOrdersOutcome(DateTime.MinValue, DateTime.Now);
            decimal totalOrderRevenue = totalOrderIncome - totalOrderOutcome;
            decimal totalCompanyExpenses = unitOfWork.CompanyExpensesRepository.GetTotalExpenses(DateTime.MinValue, DateTime.Now);

            //social media
            decimal socialMediaIncome = unitOfWork.OrderRevenueRepository.GetAllSocialMediaIncome(DateTime.MinValue, DateTime.Now);
            decimal socialMediaFinanceOutcome = unitOfWork.OrderExpenseRepository.GetAllSocialMediaFinanceOutcome(DateTime.MinValue, DateTime.Now);
            decimal socialMediaOrderExpenseOutcome = unitOfWork.OrderExpenseRepository.GetAllSocialMediaOrderExpenseOutcome(DateTime.MinValue, DateTime.Now);
            decimal socialMediaComissionOutcome = unitOfWork.OrderExpenseRepository.GetAllSocialMediaComissionOutcome(DateTime.MinValue, DateTime.Now);

            //programing
            decimal programingIncome = unitOfWork.OrderRevenueRepository.GetAllProgramingIncome(DateTime.MinValue, DateTime.Now);
            decimal programingFinanceOutcome = unitOfWork.OrderExpenseRepository.GetAllProgramingFinanceIncome(DateTime.MinValue, DateTime.Now);
            decimal programingExpenseOutcome = unitOfWork.OrderExpenseRepository.GetAllProgramingOrderExpenseIncome(DateTime.MinValue, DateTime.Now);
            decimal programingComissionOutcome = unitOfWork.OrderExpenseRepository.GetAllProgramingCommissionIncome(DateTime.MinValue, DateTime.Now);

            var dto = new DashboardDto()
            {
                FromDate = DateTime.Now,
                ToDate = DateTime.Now,

                NumberOfClients = numberOfClients,
                TotalCompanyExpenses = totalCompanyExpenses,
                NumberOfOrders = numberOfOrders,

                TotalOrderIncome = totalOrderIncome,
                TotalOrderOutcome = totalOrderOutcome,
                TotalOrderRevenue = totalOrderRevenue,
                TotalCompanyRevenue = totalOrderIncome - (totalOrderOutcome + totalCompanyExpenses),

                SocialMediaIncome = socialMediaIncome,
                SocialMediaFinanceOutcome = socialMediaFinanceOutcome,
                SocialMediaOrderExpenseOutcome = socialMediaOrderExpenseOutcome,
                SocialMediaComissionOutcome = socialMediaComissionOutcome,
                SocialMediaTotalOutcome = socialMediaFinanceOutcome + socialMediaOrderExpenseOutcome + socialMediaComissionOutcome,
                SocialMediaRevenue = socialMediaIncome
                - (socialMediaFinanceOutcome + socialMediaOrderExpenseOutcome + socialMediaComissionOutcome),


                ProgramingIncome = programingIncome,
                ProgramingFinanceOutcome = programingFinanceOutcome,
                ProgramingExpenseOutcome = programingExpenseOutcome,
                ProgramingComissionOutcome = programingComissionOutcome,
                ProgramingTotalOutcome = programingFinanceOutcome + programingExpenseOutcome + programingComissionOutcome,
                ProgramingRevenue = programingIncome - (programingFinanceOutcome + programingExpenseOutcome + programingComissionOutcome)


            };
            return View(dto);
        }

        [HttpPost]
        public ActionResult DashboardIndex(DashboardDto dto1)
        {
            var startDate = dto1.FromDate;
            var endDate = dto1.ToDate;

            int numberOfOrders = unitOfWork.OrdersRepository.GetNumberOfOrders(startDate, endDate);
            int numberOfClients = unitOfWork.ClientsRepository.GetClientsCount();
            //company
            decimal totalOrderIncome = unitOfWork.OrderRevenueRepository.GetAllOrdersIncome(startDate, endDate);
            decimal totalOrderOutcome = unitOfWork.OrderExpenseRepository.GetAllOrdersOutcome(startDate, endDate);
            decimal totalOrderRevenue = totalOrderIncome - totalOrderOutcome;
            decimal totalCompanyExpenses = unitOfWork.CompanyExpensesRepository.GetTotalExpenses(startDate, endDate);

            //socual media
            decimal socialMediaIncome = unitOfWork.OrderRevenueRepository.GetAllSocialMediaIncome(startDate, endDate);
            decimal socialMediaFinanceOutcome = unitOfWork.OrderExpenseRepository.GetAllSocialMediaFinanceOutcome(startDate, endDate);
            decimal socialMediaOrderExpenseOutcome = unitOfWork.OrderExpenseRepository.GetAllSocialMediaOrderExpenseOutcome(startDate, endDate);
            decimal socialMediaComissionOutcome = unitOfWork.OrderExpenseRepository.GetAllSocialMediaComissionOutcome(startDate, endDate);

            //programing
            decimal programingIncome = unitOfWork.OrderRevenueRepository.GetAllProgramingIncome(startDate, endDate);
            decimal programingFinanceOutcome = unitOfWork.OrderExpenseRepository.GetAllProgramingFinanceIncome(startDate, endDate);
            decimal programingExpenseOutcome = unitOfWork.OrderExpenseRepository.GetAllProgramingOrderExpenseIncome(startDate, endDate);
            decimal programingComissionOutcome = unitOfWork.OrderExpenseRepository.GetAllProgramingCommissionIncome(startDate, endDate);

            var dto = new DashboardDto()
            {
                NumberOfClients = numberOfClients,
                TotalCompanyExpenses = totalCompanyExpenses,
                NumberOfOrders = numberOfOrders,

                TotalOrderIncome = totalOrderIncome,
                TotalOrderOutcome = totalOrderOutcome,
                TotalOrderRevenue = totalOrderRevenue,
                TotalCompanyRevenue = totalOrderIncome - (totalOrderOutcome + totalCompanyExpenses),

                SocialMediaIncome = socialMediaIncome,
                SocialMediaFinanceOutcome = socialMediaFinanceOutcome,
                SocialMediaOrderExpenseOutcome = socialMediaOrderExpenseOutcome,
                SocialMediaComissionOutcome = socialMediaComissionOutcome,
                SocialMediaTotalOutcome = socialMediaFinanceOutcome + socialMediaOrderExpenseOutcome + socialMediaComissionOutcome,
                SocialMediaRevenue = socialMediaIncome
                - (socialMediaFinanceOutcome + socialMediaOrderExpenseOutcome + socialMediaComissionOutcome),


                ProgramingIncome = programingIncome,
                ProgramingFinanceOutcome = programingFinanceOutcome,
                ProgramingExpenseOutcome = programingExpenseOutcome,
                ProgramingComissionOutcome = programingComissionOutcome,
                ProgramingTotalOutcome = programingFinanceOutcome + programingExpenseOutcome + programingComissionOutcome,
                ProgramingRevenue = programingIncome - (programingFinanceOutcome + programingExpenseOutcome + programingComissionOutcome)
            };
            return View(dto);
        }
    }
}