using Domain.Models;
using Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class AircraftConfiguration : IEntityTypeConfiguration<Aircraft>
{
    public void Configure(EntityTypeBuilder<Aircraft> builder)
    {
        builder.Property(a => a.Id)
            .UseMySqlIdentityColumn()
            .IsRequired();
        
        builder.Property(a => a.Manufacturer)
            .HasMaxLength(25)
            .IsRequired();
        
        builder.Property(a => a.Model)
            .HasMaxLength(30)
            .IsRequired();
        
        builder.Property(a => a.Year)
            .IsRequired();
        
        new AircraftSeeder().Seed(builder);
    }
}