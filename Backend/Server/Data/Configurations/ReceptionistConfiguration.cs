using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Server;

public class ReceptionistConfiguration : IEntityTypeConfiguration<Receptionist>
{
    public void Configure(EntityTypeBuilder<Receptionist> builder)
    {
        builder.HasKey(p=>p.ReceptionistID);
        builder.Property(p=>p.FirstName).IsRequired();
        builder.Property(p=>p.LastName).IsRequired();
        builder.Property(p=>p.IdentificationNumber).IsRequired();
        builder.Property(p=>p.TelephoneNumber).IsRequired();
    }
}