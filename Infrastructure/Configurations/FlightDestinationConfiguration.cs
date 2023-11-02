using Domain.Models;
using Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class FlightDestinationConfiguration : IEntityTypeConfiguration<FlightDestination>
{
    
    public void Configure(EntityTypeBuilder<FlightDestination> builder)
    {
        builder.Property(f => f.Id)
            .UseMySqlIdentityColumn()
            .IsRequired()
            .ValueGeneratedOnAdd();
        
        builder.Property(f => f.Start)
            .IsRequired();
        
        builder.Property(a => a.TicketPrice)
            .HasDefaultValue(15)
            .HasPrecision(10, 2)
            .IsRequired();
            
        new FlightDestinationSeeder().Seed(builder);    
    }
}
