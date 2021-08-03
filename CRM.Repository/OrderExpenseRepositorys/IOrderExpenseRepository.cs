using CRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Repository.OrderExpenseRepositorys
{
    public interface IOrderExpenseRepository : IRepository<OrderExpense>
    {
        List<OrderExpense> GetOrderExpenses(int orderId);
        decimal GetAllOrdersOutcome(DateTime startDate, DateTime endDate);

        decimal GetAllSocialMediaFinanceOutcome(DateTime startDate, DateTime endDate);
        decimal GetAllSocialMediaOrderExpenseOutcome(DateTime startDate, DateTime endDate);
        decimal GetAllSocialMediaComissionOutcome(DateTime startDate, DateTime endDate);


        decimal GetAllProgramingFinanceIncome(DateTime startDate, DateTime endDate);
        decimal GetAllProgramingOrderExpenseIncome(DateTime startDate, DateTime endDate);
        decimal GetAllProgramingCommissionIncome(DateTime startDate, DateTime endDate);
    }
}
