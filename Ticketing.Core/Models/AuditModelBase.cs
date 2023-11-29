using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Core.Extensions;

namespace Ticketing.Core.Models
{
    public abstract class AuditModelBase :ModelBase
    {
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public string PersianCreateDateTime => CreateDate.ToPersianDateTime();
        public string PersianModifyDateTime => ModifyDate.ToPersianDateTime();
        public bool Deleted { get; set; }
    }
}
