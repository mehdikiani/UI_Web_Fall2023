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



        Task<List<Ticket>> GetAllTicketsAsync(CancellationToken cancellationToken =default);
        Task<List<Ticket>> GetTicketsBySectionIdAsync(int sectionId, CancellationToken cancellationToken = default);
        Task<Ticket> AddTicketAsync(string title, string description, int sectionId, CancellationToken cancellationToken = default);
        Task<Ticket> GetTicketByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<int> UpdateTicketAsync(Ticket ticket, CancellationToken cancellationToken = default);
        Task<int> DeleteTicketAsync(Ticket ticket, CancellationToken cancellationToken = default);
    }
}
