using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Core.Entities;
using Ticketing.Core.Models;

namespace Ticketing.Core.EntityMappings
{
    public static class LandingMapperExtensions
    {
        public static List<LandingPageModel> ToLandingPageModellList(this List<LandingPage> entities)
        {
            var result = new List<LandingPageModel>();
            if (entities?.Any() ?? false)
            {
                foreach (var entity in entities)
                {
                    result.Add(new LandingPageModel
                    {
                        Id = entity.Id,
                        section1 = entity.Section1,
                        section2 = entity.Section2
                    });
                }
            }
            return result;
        }
    }
}
