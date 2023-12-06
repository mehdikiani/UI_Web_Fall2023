using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Core.Entities;

namespace Ticketing.Data
{
    public class SectionRepository : IRepository<Section>
    {
        private readonly TicketDbContext ticketDbContext;

        public SectionRepository(
            TicketDbContext ticketDbContext)
        {
            this.ticketDbContext = ticketDbContext;
        }
        public int Delete(Section entity)
        {
            //TODO fdsafdasfafa
            throw new NotImplementedException();
        }

        public IQueryable<Section> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Insert(Section entity)
        {
            throw new NotImplementedException();
        }

        public int Update(Section entity)
        {
            throw new NotImplementedException();
        }
    }
}
