using Ticketing.Core.Models;

namespace Ticketing.Services
{
    public interface ITicketService
    {
        List<TicketModel> GetAllTickets();
        TicketModel AddTicket(string title, string description);
        TicketModel GetTicketById(int id);
        TicketModel UpdateTicket(int id, string title, string description);
    }
}
