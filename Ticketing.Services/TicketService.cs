using Ticketing.Data;
using Ticketing.Core.Models;

namespace Ticketing.Services
{
    public class TicketService :ITicketService
    {
        public TicketService()
        {
                
        }

        public TicketModel AddTicket(string title, string description)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException(nameof(title));
            return Tickets.AddTicket(title, description);   
        }

        public List<TicketModel> GetAllTickets()
        {
            return Tickets.AllTickets;
        }

        public TicketModel GetTicketById(int id)
        {
            return Tickets.GetTicketById(id);
        }

        public TicketModel UpdateTicket(int id, string title, string description)
        {
           return Tickets.UpdateTicket(id, title, description);
        }
    }
}
