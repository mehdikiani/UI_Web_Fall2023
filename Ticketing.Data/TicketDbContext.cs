using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Core.Entities;
using Ticketing.Data.EntityConfigurations;

namespace Ticketing.Data
{
    public class TicketDbContext : DbContext
    {
        //public DbSet<Ticket> Tickets { get; set; }
        //public DbSet<Section> Sections { get; set; }
        public TicketDbContext(
            DbContextOptions<TicketDbContext> options)
            : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //var ticketConfig = modelBuilder.Entity<Ticket>()
            //       .HasKey(t => t.Id)
            //       .HasName("Tickets");
            modelBuilder.ApplyConfiguration(new TicketConfig());
            modelBuilder.ApplyConfiguration(new SectionConfig());
        }

    }
}
