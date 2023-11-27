using Ticketing.Core.Entities;
using Ticketing.Core.Extensions;

namespace Ticketing.Core.Models
{
    public class TicketModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TicketStatus Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public string PersianCreateDateTime => CreateDate.ToPersianDateTime();
        public string PersianModifyDateTime => ModifyDate.ToPersianDateTime();
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
