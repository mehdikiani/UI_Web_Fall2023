using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Core.Entities
{
    public class Ticket : EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TicketStatus Status { get; set; }
    }
}
