using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Server;

public class SpecialtyConfiguration : IEntityTypeConfiguration<Specialty>
{
    public void Configure(EntityTypeBuilder<Specialty> builder)
    {
        builder.HasKey(p=>p.SpecialtyID);
        builder.Property(p=>p.SpecialtyName).IsRequired();
        builder.Property(p=>p.Description).IsRequired();
    }
}