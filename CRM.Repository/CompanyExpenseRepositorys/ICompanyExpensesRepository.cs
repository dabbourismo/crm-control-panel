using CRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Repository.CompanyExpenseRepositorys
{
    public interface ICompanyExpensesRepository : IRepository<CompanyExpense>
    {
        decimal GetTotalExpenses(DateTime startDate,DateTime endDate);
    }
}
