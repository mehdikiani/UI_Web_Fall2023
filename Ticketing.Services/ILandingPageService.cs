using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Core.Entities;

namespace Ticketing.Services
{
    public interface ILandingPageService
    {
        public Task<List<LandingPage>> LoadRandomSectionsAsync(int count);
    }
}
