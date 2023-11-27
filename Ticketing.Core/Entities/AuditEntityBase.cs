using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Core.Entities
{
    public class AuditEntityBase : EntityBase
    {
        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// Gets or sets the last modifcationb date.
        /// </summary>
        public DateTime ModifyDate { get; set; }
        /// <summary>
        /// Gets or sets the value indicating whether the enityt is deleted or not.
        /// </summary>
        public bool Deleted { get; set; }
    }
}
