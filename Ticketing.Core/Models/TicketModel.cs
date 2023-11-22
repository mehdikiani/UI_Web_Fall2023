namespace Ticketing.Core.Models
{
    public class TicketModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public static TicketModel New(int id)
        {
            return new TicketModel
            {
                Id = id,
                Title = $"Ticket_{id}",
                Description = $"Description_{id}"
            };
        }
    }
}
