using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Core.Entities;

namespace Ticketing.Data
{
    public class TicketRepository : ITicketRepository
    {
        private readonly TicketDbContext db;

        public TicketRepository(
            TicketDbContext db)
        {
            this.db = db;
        }
        public int Delete(Ticket ticket)
        {
            //db.Tickets.Remove(ticket);
            //return db.SaveChanges();
            throw new NotImplementedException();

        }

        public IQueryable<Ticket> GetAll()
        {
            // return db.Tickets;
            throw new NotImplementedException();
        }

        public int Insert(Ticket ticket)
        {
            //db.Tickets.Add(ticket);
            //return db.SaveChanges();
            throw new NotImplementedException();
        }

        public int Update(Ticket ticket)
        {
            //return db.SaveChanges();
            throw new NotImplementedException();
        }
    }
}
