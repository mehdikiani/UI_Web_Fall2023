using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Core.Entities;

namespace Ticketing.Data.EntityConfigurations
{
    public class TicketConfig : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable("Tickets");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Title)
                .IsRequired().HasMaxLength(128); // nvarchar(128)
            builder.Property(p => p.Description)
                .IsRequired() .HasMaxLength(512);
            builder.Property(p => p.Status)
                .IsRequired().HasDefaultValue(TicketStatus.New);
            
        }
    }
}
