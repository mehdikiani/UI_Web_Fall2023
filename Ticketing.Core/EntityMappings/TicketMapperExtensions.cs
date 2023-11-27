using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Core.Entities;
using Ticketing.Core.Models;

namespace Ticketing.Core.EntityMappings
{
    public static class TicketMapperExtensions
    {
        public static List<TicketModel> ToTicketModelList(this List<Ticket> entities)
        {
            var result = new List<TicketModel>();
            if (entities?.Any() ?? false)
            {
                foreach (var entity in entities)
                {
                    result.Add(new TicketModel
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        Description = entity.Description,
                        Status = entity.Status,
                        CreateDate = entity.CreateDate,
                        ModifyDate = entity.ModifyDate
                    });
                }
            }
            return result;
        }
    }
}
