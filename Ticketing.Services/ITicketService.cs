using Ticketing.Core.Entities;
using Ticketing.Core.Models;

namespace Ticketing.Services
{
    public interface ITicketService
    {
        List<Ticket> GetAllTickets();
        List<Ticket> GetTicketsBySectionId(int sectionId);
        Ticket AddTicket(string title, string description,int sectionId);
        Ticket GetTicketById(int id);
        int UpdateTicket(Ticket ticket);
        int DeleteTicket(Ticket ticket);
    }
}
