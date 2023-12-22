using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Core.Entities;
using Ticketing.Data;

namespace Ticketing.Services
{
    public class LandingPageService : ILandingPageService
    {
        private readonly IRepository<LandingPage> _repository;

        public LandingPageService(IRepository<LandingPage> repository)
        {
            this._repository = repository;
        }
        public async Task<List<LandingPage>> LoadRandomSectionsAsync(int count)
        {
            return await _repository.GetRandomRow(count).ToListAsync();
        }
    }
}
