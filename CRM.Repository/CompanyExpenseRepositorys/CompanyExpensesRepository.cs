using System;
using CRM.Models;
using System.Linq;

namespace CRM.Repository.CompanyExpenseRepositorys
{
    public class CompanyExpensesRepository : GenericRepository<CompanyExpense>, ICompanyExpensesRepository
    {
        private readonly AdlinkContext context;
        public CompanyExpensesRepository(AdlinkContext _context) : base(_context)
        {
            context = _context;
        }


        public decimal GetTotalExpenses(DateTime startDate, DateTime endDate)
        {
            var totalCompanyExpenses = context.CompanyExpenses
                .Where(x => x.ExpenseDate >= startDate && x.ExpenseDate <= endDate)
                .Select(x => x.Amount)
                .DefaultIfEmpty(0)
                .Sum();
            return totalCompanyExpenses;
        }
    }
}
