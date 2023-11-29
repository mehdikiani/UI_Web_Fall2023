using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Core.Entities;
using Ticketing.Core.Models;

namespace Ticketing.Core.EntityMappings
{
    public static class SectionMapperExtensions
    {
        public static List<SectionModel> ToSectionModelList(this List<Section> entities)
        {
            var result = new List<SectionModel>();
            if (entities?.Any() ?? false)
            {
                foreach (var entity in entities)
                {
                    result.Add(new SectionModel
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        IsActive = entity.IsActive,
                        CreateDate = entity.CreateDate,
                        ModifyDate = entity.ModifyDate
                    });
                }
            }
            return result;
        }
    }
}
