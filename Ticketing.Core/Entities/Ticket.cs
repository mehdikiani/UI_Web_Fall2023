using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Core.Entities
{
    public class Ticket : AuditEntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TicketStatus Status { get; set; }
        public Section Section { get; set; }
        public int SectionId { get; set; }

        // Relation types
        // one => one
        // one => many
        // many => many

        // section => ticket : one =>many

        //public override bool IsValidState(EntityAction action)
        //{
        //    switch (action)
        //    {
        //        case EntityAction.None:
        //            break;
        //        case EntityAction.Insert:
        //            break;
        //        case EntityAction.Update:
        //            break;
        //        case EntityAction.Delete:
        //            break;
        //        default:
        //            break;
        //    }
        //    return base.IsValidState();
        //}

    }
}
