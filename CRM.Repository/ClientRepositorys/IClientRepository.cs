using CRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM.Repository.ClientRepositorys
{
    public interface IClientRepository:IRepository<Client>
    {
        //add methods related to client here
        int GetClientsCount();
    }
}
