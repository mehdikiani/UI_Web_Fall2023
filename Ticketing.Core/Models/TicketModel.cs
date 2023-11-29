using Ticketing.Core.Entities;
using Ticketing.Core.Extensions;

namespace Ticketing.Core.Models
{
    public class TicketModel : AuditModelBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TicketStatus Status { get; set; }
        public int SectionId { get; set; }
        public string SectionTitle { get; set; }

    }
}
