using Ticketing.Core.Models;

namespace Ticketing.Data
{
    public static class Tickets
    {
        private static List<TicketModel> tickets;

        public static List<TicketModel> AllTickets
        {
            get
            {
                InitTickets();
                return tickets;
            }
        }

        private static void InitTickets()
        {
            if (tickets == null)
            {
                tickets = new List<TicketModel>();
                tickets.Add(new TicketModel { Id = 1, Title = "ticket1", Description = "Description" });
            }
            //for (int i = 1; i <= 10; i++)
            //{

            //    tickets.Add(TicketModel.New(i));
            //}
        }

        public static TicketModel AddTicket(string title, string description)
        {
            int nextId = GetNextId();
            var ticket = new TicketModel
            {
                Title = title,
                Description = description,
                Id = nextId

            };
            AllTickets.Add(ticket);
            return ticket;
        }

        public static TicketModel GetTicketById(int id)
        {

            return AllTickets.FirstOrDefault(p => p.Id == id);

        }
        public static TicketModel UpdateTicket(int id, string title, string description)
        {

            var ticket = GetTicketById(id);
            if (ticket == null)
                throw new Exception("Ticket not found");
            ticket.Title = title;
            ticket.Description = description;

            return ticket;

        }


        private static int GetNextId()
        {
            return (AllTickets.LastOrDefault()?.Id ?? 0) + 1;
        }
    }
}
