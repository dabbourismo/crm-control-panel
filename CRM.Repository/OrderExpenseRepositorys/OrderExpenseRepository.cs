using CRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Repository.OrderExpenseRepositorys
{
    public class OrderExpenseRepository : GenericRepository<OrderExpense>, IOrderExpenseRepository
    {
        private readonly AdlinkContext context;
        public OrderExpenseRepository(AdlinkContext _context) : base(_context)
        {
            context = _context;
        }
        public List<OrderExpense> GetOrderExpenses(int orderId)
        {
            var orderExpenses = context.OrderExpenses
                .Where(t => t.OrderId == orderId)
                .ToList();
            return orderExpenses;
        }

        public decimal GetAllOrdersOutcome(DateTime startDate, DateTime endDate)
        {
            var totalRev = context.OrderExpenses
                .Where(x => x.ExpenseDate >= startDate && x.ExpenseDate <= endDate)
                .Select(x => x.Amount)
                .DefaultIfEmpty(0)
                .Sum();
            return totalRev;
        }

        /// <summary>
        /// مصروفات تمويل سوشيال
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public decimal GetAllSocialMediaFinanceOutcome(DateTime startDate, DateTime endDate)
        {
            var totalRev = context.OrderExpenses
                .Where(x => x.ExpenseDate >= startDate && x.ExpenseDate <= endDate
                       && x.Order.ServiceType == Models.Enums.EnumServiceType.SocialMedia
                       && x.ExpenseType == Models.Enums.EnumOrderExpenseType.Finance)

                .Select(x => x.Amount)
                .DefaultIfEmpty(0)
                .Sum();
            return totalRev;
        }

        /// <summary>
        /// مصروفات خدمة سوشيال
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public decimal GetAllSocialMediaOrderExpenseOutcome(DateTime startDate, DateTime endDate)
        {
            var totalRev = context.OrderExpenses
                .Where(x => x.ExpenseDate >= startDate && x.ExpenseDate <= endDate
                       && x.Order.ServiceType == Models.Enums.EnumServiceType.SocialMedia
                       && x.ExpenseType == Models.Enums.EnumOrderExpenseType.OrderExpense)

                .Select(x => x.Amount)
                .DefaultIfEmpty(0)
                .Sum();
            return totalRev;
        }


        /// <summary>
        /// مصروفات عمولة سوشيال
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public decimal GetAllSocialMediaComissionOutcome(DateTime startDate, DateTime endDate)
        {
            var totalRev = context.OrderExpenses
                .Where(x => x.ExpenseDate >= startDate && x.ExpenseDate <= endDate
                       && x.Order.ServiceType == Models.Enums.EnumServiceType.SocialMedia
                       && x.ExpenseType == Models.Enums.EnumOrderExpenseType.Commission)

                .Select(x => x.Amount)
                .DefaultIfEmpty(0)
                .Sum();
            return totalRev;
        }


        public decimal GetAllProgramingFinanceIncome(DateTime startDate, DateTime endDate)
        {
            var totalRev = context.OrderExpenses
                .Where(x => x.ExpenseDate >= startDate && x.ExpenseDate <= endDate
                       && x.Order.ServiceType == Models.Enums.EnumServiceType.Programing
                       && x.ExpenseType == Models.Enums.EnumOrderExpenseType.Finance)

                .Select(x => x.Amount)
                .DefaultIfEmpty(0)
                .Sum();
            return totalRev;
        }
        public decimal GetAllProgramingOrderExpenseIncome(DateTime startDate, DateTime endDate)
        {
            var totalRev = context.OrderExpenses
                .Where(x => x.ExpenseDate >= startDate && x.ExpenseDate <= endDate
                       && x.Order.ServiceType == Models.Enums.EnumServiceType.Programing
                       && x.ExpenseType == Models.Enums.EnumOrderExpenseType.OrderExpense)

                .Select(x => x.Amount)
                .DefaultIfEmpty(0)
                .Sum();
            return totalRev;
        }
        public decimal GetAllProgramingCommissionIncome(DateTime startDate, DateTime endDate)
        {
            var totalRev = context.OrderExpenses
                .Where(x => x.ExpenseDate >= startDate && x.ExpenseDate <= endDate
                       && x.Order.ServiceType == Models.Enums.EnumServiceType.Programing
                       && x.ExpenseType == Models.Enums.EnumOrderExpenseType.Commission)

                .Select(x => x.Amount)
                .DefaultIfEmpty(0)
                .Sum();
            return totalRev;
        }
    }
}
