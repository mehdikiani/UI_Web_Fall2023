using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Core.Entities;

namespace Ticketing.Data
{
    public interface ITicketRepository
    {
        IQueryable<Ticket> GetAll();
        int Insert(Ticket ticket);
        int Update(Ticket ticket);
        int Delete(Ticket ticket);
    }
}
