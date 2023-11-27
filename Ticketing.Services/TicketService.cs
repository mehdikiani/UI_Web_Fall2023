using Ticketing.Data;
using Ticketing.Core.Models;
using Ticketing.Core.Entities;

namespace Ticketing.Services
{
    public class TicketService : ITicketService
    {
        private readonly TicketDbContext db;
        private readonly ILogSerivce logSerivce;

        public TicketService(
            TicketDbContext db
            , ILogSerivce logSerivce)
        {
            this.db = db;
            this.logSerivce = logSerivce;
        }

        public Ticket AddTicket(string title, string description)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException(nameof(title));
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentNullException(nameof(description));
            // return Tickets.AddTicket(title, description);   
            var now = DateTime.Now;
            var ticket = new Ticket
            {
                Title = title,
                Description = description,
                Status = TicketStatus.New,
                CreateDate = now,
                ModifyDate = now,
                Deleted = false
            };
            db.Tickets.Add(ticket);
            db.SaveChanges();
            return ticket;
        }

        public int DeleteTicket(Ticket ticket)
        {
            if (ticket == null)
                throw new ArgumentNullException(nameof(ticket));
            // db.Tickets.Remove(ticket);
            ticket.Deleted = true;
            ticket.ModifyDate = DateTime.Now;
            return db.SaveChanges();
        }

        public List<Ticket> GetAllTickets()
        {
            return db.Tickets.Where(p=>!p.Deleted).ToList();
        }

        public Ticket GetTicketById(int id)
        {
            //return db.Tickets.FirstOrDefault(p => p.Id == id);
            return db.Tickets.Find(id);
        }

        public int UpdateTicket(Ticket ticket)
        {
            //Tacking Chaange
            var result = db.SaveChanges();
            if (result > 0)
            {
                logSerivce.LogInfo($"The ticket {ticket.Title} was updatd at {DateTime.Now}");
            }
            return result;
        }
    }
}
