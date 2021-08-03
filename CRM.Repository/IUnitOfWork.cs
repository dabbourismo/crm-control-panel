using CRM.Models;
using CRM.Repository.ClientRepositorys;
using CRM.Repository.CompanyExpenseRepositorys;
using CRM.Repository.OldOrderRepositorys;
using CRM.Repository.OrderExpenseRepositorys;
using CRM.Repository.OrderRepositorys;
using CRM.Repository.OrderRevenueRepositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM.Repository
{
    /// <summary>
    /// Makes sure that only one instance of dbcontext is provided
    /// to all repository to avoid operation mismatch
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IClientRepository ClientsRepository { get; }
        IOrderRepository OrdersRepository { get; }
        IOrderRevenueRepository OrderRevenueRepository { get; }
        ICompanyExpensesRepository CompanyExpensesRepository { get; }
        IOrderExpenseRepository OrderExpenseRepository { get; }
        IOldOrderRepository OldOrderRepository { get; }
        //add more repos
        int Complete();
    }
}
