using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRM.Repository.ClientRepositorys;
using CRM.Repository.CompanyExpenseRepositorys;
using CRM.Repository.OldOrderRepositorys;
using CRM.Repository.OrderExpenseRepositorys;
using CRM.Repository.OrderRepositorys;
using CRM.Repository.OrderRevenueRepositorys;

namespace CRM.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AdlinkContext context;
        public UnitOfWork(AdlinkContext _context)
        {
            context = _context;
            ClientsRepository = new ClientRepository(context);
            OrdersRepository = new OrderRepository(context);
            OrderRevenueRepository = new OrderRevenueRepository(context);
            CompanyExpensesRepository = new CompanyExpensesRepository(context);
            OrderExpenseRepository = new OrderExpenseRepository(context);
            OldOrderRepository = new OldOrderRepository(context);
        }

        public IClientRepository ClientsRepository { get; private set; }
        public IOrderRepository OrdersRepository { get; private set; }
        public IOrderRevenueRepository OrderRevenueRepository { get; private set; }
        public ICompanyExpensesRepository CompanyExpensesRepository { get; private set; }
        public IOrderExpenseRepository OrderExpenseRepository { get; private set; }
        public IOldOrderRepository OldOrderRepository { get; private set; }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
