using CRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Repository.OldOrderRepositorys
{
    class OldOrderRepository : GenericRepository<OldOrder>, IOldOrderRepository
    {
        private readonly AdlinkContext context;
        public OldOrderRepository(AdlinkContext _context) : base(_context)
        {
            context = _context;
        }
    }
}
