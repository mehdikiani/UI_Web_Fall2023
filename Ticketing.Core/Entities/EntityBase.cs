﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Core.Entities
{
    public class EntityBase 
    {
        public int Id { get; set; }

        //public virtual bool IsValidState(EntityAction action = EntityAction.None) { return true; }

    }
}
