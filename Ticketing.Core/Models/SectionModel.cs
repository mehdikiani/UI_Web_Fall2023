using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Core.Entities;
using Ticketing.Core.Extensions;

namespace Ticketing.Core.Models
{
    public class SectionModel : AuditModelBase
    {
        public string Title { get; set; }
        public bool IsActive { get; set; }
    }
}
