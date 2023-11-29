using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Core.Entities
{
    public class Section : AuditEntityBase
    {
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
