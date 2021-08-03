using CRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace CRM.Repository.ClientRepositorys
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        private readonly AdlinkContext context;
        public ClientRepository(AdlinkContext _context) : base(_context)
        {
            context = _context;
        }

        public int GetClientsCount()
        {
            var numberOfClients = context.Clients.Count();
            return numberOfClients;
        }
    }
}
