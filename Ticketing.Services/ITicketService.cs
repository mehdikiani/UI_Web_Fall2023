using Ticketing.Core.Entities;
using Ticketing.Core.Models;

namespace Ticketing.Services
{
    public interface ITicketService
    {
        List<Ticket> GetAllTickets();
        Ticket AddTicket(string title, string description);
        Ticket GetTicketById(int id);
        int UpdateTicket(Ticket ticket);
        int DeleteTicket(Ticket ticket);
    }
}
